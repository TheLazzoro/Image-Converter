﻿using Image_Converter.Image_Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Image_Converter.IO
{
    public class Preview
    {
        public string errorMsg = "";
        public string fileSizeString = "";

        public Image<Rgba32> RenderPreview(String filePath)
        {
            Reader reader = new Reader();
            fileSizeString = reader.GetFileSizeString(filePath);
            SixLabors.ImageSharp.Image<Rgba32> image = reader.ReadFile(filePath);
            if (image != null)
            {
                ImageFilters filters = new ImageFilters();
                int iconsChecked = 0;
                if (FilterSettings.isIconBTN) iconsChecked++;
                if (FilterSettings.isIconPAS) iconsChecked++;
                if (FilterSettings.isIconATC) iconsChecked++;
                if (FilterSettings.isIconDISBTN) iconsChecked++;
                if (FilterSettings.isIconDISPAS) iconsChecked++;
                if (FilterSettings.isIconDISATC) iconsChecked++;
                if (FilterSettings.isIconATT) iconsChecked++;
                if (FilterSettings.isIconUPG) iconsChecked++;

                if (iconsChecked == 1)
                {
                    if (FilterSettings.isIconBTN) image = filters.AddIconBorder(image, IconTypes.BTN);
                    if (FilterSettings.isIconPAS) image = filters.AddIconBorder(image, IconTypes.PAS);
                    if (FilterSettings.isIconATC) image = filters.AddIconBorder(image, IconTypes.ATC);
                    if (FilterSettings.isIconDISBTN) image = filters.AddIconBorder(image, IconTypes.DISBTN);
                    if (FilterSettings.isIconDISPAS) image = filters.AddIconBorder(image, IconTypes.DISPAS);
                    if (FilterSettings.isIconDISATC) image = filters.AddIconBorder(image, IconTypes.DISATC);
                    if (FilterSettings.isIconATT) image = filters.AddIconBorder(image, IconTypes.ATT);
                    if (FilterSettings.isIconUPG) image = filters.AddIconBorder(image, IconTypes.UPG);
                    errorMsg = "";
                }
                else
                {
                    if (FilterSettings.war3IconType == War3IconType.ClassicIcon && iconsChecked > 1 && image.Width == 64 && image.Height == 64)
                        errorMsg = "Cannot display multiple icon filters";
                    else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && iconsChecked > 1 && image.Width == 256 && image.Height == 256)
                        errorMsg = "Cannot display multiple icon filters";
                    else
                        errorMsg = "";

                }

                if (FilterSettings.isResized)
                {
                    image.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                }
            }
            else
            {
                errorMsg = reader.errorMsg;
            }

            return image;
        }
    }
}
