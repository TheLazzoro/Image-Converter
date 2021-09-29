using BCnEncoder.Encoder;
using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using BCnEncoder.Shared;
using War3Net.Drawing.Blp;
using ImageConverter.Image_Processing;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using WebPWrapper;

namespace ImageConverter.IO
{
    public static class Converter
    {
        public static string debugString = "";
        public static string[] fileEntries;
        static int currentEntry = 0;
        public static string errorMsg;
        private static BcEncoder bcEncoder;
        private static ImageCodecInfo jpgEncoder; // for JPG compression
        private static EncoderParameter encoderParameter; // for JPG compression
        private static EncoderParameters encoderParameters; // for JPG compression
        public static int totalErrors = 0;

        public static void InitConverter()
        {
            currentEntry = 0; // Reset for next conversion

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

        public static System.Drawing.Bitmap ToBitmap(SixLabors.ImageSharp.Image<Rgba32> image)
        {
            Stream stream = new System.IO.MemoryStream();
            SixLabors.ImageSharp.Formats.Bmp.BmpEncoder bmpEncoder = new SixLabors.ImageSharp.Formats.Bmp.BmpEncoder(); // we need an encoder to preserve transparency.
            bmpEncoder.BitsPerPixel = SixLabors.ImageSharp.Formats.Bmp.BmpBitsPerPixel.Pixel32; // bitmap transparency needs 32 bits per pixel before we set transparency support.
            bmpEncoder.SupportTransparency = true;
            image.SaveAsBmp(stream, bmpEncoder);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            return new System.Drawing.Bitmap(stream);
        }

        public static Image<Rgba32> ToImageSharpImage(System.Drawing.Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                memoryStream.Seek(0, SeekOrigin.Begin);

                return SixLabors.ImageSharp.Image.Load<Rgba32>(memoryStream);
            }
        }

        public static bool ConvertWithFilters()
        {
            bool success = false;

            Reader.ReadFile(fileEntries[currentEntry]);

            List<Bitmap> filteredImages = new List<Bitmap>();
            List<string> prefix = new List<string>();

            if (Reader.image != null)
            {
                if (FilterSettings.war3IconType == War3IconType.None)
                {
                    ExportSettings.prefix = "";
                    if (FilterSettings.isResized)
                    {
                        //imageToConvert.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY)); // VERY IMPORTANT TO HAVE, PLZ FIX
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
                                //filteredImages[i].Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY)); // VERY IMPORTANT TO HAVE, PLZ FIX
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

            currentEntry++;

            return success;
        }

        private static bool Write(Bitmap imageToConvert)
        {
            bool success = false;


            if (imageToConvert != null)
            {
                if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
                    success = WriteJpg(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.PNG)
                    success = WritePng(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.BMP)
                    success = WriteBmp(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.TGA)
                    success = WriteTga(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.DDS)
                    success = WriteDds(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.WEBP)
                    success = WriteWebP(imageToConvert);
            }

            return success;
        }


        private static string GetInputFileName(String filePath)
        {
            string fileName = "";

            char cCurrent;
            int sub = 0;
            bool start = false;
            bool end = false;
            while (!end)
            {
                cCurrent = filePath[filePath.Length - 1 - sub];
                if (start)
                {
                    if (cCurrent == '/' || cCurrent == '\\')
                    {
                        end = true;
                    }
                    if (!end)
                    {
                        fileName += cCurrent; // appends file name to the string (opposite order, but we flip it later)
                    }
                }
                if (cCurrent == '.')
                {
                    start = true;
                }

                sub++;
            }

            char[] charArray = fileName.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray);
        }



        private static string getFullOutputFilePath()
        {
            string path = "";
            if (ExportSettings.keepFileNames)
                path = ExportSettings.outputDir + ExportSettings.prefix + GetInputFileName(fileEntries[currentEntry]) + ExportSettings.outputFileType;
            else if (ExportSettings.isMultipleFiles)
                path = ExportSettings.outputDir + ExportSettings.prefix + ExportSettings.fileName + "_" + currentEntry + ExportSettings.outputFileType;
            else
                path = ExportSettings.outputDir + ExportSettings.prefix + ExportSettings.fileName + ExportSettings.outputFileType;

            return path;
        }

        private static bool WriteJpg(Bitmap imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.Save(getFullOutputFilePath(), jpgEncoder, encoderParameters);
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private static bool WritePng(Bitmap imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.Save(getFullOutputFilePath(), ImageFormat.Png);
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private static bool WriteBmp(Bitmap imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.Save(getFullOutputFilePath(), ImageFormat.Bmp);
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private static bool WriteTga(Bitmap imageToConvert)
        {
            bool success = false;

            try
            {
                SixLabors.ImageSharp.Image<Rgba32> img = ToImageSharpImage(imageToConvert);
                img.SaveAsTga(getFullOutputFilePath());
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private static bool WriteDds(Bitmap imageToConvert)
        {
            bool success = false;
            FileStream fs = null;

            try
            {
                SixLabors.ImageSharp.Image<Rgba32> img = ToImageSharpImage(imageToConvert);
                fs = File.OpenWrite(getFullOutputFilePath());
                bcEncoder.Encode(img, fs);
                fs.DisposeAsync();
                success = true;
            }
            catch (Exception ex)
            {
                fs.DisposeAsync();
                errorMsg = ex.Message;
            }

            return success;
        }

        private static bool WriteWebP(Bitmap imageToConvert)
        {
            bool success = false;

            try
            {
                using (WebP webp = new WebP())
                    webp.Save(imageToConvert, getFullOutputFilePath(), ExportSettings.imageQuality);
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }
    }
}