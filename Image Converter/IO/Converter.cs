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
using System.Collections.Generic;

namespace Image_Converter.IO
{
    public partial class Converter
    {
        public string debugString = "";
        public String[] fileEntries;
        int currentEntry = 0;
        public String errorMsg;
        private Reader reader;
        private BcEncoder bcEncoder;
        private JpegEncoder jpegEncoder;
        private Warcraft.BLP.TextureCompressionType blpEncoder;
        public int totalErrors = 0;

        public Converter()
        {
            reader = new Reader();

            switch (ExportSettings.selectedFileExtension)
            {
                case ImageFormats.JPG:
                    //this.imageCodecInfo = GetEncoder(ImageFormat.Jpeg);
                    ExportSettings.outputFileType = ".jpg";
                    break;
                case ImageFormats.PNG:
                    //this.imageCodecInfo = GetEncoder(ImageFormat.Png);
                    ExportSettings.outputFileType = ".png";
                    break;
                case ImageFormats.BMP:
                    //this.imageCodecInfo = GetEncoder(ImageFormat.Bmp);
                    ExportSettings.outputFileType = ".bmp";
                    break;
                case ImageFormats.TGA:
                    ExportSettings.outputFileType = ".tga";
                    break;
                case ImageFormats.DDS:
                    ExportSettings.outputFileType = ".dds";
                    break;
                case ImageFormats.BLP:
                    ExportSettings.outputFileType = ".blp";
                    break;
            }

            // ----
            // Setup Encoders
            // ----
            if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
            {
                jpegEncoder = new JpegEncoder();
                jpegEncoder.Quality = ExportSettings.imageQualityJpeg;
            }
            if (ExportSettings.selectedFileExtension == ImageFormats.DDS)
            {
                bcEncoder = new BcEncoder();
                bcEncoder.Options.multiThreaded = true;
                bcEncoder.OutputOptions.generateMipMaps = ExportSettings.generateMipMaps;
                bcEncoder.OutputOptions.fileFormat = OutputFileFormat.Dds;

                switch (ExportSettings.selectedDDSCompression)
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

                switch (ExportSettings.selectedDDSCompressionQuality)
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
            if (ExportSettings.selectedFileExtension == ImageFormats.BLP)
            {
                blpEncoder = new Warcraft.BLP.TextureCompressionType();
            }
        }

        public bool ConvertWithFilters()
        {
            bool success = false;

            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = reader.ReadFile(fileEntries[currentEntry]);
            List<SixLabors.ImageSharp.Image<Rgba32>> filteredImages = new List<Image<Rgba32>>();
            List<string> prefix = new List<string>();

            if (FilterSettings.war3IconType == War3IconType.None)
            {
                ExportSettings.prefix = "";
                if (FilterSettings.isResized)
                {
                    imageToConvert.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                }

                success = Convert(imageToConvert);
            }
            else
            {
                errorMsg = "Image dimensions did not match selected icon dimensions.";
                ImageFilters filters = new ImageFilters();

                if (FilterSettings.war3IconType == War3IconType.ClassicIcon && imageToConvert.Width == 64 && imageToConvert.Height == 64)
                {
                    if (FilterSettings.isIconBTN)
                    {
                        prefix.Add("BTN");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.BTN));
                    }
                    if (FilterSettings.isIconPAS)
                    {
                        prefix.Add("PAS");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.PAS));
                    }
                    if (FilterSettings.isIconATC)
                    {
                        prefix.Add("ATC");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.ATC));
                    }
                    if (FilterSettings.isIconDISBTN)
                    {
                        prefix.Add("DISBTN");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISBTN));
                    }
                    if (FilterSettings.isIconDISPAS)
                    {
                        prefix.Add("DISPAS");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISPAS));
                    }
                    if (FilterSettings.isIconDISATC)
                    {
                        prefix.Add("DISATC");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISATC));
                    }
                }
                else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && imageToConvert.Width == 256 && imageToConvert.Height == 256)
                {
                    if (FilterSettings.isIconBTN_REF)
                    {
                        prefix.Add("BTN");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.BTN_REF));
                    }
                    if (FilterSettings.isIconPAS_REF)
                    {
                        prefix.Add("PAS");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.PAS_REF));
                    }
                    if (FilterSettings.isIconATC_REF)
                    {
                        prefix.Add("ATC");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.ATC_REF));
                    }
                    if (FilterSettings.isIconDISBTN_REF)
                    {
                        prefix.Add("DISBTN");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISBTN_REF));
                    }
                    if (FilterSettings.isIconDISPAS_REF)
                    {
                        prefix.Add("DISPAS");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISPAS_REF));
                    }
                    if (FilterSettings.isIconDISATC_REF)
                    {
                        prefix.Add("DISATC");
                        filteredImages.Add(filters.AddIconBorder(imageToConvert, IconTypes.DISATC_REF));
                    }
                }

                for (int i = 0; i < filteredImages.Count; i++)
                {
                    if (FilterSettings.isResized)
                    {
                        filteredImages[i].Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                    }
                    ExportSettings.prefix = prefix[i];
                    success = Convert(filteredImages[i]);
                    errorMsg = "";
                }
            }

            currentEntry++;

            return success;
        }

        private bool Convert(SixLabors.ImageSharp.Image<Rgba32> imageToConvert)
        {
            bool success = false;

            if (imageToConvert != null)
            {
                if (ExportSettings.selectedFileExtension == ImageFormats.JPG)
                    success = ConvertToJpg(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.PNG)
                    success = ConvertToPng(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.BMP)
                    success = ConvertToBmp(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.TGA)
                    success = ConvertToTga(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.DDS)
                    success = ConvertToDds(imageToConvert);
                else if (ExportSettings.selectedFileExtension == ImageFormats.BLP)
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
                if (FilterSettings.isIconBTN) iconsChecked++;
                if (FilterSettings.isIconPAS) iconsChecked++;
                if (FilterSettings.isIconATC) iconsChecked++;
                if (FilterSettings.isIconDISBTN) iconsChecked++;

                if (FilterSettings.war3IconType == War3IconType.ClassicIcon && iconsChecked <= 1) // Classic icons
                {
                    if (FilterSettings.isIconBTN) image = filters.AddIconBorder(image, IconTypes.BTN);
                    if (FilterSettings.isIconPAS) image = filters.AddIconBorder(image, IconTypes.PAS);
                    if (FilterSettings.isIconATC) image = filters.AddIconBorder(image, IconTypes.ATC);
                    if (FilterSettings.isIconDISBTN) image = filters.AddIconBorder(image, IconTypes.DISBTN);
                    if (FilterSettings.isIconDISBTN) image = filters.AddIconBorder(image, IconTypes.DISPAS);
                    if (FilterSettings.isIconDISBTN) image = filters.AddIconBorder(image, IconTypes.DISATC);
                    errorMsg = "";
                }
                else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && iconsChecked <= 1) // Reforged icons
                {
                    if (FilterSettings.isIconBTN_REF) image = filters.AddIconBorder(image, IconTypes.BTN_REF);
                    if (FilterSettings.isIconPAS_REF) image = filters.AddIconBorder(image, IconTypes.PAS_REF);
                    if (FilterSettings.isIconATC_REF) image = filters.AddIconBorder(image, IconTypes.ATC_REF);
                    if (FilterSettings.isIconDISBTN_REF) image = filters.AddIconBorder(image, IconTypes.DISBTN_REF);
                    if (FilterSettings.isIconDISBTN_REF) image = filters.AddIconBorder(image, IconTypes.DISPAS_REF);
                    if (FilterSettings.isIconDISBTN_REF) image = filters.AddIconBorder(image, IconTypes.DISATC_REF);
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
            if (ExportSettings.keepFileNames)
                path = ExportSettings.outputDir + ExportSettings.prefix + GetInputFileName(fileEntries[currentEntry]) + ExportSettings.outputFileType;
            else if (ExportSettings.isMultipleFiles)
                path = ExportSettings.outputDir + ExportSettings.prefix + ExportSettings.fileName + "_" + currentEntry + ExportSettings.outputFileType;
            else
                path = ExportSettings.outputDir + ExportSettings.prefix + ExportSettings.fileName + ExportSettings.outputFileType;

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