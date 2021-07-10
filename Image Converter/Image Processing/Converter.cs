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
using SixLabors.ImageSharp.Processing;
using BCnEncoder.Shared;
using War3Net.Drawing.Blp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using BCnEncoder.Decoder;
using CSharpImageLibrary;
using static CSharpImageLibrary.ImageFormats;
using DirectXTexNet;
using System.Runtime.InteropServices;

namespace Image_Converter
{
    public partial class Converter
    {
        public string debugString = "";
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
        public int selectedDDSCompressionQuality;
        public bool generateMipMaps;
        public bool isBLP2 = false;
        public IconSettings currentIconSetting;
        public int war3IconType;
        public bool isButtonIcon = false;
        public bool isButtonIconRef = false;
        public bool isPassiveIcon = false;
        public bool isPassiveIconRef = false;
        public bool isDisabledIcon = false;
        public bool isDisabledIconRef = false;
        public bool isAutocastIcon = false;
        public bool isAutocastIconRef = false;
        public bool isResized = false;
        public int resizeX;
        public int resizeY;
        private string filePrefix = "";
        private BcEncoder bcEncoder;
        private BcDecoder bcDecoder = new BcDecoder();
        private JpegEncoder jpegEncoder;
        private Warcraft.BLP.TextureCompressionType blpEncoder;

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
                case (int)ImageFormats.BLP:
                    outputFiletype = ".blp";
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

                switch (selectedDDSCompressionQuality)
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
            if (selectedFileExtension == (int)ImageFormats.BLP)
            {
                blpEncoder = new Warcraft.BLP.TextureCompressionType();
            }
        }

