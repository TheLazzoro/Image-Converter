using BCnEncoder.Encoder;
using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using BCnEncoder.Shared;
using War3Net.Drawing.Blp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using BCnEncoder.Decoder;
using System.Runtime.InteropServices;
using Image_Converter.Image_Processing;

namespace Image_Converter.IO
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
        public int imageQualityJpeg;
        public int selectedDDSCompression;
        public int selectedDDSCompressionQuality;
        public bool generateMipMaps;
        public IconSettings currentIconSetting;
        private Reader reader;
        private string filePrefix = "";
        private BcEncoder bcEncoder;
        private JpegEncoder jpegEncoder;
        private Warcraft.BLP.TextureCompressionType blpEncoder;

        public Converter()
        {
            reader = new Reader();
        }

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

            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = reader.ReadFile(fileEntries[currentEntry]);

            if (FilterSettings.war3IconType == War3IconType.None)
            {
                filePrefix = "";
                Convert(imageToConvert);
            }
            else
            {
                ImageFilters filters = new ImageFilters();
                if (FilterSettings.war3IconType == War3IconType.ClassicIcon)
                {
                    if (FilterSettings.isButtonIcon)
                    {
                        filePrefix = "BTN";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.BTN);
                    }
                    if (FilterSettings.isPassiveIcon)
                    {
                        filePrefix = "PAS";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.PAS);
                    }
                    if (FilterSettings.isAutocastIcon)
                    {
                        filePrefix = "ATC";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.ATC);
                    }
                    if (FilterSettings.isDisabledIcon)
                    {
                        filePrefix = "DISBTN";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.DIS);
                    }
                }
                else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon)
                {
                    if (FilterSettings.isButtonIconRef)
                    {
                        filePrefix = "BTN";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.BTN_REF);
                    }
                    if (FilterSettings.isPassiveIconRef)
                    {
                        filePrefix = "PAS";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.PAS_REF);
                    }
                    if (FilterSettings.isAutocastIconRef)
                    {
                        filePrefix = "ATC";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.ATC_REF);
                    }
                    if (FilterSettings.isDisabledIconRef)
                    {
                        filePrefix = "DISBTN";
                        imageToConvert = filters.AddIconBorder(imageToConvert, IconSettings.DIS_REF);
                    }
                }
            }

            if (FilterSettings.isResized)
            {
                imageToConvert.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
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

        public SixLabors.ImageSharp.Image<Rgba32> Preview(String filePath)
        {
            SixLabors.ImageSharp.Image<Rgba32> image = reader.ReadFile(filePath);
            if (image != null)
            {
                ImageFilters filters = new ImageFilters();
                int iconsChecked = 0;
                if (FilterSettings.isButtonIcon) iconsChecked++;
                if (FilterSettings.isPassiveIcon) iconsChecked++;
                if (FilterSettings.isAutocastIcon) iconsChecked++;
                if (FilterSettings.isDisabledIcon) iconsChecked++;

                if (FilterSettings.war3IconType == War3IconType.ClassicIcon && iconsChecked <= 1) // Classic icons
                {
                    if (FilterSettings.isButtonIcon) image = filters.AddIconBorder(image, IconSettings.BTN);
                    if (FilterSettings.isPassiveIcon) image = filters.AddIconBorder(image, IconSettings.PAS);
                    if (FilterSettings.isAutocastIcon) image = filters.AddIconBorder(image, IconSettings.ATC);
                    if (FilterSettings.isDisabledIcon) image = filters.AddIconBorder(image, IconSettings.DIS);
                    errorMsg = "";
                }
                else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && iconsChecked <= 1) // Reforged icons
                {
                    if (FilterSettings.isButtonIconRef) image = filters.AddIconBorder(image, IconSettings.BTN_REF);
                    if (FilterSettings.isPassiveIconRef) image = filters.AddIconBorder(image, IconSettings.PAS_REF);
                    if (FilterSettings.isAutocastIconRef) image = filters.AddIconBorder(image, IconSettings.ATC_REF);
                    if (FilterSettings.isDisabledIconRef) image = filters.AddIconBorder(image, IconSettings.DIS_REF);
                    errorMsg = "";
                }
                else
                {
                    if (FilterSettings.war3IconType == War3IconType.ClassicIcon && image.Width == 64 && image.Height == 64)
                        errorMsg = "Cannot display multiple icon filters";
                    else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && image.Width == 256 && image.Height == 256)
                        errorMsg = "Cannot display multiple icon filters";
                    else
                        errorMsg = "";
                }

                if (FilterSettings.isResized)
                {
                    image.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                }

            }

            return image;
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

        

        private string getFullOutputFilePath()
        {
            string path = "";
            if (keepFileNames)
                path = outputDir + filePrefix + GetInputFileName(fileEntries[currentEntry]) + outputFiletype;
            else if (isMultipleFiles)
                path = outputDir + filePrefix + fileName + "_" + currentEntry + outputFiletype;
            else
                path = outputDir + filePrefix + fileName + outputFiletype;

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
    }
}