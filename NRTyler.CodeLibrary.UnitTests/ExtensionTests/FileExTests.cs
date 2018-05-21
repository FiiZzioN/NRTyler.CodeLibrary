// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 05-21-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 05-21-2018
// 
// License          : MIT License
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.UnitTests.ExtensionTests
{
    [TestClass]
    public class FileExTests
    {
        [TestInitialize]
        public void Intialize()
        {
            var currentLocation = Environment.CurrentDirectory;
            var filePath        = $"{currentLocation}/ItemsUsedInTests/FileEx/TestFile";

            FilePathWithExtension   = $"{currentLocation}/{filePath}.xml";
            FilePathWithNoExtension = $"{currentLocation}/{filePath}";
        }

        protected string FilePathWithExtension { get; set; }
        protected string FilePathWithNoExtension { get; set; }
        
        [TestMethod]
        public void CheckFileWithExtension()
        {
            var result = FileEx.CheckFileExtension(FilePathWithExtension, ".xml");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckFileWithNoExtension()
        {
            var result = FileEx.CheckFileExtension(FilePathWithNoExtension, ".xml");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckFileAgainstMultipleExtensions()
        {
            var acceptableExtenesions = new [] {".png", ".xml"};

            var currentLocation = Environment.CurrentDirectory;
            var imageFilePath   = $"{currentLocation}/TestFileTwo.png";

            var resultXML = FileEx.CheckFileExtension(FilePathWithExtension, acceptableExtenesions);
            var resultPNG = FileEx.CheckFileExtension(imageFilePath, acceptableExtenesions);

            Assert.IsTrue(resultXML, "XML Failed");
            Assert.IsTrue(resultPNG, "PNG Failed");
        }
    }
}