using BCnEncoder.Encoder;
using System;
using BCnEncoder.Shared;
using ImageConverter.Image_Processing;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverter.IO
{
    public static class Converter
    {
        public static string errorMsg;
        private static BcEncoder bcEncoder;
        private static ImageCodecInfo jpgEncoder; // for JPG compression
        private static EncoderParameter encoderParameter; // for JPG compression
        private static EncoderParameters encoderParameters; // for JPG compression
        public static int totalErrors = 0;
        private static string fileEntry = string.Empty;
        private static int currentEntryNumber = 0;

        public static void InitConverter()
        {
            switch (ExportSettings.selectedFileExtension)
            {
                case ImageFormats.JPG:
                    ExportSettings.outputFileType = ".jpg";
                    break;
                case ImageFormats.PNG:
                    ExportSettings.outputFileType = ".png";
                    break;
                case ImageFormats.BMP:
                    ExportSettings.outputFileType = ".bmp";
                    break;
                case ImageFormats.TGA:
                    ExportSettings.outputFileType = ".tga";
                    break;
                case ImageFormats.DDS:
                    ExportSettings.outputFileType = ".dds";
                    break;
                case ImageFormats.WEBP:
                    ExportSettings.outputFileType = ".webp";
                    break;
            }

            // ----
            // Setup Encoders
            // ----
            if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.FormatID == ImageFormat.Jpeg.Guid)
                    {
                        jpgEncoder = codec;
                    }
                }
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                encoderParameters = new EncoderParameters(1);

                encoderParameter = new EncoderParameter(myEncoder, ExportSettings.imageQuality);
                encoderParameters.Param[0] = encoderParameter;


            }
            if (ExportSettings.selectedFileExtension == ImageFormats.DDS)
            {
                bcEncoder = new BcEncoder();
                bcEncoder.Options.multiThreaded = true;
                bcEncoder.OutputOptions.generateMipMaps = ExportSettings.generateMipMaps;
                bcEncoder.OutputOptions.fileFormat = OutputFileFormat.Dds;

                switch (ExportSettings.selectedDDSCompression)
                {
                    case 0:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC1;
                        break;
                    case 1:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC1WithAlpha;
                        break;
                    case 2:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC2;
                        break;
                    case 3:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC3;
                        break;
                    default:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC1;
                        break;
                }

                switch (ExportSettings.selectedDDSCompressionQuality)
                {
                    case 0:
                        bcEncoder.OutputOptions.quality = CompressionQuality.Fast;
                        break;
                    case 1:
                        bcEncoder.OutputOptions.quality = CompressionQuality.Balanced;
                        break;
                    case 2:
                        bcEncoder.OutputOptions.quality = CompressionQuality.BestQuality;
                        break;
                    default:
                        bcEncoder.OutputOptions.quality = CompressionQuality.Fast;
                        break;
                }
            }
        }



        public static bool Convert(string file, int currentEntryNumber = 0)
        {
            bool success = false;
            fileEntry = file;
            Converter.currentEntryNumber = currentEntryNumber;

            Reader.ReadFile(file);

            List<Bitmap> filteredImages = new List<Bitmap>();
            List<string> prefix = new List<string>();

            if (Reader.image != null)
            {
                if (FilterSettings.war3IconType == War3IconType.None)
                {
                    ExportSettings.prefix = "";
                    if (FilterSettings.isResized)
                    {
                        //imageToConvert.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY)); // Old ImageSharp resize function
                        Reader.image = ImageFilters.ResizeBitmap(Reader.image, FilterSettings.resizeX, FilterSettings.resizeY);
                    }

                    success = Write(Reader.image);
                }
                else
                {
                    errorMsg = "Image dimensions did not match selected icon dimensions.";
                    ImageFilters filters = new ImageFilters();

                    if ((FilterSettings.war3IconType == War3IconType.ClassicIcon && Reader.image.Width == 64 && Reader.image.Height == 64) || (FilterSettings.war3IconType == War3IconType.ReforgedIcon && Reader.image.Width == 256 && Reader.image.Height == 256))
                    {
                        if (FilterSettings.isIconBTN)
                        {
                            prefix.Add("BTN");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.BTN));
                        }
                        if (FilterSettings.isIconPAS)
                        {
                            prefix.Add("PAS");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.PAS));
                        }
                        if (FilterSettings.isIconATC)
                        {
                            prefix.Add("ATC");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.ATC));
                        }
                        if (FilterSettings.isIconDISBTN)
                        {
                            prefix.Add("DISBTN");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.DISBTN));
                        }
                        if (FilterSettings.isIconDISPAS)
                        {
                            prefix.Add("DISPAS");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.DISPAS));
                        }
                        if (FilterSettings.isIconDISATC)
                        {
                            prefix.Add("DISATC");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.DISATC));
                        }
                        if (FilterSettings.isIconATT)
                        {
                            prefix.Add("ATT");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.ATT));
                        }
                        if (FilterSettings.isIconUPG)
                        {
                            prefix.Add("UPG");
                            filteredImages.Add(filters.AddIconBorder(Reader.image, IconTypes.UPG));
                        }

                        errorMsg = "No icon selected.";

                        for (int i = 0; i < filteredImages.Count; i++)
                        {
                            if (FilterSettings.isResized)
                            {
                                //filteredImages[i].Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY)); // Old ImageSharp resize function
                                filteredImages[i] = ImageFilters.ResizeBitmap(filteredImages[i], FilterSettings.resizeX, FilterSettings.resizeY);
                            }
                            ExportSettings.prefix = prefix[i];
                            success = Write(filteredImages[i]);
                            errorMsg = "";
                        }
                    }
                }
            }
            else
            {
                errorMsg = Reader.errorMsg;
            }

            return success;
        }

        public static string getFullOutputFilePath()
        {
            string path = "";
            if (ExportSettings.keepFileNames)
                path = ExportSettings.outputDir + ExportSettings.prefix + Utility.GetInputFileName(fileEntry) + ExportSettings.outputFileType;
            else if (ExportSettings.isMultipleFiles)
                path = ExportSettings.outputDir + ExportSettings.prefix + ExportSettings.fileName + "_" + currentEntryNumber + ExportSettings.outputFileType;
            else
                path = ExportSettings.outputDir + ExportSettings.prefix + ExportSettings.fileName + ExportSettings.outputFileType;

            return path;
        }

        private static bool Write(Bitmap imageToConvert)
        {
            bool success = false;

            if (imageToConvert != null)
            {
                try
                {
                    if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
                        success = Writer.WriteJpg(imageToConvert, jpgEncoder, encoderParameters, getFullOutputFilePath());
                    else if (ExportSettings.selectedFileExtension == ImageFormats.PNG)
                        success = Writer.WritePng(imageToConvert, getFullOutputFilePath());
                    else if (ExportSettings.selectedFileExtension == ImageFormats.BMP)
                        success = Writer.WriteBmp(imageToConvert, getFullOutputFilePath());
                    else if (ExportSettings.selectedFileExtension == ImageFormats.TGA)
                        success = Writer.WriteTga(imageToConvert, getFullOutputFilePath());
                    else if (ExportSettings.selectedFileExtension == ImageFormats.DDS)
                        success = Writer.WriteDds(imageToConvert, bcEncoder, getFullOutputFilePath());
                    else if (ExportSettings.selectedFileExtension == ImageFormats.WEBP)
                        success = Writer.WriteWebP(imageToConvert, getFullOutputFilePath());
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
            }

            return success;
        }
    }
}