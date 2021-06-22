using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Mipmap processor for JPEG content BLP files.
    /// <p>
    /// In the case that a decoded JPEG image is not the correct size, it is resized
    /// and a warning generated. Resizing occurs by padding/cropping the right and
    /// bottom edges of the image. Padding is transparent black.
    /// <p>
    /// Some poor BLP implementations, such as used by Warcraft III 1.27a, do not
    /// read and process mipmap data safely so might be able to extract a valid JPEG
    /// file from a technically corrupt file.
    /// <p>
    /// Both 8 and 0 bit alpha is supported. A fully opaque alpha band is encoded
    /// when set to 0 bits. When decoding 0 bit alpha and not using direct read a
    /// warning is generated if the alpha channel is not fully opaque. Some poor BLP
    /// implementations, such as used by Warcraft III 1.27a, can still process the
    /// dummy alpha band which can result in undesirable visual artifacts depending
    /// on use.
    /// <p>
    /// The JPEG ImageReader used can be controlled by a BLPReadParam. Likewise the
    /// JPEG ImageWriter used can be controlled by a BLPWriteParam. For best encoding
    /// results it is recommended the JPEG ImageWriter be kept constant for all
    /// mipmap levels.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    class JPEGMipmapProcessor : MipmapProcessor
    {
        /// <summary>
        /// The maximum valid shared header length.
        /// <p>
        /// Shared headers beyond this size might cause massive image corruption or
        /// crashes in some readers.
        /// </summary>
        private static readonly int MAX_SHARED_HEADER_LENGTH = 0x270;
        /// <summary>
        /// BLP JPEG content band mapping array.
        /// </summary>
        private static readonly int JPEG_BAND_ARRAY = new[]{2, 1, 0, 3};
        /// <summary>
        /// The color model that the processor will use.
        /// </summary>
        private readonly ColorModel jpegBLPColorModel;
        /// <summary>
        /// JPEG header block.
        /// </summary>
        private byte jpegHeader = null;
        /// <summary>
        /// Constructs a MipmapProcessor for JPEG content.
        /// </summary>
        /// <param name="alphaBits">
        ///            the alpha component bits, if any.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if alphaBits is not valid.</exception>
        public JPEGMipmapProcessor(int alphaBits)
        {
            if (!BLPEncodingType.JPEG.IsAlphaBitsValid(alphaBits))
                throw new ArgumentException("Unsupported alphaBits.");
            bool hasAlpha = alphaBits == 8;
            jpegBLPColorModel = new ComponentColorModel(ColorSpace.GetInstance(ColorSpace.CS_LINEAR_RGB), hasAlpha, false, hasAlpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE, DataBuffer.TYPE_BYTE);
        }

        public override bool MustPostProcess()
        {
            return true;
        }

        public override IList<byte> PostProcessMipmapData(IList<byte> mmDataList, Consumer<LocalizedFormatedString> handler)
        {

            // determine maximum shared header
            byte sharedHeader = mmDataList[0].Clone();
            int sharedLength = sharedHeader.length;
            int mmDataNum = mmDataList.Count;
            for (int i = 1; i < mmDataNum; i += 1)
            {
                byte mmData = mmDataList[i];
                for (int shared = 0; shared < sharedLength; shared += 1)
                {
                    if (mmData[shared] != sharedHeader[shared])
                    {
                        sharedLength = shared;
                        break;
                    }
                }
            }


            // process shared header length
            sharedLength = Math.Min(sharedLength, MAX_SHARED_HEADER_LENGTH);
            if (sharedLength < 64)
            {
                handler.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "JPEGSmallShared", sharedLength));
            }


            // produce shared header
            jpegHeader = Arrays.CopyOf(sharedHeader, sharedLength);
            canDecode = true;

            // process mipmap data
            if (sharedLength == 0)
                return mmDataList;
            IList<byte> mmDataListOut = new List<byte>(mmDataNum);
            for (int i = 0; i < mmDataNum; i += 1)
            {
                byte mmData = mmDataList[i];
                mmDataListOut.Add(Arrays.CopyOfRange(mmData, sharedLength, mmData.length));
            }

            return mmDataListOut;
        }

        public override byte EncodeMipmap(BufferedImage img, ImageWriteParam param, Consumer<LocalizedFormatedString> handler)
        {

            // resolve a JPEG ImageWriter
            ImageWriter jpegWriter = null;
            if (param is BLPWriteParam && ((BLPWriteParam)param).GetJPEGSpi() != null)
            {

                // use explicit JPEG reader
                jpegWriter = ((BLPWriteParam)param).GetJPEGSpi().CreateWriterInstance();
            }
            else
            {

                // find a JPEG reader
                Iterator<ImageWriter> jpegWriters = ImageIO.GetImageWritersByFormatName("jpeg");
                while (jpegWriters.HasNext())
                {
                    ImageWriter writer = jpegWriters.Next();
                    if (writer.CanWriteRasters())
                    {
                        jpegWriter = writer;
                        break;
                    }
                }
            }


            // validate JPEG writer
            if (jpegWriter == null)
                throw new IIOException("No suitable JPEG ImageWriter installed.");
            else if (!jpegWriter.CanWriteRasters())
            {
                throw new IIOException(String.Format("JPEG ImageWriter cannot write raster: vendor = %s.", jpegWriter.GetOriginatingProvider().GetVendorName()));
            }


            // prepare raster
            WritableRaster srcWR = img.GetRaster();
            SampleModel srcSM = srcWR.GetSampleModel();
            int h = srcSM.GetHeight();
            int w = srcSM.GetWidth();
            WritableRaster destWR = WritableRaster.CreateBandedRaster(DataBuffer.TYPE_BYTE, w, h, JPEG_BAND_ARRAY.length, null);
            int srcBandN = srcSM.GetSampleSize().length;
            if (srcBandN == JPEG_BAND_ARRAY.length)
            {
                destWR.SetRect(srcWR);
            }
            else
            {
                int bandNum = Math.Min(JPEG_BAND_ARRAY.length, srcBandN);
                bool opaque = !jpegBLPColorModel.HasAlpha() || bandNum < JPEG_BAND_ARRAY.length;
                for (int y = 0; y < h; y += 1)
                {
                    for (int x = 0; x < w; x += 1)
                    {
                        for (int b = 0; b < bandNum; b += 1)
                        {
                            destWR.SetSample(x, y, b, srcWR.GetSample(x, y, b));
                        }

                        if (opaque)
                            destWR.SetSample(x, y, 3, 255);
                    }
                }
            }


            // prepare buffered JPEG file
            ByteArrayOutputStream bos = new ByteArrayOutputStream(100 << 10);
            ImageOutputStream ios = new MemoryCacheImageOutputStream(bos);
            jpegWriter.SetOutput(ios);

            // write JPEG file
            ImageWriteParam jpegParam = jpegWriter.GetDefaultWriteParam();
            jpegParam.SetSourceBands(JPEG_BAND_ARRAY);
            jpegParam.SetCompressionMode(ImageWriteParam.MODE_EXPLICIT);
            string compressionTypes = jpegParam.GetCompressionTypes();
            if (compressionTypes != null && compressionTypes.length > 0)
            {
                jpegParam.SetCompressionType(compressionTypes[0]);
            }

            if (param != null && param.CanWriteCompressed() && param.GetCompressionMode() == ImageWriteParam.MODE_EXPLICIT)
            {
                jpegParam.SetCompressionQuality(param.GetCompressionQuality());
            }
            else
            {
                jpegParam.SetCompressionQuality(BLPWriteParam.DEFAULT_QUALITY);
            }

            jpegWriter.AddIIOWriteWarningListener(new AnonymousIIOWriteWarningListener(this));
            jpegWriter.Write(null, new IIOImage(destWR, null, null), jpegParam);

            // cleanup
            jpegWriter.Dispose();
            ios.Close();
            bos.Close();
            return bos.ToByteArray();
        }

        private sealed class AnonymousIIOWriteWarningListener : IIOWriteWarningListener
        {
            public AnonymousIIOWriteWarningListener(JPEGMipmapProcessor parent)
            {
                this.parent = parent;
            }

            private readonly JPEGMipmapProcessor parent;
            public override void WarningOccurred(ImageWriter source, int imageIndex, string warning)
            {
                handler.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "JPEGWarning", warning));
            }
        }

        public override BufferedImage DecodeMipmap(byte mmData, ImageReadParam param, int width, int height, Consumer<LocalizedFormatedString> handler)
        {
            bool directRead = param == null || (param is BLPReadParam && ((BLPReadParam)param).IsDirectRead());

            // resolve a JPEG ImageReader
            ImageReader jpegReader = null;
            if (param is BLPReadParam && ((BLPReadParam)param).GetJPEGSpi() != null)
            {

                // use explicit JPEG reader
                jpegReader = ((BLPReadParam)param).GetJPEGSpi().CreateReaderInstance();
            }
            else
            {

                // find a JPEG reader
                Iterator<ImageReader> jpegReaders = ImageIO.GetImageReadersByFormatName("jpeg");
                while (jpegReaders.HasNext())
                {
                    ImageReader reader = jpegReaders.Next();
                    if (reader.CanReadRaster())
                    {
                        jpegReader = reader;
                        break;
                    }
                }
            }


            // validate JPEG reader
            if (jpegReader == null)
                throw new IIOException("No suitable JPEG ImageReader installed.");
            else if (!jpegReader.CanReadRaster())
            {
                throw new IIOException(String.Format("JPEG ImageReader cannot read raster: vendor = %s.", jpegReader.GetOriginatingProvider().GetVendorName()));
            }


            // create a buffered JPEG file in memory
            byte jpegBuffer = Arrays.CopyOf(jpegHeader, jpegHeader.length + mmData.length);
            System.Arraycopy(mmData, 0, jpegBuffer, jpegHeader.length, mmData.length);

            // input buffered JPEG file
            InputStream bis = new ByteArrayInputStream(jpegBuffer);
            ImageInputStream iis = new MemoryCacheImageInputStream(bis);
            jpegReader.SetInput(iis, true, true);

            // read source raster
            jpegReader.AddIIOReadWarningListener(new AnonymousIIOReadWarningListener(this));
            ImageReadParam jpegParam = jpegReader.GetDefaultReadParam();
            jpegParam.SetSourceBands(JPEG_BAND_ARRAY);
            if (directRead)
            {

                // optimizations to improve direct read mode performance
                jpegParam.SetSourceRegion(new Rectangle(width, height));
            }

            Raster srcRaster = jpegReader.ReadRaster(0, jpegParam);

            // cleanup
            iis.Close();
            jpegReader.Dispose();

            // direct read shortcut
            if (directRead && srcRaster is WritableRaster && srcRaster.GetWidth() == width && srcRaster.GetHeight() == height)
            {
                WritableRaster destRaster = (WritableRaster)srcRaster;

                // enforce alpha band to match color model
                if (!jpegBLPColorModel.HasAlpha())
                    destRaster = destRaster.CreateWritableChild(0, 0, destRaster.GetWidth(), destRaster.GetHeight(), 0, 0, new int {0, 1, 2});
                return new BufferedImage(jpegBLPColorModel, destRaster, false, null);
            }


            // alpha warning check
            if (!jpegBLPColorModel.HasAlpha())
            {
                int alphaSamples = srcRaster.GetSamples(0, 0, srcRaster.GetWidth(), srcRaster.GetHeight(), 3, (int)null);
                foreach (int aSample in alphaSamples)
                {
                    if (aSample != 255)
                    {
                        handler.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadPixelAlpha"));
                        break;
                    }
                }
            }


            // dimension check warning
            if (srcRaster.GetWidth() != width || srcRaster.GetHeight() != height)
                handler.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "JPEGDimensionMismatch", srcRaster.GetWidth(), srcRaster.GetHeight(), width, height));

            // create destination image
            BufferedImage destImg = new BufferedImage(jpegBLPColorModel, jpegBLPColorModel.CreateCompatibleWritableRaster(width, height), false, null);
            WritableRaster destRaster = destImg.GetRaster();

            // copy data
            destRaster.SetRect(srcRaster.CreateChild(0, 0, srcRaster.GetWidth(), srcRaster.GetHeight(), 0, 0, Arrays.CopyOf(new int {0, 1, 2, 3}, jpegBLPColorModel.GetNumComponents())));
            return destImg;
        }

        private sealed class AnonymousIIOReadWarningListener : IIOReadWarningListener
        {
            public AnonymousIIOReadWarningListener(JPEGMipmapProcessor parent)
            {
                this.parent = parent;
            }

            private readonly JPEGMipmapProcessor parent;
            public override void WarningOccurred(ImageReader source, string warning)
            {
                handler.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "JPEGWarning", warning));
            }
        }

        public override Iterator<ImageTypeSpecifier> GetSupportedImageTypes(int width, int height)
        {
            return Arrays.AsList(new ImageTypeSpecifier(jpegBLPColorModel, jpegBLPColorModel.CreateCompatibleSampleModel(width, height))).Iterator();
        }

        public override void ReadObject(ImageInputStream src, Consumer<LocalizedFormatedString> warning)
        {

            // read JPEG header
            src.SetByteOrder(ByteOrder.LITTLE_ENDIAN);
            int length = src.ReadInt();
            byte jpegh = new byte[length];
            src.ReadFully(jpegh, 0, jpegh.length);

            // process length
            if (length > MAX_SHARED_HEADER_LENGTH)
            {
                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "JPEGBigShared", length, MAX_SHARED_HEADER_LENGTH));
            }

            jpegHeader = jpegh;
            canDecode = true;
        }

        public override void WriteObject(ImageOutputStream dst)
        {
            byte jpegh = jpegHeader != null ? jpegHeader : new byte[0];

            // write JPEG header
            dst.SetByteOrder(ByteOrder.LITTLE_ENDIAN);
            dst.WriteInt(jpegh.length);
            dst.Write(jpegh);
        }
    }
}