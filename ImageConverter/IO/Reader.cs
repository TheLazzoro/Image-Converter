using BCnEncoder.Decoder;
using ImageConverter.Image_Processing;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War3Net.Drawing.Blp;
using WebPWrapper;

namespace ImageConverter.IO
{
    public static class Reader
    {
        public static Bitmap image = null;
        public static string errorMsg = "";
        public static string fileSizeString = "";
        private static BcDecoder bcDecoder = new BcDecoder();

        public static void ReadFile(string filePath)
        {
            if (image != null) image.Dispose();
            image = null;

            string fileExtension = Shared.GetFileExtension(filePath);
            string fileExtensionCorreced = fileExtension.ToLower();
            try
            {
                fileSizeString = GetFileSizeString(filePath);

                switch (fileExtensionCorreced)
                {
                    case ".jpg":
                        image = ReadLegacy(filePath);
                        break;
                    case ".jpeg":
                        image = ReadLegacy(filePath);
                        break;
                    case ".png":
                        image = ReadLegacy(filePath);
                        break;
                    case ".bmp":
                        image = ReadLegacy(filePath);
                        break;
                    case ".tga":
                        image = ReadTGA(filePath);
                        break;
                    case ".dds":
                        image = ReadDDS(filePath);
                        break;
                    case ".blp":
                        image = ReadBLP(filePath);
                        break;
                    case ".cr2":
                        image = ReadCR2(filePath);
                        break;
                    case ".webp":
                        image = ReadWebP(filePath);
                        break;
                    default:
                        errorMsg = "Unsupported format.";
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                errorMsg = "File not found.";
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
        }

        public static String GetFileSizeString(string filePath)
        {
            String finalText = "";
            String howBigBytes = "bytes";

            try
            {
                using (Stream fs = new FileStream(filePath, FileMode.Open))
                {
                    long sizeBytes = fs.Length;
                    String text = sizeBytes.ToString();
                    int textLength = text.Length;

                    if (sizeBytes > 1000)
                    {
                        howBigBytes = "KB";
                        sizeBytes = sizeBytes / 1000;
                        text = sizeBytes.ToString();
                        textLength = text.Length;
                    }

                    int dotPlacementHelper = 0;
                    for (int i = textLength; i > 0; i--)
                    {
                        if (dotPlacementHelper % 3 == 0 && dotPlacementHelper != 0)
                        {
                            finalText += "." + text.Substring(i - 1, 1);
                        }
                        else
                        {
                            finalText += text.Substring(i - 1, 1);
                        }
                        dotPlacementHelper++;
                    }
                }
            }
            catch (System.Exception ex)
            {
                errorMsg = ex.Message;
            }


            char[] charArray = finalText.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray) + " " + howBigBytes;
        }

        private static Bitmap ReadLegacy(String filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Bitmap bitmap = new Bitmap(Image.FromStream(fs));
                return bitmap;
            }
        }

        private static Bitmap ReadTGA(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(filePath);

            return Converter.ToBitmap(image);
        }

        private static Bitmap ReadBLP(String filePath)
        {
            FileStream fs = File.OpenRead(filePath);
            BlpFile blpFile = new BlpFile(fs);
            int width;
            int height;
            // The library does not determine what's BLP1 and BLP2 properly, so we manually set bool bgra in GetPixels depending on the checkbox.
            byte[] bytes = blpFile.GetPixels(0, out width, out height, FilterSettings.isBLP2); // 0 indicates first mipmap layer. width and height are assigned width and height in GetPixels().
            var actualImage = blpFile.GetBitmapSource(0);
            int bytesPerPixel = (actualImage.Format.BitsPerPixel + 7) / 8;
            int stride = bytesPerPixel * actualImage.PixelWidth;

            // blp read and convert
            Bitmap image = new Bitmap(width, height);

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

                    image.SetPixel(x, y, Color.FromArgb(alpha, blue, green, red)); // assign color to pixel
                }
            }

            blpFile.Dispose();

            return image;
        }

        private static Bitmap ReadDDS(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = null;
            using FileStream fs = File.OpenRead(filePath);
            image = bcDecoder.Decode(fs);

            return Converter.ToBitmap(image);
        }

        private static Bitmap ReadCR2(String filePath)
        {
            int _bufferSize = 512 * 1024;
            byte[] _buffer = new byte[_bufferSize];
            ImageCodecInfo _jpgImageCodec = GetJpegCodec();


            Bitmap bitmap = null;

            FileStream fs = File.OpenRead(filePath);
            // Start address is at offset 0x62, file size at 0x7A, orientation at 0x6E
            fs.Seek(0x62, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(fs);
            UInt32 jpgStartPosition = br.ReadUInt32();  // 62
            br.ReadUInt32();  // 66
            br.ReadUInt32();  // 6A
            UInt32 orientation = br.ReadUInt32() & 0x000000FF; // 6E
            br.ReadUInt32();  // 72
            br.ReadUInt32();  // 76
            Int32 fileSize = br.ReadInt32();  // 7A

            fs.Seek(jpgStartPosition, SeekOrigin.Begin);

            var ps = new PartialStream(fs, jpgStartPosition, fileSize);
            bitmap = new Bitmap(ps);

            br.Close();
            ps.Close();
            fs.Close();

            try
            {
                if (_jpgImageCodec != null && (orientation == 8 || orientation == 6))
                {
                    if (orientation == 8)
                        bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    else
                        bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            catch (Exception ex)
            {
                // Image Skipped
            }


            Bitmap bitmapCopy = new Bitmap((Image)bitmap);

            return bitmapCopy;
        }

        private static ImageCodecInfo GetJpegCodec()
        {
            foreach (ImageCodecInfo c in ImageCodecInfo.GetImageEncoders())
            {
                if (c.CodecName.ToLower().Contains("jpeg")
                    || c.FilenameExtension.ToLower().Contains("*.jpg")
                    || c.FormatDescription.ToLower().Contains("jpeg")
                    || c.MimeType.ToLower().Contains("image/jpeg"))
                    return c;
            }

            return null;
        }

        private static Bitmap ReadWebP(String filePath)
        {
            using (WebP webp = new WebP()) { 
                Bitmap bitmap = webp.Load(filePath);
                return bitmap;
            }
        }
    }
}
