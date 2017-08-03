// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-03-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests.GeneratorTests
{
    /// <summary>
    /// <see cref="NumericGeneratorTests"/> holds all unit tests relating to the <see cref="NumericGenerator"/> class' methods.
    /// </summary>
    [TestClass]
    public class NumericGeneratorTests
    {
		#region Base Tests

		[TestMethod]
        public void ValueFailed()
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
        public void ArrayFailed()
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

	    #region IntergerOverloads

	    [TestMethod]
	    public void IntegerValueOverloadOne()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<int>(0, Int32.MaxValue);
		    var value       = NumericGenerator.GenerateValue<int>();

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void IntegerValueOverloadTwo()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<int>(Int32.MinValue, Int32.MaxValue);
		    var value       = NumericGenerator.GenerateValue(paramBundle.MinValue, paramBundle.MaxValue);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

		[TestMethod]
		public void IntegerArrayOverloadOne()
		{
			//Arrange
			var paramBundle = new ParameterBundle<int>(0, Int32.MaxValue, 30);
			var array       = NumericGenerator.GenerateArray<int>(paramBundle.ArraySize);

			var expected    = UnitTestResult.Passed;

			//Act
			var actual      = VerifyArray(paramBundle, array);

			//Assert
			Assert.AreEqual(expected, actual);
		}

	    [TestMethod]
	    public void IntegerArrayOverloadTwo()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<int>(Int32.MinValue, Int32.MaxValue, 30);
		    var array       = NumericGenerator.GenerateArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

		#endregion

		[TestMethod]
        public void GenerateIntegerArray()
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

	    [TestMethod]
	    public void GenerateIntegerValue()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<int>(-5, 5);
		    var value = NumericGenerator.GenerateValue(paramBundle);

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

		#endregion

		#region Doubles

	    #region DoubleOverloads

	    [TestMethod]
	    public void DoubleValueOverloadOne()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<double>(0, Double.MaxValue);
		    var value = NumericGenerator.GenerateValue<double>();

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void DoubleValueOverloadTwo()
	    {
			//Arrange
		    var paramBundle = new ParameterBundle<double>(Double.MinValue, Double.MaxValue);
			var value = NumericGenerator.GenerateValue(paramBundle.MinValue, paramBundle.MaxValue);

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void DoubleArrayOverloadOne()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<double>(0, Double.MaxValue, 30);
		    var array = NumericGenerator.GenerateArray<double>(paramBundle.ArraySize);

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void DoubleArrayOverloadTwo()
	    {
			//Arrange
		    var paramBundle = new ParameterBundle<double>(Double.MinValue, Double.MaxValue, 30);
			var array = NumericGenerator.GenerateArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    #endregion

		[TestMethod]
        public void GenerateDoubleValue()
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
        public void GenerateDoubleArray()
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

		#region ByteOverloads

	    [TestMethod]
	    public void ByteValueOverloadOne()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<byte>(0, Byte.MaxValue);
		    var value       = NumericGenerator.GenerateValue<byte>();

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void ByteValueOverloadTwo()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<byte>(Byte.MinValue, Byte.MaxValue);
		    var value       = NumericGenerator.GenerateValue(paramBundle.MinValue, paramBundle.MaxValue);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void ByteArrayOverloadOne()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<byte>(0, Byte.MaxValue, 30);
		    var array       = NumericGenerator.GenerateArray<byte>(paramBundle.ArraySize);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    public void ByteArrayOverloadTwo()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<byte>(Byte.MinValue, Byte.MaxValue, 30);
		    var array       = NumericGenerator.GenerateArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    #endregion

		[TestMethod]
        public void GenerateByteValue()
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
        public void GenerateByteArray()
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
        public void GenerateTandemValue()
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
        public void GenerateTandemArray()
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
		public void MinGreaterThanMax()
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
	    public void ArraySizeException()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<int>(-3, 185, -1);
		    var array       = NumericGenerator.GenerateArray(paramBundle);

		    var expected    = UnitTestResult.Passed;

		    //Act
		    var actual      = VerifyArray(paramBundle, array);

		    //Assert
		    Assert.AreEqual(expected, actual);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentException))]
	    public void InvalidType()
	    {
		    //Arrange
		    var paramBundle = new ParameterBundle<decimal>(85, 187);
		    var value = NumericGenerator.GenerateValue(paramBundle);

		    var expected = UnitTestResult.Passed;

		    //Act
		    var actual = VerifyValue(paramBundle, value);

		    //Assert
		    Assert.AreEqual(expected, actual);
		    Assert.AreEqual(expected, actual);

		}

		#endregion


		#region VerifyResults

		/// <summary>
		/// Verifies that the array is within the bounds of its minimum and maximum values.
		/// </summary>
		/// <typeparam name="T">The type of the array</typeparam>
		/// <param name="paramBundle">The parameter bundle.</param>
		/// <param name="arrayToVerify">The array to verify.</param>
		/// <returns>UnitTestResult.</returns>
		private static UnitTestResult VerifyArray<T>(ParameterBundle<T> paramBundle, T[] arrayToVerify) where T : struct, IComparable<T>
		{
            var arrayVerification = new VerificationTool<T>(paramBundle, arrayToVerify);

            return arrayVerification.TestResult;
        }

		/// <summary>
		/// Verifies that the value is within the bounds of its minimum and maximum values.
		/// </summary>
		/// <typeparam name="T">The type of the value</typeparam>
		/// <param name="paramBundle">The parameter bundle.</param>
		/// <param name="valueToVerify">The value to verify.</param>
		/// <returns>UnitTestResult.</returns>
		private static UnitTestResult VerifyValue<T>(ParameterBundle<T> paramBundle, T valueToVerify) where T : struct, IComparable<T>
		{
            var valueVerification = new VerificationTool<T>(paramBundle, valueToVerify);

            return valueVerification.TestResult;
        }
        
        #endregion
    }
}
