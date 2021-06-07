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

namespace Image_Converter
{
    public partial class ConvertImage
    {
        public String[] fileEntries;
        int currentEntry = 0;
        public String errorMsg;
        public String outputDir;
        public String fileName;
        public String filetype = ".jpg"; // defaults to jpg if anything goes wrong.
        public ImageCodecInfo imageCodecInfo; // for standard formats like jpg, png, tiff and bmp.
        public EncoderParameters encoderParameters; // for standard formats like jpg, png, tiff and bmp.
        public int DDSCompressionFormat;


        public ConvertImage(int fileExtension)
        {
            switch (fileExtension)
            {
                case 0:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Jpeg);
                    filetype = ".jpg";
                    break;
                case 1:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Png);
                    filetype = ".png";
                    break;
                case 2:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Tiff);
                    filetype = ".tiff";
                    break;
                case 3:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Gif);
                    filetype = ".gif";
                    break;
                case 4:
                    this.imageCodecInfo = GetEncoder(ImageFormat.Bmp);
                    filetype = ".bmp";
                    break;
                case 5:
                    filetype = ".dds";
                    break;
            }
        }


        public bool ConvertToDDS()
        {
            bool success = false;

            try
            {
                using SixLabors.ImageSharp.Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(fileEntries[currentEntry]);

                BcEncoder encoder = new BcEncoder();

                encoder.OutputOptions.generateMipMaps = true;
                encoder.OutputOptions.quality = CompressionQuality.Balanced;
                encoder.OutputOptions.format = CompressionFormat.BC1;
                encoder.OutputOptions.fileFormat = OutputFileFormat.Dds; //Change to Dds for a dds file.

                using FileStream fs = File.OpenWrite(outputDir + fileName + filetype);
                encoder.Encode(image, fs);

                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                throw;
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
                    bmp.Save(outputDir + fileName + "_" + currentEntry + filetype, imageCodecInfo, encoderParameters);
                }
                else
                {
                    bmp.Save(outputDir + fileName + filetype, imageCodecInfo, encoderParameters);
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
        public bool ConvertLegacySingle()
        {
            if (ConvertLegacy(false) == true)
            {
                return true;
            }
            return false;
        }

        public bool ConvertLegacyMulti()
        {
            if (ConvertLegacy(true) == true)
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