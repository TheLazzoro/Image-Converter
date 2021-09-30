using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageConverter
{
    public static class Utility
    {
        public static string GetFileNameAndExtension(string filePath)
        {
            string fileName = "";

            char cCurrent;
            int sub = 0;
            bool start = true;
            bool end = false;
            while (!end && filePath.Length > sub)
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

        public static string GetFileExtension(String filePath)
        {
            string fileExtension = "";

            char cCurrent;
            int sub = 0;
            bool end = false;
            while (!end && filePath.Length > sub)
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
    }
}