        public bool ConvertWithFilters()
        {
            bool success = false;

            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = ReadInputFile(fileEntries[currentEntry]);

            if (war3IconType == 0)
            {
                filePrefix = "";
                Convert(imageToConvert);
            }
            else
            {
                if (war3IconType == 1)
                {
                    if (isButtonIcon)
                    {
                        filePrefix = "BTN";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.BTN);
                    }
                    if (isPassiveIcon)
                    {
                        filePrefix = "PAS";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.PAS);
                    }
                    if (isAutocastIcon)
                    {
                        filePrefix = "ATC";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.ATC);
                    }
                    if (isDisabledIcon)
                    {
                        filePrefix = "DISBTN";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.DIS);
                    }
                }
                else if (war3IconType == 2)
                {
                    if (isButtonIconRef)
                    {
                        filePrefix = "BTN";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.BTN_REF);
                    }
                    if (isPassiveIconRef)
                    {
                        filePrefix = "PAS";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.PAS_REF);
                    }
                    if (isAutocastIconRef)
                    {
                        filePrefix = "ATC";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.ATC_REF);
                    }
                    if (isDisabledIconRef)
                    {
                        filePrefix = "DISBTN";
                        imageToConvert = AddIconBorder(imageToConvert, IconSettings.DIS_REF);
                    }
                }
            }

            if (isResized)
            {
                imageToConvert.Mutate(x => x.Resize(resizeX, resizeY));
            }

            Convert(imageToConvert);

            currentEntry++;

            return success;
        }

        private bool Convert(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            if (imageToConvert != null)
            {
                if (selectedFileExtension == (int)ImageFormats.JPG)
                    success = ConvertToJpg(imageToConvert);
                else if (selectedFileExtension == (int)ImageFormats.PNG)
                    success = ConvertToPng(imageToConvert);
                else if (selectedFileExtension == (int)ImageFormats.BMP)
                    success = ConvertToBmp(imageToConvert);
                else if (selectedFileExtension == (int)ImageFormats.TGA)
                    success = ConvertToTga(imageToConvert);
                else if (selectedFileExtension == (int)ImageFormats.DDS)
                    success = ConvertToDds(imageToConvert);
                else if (selectedFileExtension == (int)ImageFormats.BLP)
                    success = ConvertToBlp(imageToConvert);
            }

            return success;
        }

        public SixLabors.ImageSharp.Image<Rgba32> ReadPreview(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = ReadInputFile(filePath);
            if (image != null)
            {
                int iconsChecked = 0;
                if (isButtonIcon) iconsChecked++;
                if (isPassiveIcon) iconsChecked++;
                if (isAutocastIcon) iconsChecked++;
                if (isDisabledIcon) iconsChecked++;

                if (war3IconType == 1 && iconsChecked <= 1) // Classic icons
                {
                    if (isButtonIcon) image = AddIconBorder(image, IconSettings.BTN);
                    if (isPassiveIcon) image = AddIconBorder(image, IconSettings.PAS);
                    if (isAutocastIcon) image = AddIconBorder(image, IconSettings.ATC);
                    if (isDisabledIcon) image = AddIconBorder(image, IconSettings.DIS);
                    errorMsg = "";
                }
                else if (war3IconType == 2 && iconsChecked <= 1) // Reforged icons
                {
                    if (isButtonIconRef) image = AddIconBorder(image, IconSettings.BTN_REF);
                    if (isPassiveIconRef) image = AddIconBorder(image, IconSettings.PAS_REF);
                    if (isAutocastIconRef) image = AddIconBorder(image, IconSettings.ATC_REF);
                    if (isDisabledIconRef) image = AddIconBorder(image, IconSettings.DIS_REF);
                    errorMsg = "";
                }
                else
                {
                    if (war3IconType != 0 && image.Width == 64 && image.Height == 64)
                        errorMsg = "Cannot display multiple icon filters";
                    else
                        errorMsg = "";
                }

                if (isResized)
                {
                    image.Mutate(x => x.Resize(resizeX, resizeY));
                }

            }

            return image;
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

        private string getFullOutputFilePath()
        {
            string path = "";
            if (keepFileNames)
            {
                path = outputDir + filePrefix + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
            }
            else if (isMultipleFiles)
            {
                path = outputDir + filePrefix + fileName + "_" + currentEntry + outputFiletype;
            }
            else
            {
                path = outputDir + filePrefix + fileName + outputFiletype;
            }

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

            try
            {
                /*
                ImageMagick.MagickImage img = new ImageMagick.MagickImage("C:\\Users\\Lasse Dam\\Desktop\\Uploaded\\Death Knight Spells\\AntiMagicZone.png");
                var defines = new ImageMagick.Formats.DdsWriteDefines {Compression = ImageMagick.Formats.DdsCompression.Dxt1, Mipmaps = 4, };
                img.Settings.Compression = ImageMagick.CompressionMethod.DXT1;
                img.Write(getFullOutputFilePath(), ImageMagick.MagickFormat.Dds);

                */
                /*
                byte[] pixeldata = new byte[imageToConvert.Width * imageToConvert.Height * 4];
                for (int x = 0; x < imageToConvert.Width; x++)
                {
                    for (int y = 0; y < imageToConvert.Height; y++)
                    {
                        pixeldata[x + (imageToConvert.Width * y)] = imageToConvert[x, y].R;
                        pixeldata[x + (imageToConvert.Width * y) + 1] = imageToConvert[x, y].G;
                        pixeldata[x + (imageToConvert.Width * y) + 2] = imageToConvert[x, y].B;
                        pixeldata[x + (imageToConvert.Width * y) + 3] = imageToConvert[x, y].A;
                    }
                }
                Stream stream = new MemoryStream(pixeldata);

                TeximpNet.RGBAQuad color = new TeximpNet.RGBAQuad(255, 255, 255, 255);
                TeximpNet.Surface img = new TeximpNet.Surface(64, 64);
                img = TeximpNet.Surface.LoadFromFile("D:\\Game Projects\\Warcraft 3 Maps\\Direct Strike\\Direct Strike Imports\\Loading Screeen.tga");
                img.FlipVertically();


                //img.SaveToFile(TeximpNet.ImageFormat.DDS, getFullOutputFilePath());
                TeximpNet.Compression.Compressor compressor = new TeximpNet.Compression.Compressor();
                compressor.Input.GenerateMipmaps = true;
                compressor.Compression.Format = TeximpNet.Compression.CompressionFormat.BC1;
                compressor.Compression.Quality = TeximpNet.Compression.CompressionQuality.Fastest;
                compressor.Input.SetData(img);
                compressor.Process(getFullOutputFilePath());
                compressor.Dispose();
                */

                /*
                    //IntPtr pixels = new IntPtr(pixeldata[0]);

                    IntPtr pixels = Marshal.AllocHGlobal(pixeldata.Length);
                    Marshal.Copy(pixeldata, 0, pixels, pixeldata.Length);


                    DirectXTexNet.Image img = new DirectXTexNet.Image(imageToConvert.Width, imageToConvert.Height, DirectXTexNet.DXGI_FORMAT.BC1_TYPELESS, 0, 0, pixels, new Object());
                    DirectXTexNet.Image[] images = {img};
                    TexMetadata metadata = new TexMetadata(imageToConvert.Width, imageToConvert.Height, 0, pixeldata.Length, 1, TEX_MISC_FLAG.TEXTURECUBE, TEX_MISC_FLAG2.ALPHA_MODE_MASK, DirectXTexNet.DXGI_FORMAT.BC1_TYPELESS, TEX_DIMENSION.TEXTURE1D);
                    //DirectXTexNet.ScratchImage scratch = TexHelper.Instance.Initialize(metadata, CP_FLAGS.NONE);
                    //DirectXTexNet.ScratchImage scratch = TexHelper.Instance.Initialize2D(DirectXTexNet.DXGI_FORMAT.BC1_TYPELESS, imageToConvert.Width, imageToConvert.Height, pixeldata.Length, 0, CP_FLAGS.NONE);
                    DirectXTexNet.ScratchImage scratch = TexHelper.Instance.InitializeTemporary(images, metadata);
                    scratch.SaveToDDSFile(DDS_FLAGS.NONE, getFullOutputFilePath());
                */

                //MemoryStream ms = new MemoryStream();
                //imageToConvert.SaveAsBmp(ms);
                //ImageEngineImage img = new ImageEngineImage(ms);
                //ImageEngineFormatDetails details = new ImageEngineFormatDetails(ImageEngineFormat.DDS_DXT1);
                //img.Save(getFullOutputFilePath(), details, MipHandling.GenerateNew);

                using FileStream fs = File.OpenWrite(getFullOutputFilePath());
                bcEncoder.Encode(imageToConvert, fs);
                fs.DisposeAsync();
                success = true;
            }
            catch (Exception ex)
            {

                errorMsg = ex.Message;
                throw;
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
                //throw;
            }

            return success;
        }

        private SixLabors.ImageSharp.Image<Rgba32> AddIconBorder(SixLabors.ImageSharp.Image<Rgba32> source, IconSettings iconSetting)
        {
            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = source.Clone();
            SixLabors.ImageSharp.Image<Rgba32> border = null;
            int width = imageToConvert.Width;
            int height = imageToConvert.Height;

            if (war3IconType == 1 && imageToConvert.Width == 64 && imageToConvert.Height == 64)
            {
                if (iconSetting == IconSettings.BTN)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Icon_Border);
                else if (iconSetting == IconSettings.PAS)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Icon_Border_Passive);
                else if (iconSetting == IconSettings.ATC)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Icon_Border_Autocast);
                else if (iconSetting == IconSettings.DIS)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Icon_Border_Disabled);

            }
            else if (imageToConvert.Width == 256 && imageToConvert.Height == 256)
            {
                if (iconSetting == IconSettings.BTN_REF)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Button);
                if (iconSetting == IconSettings.PAS_REF)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Passive);
                if (iconSetting == IconSettings.ATC_REF)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Autocast);
                if (iconSetting == IconSettings.DIS_REF)
                    border = SixLabors.ImageSharp.Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Disabled);
            }


            if (border != null)
            {
                for (int y = 0; y < width; y++)
                {
                    for (int x = 0; x < height; x++)
                    {
                        byte redSource = imageToConvert[x, y].R;
                        byte greenSource = imageToConvert[x, y].G;
                        byte blueSource = imageToConvert[x, y].B;
                        byte alphaSource = imageToConvert[x, y].A;

                        if (iconSetting == IconSettings.DIS_REF) // Disabled icon color saturation reduction
                        {
                            int greyscale = (int)(redSource * 0.3 + greenSource * 0.59 + blueSource * 0.11);

                            int redDiff = greyscale - redSource;
                            int greenDiff = greyscale - greenSource;
                            int blueDiff = greyscale - blueSource;

                            double redChange = redDiff * 0.01 * 55;
                            double greenChange = greenDiff * 0.01 * 55;
                            double blueChange = blueDiff * 0.01 * 55;

                            int redInt = greyscale - (int)redChange;
                            int greenInt = greyscale - (int)greenChange;
                            int blueInt = greyscale - (int)blueChange;

                            byte redNew = (byte)redInt;
                            byte greenNew = (byte)greenInt;
                            byte blueNew = (byte)blueInt;

                            redSource = redNew;
                            greenSource = greenNew;
                            blueSource = blueNew;
                        }

                        byte redBorder = border[x, y].R;
                        byte greenBorder = border[x, y].G;
                        byte blueBorder = border[x, y].B;
                        byte alphaBorder = border[x, y].A;

                        if (alphaBorder != 0)
                        {
                            float alphaPercent = (float)alphaBorder / 255;

                            byte redBlended = (byte)((int)redSource * (1 - alphaPercent) + (redBorder * alphaPercent));
                            byte greenBlended = (byte)((int)greenSource * (1 - alphaPercent) + (greenBorder * alphaPercent));
                            byte blueBlended = (byte)((int)blueSource * (1 - alphaPercent) + (blueBorder * alphaPercent));

                            imageToConvert[x, y] = new Rgba32(redBlended, greenBlended, blueBlended);
                        }
                    }
                }
            }

            return imageToConvert;
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