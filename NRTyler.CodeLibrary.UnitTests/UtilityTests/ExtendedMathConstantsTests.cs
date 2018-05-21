// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-13-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-13-2017
//
// License          : MIT License
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
    [TestClass]
	public class ExtendedMathConstantsTests
	{
		[TestMethod]
		public void StandardGravity()
		{
			//Arrange
			var expected = ExtendedMathConstants.ɡ;

			//Act
			var actual = 9.80665;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SpeedOfLight()
		{
			//Arrange
			var expected = ExtendedMathConstants.c;

			//Act
			var actual = 299792458;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InternationalStandardAtmosphere()
		{
			//Arrange
			var expected = ExtendedMathConstants.atm;

			//Act
			var actual = 101325;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
