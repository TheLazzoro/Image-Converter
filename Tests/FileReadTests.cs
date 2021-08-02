using Image_Converter.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace Image_Converter.Tests
{
    [TestClass]
    public class FileReadTests
    {
        [TestMethod]
        public void FileReadJPG()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\Power.jpg";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNotNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadPNG()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\LivingBomb.png";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNotNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadDDS()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\city_cliffdirt.dds";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNotNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadBLP1JPEG()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ATCABTNCurse2.blp";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNotNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadBLP1Direct()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\ATCCircleofRenewal.blp";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNotNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadBLP2()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\6bf_blackrock_nova.blp";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNotNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadTXT()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "TestImages\\notAnImage.txt";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNull(image, reader.errorMsg);
        }

        [TestMethod]
        public void FileReadNonExisting()
        {
            Reader reader = new Reader();
            string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "none";
            Image<Rgba32> image = reader.ReadFile(filePath);

            Assert.IsNull(image, reader.errorMsg);
        }
    }
}
