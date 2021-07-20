using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Converter.Image_Processing
{
    public partial class ImageFilters
    {
        public Image<Rgba32> AddIconBorder(Image<Rgba32> source, IconTypes iconSetting)
        {
            Image<Rgba32> imageToConvert = source.Clone();
            Image<Rgba32> border = null;
            int width = imageToConvert.Width;
            int height = imageToConvert.Height;


            if (FilterSettings.war3IconType == War3IconType.ClassicIcon && imageToConvert.Width == 64 && imageToConvert.Height == 64)
            {
                if (iconSetting == IconTypes.BTN)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border);
                else if (iconSetting == IconTypes.PAS)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Passive);
                else if (iconSetting == IconTypes.ATC)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Autocast);
                else if (iconSetting == IconTypes.DISBTN)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Disabled);
                else if (iconSetting == IconTypes.DISPAS)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Disabled);
                else if (iconSetting == IconTypes.DISATC)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Disabled);
                else if (iconSetting == IconTypes.ATT) 
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Attack);
                else if (iconSetting == IconTypes.UPG)
                    border = Image<Rgba32>.Load(Properties.Resources.Icon_Border_Attack_Upgrade);

            }
            else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && imageToConvert.Width == 256 && imageToConvert.Height == 256)
            {
                if (iconSetting == IconTypes.BTN)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Button);
                if (iconSetting == IconTypes.PAS)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Passive);
                if (iconSetting == IconTypes.ATC)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Autocast);
                if (iconSetting == IconTypes.DISBTN)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Disabled);
                if (iconSetting == IconTypes.DISPAS)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Passive_Disabled);
                if (iconSetting == IconTypes.DISATC)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Disabled);
                else if (iconSetting == IconTypes.ATT)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Attack);
                else if (iconSetting == IconTypes.UPG)
                    border = Image<Rgba32>.Load(Properties.Resources.Reforged_Icon_Border_Attack_Upgrade);
            }

            if (border != null)
            {
                if (iconSetting != IconTypes.ATT && iconSetting != IconTypes.UPG)
                {
                    AddRegularBorder(imageToConvert, border, iconSetting);
                }
                else
                {
                    imageToConvert = AddATTUPGBorders(imageToConvert, border, iconSetting);
                }
            }

            return imageToConvert;
        }

        private void AddRegularBorder(Image<Rgba32> imageToConvert, Image<Rgba32> border, IconTypes iconSetting)
        {

            int width = imageToConvert.Width;
            int height = imageToConvert.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    byte redSource = imageToConvert[x, y].R;
                    byte greenSource = imageToConvert[x, y].G;
                    byte blueSource = imageToConvert[x, y].B;
                    byte alphaSource = imageToConvert[x, y].A;

                    if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && iconSetting == IconTypes.DISBTN || iconSetting == IconTypes.DISPAS || iconSetting == IconTypes.DISATC) // Disabled icon color saturation reduction
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

        private Image<Rgba32> AddATTUPGBorders(Image<Rgba32> imageToConvert, Image<Rgba32> border, IconTypes iconSetting)
        {

            int width = imageToConvert.Width;
            int height = imageToConvert.Height;
            Image<Rgba32> canvas = new Image<Rgba32>(width, height);

            if(width == 256 && height == 256) 
                imageToConvert.Mutate(i => i.Resize(222, 222));
            else if(width == 64 && height == 64)
                imageToConvert.Mutate(i => i.Resize(56, 56));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {

                    if (x < imageToConvert.Width && y < imageToConvert.Height)
                    {
                        canvas[x, y] = imageToConvert[x, y];
                    }

                    byte redSource = canvas[x, y].R;
                    byte greenSource = canvas[x, y].G;
                    byte blueSource = canvas[x, y].B;
                    byte alphaSource = canvas[x, y].A;

                    byte redBorder = border[x, y].R;
                    byte greenBorder = border[x, y].G;
                    byte blueBorder = border[x, y].B;
                    byte alphaBorder = border[x, y].A;

                    if (border[x, y].R > 216 && border[x, y].G == 0 && border[x, y].B == 0) // Detects red on the border (Includes an unknown margin of error. The red color seems to go lower in the corners and sides?)
                    {
                        canvas[x, y] = new Rgba32(0,0,0,0); // the border's red color becomes 100% transparent
                    }
                    else if (alphaBorder != 0)
                    {
                        float alphaPercent = (float)alphaBorder / 255;

                        byte redBlended = (byte)((int)redSource * (1 - alphaPercent) + (redBorder * alphaPercent));
                        byte greenBlended = (byte)((int)greenSource * (1 - alphaPercent) + (greenBorder * alphaPercent));
                        byte blueBlended = (byte)((int)blueSource * (1 - alphaPercent) + (blueBorder * alphaPercent));

                        canvas[x, y] = new Rgba32(redBlended, greenBlended, blueBlended);
                    }
                }
            }

            return canvas;
        }
    }
}
