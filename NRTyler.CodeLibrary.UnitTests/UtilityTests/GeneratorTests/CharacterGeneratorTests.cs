// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-31-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-31-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests
{
    [TestClass]
    public class CharacterGeneratorTests
    {
        #region Base Tests

        [TestMethod]
        public void CharacterGenerator_ValueFailed()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(97, 123);
            var value       = CharacterGenerator.Upper();

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void CharacterGenerator_ArrayFailed()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(65, 91, 500);
            var value       = CharacterGenerator.LowerArray(paramBundle.ArraySize);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, ConvertToIntArray(value));

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        #endregion

        #region Upper Tests

        [TestMethod]
        public void CharacterGenerator_Upper()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(65, 91);
            var value       = CharacterGenerator.Upper();

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharacterGenerator_UpperArray()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(65, 91, 500);
            var value       = CharacterGenerator.UpperArray(paramBundle.ArraySize);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, ConvertToIntArray(value));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Lower Tests

        [TestMethod]
        public void CharacterGenerator_Lower()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(97, 123);
            var value       = CharacterGenerator.Lower();

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyValue(paramBundle, value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharacterGenerator_LowerArray()
        {
            //Arrange
            var paramBundle = new ParameterBundle<int>(97, 123, 500);
            var value       = CharacterGenerator.LowerArray(paramBundle.ArraySize);

            var expected    = UnitTestResult.Passed;

            //Act
            var actual      = VerifyArray(paramBundle, ConvertToIntArray(value));

            //Assert
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
	    private static UnitTestResult VerifyArray<T>(ParameterBundle<T> paramBundle, T[] arrayToVerify)
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
	    private static UnitTestResult VerifyValue<T>(ParameterBundle<T> paramBundle, T valueToVerify)
	    {
		    var valueVerification = new VerificationTool<T>(paramBundle, valueToVerify);

		    return valueVerification.TestResult;
	    }

	    #endregion

		private static int[] ConvertToIntArray(char[] array)
        {
            var arrayToReturn = new int[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                arrayToReturn[i] = array[i];
            }

            return arrayToReturn;
        }

    }
}