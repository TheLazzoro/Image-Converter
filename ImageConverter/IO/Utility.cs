using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageConverter
{
    public static class Utility
    {
        public static string GetFileNameAndExtension(string filePath)
        {
            string fileName = "";

            char cCurrent;
            int sub = 0;
            bool start = true;
            bool end = false;
            while (!end && filePath.Length > sub)
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

                sub++;
            }

            char[] charArray = fileName.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray);
        }

        public static string GetFileExtension(String filePath)
        {
            string fileExtension = "";

            char cCurrent;
            int sub = 0;
            bool end = false;
            while (!end && filePath.Length > sub)
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

        public static string GetInputFileName(String filePath)
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
    }
}
