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
        public String outputFiletype = ".jpg"; // defaults to jpg if anything goes wrong.
        public ImageCodecInfo imageCodecInfo; // for standard formats like jpg, png, tiff and bmp.
        public EncoderParameters encoderParameters; // for standard formats like jpg, png, tiff and bmp.
        public long imageQualityJpeg;
        public int selectedDDSCompression;
        private BcEncoder bcEncoder;
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
                    this.imageCodecInfo = GetEncoder(ImageFormat.Tiff);
                    outputFiletype = ".tiff";
                    break;
                case 3:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Gif);
                    outputFiletype = ".gif";
                    break;
                case 4:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Bmp);
                    outputFiletype = ".bmp";
                    break;
                case 5:
                    outputFiletype = ".dds";
                    break;
            }

            // ----
            // Setup Encoders
            // ----
            if (selectedFileExtension < 5) // Legacy formats i.e jpg, png, bmp
            {
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                encoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);

                if (selectedFileExtension == 0) // jpg format
                {
                    myEncoderParameter = new EncoderParameter(myEncoder, imageQualityJpeg);
                }
                encoderParameters.Param[0] = myEncoderParameter;
            }
            if (selectedFileExtension == 5) // dds format
            {
                bcEncoder = new BcEncoder();
                bcEncoder.Options.multiThreaded = true;
                bcEncoder.OutputOptions.generateMipMaps = true;
                bcEncoder.OutputOptions.quality = CompressionQuality.BestQuality;
                bcEncoder.OutputOptions.format = CompressionFormat.BC1;
                bcEncoder.OutputOptions.fileFormat = OutputFileFormat.Dds; //Change to Dds for a dds file.
            }
        }

        public bool Convert()
        {
            bool success = false;
            if (selectedFileExtension < 5) // Legacy formats
            {
                success = ConvertLegacy(isMultipleFiles);
            }
            else if (selectedFileExtension == 5) // dds format
            {
                success = ConvertToDds(isMultipleFiles);
            }

            return success;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadInputFile()
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;
            String fileExtension = GetInputFileFormat();

            switch (fileExtension)
            {
                case ".jpg":
                    image = ReadLegacy();
                    break;
                case ".png":
                    image = ReadLegacy();
                    break;
                case ".blp":
                    image = ReadBLP();
                    break;
                case ".dds":
                    break;
                default:
                    break;
            }

            return image;
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
            SixLabors.ImageSharp.Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(fileEntries[currentEntry]);

            return image;
        }

        private SixLabors.ImageSharp.Image<Rgba32> ReadBLP()
        {
            SixLabors.ImageSharp.Image<Rgba32> image;

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

            return image;
        }

        

        private bool ConvertLegacy(bool isMulti)
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

        private bool ConvertToDds(bool isMulti)
        {
            bool success = false;

            try
            {
                FileStream fileStream = File.OpenRead(fileEntries[currentEntry]);
                BlpFile blpFile = new BlpFile(fileStream);
                int width;
                int height;
                byte[] bytes = blpFile.GetPixels(0, out width, out height, false); // 0 indicates first mipmap layer. width and height are assigned width and height in GetPixels().
                Bitmap blpPixels = blpFile.GetBitmap();

                // blp read and convert
                using (SixLabors.ImageSharp.Image<Rgba32> image = new SixLabors.ImageSharp.Image<Rgba32>(width, height))
                {
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

                    String path;
                    if (isMulti)
                    {
                        path = outputDir + fileName + "_" + currentEntry + outputFiletype;
                    }
                    else
                    {
                        path = outputDir + fileName + outputFiletype;
                    }
                    using FileStream fs = File.OpenWrite(path);
                    bcEncoder.Encode(image, fs);

                    fs.DisposeAsync();

                    // below is just testing
                    JpegEncoder jpegEncoder = new JpegEncoder();
                    jpegEncoder.Quality = 100;
                    image.SaveAsJpeg(path, jpegEncoder);

                    image.SaveAsPng(path);
                }



                //SixLabors.ImageSharp.Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(fileEntries[currentEntry]); // use for legacy files



                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                //throw;
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