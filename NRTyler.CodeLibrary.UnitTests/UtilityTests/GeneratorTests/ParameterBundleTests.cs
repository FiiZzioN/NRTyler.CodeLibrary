// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-01-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests.GeneratorTests
{
	[TestClass]
	public class ParameterBundleTests
	{
		[TestMethod]
		public void ConstructorTestOne()
		{
			//Arrange
			var paramBundle = new ParameterBundle<int>(500);
			var expected = new List<int> { 0, 500, 0};

			//Act
			var actual = new List<int>
			{
				paramBundle.MinValue,
				paramBundle.MaxValue,
				paramBundle.ArraySize
			};

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ConstructorTestTwo()
		{
			//Arrange
			var paramBundle = new ParameterBundle<double>(-2500, 95000);
			var expected = new List<double> { -2500, 95000, 0 };

			//Act
			var actual = new List<double>
			{
				paramBundle.MinValue,
				paramBundle.MaxValue,
				paramBundle.ArraySize
			};

			//Assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ConstructorTestThree()
		{
			//Arrange
			var paramBundle       = new ParameterBundle<byte>(130, 240, 30);
			var expectedValues    = new List<byte> { 130, 240 };
			var expectedArraySize = 30;

			//Act
			var actualArraySize = paramBundle.ArraySize;
			var actualValues    = new List<byte>
			{
				paramBundle.MinValue,
				paramBundle.MaxValue
			};
            
			//Assert
			CollectionAssert.AreEqual(expectedValues, actualValues);
			Assert.AreEqual(expectedArraySize, actualArraySize);
		}
	}
}