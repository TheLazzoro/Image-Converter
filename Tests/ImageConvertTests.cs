﻿using Image_Converter.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace Image_Converter.Tests
{
    [TestClass]
    public class ImageConvertTests
    {
        [TestMethod]
        public void FileWriteJPG()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.JPG;
            Converter converter = new Converter();
            converter.fileEntries = new string[] { filePath };

            bool isSuccess = converter.ConvertWithFilters();

            Assert.IsTrue(isSuccess, converter.errorMsg);
        }

        [TestMethod]
        public void FileWritePNG()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.PNG;
            Converter converter = new Converter();

            converter.fileEntries = new string[] { filePath };

            bool isSuccess = converter.ConvertWithFilters();

            Assert.IsTrue(isSuccess, converter.errorMsg);
        }

        [TestMethod]
        public void FileWriteBMP()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.BMP;
            Converter converter = new Converter();
            converter.fileEntries = new string[] { filePath };

            bool isSuccess = converter.ConvertWithFilters();

            Assert.IsTrue(isSuccess, converter.errorMsg);
        }

        [TestMethod]
        public void FileWriteTGA()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.TGA;
            Converter converter = new Converter();
            converter.fileEntries = new string[] { filePath };

            bool isSuccess = converter.ConvertWithFilters();

            Assert.IsTrue(isSuccess, converter.errorMsg);
        }

        /*
         * This test passes but is very questionable.
         * We NEED to set the ExportSettings to DDS conversion before we instanciate the Converter object.
         * There is no exception-handling if someone was to do the opposite order.
         */
        [TestMethod]
        public void FileWriteDDS()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.DDS;
            Converter converter = new Converter();
            converter.fileEntries = new string[] { filePath };

            bool isSuccess = converter.ConvertWithFilters();

            Assert.IsTrue(isSuccess, converter.errorMsg);
        }

        [TestMethod]
        public void FileAttemptWriteInvalidFile()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\notAnImage.txt";
            ExportSettings.selectedFileExtension = ImageFormats.DDS;
            Converter converter = new Converter();
            converter.fileEntries = new string[] { filePath };

            bool isSuccess = converter.ConvertWithFilters();

            Assert.IsFalse(isSuccess, converter.errorMsg);
        }
    }
}