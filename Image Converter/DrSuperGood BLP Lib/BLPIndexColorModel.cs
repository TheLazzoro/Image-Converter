using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// BLP compliant index (palette) color model. Functions similar to the standard
    /// IndexColorModel except permits the use of an optional separate alpha channel
    /// of various bit depths.
    /// <p>
    /// BLP files with indexed color content always use a 256 index color palette of
    /// 8 bit per channel RGB values and an optional separate 1, 4 or 8 bit alpha
    /// channel to determine pixel color. The underlying Raster must use 8 bit
    /// samples for index with appropriately sized samples for alpha.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public sealed class BLPIndexColorModel : ColorModel
    {
        /// <summary>
        /// Number of bits used for palette entries.
        /// </summary>
        public static readonly int PALETTE_INDEX_BITS = 8;
        /// <summary>
        /// Maximum palette length for this ColorModel.
        /// </summary>
        public static readonly int MAX_PALETTE_LENGTH = 1 << PALETTE_INDEX_BITS;
        /// <summary>
        /// Internal ColorModel used to decode palette and alpha values. Handles much
        /// of the required form conversions.
        /// </summary>
        private readonly ColorModel internalColorModel;
        /// <summary>
        /// Palette used to lookup color. In form compatible with internalColorModel.
        /// </summary>
        private readonly int palette;
        /// <summary>
        /// Normalized component cache for the palette colors converted into sRGB
        /// ColorSpace. This is used to speed up conversion from component values to
        /// color index. Linearly perceived color components are preferred when
        /// choosing a color index which is why sRGB is used.
        /// </summary>
        private float normalizedComponentCache = null;
        /// <summary>
        /// Produces a ColorModel suitable for producing palette entries in the
        /// specified ColorSpace. The ColorModel can be used to decode or encode
        /// colors in the palette.
        /// <p>
        /// The ColorSpace must be an RGB type.
        /// </summary>
        /// <param name="colorSpace">
        ///            RGB color space of the palette.</param>
        /// <returns>ColorModel suitable for interacting with the palette.</returns>
        public static ColorModel CreatePaletteColorModel(ColorSpace colorSpace)
        {
            if (colorSpace.GetType() != ColorSpace.TYPE_RGB)
            {
                throw new ArgumentException("Unsupported color space type.");
            }

            return new DirectColorModel(colorSpace, 24, 0x00FF0000, 0x0000FF00, 0x000000FF, 0, false, DataBuffer.TYPE_INT);
        }

        /// <summary>
        /// Construct a universal palette with the specified number of color levels.
        /// <p>
        /// A color must have at least 2 levels, allowing for 0.0f and 1.0f
        /// intensities. The total product of all color levels must be less than
        /// <code>MAX_PALETTE_LENGTH</code>.
        /// <p>
        /// Color levels are distributed evenly within the sRGB ColorSpace. These are
        /// then converted for use with colorSpace.
        /// </summary>
        /// <param name="redLevels">
        ///            Number of red levels.</param>
        /// <param name="greenLevels">
        ///            Number of green levels.</param>
        /// <param name="blueLevels">
        ///            Number of blue levels.</param>
        /// <param name="colorSpace">
        ///            Intended color space of the palette.</param>
        /// <returns>Populated palette.</returns>
        public static int CreateUniversalPaletteColorMap(int redLevels, int greenLevels, int blueLevels, ColorSpace colorSpace)
        {
            if (colorSpace.GetType() != ColorSpace.TYPE_RGB)
            {
                throw new ArgumentException("Unsupported color space type.");
            }
            else if (redLevels < 2)
            {
                throw new ArgumentException("Invalid redLevels value.");
            }
            else if (greenLevels < 2)
            {
                throw new ArgumentException("Invalid greenLevels value.");
            }
            else if (blueLevels < 2)
            {
                throw new ArgumentException("Invalid blueLevels value.");
            }
            else if (redLevels * greenLevels * blueLevels > MAX_PALETTE_LENGTH)
            {
                throw new ArgumentException("Requires too many colors.");
            }

            int palette = new int[MAX_PALETTE_LENGTH];
            float sRGBComponents = new float[3];
            ColorModel colorMapColorModel = CreatePaletteColorModel(colorSpace);
            int i = 0;
            for (int r = 0; r < redLevels; r += 1)
            {
                sRGBComponents[0] = (float)r / (float)(redLevels - 1);
                for (int g = 0; g < greenLevels; g += 1)
                {
                    sRGBComponents[1] = (float)g / (float)(greenLevels - 1);
                    for (int b = 0; b < blueLevels; b += 1)
                    {
                        sRGBComponents[2] = (float)b / (float)(blueLevels - 1);
                        palette[i++] = colorMapColorModel.GetDataElement(colorSpace.FromRGB(sRGBComponents), 0);
                    }
                }
            }

            return palette;
        }

        /// <summary>
        /// Utility method to convert an alpha bits amount into a transparency mode
        /// as defined by Transparency interface.
        /// </summary>
        /// <param name="alphaBits">
        ///            Number of bits in alpha channel.</param>
        /// <returns>Transparency mode.</returns>
        private static int ResolveTransparency(int alphaBits)
        {
            if (alphaBits == 0)
            {
                return Transparency.OPAQUE;
            }
            else if (alphaBits == 1)
            {
                return Transparency.BITMASK;
            }

            return Transparency.TRANSLUCENT;
        }

        /// <summary>
        /// Constructs a linear RGB BLP indexed ColorModel from a palette. Up to the
        /// <code>MAX_PALETTE_LENGTH</code> colors may be used. Each index of the
        /// palette is in the form of 0xBBGGRR.
        /// <p>
        /// A palette of null will allocate a universal 8-8-4 palette. This will be
        /// sufficient to hold any image with vague color accuracy. For best results
        /// it is recommended to use an adaptive palette for the target image.
        /// <p>
        /// Alpha bits is the precision of the alpha channel. Valid values are 0, 1,
        /// 4 and 8.
        /// </summary>
        /// <param name="palette">
        ///            Palette this ColorModel will use.</param>
        /// <param name="alphaBits">
        ///            Precision of alpha component in bits.</param>
        public BLPIndexColorModel(int palette, int alphaBits) : this(palette, alphaBits, ColorSpace.GetInstance(ColorSpace.CS_LINEAR_RGB))
        {
        }

        /// <summary>
        /// Constructs a BLP indexed ColorModel from a palette. Up to the
        /// <code>MAX_PALETTE_LENGTH</code> colors may be used. Each index of the
        /// palette is in the form of 0xBBGGRR.
        /// <p>
        /// A palette of null will allocate a universal 8-8-4 palette. This will be
        /// sufficient to hold any image with vague color accuracy. For best results
        /// it is recommended to use an adaptive palette for the target image.
        /// <p>
        /// Alpha bits is the precision of the alpha channel. Valid values are 0, 1,
        /// 4 and 8.
        /// </summary>
        /// <param name="palette">
        ///            Palette this ColorModel will use.</param>
        /// <param name="alphaBits">
        ///            Precision of alpha component in bits.</param>
        /// <param name="colorSpace">
        ///            RGB color space used by this ColorModel.</param>
        public BLPIndexColorModel(int palette, int alphaBits, ColorSpace colorSpace) : base(8 + alphaBits, alphaBits == 0 ? new int { 8, 8, 8 } : new int { 8, 8, 8, alphaBits }, colorSpace, alphaBits != 0, false, ResolveTransparency(alphaBits), DataBuffer.TYPE_BYTE)
        {
            if (!BLPEncodingType.INDEXED.IsAlphaBitsValid(alphaBits))
            {
                throw new ArgumentException("Unsupported alphaBits value.");
            }
            else if (colorSpace.GetType() != ColorSpace.TYPE_RGB)
            {
                throw new ArgumentException("Unsupported color space type.");
            }

            if (palette != null)
            {
                if (palette.length > MAX_PALETTE_LENGTH)
                {
                    throw new ArgumentException("Unsupported palette length.");
                }

                this.palette = Arrays.CopyOf(palette, MAX_PALETTE_LENGTH);
            }
            else
            {
                this.palette = CreateUniversalPaletteColorMap(8, 8, 4, colorSpace);
            }

            internalColorModel = new DirectColorModel(colorSpace, 24 + alphaBits, 0x00FF0000, 0x0000FF00, 0x000000FF, (1 << alphaBits) - 1 << 24, false, DataBuffer.TYPE_INT);
        }

        /// <summary>
        /// Utility method to construct an internal pixel.
        /// </summary>
        /// <param name="index">
        ///            Palette index element.</param>
        /// <param name="alpha">
        ///            Alpha element.</param>
        /// <returns>Internal pixel.</returns>
        private int ConstructInternalPixel(int index, int alpha)
        {
            return GetPaletteColor(index) | alpha << 24;
        }

        public override SampleModel CreateCompatibleSampleModel(int w, int h)
        {
            return new BLPPackedSampleModel(w, h, HasAlpha() ? new int { PALETTE_INDEX_BITS, GetComponentSize(GetNumColorComponents()) } : new int { PALETTE_INDEX_BITS }, null);
        }

        public override WritableRaster CreateCompatibleWritableRaster(int w, int h)
        {
            SampleModel sm = CreateCompatibleSampleModel(w, h);
            return Raster.CreateWritableRaster(sm, sm.CreateDataBuffer(), null);
        }

        /// <summary>
        /// Produces a ColorModel suitable for processing palette entries in the
        /// specified ColorSpace. The ColorModel can be used to decode or encode
        /// colors in the palette.
        /// </summary>
        /// <returns>ColorModel suitable for interacting with the palette.</returns>
        public ColorModel CreatePaletteColorModel()
        {
            return CreatePaletteColorModel(GetColorSpace());
        }

        public override int GetAlpha(int pixel)
        {
            return internalColorModel.GetAlpha(PixelToInternalPixel(pixel));
        }

        public override int GetAlpha(Object inData)
        {
            return internalColorModel.GetAlpha(PixelToInternalPixel(inData));
        }

        public override WritableRaster GetAlphaRaster(WritableRaster raster)
        {
            if (HasAlpha())
                return raster.CreateWritableChild(raster.GetMinX(), raster.GetMinY(), raster.GetWidth(), raster.GetHeight(), raster.GetMinX(), raster.GetMinY(), new int { 1 });
            else
                return null;
        }

        /// <summary>
        /// Get number of bands in a pixel of this ColorModel.
        /// </summary>
        /// <returns>Band count.</returns>
        public int GetBandNumber()
        {
            return HasAlpha() ? 2 : 1;
        }

        /// <summary>
        /// Finds the index of the best matching color to what was requested. This
        /// may be very slow but allows for maximum compatibility.
        /// <p>
        /// Comparison is done in a visually linear ColorSpace sRGB.
        /// <p>
        /// The algorithms used are for basic color quantization support. Efficiency
        /// is only a minor consideration and the accuracy of the results is not
        /// measured. The results should be vaguely what one can expect for indexed
        /// ColorModels. For best indexed color quantization a separate algorithm
        /// should be used with the results fed to this color model.
        /// </summary>
        /// <param name="normComponents">
        ///            normalized components</param>
        /// <param name="normOffset">
        ///            offset in normalized components array</param>
        /// <returns>index of closest matching color</returns>
        private int GetBestPaletteIndex(float normComponents, int normOffset)
        {

            // need color cache
            PopulateComponentCache();

            // Prepare desired sRGB components.
            float desiredComponents;
            desiredComponents = Arrays.CopyOfRange(normComponents, normOffset, normOffset + 3);
            if (!GetColorSpace().IsCS_sRGB())
            {
                desiredComponents = GetColorSpace().ToRGB(desiredComponents);
            }


            // Search for closest match.
            int best = -1;
            int nComponents = GetColorSpace().GetNumComponents();
            float bestDiff = Float.MAX_VALUE;
            for (int i = 0; i < palette.length; i += 1)
            {
                int cacheOffset = i * nComponents;

                // compare color channels using euclidian distance
                float diff = 0F;
                for (int component = 0; component < nComponents; component += 1)
                {
                    float delta = normalizedComponentCache[cacheOffset + component] - desiredComponents[component];
                    diff += delta * delta;
                }

                diff = (float)Math.Sqrt(diff);

                // find best result
                if (diff < bestDiff)
                {
                    best = i;
                    bestDiff = diff;
                }
            }

            return best;
        }

        public override int GetBlue(int pixel)
        {
            return internalColorModel.GetBlue(PixelToInternalPixel(pixel));
        }

        public override int GetBlue(Object inData)
        {
            return internalColorModel.GetBlue(PixelToInternalPixel(inData));
        }

        public override int GetComponents(int pixel, int components, int offset)
        {
            return internalColorModel.GetComponents(PixelToInternalPixel(pixel), components, offset);
        }

        public override int GetComponents(Object pixel, int components, int offset)
        {
            return internalColorModel.GetComponents(PixelToInternalPixel(pixel), components, offset);
        }

        public override int GetDataElement(float normComponents, int normOffset)
        {
            int pixel = GetBestPaletteIndex(normComponents, normOffset);
            if (HasAlpha())
            {
                pixel |= ((internalColorModel.GetDataElement(normComponents, normOffset) >> 24) & 0xFF) << 8;
            }

            return pixel;
        }

        public override int GetDataElement(int components, int offset)
        {
            int pixel = GetBestPaletteIndex(internalColorModel.GetNormalizedComponents(components, offset, null, 0), 0) & 0xFF;
            if (HasAlpha())
                pixel |= components[offset + 3] << 8;
            return pixel;
        }

        public override Object GetDataElements(float normComponents, int normOffset, Object obj)
        {
            if (obj == null)
            {
                obj = new byte[GetBandNumber()];
            }

            byte bytepixel = (byte)obj;
            bytepixel[0] = (byte)GetBestPaletteIndex(normComponents, normOffset);
            if (HasAlpha())
            {
                bytepixel[1] = (byte)(internalColorModel.GetUnnormalizedComponents(normComponents, normOffset, null, 0)[GetNumColorComponents()]);
            }

            return obj;
        }

        public override Object GetDataElements(int rgb, Object pixel)
        {
            if (pixel == null)
            {
                pixel = new byte[GetBandNumber()];
            }

            byte bytepixel = (byte)pixel;
            Object rgbpixel = internalColorModel.GetDataElements(rgb, null);
            bytepixel[0] = (byte)GetBestPaletteIndex(internalColorModel.GetNormalizedComponents(rgbpixel, null, 0), 0);
            if (HasAlpha())
            {
                bytepixel[1] = (byte)internalColorModel.GetComponents(rgbpixel, null, 0)[GetNumColorComponents()];
            }

            return pixel;
        }

        public override Object GetDataElements(int components, int offset, Object obj)
        {
            if (obj == null)
            {
                obj = new byte[GetBandNumber()];
            }

            byte bytepixel = (byte)obj;
            bytepixel[0] = (byte)GetBestPaletteIndex(internalColorModel.GetNormalizedComponents(components, offset, null, 0), 0);
            if (HasAlpha())
                bytepixel[1] = (byte)components[offset + GetNumColorComponents()];
            return obj;
        }

        public override int GetGreen(int pixel)
        {
            return internalColorModel.GetGreen(PixelToInternalPixel(pixel));
        }

        public override int GetGreen(Object inData)
        {
            return internalColorModel.GetGreen(PixelToInternalPixel(inData));
        }

        /// <summary>
        /// Return a copy of the palette used. Color indices correspond with pixel
        /// values and the returned array will always have a length of
        /// <code>MAX_PALETTE_LENGTH</code>. Indices can be processed using a color
        /// model returned from <b>createPaletteColorModel</b>.
        /// </summary>
        /// <returns>Array of palette colors.</returns>
        public int GetPalette()
        {
            return palette.Clone();
        }

        /// <summary>
        /// Lookup a color in the palette.
        /// </summary>
        /// <param name="index">
        ///            Index of requested color.</param>
        /// <returns>Color compatible with <code>paletteColorModel</code>.</returns>
        private int GetPaletteColor(int index)
        {
            return palette[index] & 0xFFFFFF;
        }

        public override int GetRed(int pixel)
        {
            return internalColorModel.GetRed(PixelToInternalPixel(pixel));
        }

        public override int GetRed(Object inData)
        {
            return internalColorModel.GetRed(PixelToInternalPixel(inData));
        }

        public override int GetRGB(int pixel)
        {
            return internalColorModel.GetRGB(PixelToInternalPixel(pixel));
        }

        public override int GetRGB(Object inData)
        {
            return internalColorModel.GetRGB(PixelToInternalPixel(inData));
        }

        public override bool IsCompatibleRaster(Raster raster)
        {
            return IsCompatibleSampleModel(raster.GetSampleModel()) && raster.GetNumBands() == GetBandNumber();
        }

        public override bool IsCompatibleSampleModel(SampleModel sm)
        {

            // validate number of bands
            int bands = GetBandNumber();
            if (sm.GetNumBands() != bands)
            {
                return false;
            }


            // transfer type must always be TYPE_BYTE
            if (sm.GetTransferType() != DataBuffer.TYPE_BYTE)
            {
                return false;
            }


            // check index band size
            if (sm.GetSampleSize(0) != PALETTE_INDEX_BITS)
                return false;

            // check alpha band size
            if (HasAlpha() && sm.GetSampleSize(1) != GetComponentSize(GetNumColorComponents()))
                return false;
            return true;
        }

        /// <summary>
        /// Utility method to convert an input pixel into an internal pixel for
        /// processing.
        /// </summary>
        /// <param name="pixel">
        ///            Input pixel.</param>
        /// <returns>Internal pixel.</returns>
        private int PixelToInternalPixel(int pixel)
        {
            int index = pixel & 0xFF;
            int alpha = HasAlpha() ? pixel >> 8 & 0xFF : 0;
            return ConstructInternalPixel(index, alpha);
        }

        /// <summary>
        /// Utility method to convert an input pixel into an internal pixel for
        /// processing.
        /// </summary>
        /// <param name="inData">
        ///            Array of pixel values.</param>
        /// <returns>Internal pixel.</returns>
        private int PixelToInternalPixel(Object inData)
        {
            byte pixel = (byte)inData;
            int index = Byte.ToUnsignedInt(pixel[0]);
            int alpha = HasAlpha() ? Byte.ToUnsignedInt(pixel[1]) : 0;
            return ConstructInternalPixel(index, alpha);
        }

        /// <summary>
        /// Populates the color component cache used to help select which color index
        /// to use to represent a color. This cache is populated only when converting
        /// from components to a pixel.
        /// </summary>
        private void PopulateComponentCache()
        {

            // only initialize once, this is expensive
            if (normalizedComponentCache != null)
                return;
            int nColorComponents = internalColorModel.GetNumColorComponents();
            int nComponents = internalColorModel.GetNumComponents();
            normalizedComponentCache = new float[palette.length * nColorComponents];
            int componentCacheArray = new int[nComponents];
            float normCacheArray = new float[nComponents];
            for (int i = 0; i < palette.length; i += 1)
            {

                // normalize pixel
                int pixel = GetPaletteColor(i);
                internalColorModel.GetNormalizedComponents(internalColorModel.GetComponents(pixel, componentCacheArray, 0), 0, normCacheArray, 0);

                // translate color components to sRGB
                float srgbComponents = internalColorModel.GetColorSpace().ToRGB(normCacheArray);

                // cache
                int offset = i * nColorComponents;
                System.Arraycopy(srgbComponents, 0, normalizedComponentCache, offset, nColorComponents);
            }
        }
    }
}