using ImageConverter.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Image_Converter.Tests
{
    [TestClass]
    public class FileReadTests
    {
        [TestMethod]
        public void FileReadJPG()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\Power.jpg";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNotNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadPNG()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\LivingBomb.png";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNotNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadDDS()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\city_cliffdirt.dds";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNotNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadBLP1JPEG()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ATCABTNCurse2.blp";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNotNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadBLP1Direct()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ATCCircleofRenewal.blp";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNotNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadBLP2()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\6bf_blackrock_nova.blp";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNotNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadTXT()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\notAnImage.txt";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNull(image, Reader.errorMsg);
        }

        [TestMethod]
        public void FileReadNonExisting()
        {
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "none";
            Reader.ReadFile(filePath);
            Bitmap image = Reader.image;

            Assert.IsNull(image, Reader.errorMsg);
        }
    }
}
