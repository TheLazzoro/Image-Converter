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
        private BcDecoder bcDecoder;
        private JpegEncoder jpegEncoder;
        private SixLabors.ImageSharp.Image<Rgba32> imageToConvert;

        public void Init(int selectedFileExtension)
        {
            this.selectedFileExtension = selectedFileExtension;
            switch (selectedFileExtension)
            {
                case 0:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Jpeg);
                    outputFiletype = ".jpg";
                    break;
                case 1:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Png);
                    outputFiletype = ".png";
                    break;
                case 2:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Bmp);
                    outputFiletype = ".bmp";
                    break;
                case 3:
                    outputFiletype = ".dds";
                    break;
            }

            // ----
            // Setup Decoders
            // ----
            bcDecoder = new BcDecoder();

            // ----
            // Setup Encoders
            // ----
            if (selectedFileExtension == 0) // jpg
            {
                jpegEncoder = new JpegEncoder();
                jpegEncoder.Quality = imageQualityJpeg;
            }
            if (selectedFileExtension == 3) // dds format
            {
                bcEncoder = new BcEncoder();
                bcEncoder.Options.multiThreaded = true;
                bcEncoder.OutputOptions.generateMipMaps = generateMipMaps;
                bcEncoder.OutputOptions.fileFormat = OutputFileFormat.Dds; //Change to Dds for a dds file.
                bcEncoder.OutputOptions.quality = CompressionQuality.BestQuality;

                switch (selectedDDSCompression)
                {
                    case 0:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC1;
                        break;
                    case 1:
                        bcEncoder.OutputOptions.format = CompressionFormat.BC2;
                        break;
                    case 2:
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
            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = ReadInputFile();

            if (imageToConvert != null)
            {
                if (selectedFileExtension == 0) // jpg
                {
                    success = ConvertToJpg(imageToConvert);
                }
                else if (selectedFileExtension == 1) // png
                {
                    success = ConvertToPng(imageToConvert);
                }
                else if (selectedFileExtension == 2) // bmp
                {
                    success = ConvertToBmp(imageToConvert);
                }
                else if (selectedFileExtension == 3) // dds
                {
                    success = ConvertToDds(imageToConvert);
                }
            }

            currentEntry++;

            return success;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadInputFile()
        {
            String fileExtension = GetInputFileFormat();
            string fileExtensionCorreced = fileExtension.ToLower();
            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = null;

            switch (fileExtensionCorreced)
            {
                case ".jpg":
                    imageToConvert = ReadLegacy();
                    break;
                case ".png":
                    imageToConvert = ReadLegacy();
                    break;
                case ".bmp":
                    imageToConvert = ReadLegacy();
                    break;
                case ".blp":
                    imageToConvert = ReadBLP();
                    break;
                case ".dds":
                    imageToConvert = ReadDDS();
                    break;
                default:
                    break;
            }

            return imageToConvert;
        }

        private String GetInputFileFormat()
        {
            String filePath = fileEntries[currentEntry];
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

        private SixLabors.ImageSharp.Image<Rgba32> ReadLegacy()
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;

            try
            {
                image = SixLabors.ImageSharp.Image.Load<Rgba32>(fileEntries[currentEntry]);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return image;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadBLP()
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;

            try
            {
                FileStream fileStream = File.OpenRead(fileEntries[currentEntry]);
                BlpFile blpFile = new BlpFile(fileStream);
                int width;
                int height;
                byte[] bytes = blpFile.GetPixels(0, out width, out height, false); // 0 indicates first mipmap layer. width and height are assigned width and height in GetPixels().
                Bitmap blpPixels = blpFile.GetBitmap();

                // blp read and convert
                image = new SixLabors.ImageSharp.Image<Rgba32>(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte red = blpPixels.GetPixel(x, y).R;
                        byte green = blpPixels.GetPixel(x, y).G;
                        byte blue = blpPixels.GetPixel(x, y).B;
                        byte alpha = blpPixels.GetPixel(x, y).A;
                        Rgba32 pixel = new Rgba32(red, green, blue, alpha);

                        image[x, y] = pixel; // assign color to pixel
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return image;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadDDS()
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;

            try
            {
                using FileStream fs = File.OpenRead(fileEntries[currentEntry]);
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
                if (isMultipleFiles)
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
                if (isMultipleFiles)
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
                if (isMultipleFiles)
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

        private bool ConvertToDds(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            try
            {
                String path;
                if (isMultipleFiles)
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