﻿using BCnEncoder.Decoder;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War3Net.Drawing.Blp;

namespace Image_Converter.IO
{
    public partial class Reader
    {
        public string errorMsg = "";
        private BcDecoder bcDecoder;
        private bool isBLP2;

        public Reader(bool isBLP2) {
            this.bcDecoder = new BcDecoder();
            this.isBLP2 = isBLP2;
        }

        public SixLabors.ImageSharp.Image<Rgba32> ReadFile(String filePath)
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
                case ".dds":
                    imageToConvert = ReadDDS(filePath);
                    break;
                case ".blp":
                    imageToConvert = ReadBLP(filePath);
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
                /*
                    FileStream fileStream = File.OpenRead(filePath);
                    MemoryStream ms = new MemoryStream();
                    fileStream.CopyTo(ms);
                    fileStream.Close();
                    fileStream.Dispose();
                    Warcraft.BLP.BLP blpFile = new Warcraft.BLP.BLP(ms.ToArray());
                    image = blpFile.GetMipMap(0);
                */

                FileStream fileStream = File.OpenRead(filePath);
                BlpFile blpFile = new BlpFile(fileStream);
                int width;
                int height;
                blpFile.GetPixels(0, out width, out height);
                // The library does not determine what's BLP1 and BLP2 properly, so we manually set bool bgra in GetPixels depending on the checkbox.
                byte[] bytes = blpFile.GetPixels(0, out width, out height, isBLP2); // 0 indicates first mipmap layer. width and height are assigned width and height in GetPixels().
                var actualImage = blpFile.GetBitmapSource(0);
                int bytesPerPixel = (actualImage.Format.BitsPerPixel + 7) / 8;
                int stride = bytesPerPixel * actualImage.PixelWidth;

                // blp read and convert
                image = new SixLabors.ImageSharp.Image<Rgba32>(width, height);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
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
    }
}
