using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Converter.Image_Processing
{
    public partial class ImageFilters
    {

        public SixLabors.ImageSharp.Image<Rgba32> AddIconBorder(SixLabors.ImageSharp.Image<Rgba32> source, IconSettings iconSetting)
        {
            SixLabors.ImageSharp.Image<Rgba32> imageToConvert = source.Clone();
            SixLabors.ImageSharp.Image<Rgba32> border = null;
            int width = imageToConvert.Width;
            int height = imageToConvert.Height;

            if (FilterSettings.war3IconType == War3IconType.ClassicIcon && imageToConvert.Width == 64 && imageToConvert.Height == 64)
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
            else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && imageToConvert.Width == 256 && imageToConvert.Height == 256)
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

                            // 55% greyscale
                            double redChange = redDiff * 0.55;
                            double greenChange = greenDiff * 0.55;
                            double blueChange = blueDiff * 0.55;

                            int redInt = greyscale - (int)redChange;
                            int greenInt = greyscale - (int)greenChange;
                            int blueInt = greyscale - (int)blueChange;

                            // Further desaturation towards white (5%)
                            redInt = redInt + (int)((255 - redInt) * 0.05);
                            greenInt = greenInt + (int)((255 - greenInt) * 0.05);
                            blueInt = blueInt + (int)((255 - blueInt) * 0.05);

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
    }
}
