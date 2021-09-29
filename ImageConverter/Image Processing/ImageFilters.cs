using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Image_Processing
{
    public partial class ImageFilters
    {
        public Bitmap AddIconBorder(Bitmap source, IconTypes iconSetting)
        {
            Bitmap imageToConvert = (Bitmap)source.Clone();
            Bitmap border = null;
            int width = imageToConvert.Width;
            int height = imageToConvert.Height;


            if (FilterSettings.war3IconType == War3IconType.ClassicIcon && imageToConvert.Width == 64 && imageToConvert.Height == 64)
            {
                if (iconSetting == IconTypes.BTN)

                    border = Properties.Resources.Warcraft_W;
                else if (iconSetting == IconTypes.PAS)
                    border = Properties.Resources.Icon_Border_Passive;
                else if (iconSetting == IconTypes.ATC)
                    border = Properties.Resources.Icon_Border_Autocast;
                else if (iconSetting == IconTypes.DISBTN)
                    border = Properties.Resources.Icon_Border_Disabled;
                else if (iconSetting == IconTypes.DISPAS)
                    border = Properties.Resources.Icon_Border_Disabled;
                else if (iconSetting == IconTypes.DISATC)
                    border = Properties.Resources.Icon_Border_Disabled;
                else if (iconSetting == IconTypes.ATT)
                    border = Properties.Resources.Icon_Border_Attack;
                else if (iconSetting == IconTypes.UPG)
                    border = Properties.Resources.Icon_Border_Attack_Upgrade;

            }
            else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && imageToConvert.Width == 256 && imageToConvert.Height == 256)
            {
                if (iconSetting == IconTypes.BTN)
                    border = Properties.Resources.Reforged_Icon_Border_Button;
                else if (iconSetting == IconTypes.PAS)
                    border = Properties.Resources.Reforged_Icon_Border_Passive;
                else if (iconSetting == IconTypes.ATC)
                    border = Properties.Resources.Reforged_Icon_Border_Autocast;
                else if (iconSetting == IconTypes.DISBTN)
                    border = Properties.Resources.Reforged_Icon_Border_Disabled;
                else if (iconSetting == IconTypes.DISPAS)
                    border = Properties.Resources.Reforged_Icon_Border_Passive_Disabled;
                else if (iconSetting == IconTypes.DISATC)
                    border = Properties.Resources.Reforged_Icon_Border_Disabled;
                else if (iconSetting == IconTypes.ATT)
                    border = Properties.Resources.Reforged_Icon_Border_Attack;
                else if (iconSetting == IconTypes.UPG)
                    border = Properties.Resources.Reforged_Icon_Border_Attack_Upgrade;
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

        private void AddRegularBorder(Bitmap imageToConvert, Bitmap border, IconTypes iconSetting)
        {

            int width = imageToConvert.Width;
            int height = imageToConvert.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = imageToConvert.GetPixel(x, y);
                    byte redSource = color.R;
                    byte greenSource = color.G;
                    byte blueSource = color.B;
                    byte alphaSource = color.A;

                    // Disabled icon color saturation reduction
                    if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && (iconSetting == IconTypes.DISBTN || iconSetting == IconTypes.DISPAS || iconSetting == IconTypes.DISATC))
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

                    Color colorBorder = border.GetPixel(x, y);

                    byte redBorder = colorBorder.R;
                    byte greenBorder = colorBorder.G;
                    byte blueBorder = colorBorder.B;
                    byte alphaBorder = colorBorder.A;

                    if (alphaBorder != 0)
                    {
                        float alphaPercent = (float)alphaBorder / 255;

                        byte redBlended = (byte)((int)redSource * (1 - alphaPercent) + (redBorder * alphaPercent));
                        byte greenBlended = (byte)((int)greenSource * (1 - alphaPercent) + (greenBorder * alphaPercent));
                        byte blueBlended = (byte)((int)blueSource * (1 - alphaPercent) + (blueBorder * alphaPercent));

                        imageToConvert.SetPixel(x, y, Color.FromArgb(255, redBlended, greenBlended, blueBlended));
                    }
                }
            }
        }

        private Bitmap AddATTUPGBorders(Bitmap imageToConvert, Bitmap border, IconTypes iconSetting)
        {
            int width = imageToConvert.Width;
            int height = imageToConvert.Height;
            Bitmap canvas = new Bitmap(width, height);

            if(width == 256 && height == 256) {
                //imageToConvert.Mutate(i => i.Resize(222, 222)); // VERY IMPORTANT TO FIX LATER
            }
            else if(width == 64 && height == 64){
                //imageToConvert.Mutate(i => i.Resize(56, 56)); // VERY IMPORTANT TO FIX LATER
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    Color color = imageToConvert.GetPixel(x, y);

                    if (x < imageToConvert.Width && y < imageToConvert.Height)
                    {
                        canvas.SetPixel(x, y, color);
                    }

                    byte redSource = color.R;
                    byte greenSource = color.G;
                    byte blueSource = color.B;
                    byte alphaSource = color.A;

                    Color colorBorder = border.GetPixel(x, y);

                    byte redBorder = colorBorder.R;
                    byte greenBorder = colorBorder.G;
                    byte blueBorder = colorBorder.B;
                    byte alphaBorder = colorBorder.A;

                    // The outer transparent part of the actual applied border is red or (255,0,0), so we make that part fully transparent.
                    // However, there is an unknown error when displaying the final icon. The red color seems to go down to 217 in the corners and sides?
                    // This is compensated for here.
                    if (colorBorder.R > 216 && colorBorder.G == 0 && colorBorder.B == 0)
                    {
                        canvas.SetPixel(x, y, Color.FromArgb(0,0,0,0)); // The border's red color becomes 100% transparent.
                        //canvas[x, y] = new Rgba32(0,0,0,0); // The border's red color becomes 100% transparent.
                    }
                    else if (alphaBorder != 0)
                    {
                        float alphaPercent = (float)alphaBorder / 255;

                        byte redBlended = (byte)((int)redSource * (1 - alphaPercent) + (redBorder * alphaPercent));
                        byte greenBlended = (byte)((int)greenSource * (1 - alphaPercent) + (greenBorder * alphaPercent));
                        byte blueBlended = (byte)((int)blueSource * (1 - alphaPercent) + (blueBorder * alphaPercent));

                        //canvas[x, y] = new Rgba32(redBlended, greenBlended, blueBlended);
                        canvas.SetPixel(x, y, Color.FromArgb(255, redBlended, greenBlended, blueBlended));
                    }
                }
            }

            return canvas;
        }
    }
}
