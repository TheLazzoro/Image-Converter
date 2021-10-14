using ImageConverter.IO;
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
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsTrue(isSuccess, Converter.errorMsg);
        }

        [TestMethod]
        public void FileWritePNG()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.PNG;
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsTrue(isSuccess, Converter.errorMsg);
        }

        [TestMethod]
        public void FileWriteBMP()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.BMP;
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsTrue(isSuccess, Converter.errorMsg);
        }

        [TestMethod]
        public void FileWriteTGA()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.TGA;
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsTrue(isSuccess, Converter.errorMsg);
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
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsTrue(isSuccess, Converter.errorMsg);
        }

        [TestMethod]
        public void FileWriteWEBP()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ImageToConvert.png";
            ExportSettings.selectedFileExtension = ImageFormats.WEBP;
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsTrue(isSuccess, Converter.errorMsg);
        }

        [TestMethod]
        public void FileAttemptWriteInvalidFile()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\notAnImage.txt";
            ExportSettings.selectedFileExtension = ImageFormats.DDS;
            Converter.InitConverter();

            bool isSuccess = Converter.Convert(filePath);

            Assert.IsFalse(isSuccess, Converter.errorMsg);
        }
    }
}
