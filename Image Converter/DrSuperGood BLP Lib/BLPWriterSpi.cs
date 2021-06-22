using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Service provider for BLP image file ImageWriter.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    public class BLPWriterSpi : ImageWriterSpi
    {
        static readonly string WRITER_CLASS = "com.hiveworkshop.blizzard.blp.BLPWriter";
        static readonly Class<? >[] OUTPUT_TYPES = new[]{typeof(ImageOutputStream), typeof(File), typeof(Path)};
        static readonly string READER_SPI_CLASSES = new[]{"com.hiveworkshop.blizzard.blp.BLPReaderSpi"};
        public BLPWriterSpi(): base(VENDOR, VERSION, FORMAT_NAMES, FORMAT_SUFFIXES, FORMAT_MIMES, WRITER_CLASS, OUTPUT_TYPES, READER_SPI_CLASSES, STANDARD_STREAM_METADATA_SUPPORT, NATIVE_STREAM_METADATA_NAME, NATIVE_STREAM_METADATA_CLASS, EXTRA_STREAM_METADATA_NAME, EXTRA_STREAM_METADATA_CLASS, STANDARD_IMAGE_METADATA_SUPPORT, NATIVE_IMAGE_METADATA_NAME, NATIVE_IMAGE_METADATA_CLASS, EXTRA_IMAGE_METADATA_NAME, EXTRA_IMAGE_METADATA_CLASS)
        {
        }

        public override bool CanEncodeImage(ImageTypeSpecifier type)
        {

            // not at all strict for maximum usability
            return true;
        }

        public override ImageWriter CreateWriterInstance(Object extension)
        {
            return new BLPWriter(this);
        }

        public override string GetDescription(Locale locale)
        {
            return "BLP file image writer.";
        }
    }
}