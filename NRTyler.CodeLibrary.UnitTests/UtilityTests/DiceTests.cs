// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-07-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-07-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
	[TestClass]
	public class DiceTests
	{
		[TestMethod]
		public void TestChoiceRange()
		{
			//Arrange
			var rollReturns = new int[500];

			for (var i = 0; i < rollReturns.Length; i++)
			{
				var choices    = NumericGenerator.GenerateValue(2, 256);
				rollReturns[i] = Dice.Roll(choices);
			}

			var expected         = UnitTestResult.Passed;
			var verificationTool = new VerificationTool<int>(0, 256, rollReturns);

			//Act
			var actual = verificationTool.TestResult;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void CheckException()
		{
			//Arrange
			Dice.Roll(1);

			//Act

			//Assert
			Assert.IsTrue(false);
		}
	}
}