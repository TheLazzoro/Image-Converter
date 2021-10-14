using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using WebPWrapper;
using BCnEncoder.Encoder;

namespace ImageConverter.IO
{
    public static class Writer
    {
        public static bool WriteJpg(Bitmap imageToConvert, ImageCodecInfo jpgEncoder, EncoderParameters encoderParameters, string outputPath)
        {
            bool success = false;

            imageToConvert.Save(outputPath, jpgEncoder, encoderParameters);
            success = true;

            return success;
        }

        public static bool WritePng(Bitmap imageToConvert, string outputPath)
        {
            bool success = false;

            imageToConvert.Save(outputPath, ImageFormat.Png);
            success = true;

            return success;
        }

        public static bool WriteBmp(Bitmap imageToConvert, string outputPath)
        {
            bool success = false;

            imageToConvert.Save(outputPath, ImageFormat.Bmp);
            success = true;

            return success;
        }

        public static bool WriteTga(Bitmap imageToConvert, string outputPath)
        {
            bool success = false;

            SixLabors.ImageSharp.Image<Rgba32> img = Utility.ToImageSharpImage(imageToConvert);
            img.SaveAsTga(outputPath);
            success = true;

            return success;
        }

        public static bool WriteDds(Bitmap imageToConvert, BcEncoder bcEncoder, string outputPath)
        {
            bool success = false;
            FileStream fs = null;

            SixLabors.ImageSharp.Image<Rgba32> img = Utility.ToImageSharpImage(imageToConvert);
            fs = File.OpenWrite(outputPath);
            bcEncoder.Encode(img, fs);
            fs.DisposeAsync();
            success = true;

            return success;
        }

        public static bool WriteWebP(Bitmap imageToConvert, string outputPath)
        {
            bool success = false;

            using (WebP webp = new WebP())
                webp.Save(imageToConvert, outputPath, ExportSettings.imageQuality);
            success = true;

            return success;
        }
    }
}
