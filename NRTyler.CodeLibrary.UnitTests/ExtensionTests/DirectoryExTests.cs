// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 10-09-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-09-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Attributes;
using NRTyler.CodeLibrary.Extensions;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.ExtensionTests
{
    [TestClass]
    public class DirectoryExTests
    {
        private static string Path { get; } = $"{TestAid.DocumentTestLocation}/DirectoryExTests";

        [TestInitialize]
        public void Setup()
        {
            // Make sure the test folder is deleted before the test takes place to ensure the method is actually functioning. 
            // We don't want the test to keep passing just because the folder already existed due to previous tests...
            TestAid.RemoveDirectoryFromPreviousTest(Path);
        }

        [TestMethod]
        public void DirectoryCreation()
        {
            DirectoryEx.CreateDirectoryIfNonexistent(Path);

            // Check if it was created.
            Assert.IsTrue(Directory.Exists(Path));
        }

        [TestMethod]
        [ExpectedExceptionMsg(typeof(ArgumentException), "The path provided contained an invalid character. The invalid character was: '<'")]
        public void CatchSingleInvalidPathCharacter()
        {
            DirectoryEx.CreateDirectoryIfNonexistent($"{Path}/<Tests");
        }

        [TestMethod]
        [ExpectedExceptionMsg(typeof(ArgumentException), "The path provided contained invalid characters. The invalid characters were: '<', '>'")]
        public void CatchMultipleInvalidPathCharacters()
        {
            DirectoryEx.CreateDirectoryIfNonexistent($"{Path}/<Tests>");
        }

        [TestMethod]
        public void CheckDirectoryInfoEquality()
        {
            // Arrange
            var directoryExDirectoryInfo = DirectoryEx.CreateDirectoryIfNonexistent(Path);
            var normalDirectoryInfo      = new DirectoryInfo(Path);

            // Assert
            Assert.IsTrue(normalDirectoryInfo.CompareObject(directoryExDirectoryInfo));
        }
    }
}