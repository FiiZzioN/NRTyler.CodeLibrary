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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.UnitTests.ExtensionTests
{
    [TestClass]
    public class PathExTests
    {
        [TestMethod]
        public void ReturnTrue()
        {
            Assert.IsTrue(PathEx.HasInvalidCharacters(@"C:\Users\Nick\AppData\Roaming\Microsoft<>"));
        }

        [TestMethod]
        public void ReturnFalse()
        {
            Assert.IsFalse(PathEx.HasInvalidCharacters(@"C:\Users\Nick\AppData\Roaming\Microsoft"));
        }
    }
}