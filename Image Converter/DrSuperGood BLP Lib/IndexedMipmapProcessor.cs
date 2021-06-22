using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// A class that is responsible for processing between mipmap data and indexed
    /// color content.
    /// <p>
    /// During decoding if the mipmap data is of incorrect size then it is resized to
    /// fit and a warning is generated. Some poor BLP implementations, such as used
    /// by some versions of Warcraft III, do not read and process mipmap data safely
    /// so might be able to extract more meaningful visual information from a
    /// technically corrupt file.
    /// <p>
    /// When encoding images the first image ColorModel is used to determine the
    /// color map used. Both BLPIndexColorModel and IndexColorModel are supported
    /// although IndexColorModel alpha is not. The direct values of the required
    /// bands are then used without further processing. Alpha band is always assumed
    /// to be the second band and will be rescaled as required. Missing alpha band
    /// will be substituted with opaque pixels if required. Any other bands are
    /// discarded.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public class IndexedMipmapProcessor : MipmapProcessor
    {
        /// <summary>
        /// The BLP indexed color model used to process mipmaps.
        /// </summary>
        private BLPIndexColorModel indexedBLPColorModel = null;
        /// <summary>
        /// The bandSizes to use.
        /// </summary>
        private readonly int bandSizes;
        /// <summary>
        /// Constructs a MipmapProcessor for indexed color content.
        /// </summary>
        /// <param name="alphaBits">
        ///            the alpha component bits, if any.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if alphaBits is not valid.</exception>
        public IndexedMipmapProcessor(int alphaBits)
        {
            if (!BLPEncodingType.INDEXED.IsAlphaBitsValid(alphaBits))
                throw new ArgumentException("Unsupported alphaBits.");
            bandSizes = alphaBits != 0 ? new int {8, alphaBits} : new int {8};

            // dummy color model
            indexedBLPColorModel = new BLPIndexColorModel(null, bandSizes.length > 1 ? bandSizes[1] : 0);
        }

        public override byte EncodeMipmap(BufferedImage img, ImageWriteParam param, Consumer<LocalizedFormatedString> handler)
        {
            WritableRaster srcWR = img.GetRaster();
            ColorModel srcCM = img.GetColorModel();
            SampleModel srcSM = srcWR.GetSampleModel();
            int h = srcSM.GetHeight();
            int w = srcSM.GetWidth();

            // process ColorModel
            if (!canDecode)
            {

                // get a color model
                if (srcCM is BLPIndexColorModel)
                {
                    BLPIndexColorModel blpICM = (BLPIndexColorModel)srcCM;
                    indexedBLPColorModel = new BLPIndexColorModel(blpICM.GetPalette(), bandSizes.length > 1 ? bandSizes[1] : 0);
                }
                else if (srcCM is IndexColorModel)
                {

                    // basic IndexColorModel compatibility
                    IndexColorModel iCM = (IndexColorModel)srcCM;
                    int srcCMap = new int[iCM.GetMapSize()];
                    iCM.GetRGBs(srcCMap);

                    // color space conversion
                    ColorModel srcCMapCM = ColorModel.GetRGBdefault();
                    ColorModel destCMapCM = BLPIndexColorModel.CreatePaletteColorModel(ColorSpace.GetInstance(ColorSpace.CS_LINEAR_RGB));
                    int destCMap = new int[srcCMap.length];
                    int components = new int[srcCMapCM.GetNumColorComponents()];
                    for (int i = 0; i < srcCMap.length; i += 1)
                    {
                        destCMap[i] = destCMapCM.GetDataElement(srcCMapCM.GetComponents(srcCMap[i], components, 0), 0);
                    }

                    indexedBLPColorModel = new BLPIndexColorModel(destCMap, bandSizes.length > 1 ? bandSizes[1] : 0);
                }
                else
                {
                    throw new IIOException("Cannot obtain sensible color map from ColorModel.");
                }

                canDecode = true;
            }


            // create destination
            SampleModel destSM = new BLPPackedSampleModel(w, h, bandSizes, null);
            DataBuffer destDB = destSM.CreateDataBuffer();
            WritableRaster destWR = WritableRaster.CreateWritableRaster(destSM, destDB, null);

            // copy bands
            bool hasAlpha = bandSizes.length > 1;
            bool srcHasAlpha = hasAlpha && srcSM.GetNumBands() > 1;
            bool rescaleAlpha = srcHasAlpha && srcSM.GetSampleSize(1) != bandSizes[1];
            int alphaMask = hasAlpha ? (1 << bandSizes[1]) - 1 : 0;
            for (int y = 0; y < h; y += 1)
            {
                for (int x = 0; x < w; x += 1)
                {
                    destWR.SetSample(x, y, 0, srcWR.GetSample(x, y, 0));
                    if (hasAlpha)
                    {
                        if (srcHasAlpha)
                        {
                            int alphaSample = srcWR.GetSample(x, y, 1);
                            if (rescaleAlpha)
                                alphaSample = (int)((float)alphaMask * (float)alphaSample / (float)(srcSM.GetSampleSize(1) - 1));
                            destWR.SetSample(x, y, 1, alphaSample);
                        }
                        else
                            destWR.SetSample(x, y, 1, alphaMask);
                    }
                }
            }


            // return destination results
            return ((DataBufferByte)srcWR.GetDataBuffer()).GetData();
        }

        public override BufferedImage DecodeMipmap(byte mmData, ImageReadParam param, int width, int height, Consumer<LocalizedFormatedString> handler)
        {

            // create sample model
            BLPPackedSampleModel sm = new BLPPackedSampleModel(width, height, bandSizes, null);

            // validate chunk size
            int expected = sm.GetBufferSize();
            if (mmData.length != expected)
            {
                handler.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadBuffer", mmData.length, expected));
                mmData = Arrays.CopyOf(mmData, expected);
            }


            // produce image WritableRaster
            DataBuffer db = new DataBufferByte(mmData, mmData.length);
            WritableRaster raster = Raster.CreateWritableRaster(sm, db, null);

            // produce buffered image
            BufferedImage img = new BufferedImage(indexedBLPColorModel, raster, false, null);
            return img;
        }

        public override Iterator<ImageTypeSpecifier> GetSupportedImageTypes(int width, int height)
        {
            return Arrays.AsList(new ImageTypeSpecifier(indexedBLPColorModel, new BLPPackedSampleModel(width, height, bandSizes, null))).Iterator();
        }

        public override void ReadObject(ImageInputStream src, Consumer<LocalizedFormatedString> warning)
        {
            src.SetByteOrder(ByteOrder.LITTLE_ENDIAN);
            int palette = new int[BLPIndexColorModel.MAX_PALETTE_LENGTH];
            src.ReadFully(palette, 0, palette.length);
            indexedBLPColorModel = new BLPIndexColorModel(palette, bandSizes.length > 1 ? bandSizes[1] : 0);
            canDecode = true;
        }

        public override void WriteObject(ImageOutputStream dst)
        {
            dst.SetByteOrder(ByteOrder.LITTLE_ENDIAN);
            int palette = indexedBLPColorModel.GetPalette();
            dst.WriteInts(palette, 0, palette.length);
        }
    }
}