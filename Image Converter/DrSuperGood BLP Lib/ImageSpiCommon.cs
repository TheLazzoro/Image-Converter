using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hiveworkshop.Blizzard.Blp
{
    /// <summary>
    /// Common for blp spis.
    /// <p>
    /// Contains all constants in common with the spi classes.
    /// </summary>
    /// <remarks>@authorImperial Good</remarks>
    abstract class ImageSpiCommon
    {
        // file format specification
        static readonly string VENDOR = "Hive Workshop";
        static readonly string VERSION = "1.2";
        static readonly string FORMAT_NAMES = new[]{"Blizzard Picture", "blp"};
        static readonly string FORMAT_SUFFIXES = new[]{"blp"};
        static readonly string FORMAT_MIMES = new[]{"image/hw.blp"};
        // metadata format specification
        static readonly bool STANDARD_STREAM_METADATA_SUPPORT = false;
        static readonly string NATIVE_STREAM_METADATA_NAME = null;
        static readonly string NATIVE_STREAM_METADATA_CLASS = null;
        static readonly string EXTRA_STREAM_METADATA_NAME = null;
        static readonly string EXTRA_STREAM_METADATA_CLASS = null;
        static readonly bool STANDARD_IMAGE_METADATA_SUPPORT = false;
        static readonly string NATIVE_IMAGE_METADATA_NAME = null;
        static readonly string NATIVE_IMAGE_METADATA_CLASS = null;
        static readonly string EXTRA_IMAGE_METADATA_NAME = null;
        static readonly string EXTRA_IMAGE_METADATA_CLASS = null;
    }
}