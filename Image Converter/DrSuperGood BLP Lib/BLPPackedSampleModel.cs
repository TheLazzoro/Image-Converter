using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// SampleModel to help process BLP indexed content. Acts like a multi banded non
    /// standard MultiPixelPackedSampleModel.
    /// <p>
    /// All samples for each band are stored in a block. Band blocks are stored
    /// sequentially in the same bank. Pixel packing occurs from least significant
    /// bit towards most significant bit.
    /// <p>
    /// Although intended for use with samples with power of 2 bit length, other bit
    /// lengths are supported. The only restriction is that sample bit length is less
    /// than 8. Sample bit lengths that do not divide 8 by a whole number will pad
    /// the most significant bits.
    /// <p>
    /// This SampleModel is not intended to be fast.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public class BLPPackedSampleModel : SampleModel
    {
        /// <summary>
        /// Band sizes array.
        /// </summary>
        private readonly int bandSizes;
        /// <summary>
        /// Band offset array.
        /// </summary>
        private readonly int bandOffsets;
        /// <summary>
        /// Bands redirection array used to determine the number of advertised bands.
        /// </summary>
        private readonly int bands;
        /// <summary>
        /// Constructs a SampleModel for the given dimension with the specified bits
        /// per band.
        /// <p>
        /// The bandSizes field determines the number of bits per band. Bands must be
        /// between 1 and 8 bits.
        /// <p>
        /// The bands field allows band redirection, such as if only a subset of
        /// bands or different ordering is required. Available band numbers to
        /// reference is determined by the length of bandSizes. Due to the variable
        /// packing density of this SampleModel it is not possible to forego a full
        /// sequential set of bandSizes even if only a subset of the available bands
        /// are used. Although bands does check if a band number is valid, it does
        /// not check for duplicates. A value of null will automatically assign bands
        /// in a natural way as determined by bandSizes.
        /// </summary>
        /// <param name="w">
        ///            width in pixels.</param>
        /// <param name="h">
        ///            height in pixels.</param>
        /// <param name="bandSizes">
        ///            array of bits per band.</param>
        /// <param name="bands">
        ///            band redirection array.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if w or h are not greater than 0.</exception>
        /// <exception cref="IllegalArgumentException">
        ///             if bandSizes contains an invalid value.</exception>
        /// <exception cref="IllegalArgumentException">
        ///             if bands contains an invalid band number.</exception>
        public BLPPackedSampleModel(int w, int h, int bandSizes, int bands): base(DataBuffer.TYPE_BYTE, w, h, bands != null ? bands.length : bandSizes.length)
        {

            // validate arguments
            for (int i = 0; i < bandSizes.length; i += 1)
            {
                int bandSize = bandSizes[i];
                if (bandSize < 1 || 8 < bandSize)
                    throw new ArgumentException("Invalid bandSizes.");
            }

            this.bandSizes = bandSizes.Clone();

            // compute band offsets
            bandOffsets = new int[bandSizes.length + 1];
            for (int i = 0; i < bandSizes.length; i += 1)
            {
                int baseOffset = bandOffsets[i];
                int bandSize = bandSizes[i];
                bandOffsets[i + 1] = baseOffset + (w * h * bandSize + 7) / 8;
            }


            // process bands
            if (bands == null)
            {
                bands = new int[bandSizes.length];
                for (int i = 0; i < bands.length; i += 1)
                    bands[i] = i;
            }
            else
            {
                bands = bands.Clone();
                for (int i = 0; i < bands.length; i += 1)
                {
                    int bandref = bands[i];
                    if (bandref < 0 || bandSizes.length <= bandref)
                        throw new ArgumentException("Invalid bands.");
                }
            }

            this.bands = bands;
        }

        public override int GetNumDataElements()
        {
            return numBands;
        }

        public override Object GetDataElements(int x, int y, Object obj, DataBuffer data)
        {

            // process obj
            if (obj == null)
                obj = new byte[numBands];
            byte pixel = (byte)(obj);

            // get pixel
            for (int i = 0; i < numBands; i += 1)
            {
                pixel[i] = (byte)GetSample(x, y, i, data);
            }

            return obj;
        }

        public override void SetDataElements(int x, int y, Object obj, DataBuffer data)
        {

            // process obj
            byte pixel = (byte)(obj);

            // set pixel
            for (int i = 0; i < numBands; i += 1)
            {
                SetSample(x, y, i, pixel[i], data);
            }
        }

        private int GetPixelNumber(int x, int y)
        {
            return x + width * y;
        }

        private int GetSamplePacking(int b)
        {
            return 8 / bandSizes[b];
        }

        private int GetElementNumber(int pixelNumber, int samplePacking, int b)
        {
            return bandOffsets[b] + pixelNumber / samplePacking;
        }

        private int GetSampleOffset(int pixelNumber, int samplePacking, int b)
        {
            return (pixelNumber % samplePacking) * bandSizes[b];
        }

        private int GetSampleMask(int b)
        {
            return (1 << bandSizes[b]) - 1;
        }

        public override int GetSample(int x, int y, int b, DataBuffer data)
        {
            b = bands[b];
            int pixelNumber = GetPixelNumber(x, y);
            int samplePacking = GetSamplePacking(b);
            return data.GetElem(GetElementNumber(pixelNumber, samplePacking, b)) >> GetSampleOffset(pixelNumber, samplePacking, b) & GetSampleMask(b);
        }

        public override void SetSample(int x, int y, int b, int s, DataBuffer data)
        {
            b = bands[b];
            int pixelNumber = GetPixelNumber(x, y);
            int samplePacking = GetSamplePacking(b);
            int elementNumber = GetElementNumber(pixelNumber, samplePacking, b);
            int sampleOff = GetSampleOffset(pixelNumber, samplePacking, b);
            int sampleMask = GetSampleMask(b);
            data.SetElem(elementNumber, data.GetElem(elementNumber) & ~(sampleMask << sampleOff) | (s & sampleMask) << sampleOff);
        }

        public override BLPPackedSampleModel CreateCompatibleSampleModel(int w, int h)
        {
            return new BLPPackedSampleModel(w, h, bandSizes, bands);
        }

        public override SampleModel CreateSubsetSampleModel(int bands)
        {

            // validation
            if (bands.length > numBands)
                throw new ArgumentException("Too many bands.");

            // process band redirection
            bool bandUsed = new bool[this.bands.length];
            int destBands = new int[bands.length];
            for (int i = 0; i < bands.length; i += 1)
            {
                int bandref = bands[i];
                if (bandref < 0 || this.bands.length <= bandref || bandUsed[bandref])
                    throw new ArgumentException("Invalid bands.");
                bandUsed[bandref] = true;
                destBands[i] = this.bands[bandref];
            }

            return new BLPPackedSampleModel(width, height, bandSizes, destBands);
        }

        public virtual int GetBufferSize()
        {
            return bandOffsets[bandOffsets.length - 1];
        }

        public override DataBuffer CreateDataBuffer()
        {
            return new DataBufferByte(GetBufferSize());
        }

        public override int GetSampleSize()
        {

            // generate band size array
            int bandSizes = new int[numBands];
            for (int i = 0; i < numBands; i += 1)
            {
                bandSizes[i] = this.bandSizes[bands[i]];
            }

            return bandSizes;
        }

        public override int GetSampleSize(int band)
        {
            return bandSizes[bands[band]];
        }
    }
}