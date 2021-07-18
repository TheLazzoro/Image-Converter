using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Image_Converter
{
    public partial class Shared
    {
        public String GetInputFileNameAndExtension(String filePath)
        {
            String fileName = "";

            char cCurrent;
            int sub = 0;
            bool start = true;
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

                sub++;
            }

            char[] charArray = fileName.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray);
        }

        public String GetFileSizeString(Stream stream)
        {
            long sizeBytes = stream.Length;
            String text = sizeBytes.ToString();
            int textLength = text.Length;
            String howBigBytes = "bytes";

            if (sizeBytes > 1000)
            {
                howBigBytes = "KB";
                sizeBytes = sizeBytes / 1000;
                text = sizeBytes.ToString();
                textLength = text.Length;
            }

            String finalText = "";
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

            char[] charArray = finalText.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray) + " " + howBigBytes;
        }
    }
}
