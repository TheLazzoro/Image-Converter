using System;
using System.Collections.Generic;
using System.Text;

namespace Image_Converter.IO
{
    public static partial class ExportSettings
    {
        public static string fileName = "";
        public static string prefix = "";
        public static string outputDir = "";
        public static string outputFileType = ".jpg"; // default is jpg if anything goes wrong.
        public static bool isMultipleFiles;
        public static bool keepFileNames;
        public static ImageFormats selectedFileExtension;
        public static int imageQualityJpeg;
        public static int selectedDDSCompression;
        public static int selectedDDSCompressionQuality;
        public static bool generateMipMaps;
    }
}
