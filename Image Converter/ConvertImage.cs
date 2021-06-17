using BCnEncoder.Encoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using BCnEncoder.Shared;
using War3Net.Drawing.Blp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using BCnEncoder.Decoder;

namespace Image_Converter
{
    public partial class ConvertImage
    {
        public String[] fileEntries;
        int currentEntry = 0;
        public bool isMultipleFiles;
        public String errorMsg;
        public String outputDir;
        public String fileName;
        public int selectedFileExtension;
        public bool keepFileNames;
        public String outputFiletype = ".jpg"; // defaults to jpg if anything goes wrong.
        public ImageCodecInfo imageCodecInfo; // for standard formats like jpg, png, tiff and bmp.
        public EncoderParameters encoderParameters; // for standard formats like jpg, png, tiff and bmp.
        public int imageQualityJpeg;
        public int selectedDDSCompression;
        public bool generateMipMaps;
        private BcEncoder bcEncoder;
        private BcDecoder bcDecoder = new BcDecoder();
        private JpegEncoder jpegEncoder;

        public void Init(int selectedFileExtension)
        {
            this.currentEntry = 0; // in case a user wants to convert more times.
            this.selectedFileExtension = selectedFileExtension;
            switch (selectedFileExtension)
            {
                case (int)ImageFormats.JPG:
                    //this.imageCodecInfo = GetEncoder(ImageFormat.Jpeg);
                    outputFiletype = ".jpg";
                    break;
                case (int)ImageFormats.PNG:
                    //this.imageCodecInfo = GetEncoder(ImageFormat.Png);
                    outputFiletype = ".png";
                    break;
                case (int)ImageFormats.BMP:
                    //this.imageCodecInfo = GetEncoder(ImageFormat.Bmp);
                    outputFiletype = ".bmp";
                    break;
                case (int)ImageFormats.TGA:
                    outputFiletype = ".tga";
                    break;
                case (int)ImageFormats.DDS:
                    outputFiletype = ".dds";
                    break;
            }

            // ----
            // Setup Encoders
            // ----
            if (selectedFileExtension == (int)ImageFormats.JPG)
            {
                jpegEncoder = new JpegEncoder();
                jpegEncoder.Quality = imageQualityJpeg;
            }
            if (selectedFileExtension == (int)ImageFormats.DDS)
            {
                bcEncoder = new BcEncoder();
                bcEncoder.Options.multiThreaded = true;
                bcEncoder.OutputOptions.generateMipMaps = generateMipMaps;
                bcEncoder.OutputOptions.fileFormat = OutputFileFormat.Dds;
                bcEncoder.OutputOptions.quality = CompressionQuality.BestQuality;

                switch (selectedDDSCompression)
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
            }
        }

        public bool Convert()
        {
            bool success = false;
            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = ReadInputFile(fileEntries[currentEntry]);

            if (imageToConvert != null)
            {
                if (selectedFileExtension == (int)ImageFormats.JPG)
                {
                    success = ConvertToJpg(imageToConvert);
                }
                else if (selectedFileExtension == (int)ImageFormats.PNG)
                {
                    success = ConvertToPng(imageToConvert);
                }
                else if (selectedFileExtension == (int)ImageFormats.BMP)
                {
                    success = ConvertToBmp(imageToConvert);
                }
                else if (selectedFileExtension == (int)ImageFormats.TGA)
                {
                    success = ConvertToTga(imageToConvert);
                }
                else if (selectedFileExtension == (int)ImageFormats.DDS)
                {
                    success = ConvertToDds(imageToConvert);
                }
            }

            currentEntry++;

            return success;
        }

        public SixLabors.ImageSharp.Image<Rgba32> ReadInputFile(String filePath)
        {
            String fileExtension = GetInputFileFormat(filePath);
            string fileExtensionCorreced = fileExtension.ToLower();
            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = null;

            switch (fileExtensionCorreced)
            {
                case ".jpg":
                    imageToConvert = ReadLegacy(filePath);
                    break;
                case ".jpeg":
                    imageToConvert = ReadLegacy(filePath);
                    break;
                case ".png":
                    imageToConvert = ReadLegacy(filePath);
                    break;
                case ".bmp":
                    imageToConvert = ReadLegacy(filePath);
                    break;
                case ".tga":
                    imageToConvert = ReadLegacy(filePath);
                    break;
                case ".blp":
                    imageToConvert = ReadBLP(filePath);
                    break;
                case ".dds":
                    imageToConvert = ReadDDS(filePath);
                    break;
                default:
                    errorMsg = "Unsupported input format.";
                    break;
            }

            return imageToConvert;
        }

