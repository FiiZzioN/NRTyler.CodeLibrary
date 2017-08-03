﻿// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-03-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-03-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Assistants;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests
{
	[TestClass]
	public class VerificationToolTests
	{
		[TestMethod]
		public void ConstructorTestOne() // Value Test
		{
			//Arrange
			var paramBundle = new ParameterBundle<int>(-3, 10, 5);
			var tool        = new VerificationTool<int>(paramBundle, 3);
			var list        = new List<int>
			{
				tool.MinValue,
				tool.MaxValue,
				tool.ValueToVerify
			};

			var expectedValues = new List<int> { -3, 10, 3};
			var expectedResult = UnitTestResult.Passed;

			//Act
			var actualValues = list;
			var actualResult = tool.TestResult;

			//Assert
			CollectionAssert.AreEqual(expectedValues, actualValues);
			          Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void ConstructorTestTwo() // Array Test
		{
			//Arrange

			// Primary values that are to be used a lot.
			var range          = new Tuple<double, double, int>(-50.3, 2036.34, 30);

			// Generate a usable array for the test.
			var array          = NumericGenerator.GenerateArray(range.Item1, range.Item2, range.Item3);

			var paramBundle    = new ParameterBundle<double>(range.Item1, range.Item2, range.Item3);
			var tool           = new VerificationTool<double>(paramBundle, array);

			var expectedArray  = array;
			var expectedValues = new List<double> { range.Item1, range.Item2 };
			var expectedResult = UnitTestResult.Passed;

			//Act
			var actualArray  = tool.ArrayToVerify;
			var actualValues = new List<double> { tool.MinValue, tool.MaxValue };
			var actualResult = tool.TestResult;

			UnitTestAlert.CollectionAlert(expectedValues, actualValues, "Generator constraints don't match!");
			UnitTestAlert.CollectionAlert(expectedArray, actualArray, "Arrays don't match!");

			//Assert
			Assert.AreEqual(expectedArray, actualArray);
			CollectionAssert.AreEqual(expectedValues, actualValues);
			          Assert.AreEqual(expectedResult, actualResult);
		}
	}
}