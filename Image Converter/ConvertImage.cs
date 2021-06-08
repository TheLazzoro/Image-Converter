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

namespace Image_Converter
{
    public partial class ConvertImage
    {
        public String[] fileEntries;
        int currentEntry = 0;
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

        public bool Convert(bool isMultipleFiles)
        {
            bool success = false;
            if (isMultipleFiles == false)
            {
                success = ConvertSingle();
            }
            else
            {
                success = ConvertMulti();
            }

            return success;
        }

        private bool ConvertSingle()
        {
            bool success = false;
            if (selectedFileExtension < 5)
            {
                success = ConvertLegacySingle();
            }
            else if (selectedFileExtension == 5)
            {
                success = ConvertToDdsSingle();
            }

            return success;
        }

        private bool ConvertMulti()
        {
            bool success = false;
            if (selectedFileExtension < 5)
            {
                success = ConvertLegacyMulti();
            }
            else if (selectedFileExtension == 5)
            {
                success = ConvertToDdsMulti();
            }

            return success;
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
                byte[] bytes = blpFile.GetPixels(0, out width, out height, false); // x and y are assigned width and height in GetPixels().
                Bitmap temp = blpFile.GetBitmap();

                // blp read and convert
                using (SixLabors.ImageSharp.Image<Rgba32> image = new SixLabors.ImageSharp.Image<Rgba32>(width, height))
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            /*
                            // This block has been outcommented to save memory.

                            byte red = blpFile.GetBitmap().GetPixel(x, y).R;
                            byte green = blpFile.GetBitmap().GetPixel(x, y).G;
                            byte blue = blpFile.GetBitmap().GetPixel(x, y).B;
                            byte alpha = blpFile.GetBitmap().GetPixel(x, y).A;
                            Rgba32 pixel = new Rgba32(red, green, blue);
                            image3[x, y] = pixel;
                            */

                            image[x, y] = new Rgba32(temp.GetPixel(x, y).R, temp.GetPixel(x, y).G, temp.GetPixel(x, y).B, temp.GetPixel(x, y).A); // assign color to pixel
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

        private bool ConvertLegacySingle()
        {
            if (ConvertLegacy(false) == true)
            {
                return true;
            }
            return false;
        }

        private bool ConvertLegacyMulti()
        {
            if (ConvertLegacy(true) == true)
            {
                return true;
            }
            return false;
        }

        private bool ConvertToDdsSingle()
        {
            if (ConvertToDds(false) == true)
            {
                return true;
            }
            return false;
        }

        private bool ConvertToDdsMulti()
        {
            if (ConvertToDds(true) == true)
            {
                return true;
            }
            return false;
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