// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-01-2017
//
// License          : GNU General Public License v3.0
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

			if (paramBundle.ArraySize != expectedArraySize)
				Console.WriteLine("ArraySizes don't match!");

			CheckListEquality(expectedValues, actualValues);

			//Assert
			CollectionAssert.AreEqual(expectedValues, actualValues);
			Assert.AreEqual(expectedArraySize, actualArraySize);
		}

		private void CheckListEquality<T>(List<T> valueOne, List<T> valueTwo) where T : IComparable<T>
		{
			if (valueOne.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(valueOne));
			if (valueTwo.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(valueTwo));

			for (var i = 0; i < valueOne.Count; i++)
			{
				if (valueOne[i].CompareTo(valueTwo[i]) < 0)
				{
					Console.WriteLine("Values don't match!");
					break;
				}
			}
		}
	}
}