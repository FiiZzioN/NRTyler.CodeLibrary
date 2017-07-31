// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-31-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests
{
    /// <summary>
    /// <see cref="NumericGeneratorTests"/> holds all unit tests relating to the <see cref="NumericGenerator"/> class' methods.
    /// </summary>
    [TestClass]
    public class NumericGeneratorTests
    {
        #region Base Tests

        [TestMethod]
        public void NumericGenerator_ValueFailed()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(-5, 5);
            var value       = 10;

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void NumericGenerator_ArrayFailed()
        {
            //Arrange  
            var paramBundle = new ParameterBundle<int>(-200, 200, 200);

            var array       = NumericGenerator.GenerateArray(paramBundle);
            array[0]        = 500;

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, array);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        #endregion

        #region Integers

        [TestMethod]
        public void NumericGenerator_IntegerValue()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(-5, 5);
            var value       = NumericGenerator.GenerateValue(paramBundle);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumericGenerator_IntegerArray()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(-86, 500, 500);
            var array       = NumericGenerator.GenerateArray(paramBundle);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Doubles

        [TestMethod]
        public void NumericGenerator_DoubleValue()
        {
            //Arrange
            var paramBundle = new ParameterBundle<double>(90, 90.5687);
            var value       = NumericGenerator.GenerateValue(paramBundle);

            var expected    = UnitTestResult.Passed;
            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumericGenerator_DoubleArray()
        {
            //Arrange
            var paramBundle = new ParameterBundle<double>(-20.654, 10.92, 500);
            var array       = NumericGenerator.GenerateArray(paramBundle);

            var expected    = UnitTestResult.Passed;
            //Act
            var actual      = VerifyArray(paramBundle, array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Bytes

        [TestMethod]
        public void NumericGenerator_ByteValue()
        {
            //Arrange
            var paramBundle = new ParameterBundle<byte>(34, 73);
            var value       = NumericGenerator.GenerateValue(paramBundle);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumericGenerator_ByteArray()
        {
            //Arrange
            var paramBundle = new ParameterBundle<byte>(14, 185, 500);
            var array       = NumericGenerator.GenerateArray(paramBundle);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, array);

            //Assert
            Assert.AreEqual(expected, actual);
        }

		#endregion

		#region Tandem

        [TestMethod]
        public void NumericGenerator_TandemValue()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(-68, 72, 500);
            var tuple       = NumericGenerator.TandemGeneration(paramBundle);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, tuple.Item1);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumericGenerator_TandemArray()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(-68, 72, 500);
            var tuple       = NumericGenerator.TandemGeneration(paramBundle);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, tuple.Item2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

		#endregion

		#region Exceptions


		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void NumericGenerator_MinGreaterThanMax()
		{
			//Arrange
			var valueOne    = 10 - 20;

			var paramBundle = new ParameterBundle<byte>((byte)valueOne, 185, 500);
			var array       = NumericGenerator.GenerateArray(paramBundle);

			var expected    = UnitTestResult.Passed;

			//Act
			var actual      = VerifyArray(paramBundle, array);

			//Assert
			Assert.AreEqual(expected, actual);
		}

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentOutOfRangeException))]
	    public void NumericGenerator_ArraySizeException()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<int>(-3, 185, -1);
		    var array       = NumericGenerator.GenerateArray(-3, 185, -1);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentException))]
	    public void NumericGenerator_InvalidType()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<uint>(85, 187);
		    var value = NumericGenerator.GenerateValue(paramBundle);

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

		#endregion


		#region VerifyResults

		private static UnitTestResult VerifyArray<T>(ParameterBundle<T> paramBundle, T[] arrayToVerify)
        {
            var arrayVerification = new VerificationTool<T>(paramBundle, arrayToVerify);

            return arrayVerification.TestResult;
        }

        private static UnitTestResult VerifyValue<T>(ParameterBundle<T> paramBundle, T valueToVerify)
        {
            var valueVerification = new VerificationTool<T>(paramBundle, valueToVerify);

            return valueVerification.TestResult;
        }
        
        #endregion
    }
}
