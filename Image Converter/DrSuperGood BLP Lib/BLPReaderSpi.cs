using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Service provider for BLP image file ImageReader.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public class BLPReaderSpi : ImageReaderSpi
    {
        static readonly string READER_CLASS = "com.hiveworkshop.blizzard.blp.BLPReader";
        static readonly Class<? >[] INPUT_TYPES = new[]{typeof(ImageInputStream), typeof(File), typeof(Path)};
        static readonly string WRITER_SPI_CLASSES = new[]{"com.hiveworkshop.blizzard.blp.BLPWriterSpi"};
        public BLPReaderSpi(): base(VENDOR, VERSION, FORMAT_NAMES, FORMAT_SUFFIXES, FORMAT_MIMES, READER_CLASS, INPUT_TYPES, WRITER_SPI_CLASSES, STANDARD_STREAM_METADATA_SUPPORT, NATIVE_STREAM_METADATA_NAME, NATIVE_STREAM_METADATA_CLASS, EXTRA_STREAM_METADATA_NAME, EXTRA_STREAM_METADATA_CLASS, STANDARD_IMAGE_METADATA_SUPPORT, NATIVE_IMAGE_METADATA_NAME, NATIVE_IMAGE_METADATA_CLASS, EXTRA_IMAGE_METADATA_NAME, EXTRA_IMAGE_METADATA_CLASS)
        {
        }

        public override bool CanDecodeInput(Object source)
        {
            if (source is ImageInputStream)
            {

                // Record stream state.
                ImageInputStream src = (ImageInputStream)source;
                src.Mark();
                ByteOrder order = src.GetByteOrder();
                try
                {

                    // Check magic number.
                    src.SetByteOrder(ByteOrder.LITTLE_ENDIAN);
                    MagicInt magic = new MagicInt(src.ReadInt(), ByteOrder.LITTLE_ENDIAN);
                    if (BLPCommon.ResolveVersion(magic) != -1)
                        return true;
                }
                finally
                {

                    // Restore stream.
                    src.SetByteOrder(order);
                    src.Reset();
                }
            }

            return false;
        }

        public override ImageReader CreateReaderInstance(Object extension)
        {
            return new BLPReader(this);
        }

        public override string GetDescription(Locale locale)
        {
            return "BLP file image reader.";
        }
    }
}