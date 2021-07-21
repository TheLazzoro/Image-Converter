using BCnEncoder.Encoder;
using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using BCnEncoder.Shared;
using War3Net.Drawing.Blp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using BCnEncoder.Decoder;
using System.Runtime.InteropServices;
using Image_Converter.Image_Processing;
using System.Collections.Generic;

namespace Image_Converter.IO
{
    public partial class Converter
    {
        public string debugString = "";
        public String[] fileEntries;
        int currentEntry = 0;
        public String errorMsg;
        private Reader reader;
        private BcEncoder bcEncoder;
        private JpegEncoder jpegEncoder;
        private Warcraft.BLP.TextureCompressionType blpEncoder;
        public int totalErrors = 0;

        public Converter()
        {
            reader = new Reader();

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
                case ImageFormats.BLP:
                    ExportSettings.outputFileType = ".blp";
                    break;
            }

            // ----
            // Setup Encoders
            // ----
            if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
            {
                jpegEncoder = new JpegEncoder();
                jpegEncoder.Quality = ExportSettings.imageQualityJpeg;
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
            if (ExportSettings.selectedFileExtension == ImageFormats.BLP)
            {
                blpEncoder = new Warcraft.BLP.TextureCompressionType();
            }
        }

        public bool ConvertWithFilters()
        {
            bool success = false;

            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = reader.ReadFile(fileEntries[currentEntry]);
            List<SixLabors.ImageSharp.Image<Rgba32>> filteredImages = new List<Image<Rgba32>>();
            List<string> prefix = new List<string>();

            if (imageToConvert != null)
            {
                if (FilterSettings.war3IconType == War3IconType.None)
                {
                    ExportSettings.prefix = "";
                    if (FilterSettings.isResized)
                    {
                        imageToConvert.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                    }

                    success = Convert(imageToConvert);
                }
                else
                {
                    errorMsg = "Image dimensions did not match selected icon dimensions.";
                    ImageFilters filters = new ImageFilters();

                    if ((FilterSettings.war3IconType == War3IconType.ClassicIcon && imageToConvert.Width == 64 && imageToConvert.Height == 64) || (FilterSettings.war3IconType == War3IconType.ReforgedIcon && imageToConvert.Width == 256 && imageToConvert.Height == 256))
                    {
                        if (FilterSettings.isIconBTN)
                        {
                            prefix.Add("BTN");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.BTN));
                        }
                        if (FilterSettings.isIconPAS)
                        {
                            prefix.Add("PAS");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.PAS));
                        }
                        if (FilterSettings.isIconATC)
                        {
                            prefix.Add("ATC");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.ATC));
                        }
                        if (FilterSettings.isIconDISBTN)
                        {
                            prefix.Add("DISBTN");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISBTN));
                        }
                        if (FilterSettings.isIconDISPAS)
                        {
                            prefix.Add("DISPAS");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISPAS));
                        }
                        if (FilterSettings.isIconDISATC)
                        {
                            prefix.Add("DISATC");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISATC));
                        }
                        if (FilterSettings.isIconATT)
                        {
                            prefix.Add("ATT");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.ATT));
                        }
                        if (FilterSettings.isIconUPG)
                        {
                            prefix.Add("UPG");
                            filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.UPG));
                        }

                        errorMsg = "No icon selected.";

                        for (int i = 0; i < filteredImages.Count; i++)
                        {
                            if (FilterSettings.isResized)
                            {
                                filteredImages[i].Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                            }
                            ExportSettings.prefix = prefix[i];
                            success = Convert(filteredImages[i]);
                            errorMsg = "";
                        }
                    }
                }
            }
            else
            {
                errorMsg = reader.errorMsg;
            }

            currentEntry++;

            return success;
        }

        private bool Convert(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;


            if (imageToConvert != null)
            {
                if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
                    success = ConvertToJpg(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.PNG)
                    success = ConvertToPng(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.BMP)
                    success = ConvertToBmp(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.TGA)
                    success = ConvertToTga(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.DDS)
                    success = ConvertToDds(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.BLP)
                    success = ConvertToBlp(imageToConvert);
            }

            return success;
        }


        private String GetInputFileName(String filePath)
        {
            String fileName = "";

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



        private string getFullOutputFilePath()
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

        private bool ConvertToJpg(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.SaveAsJpeg(getFullOutputFilePath(), jpegEncoder);
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private bool ConvertToPng(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.SaveAsPng(getFullOutputFilePath());
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private bool ConvertToBmp(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.SaveAsBmp(getFullOutputFilePath());
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private bool ConvertToTga(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                imageToConvert.SaveAsTga(getFullOutputFilePath());
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return success;
        }

        private bool ConvertToDds(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;
            FileStream fs = null;

            try
            {
                fs = File.OpenWrite(getFullOutputFilePath());
                bcEncoder.Encode(imageToConvert, fs);
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

        // NOT YET IMPLEMENTED
        private bool ConvertToBlp(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                Warcraft.BLP.BLP blpFile = new Warcraft.BLP.BLP(imageToConvert, Warcraft.BLP.TextureCompressionType.JPEG);
                File.WriteAllBytes(getFullOutputFilePath(), blpFile.Serialize());
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