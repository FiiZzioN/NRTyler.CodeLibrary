// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-10-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-10-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Attributes;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
	[TestClass]
	public class TypeValidatorTests
	{
		[TestMethod]
		public void ValidateType()
		{
			//Arrange
			var list = new List<Type> { typeof(int), typeof(byte) };

			byte testValue = 255;

			TypeValidator.ValidateType(list, testValue.GetType());

			var expected = true;

			//Act
			var actual = TypeValidator.CorrectType;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedExceptionMsg(typeof(ArgumentException), "This is a test message")]
		public void ValidateTypeCustomMessage()
		{
			//Arrange
			var list = new List<Type> { typeof(int), typeof(double)};

			byte testValue = 255;

			TypeValidator.ValidateType(list, testValue.GetType(), "This is a test message");

			//Act

			//Assert
			
		}
	}
}