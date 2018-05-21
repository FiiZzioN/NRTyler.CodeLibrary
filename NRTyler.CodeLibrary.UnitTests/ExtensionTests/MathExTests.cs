// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 03-29-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 03-29-2018
// 
// License          : MIT License
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.UnitTests.ExtensionTests
{
    [TestClass]
    public class MathExTests
    {
        [TestMethod]
        public void StandardGravity()
        {
            //Arrange
            var expected = MathEx.ɡ;

            //Act
            var actual = 9.80665;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SpeedOfLight()
        {
            //Arrange
            var expected = MathEx.c;

            //Act
            var actual = 299792458;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InternationalStandardAtmosphere()
        {
            //Arrange
            var expected = MathEx.atm;

            //Act
            var actual = 101325;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}