        private String GetInputFileFormat(String filePath)
        {
            String fileExtension = "";

            char cCurrent;
            int sub = 0;
            bool end = false;
            while (!end)
            {
                cCurrent = filePath[filePath.Length - 1 - sub];
                if (cCurrent == '.')
                {
                    end = true;
                }
                fileExtension += cCurrent; // appends file extension to the string (opposite order, but we flip it later)

                sub++;
            }

            char[] charArray = fileExtension.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray);
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

        private SixLabors.ImageSharp.Image<Rgba32> ReadLegacy(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;

            try
            {
                image = SixLabors.ImageSharp.Image.Load<Rgba32>(filePath);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return image;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadBLP(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;

            try
            {
                FileStream fileStream = File.OpenRead(filePath);
                BlpFile blpFile = new BlpFile(fileStream);
                int width;
                int height;
                blpFile.GetPixels(0, out width, out height);
                // It's very important we set the bool bgra = false in GetPixels
                byte[] bytes = blpFile.GetPixels(0, out width, out height, false); // 0 indicates first mipmap layer. width and height are assigned width and height in GetPixels().
                var actualImage = blpFile.GetBitmapSource(0);
                int bytesPerPixel = (actualImage.Format.BitsPerPixel + 7) / 8;
                int stride = bytesPerPixel * actualImage.PixelWidth;

                // blp read and convert
                image = new SixLabors.ImageSharp.Image<Rgba32>(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var offset = (y * stride) + (x * bytesPerPixel);

                        byte red;
                        byte green;
                        byte blue;
                        byte alpha = 0;

                        red = bytes[offset + 0];
                        green = bytes[offset + 1];
                        blue = bytes[offset + 2];
                        alpha = bytes[offset + 3];

                        Rgba32 pixel = new Rgba32(blue, green, red, alpha);

                        image[x, y] = pixel; // assign color to pixel
                    }
                }

                blpFile.Dispose();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }


            return image;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadDDS(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;

            try
            {
                using FileStream fs = File.OpenRead(filePath);
                image = bcDecoder.Decode(fs);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return image;
        }

        private bool ConvertToJpg(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                String path;
                if (keepFileNames)
                {
                    path = outputDir + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
                }
                else if (isMultipleFiles)
                {
                    path = outputDir + fileName + "_" + currentEntry + outputFiletype;
                }
                else
                {
                    path = outputDir + fileName + outputFiletype;
                }

                imageToConvert.SaveAsJpeg(path, jpegEncoder);

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
                String path;
                if (keepFileNames)
                {
                    path = outputDir + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
                }
                else if (isMultipleFiles)
                {
                    path = outputDir + fileName + "_" + currentEntry + outputFiletype;
                }
                else
                {
                    path = outputDir + fileName + outputFiletype;
                }

                imageToConvert.SaveAsPng(path);

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
                String path;
                if (keepFileNames)
                {
                    path = outputDir + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
                }
                else if (isMultipleFiles)
                {
                    path = outputDir + fileName + "_" + currentEntry + outputFiletype;
                }
                else
                {
                    path = outputDir + fileName + outputFiletype;
                }

                imageToConvert.SaveAsBmp(path);

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
                String path;
                if (keepFileNames)
                {
                    path = outputDir + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
                }
                else if (isMultipleFiles)
                {
                    path = outputDir + fileName + "_" + currentEntry + outputFiletype;
                }
                else
                {
                    path = outputDir + fileName + outputFiletype;
                }

                imageToConvert.SaveAsTga(path);

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

            try
            {
                String path;
                if (keepFileNames)
                {
                    path = outputDir + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
                }
                else if (isMultipleFiles)
                {
                    path = outputDir + fileName + "_" + currentEntry + outputFiletype;
                }
                else
                {
                    path = outputDir + fileName + outputFiletype;
                }
                using FileStream fs = File.OpenWrite(path);
                bcEncoder.Encode(imageToConvert, fs);

                fs.DisposeAsync();

                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                //throw;
            }

            return success;
        }


        private bool ConvertOLD(bool isMulti)
        {
            bool success = false;
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(fileEntries[currentEntry]);
                if (isMulti)
                {
                    bmp.Save(outputDir + fileName + "_" + currentEntry + outputFiletype, imageCodecInfo, encoderParameters);
                }
                else
                {
                    bmp.Save(outputDir + fileName + outputFiletype, imageCodecInfo, encoderParameters);
                }
                bmp.Dispose();

                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            currentEntry++;

            return success;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}