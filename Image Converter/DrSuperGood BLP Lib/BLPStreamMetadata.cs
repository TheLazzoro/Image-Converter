using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// BLP file header object. Describes the contents of a BLP file (the metadata).
    /// The rest of the file is processed using this content description.
    /// <p>
    /// BLP header versions 0, 1 and 2 are supported. Each version imposes different
    /// limitations on the state which can be represented as stated in the format
    /// specification. Mutator method calls which attempt to set object state to
    /// values not supported by the version will result in an
    /// IllegalArgumentException being thrown.
    /// <p>
    /// Reading a header object with some invalid state from an image stream may
    /// generate warnings however the resulting object state will still be valid.
    /// <p>
    /// Node view and manipulation is currently not supported as no metadata format
    /// has been designed for BLP. Type cast BLP stream IIOMetadata objects to this
    /// class and manipulate them directly using the many accessor and mutator
    /// methods.
    /// <p>
    /// Only BLP version 0 and 1 are fully supported. Version 2 lacks sufficient
    /// documentation to create a reliable implementation. It will still parse and
    /// produce version 2 headers however such headers cannot be used in a sensible
    /// way.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public sealed class BLPStreamMetadata : IIOMetadata
    {
        /// <summary>
        /// The maximum dimension size allowed by version 0 and loaded by version 1.
        /// </summary>
        public static readonly int LEGACY_MAX_DIMENSION = 512;
        /// <summary>
        /// The BLP Content type.
        /// </summary>
        public enum ContentType
        {
            JPEG,
            DIRECT
        }

        /// <summary>
        /// The BLP Content type.
        /// </summary>
        public enum PixmapType
        {
            NONE,
            INDEXED,
            SAMPLED,
            BGRA,
            BGRA_2
        }

        /// <summary>
        /// The BLP sample type, used as a form of BLP compression.
        /// </summary>
        public enum SampleType
        {
            DXT1,
            DXT3,
            BGRA8888,
            BGRA5551,
            BGRA4444,
            BGR565,
            UNKNOWN1,
            DXT5,
            UNKNOWN2,
            BGRA2565
        }

        /// <summary>
        /// BLP format version. Determines overall compatibility and features.
        /// </summary>
        private int version;
        /// <summary>
        /// Content type being used.
        /// </summary>
        private ContentType contentType;
        /// <summary>
        /// Pixmap type being used.
        /// </summary>
        private PixmapType pixmapType;
        /// <summary>
        /// Sample type being used.
        /// </summary>
        private SampleType sampleType;
        /// <summary>
        /// Alpha bit precision of contained image data.
        /// </summary>
        private byte alphaBits;
        /// <summary>
        /// Accompanying mipmap images exist.
        /// </summary>
        private bool hasMipmaps;
        /// <summary>
        /// Image width in pixels.
        /// </summary>
        private int width;
        /// <summary>
        /// Image height in pixels.
        /// </summary>
        private int height;
        /// <summary>
        /// An extra integer that is never used.
        /// </summary>
        private int extra;
        /// <summary>
        /// Warning consumer function. Default is to log own warnings.
        /// </summary>
        private Consumer<LocalizedFormatedString> warning;
        /// <summary>
        /// Constructs a BLP1 header for JPEG content with no alpha or mipmaps and
        /// image dimensions of 1*1.
        /// </summary>
        public BLPStreamMetadata()
        {
            version = 1;
            SetEncoding(BLPEncodingType.JPEG, (byte)0);
            hasMipmaps = true;
            width = 1;
            height = 1;
            extra = 6;
            SetWarningHandler(null);
        }

        private static void Warn(LocalizedFormatedString msg)
        {
            Logger.GetLogger(typeof(BLPStreamMetadata).GetName()).Warning(msg.ToString());
        }

        /// <summary>
        /// Sets the function for processing warning messages. Warning messages are
        /// usually generated during input from potentially malformed files which
        /// still can be parsed.
        /// <p>
        /// If handler is null then a default logging function will be used.
        /// </summary>
        /// <param name="handler">
        ///            function to handle warning messages.</param>
        public void SetWarningHandler(Consumer<LocalizedFormatedString> handler)
        {
            if (handler == null)
                handler = BLPStreamMetadata.Warn();
            warning = handler;
        }

        /// <summary>
        /// Get the general encoding type of the image. This is the high-level
        /// meaning of several different fields.
        /// </summary>
        /// <returns>the encoding type for the image.</returns>
        public BLPEncodingType GetEncodingType()
        {

            // convert configuration to encoding
            if (contentType == ContentType.JPEG && pixmapType == PixmapType.NONE)
                return BLPEncodingType.JPEG;
            else if (contentType == ContentType.DIRECT && pixmapType == PixmapType.INDEXED)
                return BLPEncodingType.INDEXED;
            return BLPEncodingType.UNKNOWN;
        }

        /// <summary>
        /// Get the alpha component bit precision. The value returned is always valid
        /// for the encoding type used.
        /// </summary>
        /// <returns>the bit precision of the alpha component.</returns>
        public byte GetAlphaBits()
        {
            return alphaBits;
        }

        /// <summary>
        /// Set the encoding type for the image. Takes both an encoding type and
        /// alpha component bit precision value to enforce consistency.
        /// </summary>
        /// <param name="encodingType">
        ///            the encoding type to use.</param>
        /// <param name="alphaBits">
        ///            the bit precision of the alpha component.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if encodingType is UNKNOWN.</exception>
        /// <exception cref="IllegalArgumentException">
        ///             if encodingType does not support alphaBit.</exception>
        /// <exception cref="IllegalArgumentException">
        ///             if version does not support encodingType.</exception>
        public void SetEncoding(BLPEncodingType encodingType, byte alphaBits)
        {
            if (encodingType == BLPEncodingType.UNKNOWN)
                throw new ArgumentException("cannot use UNKNOWN encodingType");
            else if (!encodingType.IsAlphaBitsValid(alphaBits))
                throw new ArgumentException("encodingType does not support alphaBits");
            else if (encodingType.minVersion > version)
                throw new ArgumentException("version does not support encodingType");

            // convert encoding to configuration
            switch encodingType
            {
                default:
                case JPEG:
                    contentType = ContentType.JPEG;
                    pixmapType = PixmapType.NONE;
                    sampleType = SampleType.DXT1;
                    break;
                case INDEXED:
                    contentType = ContentType.DIRECT;
                    pixmapType = PixmapType.INDEXED;
                    sampleType = SampleType.DXT1;
                    break;
            }

            this.alphaBits = alphaBits;
        }

        /// <summary>
        /// Get the BLP version number that is currently being used.
        /// </summary>
        /// <returns>the blp version number.</returns>
        public int GetVersion()
        {
            return version;
        }

        /// <summary>
        /// Specify which BLP version to use. Different BLP versions have different
        /// features and compatibility.
        /// <p>
        /// Version 0 is only used by the Warcraft III Reign of Chaos beta. Version 1
        /// is used by the release versions of Warcraft III. Version 2 is used by
        /// World of Warcraft.
        /// </summary>
        /// <param name="version">
        ///            the new version number.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if version is not a supported version (0 to 2).</exception>
        public void SetVersion(int version)
        {
            if (version < 0 || 2 < version)
                throw new ArgumentException("versions 0 to 2 supported");
            this.version = version;
        }

        /// <summary>
        /// Test if mipmap images are specified.
        /// </summary>
        /// <returns>true if mipmap images are specified, otherwise false.</returns>
        public bool HasMipmaps()
        {
            return hasMipmaps;
        }

        /// <summary>
        /// Specify the existence of mipmap images. If true then a full series of
        /// mipmap images are available. If false then only the full sized image is
        /// available.
        /// <p>
        /// Mipmap images are usually required by model textures. Mipmap images are
        /// usually not required by UI elements.
        /// </summary>
        /// <param name="hasMipmaps">
        ///            if mipmap images exist.</param>
        public void SetMipmaps(bool hasMipmaps)
        {
            this.hasMipmaps = hasMipmaps;
        }

        /// <summary>
        /// Scales an image dimension to be for a given mipmap level.
        /// </summary>
        /// <param name="dimension">
        ///            the dimension to scale in pixels.</param>
        /// <param name="level">
        ///            the mipmap level.</param>
        /// <returns>the mipmap dimension in pixels.</returns>
        private static int ScaleImageDimension(int dimension, int level)
        {
            return Math.Max(dimension >> level, 1);
        }

        /// <summary>
        /// Get the image width in pixels.
        /// </summary>
        /// <returns>width in pixels.</returns>
        public int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Get the image width in pixels for a certain mipmap level.
        /// </summary>
        /// <param name="level">
        ///            mipmap level.</param>
        /// <returns>width in pixels.</returns>
        public int GetWidth(int level)
        {
            return ScaleImageDimension(width, level);
        }

        /// <summary>
        /// Set the image width in pixels. Width is valid between 1 and
        /// getDimensionMaximum.
        /// </summary>
        /// <param name="width">
        ///            width in pixels.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if width is invalid.</exception>
        public void SetWidth(int width)
        {
            if (width < 1 || GetDimensionMaximum() < width)
                throw new ArgumentException("Invalid dimension size.");
            this.width = width;
        }

        /// <summary>
        /// Get the image height in pixels.
        /// </summary>
        /// <returns>height in pixels.</returns>
        public int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Get the image height in pixels for a certain mipmap level.
        /// </summary>
        /// <param name="level">
        ///            mipmap level.</param>
        /// <returns>height in pixels.</returns>
        public int GetHeight(int level)
        {
            return ScaleImageDimension(height, level);
        }

        /// <summary>
        /// Set the image height in pixels. height is valid between 1 and
        /// getDimensionMaximum.
        /// </summary>
        /// <param name="height">
        ///            height in pixels.</param>
        /// <exception cref="IllegalArgumentException">
        ///             if height is invalid.</exception>
        public void SetHeight(int height)
        {
            if (height < 1 || GetDimensionMaximum() < height)
                throw new ArgumentException("Invalid dimension size.");
            this.height = height;
        }

        /// <summary>
        /// Maximum image dimension size in pixels. With a dimension larger than this
        /// value are not valid.
        /// </summary>
        /// <returns>the maximum allowed dimension size.</returns>
        public int GetDimensionMaximum()
        {
            if (version < 1)
                return LEGACY_MAX_DIMENSION;
            return (1 << MIPMAP_MAX) - 1;
        }

        /// <summary>
        /// Convenience method that derives the number of mipmap levels for the
        /// image.
        /// <p>
        /// Images without mipmaps have only 1 level which is the full sized image.
        /// Images with mipmaps have a number of mipmaps based on the maximum of
        /// image height and width.
        /// </summary>
        /// <returns>the number of mipmap levels for the image.</returns>
        public int GetMipmapCount()
        {

            // if mipmaps then number of mipmap levels based on largest dimension
            return hasMipmaps ? 32 - Integer.NumberOfLeadingZeros(Math.Max(width, height)) : 1;
        }

        public void ReadObject(ImageInputStream src)
        {
            src.SetByteOrder(ByteOrder.LITTLE_ENDIAN);

            // read and validate magic and version
            version = ResolveVersion(new MagicInt(src.ReadInt(), ByteOrder.LITTLE_ENDIAN));
            if (version == -1)
            {
                throw new IIOException("Not valid BLP file magic.");
            }


            // read contentType
            int content = src.ReadInt();
            ContentType ctvalues = ContentType.Values();
            if (content >= ctvalues.length || content < 0)
            {
                ContentType defaultContentType = ContentType.JPEG;
                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadContent", content, defaultContentType.Name()));
                content = defaultContentType.Ordinal();
            }

            contentType = ctvalues[content];
            if (version < 2)
            {

                // read alphaBits
                alphaBits = (byte)src.ReadInt();

                // fill in non-existent fields
                pixmapType = PixmapType.Values()[contentType.Ordinal()];
                sampleType = SampleType.DXT1;
            }
            else
            {

                // read pixmapType
                int pixmap = src.ReadByte() & 0xFF;
                PixmapType ptvalues = PixmapType.Values();
                if (pixmap >= ptvalues.length)
                    throw new IIOException(String.Format("pixmap type %#0X is invalid", pixmap));
                pixmapType = ptvalues[pixmap];

                // read alphaBits
                alphaBits = src.ReadByte();

                // read sampleType
                int sample = src.ReadByte() & 0xFF;
                SampleType stvalues = SampleType.Values();
                if (sample >= stvalues.length)
                    throw new IIOException(String.Format("sample type %#0X is invalid", (byte)sample));
                sampleType = SampleType.Values()[sample];

                // read hasMipmaps
                hasMipmaps = src.ReadByte() != 0;
            }

            BLPEncodingType encodingType = GetEncodingType();
            if (encodingType == BLPEncodingType.UNKNOWN)
                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadEncoding", contentType.Name(), pixmapType.Name(), sampleType.Name()));
            if (!encodingType.IsAlphaBitsValid(alphaBits))
            {
                int defaultAlphaBits = 0;
                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadAlpha", alphaBits, defaultAlphaBits));
                alphaBits = defaultAlphaBits;
            }


            // read width and height
            width = src.ReadInt();
            height = src.ReadInt();

            // clamp width and height
            int maxDim = GetDimensionMaximum();
            long widthU = width & 4294967295L;
            long heightU = height & 4294967295L;
            if (maxDim < Math.Max(widthU, heightU))
            {
                if (version < 1)
                {

                    // assumed behavior based on Warcraft III prior to 1.27b
                    throw new IIOException(String.Format("Invalid image dimensions %d*%d pixels.", width, height));
                }

                long oldWidth = widthU;
                long oldHeight = heightU;

                // clamp to maximum dimension
                width = (int)(Math.Min(widthU, maxDim));
                height = (int)(Math.Min(heightU, maxDim));
                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "BadDimension", oldWidth, oldHeight, width, height));
            }

            if (version < 2)
            {

                // read extra value
                extra = src.ReadInt();

                // read hasMipmaps
                hasMipmaps = src.ReadInt() != 0;
            }


            // warn about unusable mipmaps
            int bigDim = Math.Max(width, height);
            if (version < 2 && LEGACY_MAX_DIMENSION < bigDim)
            {
                int i = 0;
                while (LEGACY_MAX_DIMENSION < bigDim)
                {
                    i += 1;
                    bigDim >>= 1;
                }

                warning.Accept(new LocalizedFormatedString("com.hiveworkshop.text.blp", "WastefulDimension", i));
            }
        }

        public void WriteObject(ImageOutputStream dst)
        {
            dst.SetByteOrder(ByteOrder.LITTLE_ENDIAN);

            // write magic and version
            dst.WriteInt(ResolveMagic(version).ToInt(ByteOrder.LITTLE_ENDIAN));

            // write content
            dst.WriteInt(contentType.Ordinal());
            if (version < 2)
            {

                // write alphaBits
                dst.WriteInt(alphaBits & 0xFF);
            }
            else
            {

                // write pixmapType
                dst.WriteByte(pixmapType.Ordinal());

                // write alphaBits
                dst.WriteByte(alphaBits);

                // write sampleType
                dst.WriteByte(sampleType.Ordinal());

                // write hasMipmaps
                dst.WriteByte(hasMipmaps ? 1 : 0);
            }


            // write width and height
            dst.WriteInt(width);
            dst.WriteInt(height);
            if (version < 2)
            {

                // write unknown, value does not appear to matter.
                dst.WriteInt(extra);

                // write hasMipmaps
                dst.WriteInt(hasMipmaps ? 1 : 0);
            }
        }

        public override bool IsReadOnly()
        {
            return true;
        }

        public override Node GetAsTree(string formatName)
        {
            throw new ArgumentException("no formats are supported");
        }

        public override void MergeTree(string formatName, Node root)
        {
            throw new InvalidOperationException();
        }

        public override void Reset()
        {
            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return "{BLP Stream Metadata: Version = " + version + ", width = " + width + ", height = " + height + ", content = " + contentType + ", pixmap = " + pixmapType + ", sample = " + sampleType + ", alpha bits = " + alphaBits + ", mipmaps = " + hasMipmaps + ", extra = " + extra + "}";
        }
    }
}