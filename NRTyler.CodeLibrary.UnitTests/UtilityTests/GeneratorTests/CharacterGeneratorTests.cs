// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-31-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-03-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests.GeneratorTests
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

        #region Special Tests

        [TestMethod]
        public void CharacterGenerator_Special()
        {
            var expected = UnitTestResult.Passed;
            var value    = CharacterGenerator.Special();
      
            Assert.AreEqual(expected, VerifySpecialCharacters(value));
        }

        [TestMethod]
        public void CharacterGenerator_SpecialArray()
        {
            var expected = UnitTestResult.Passed;
            var value = CharacterGenerator.SpecialArray(500);

            Assert.AreEqual(expected, VerifySpecialCharacters(value));
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

        private static UnitTestResult VerifySpecialCharacters(char valueToVerify)
        {
            foreach (var item in CharacterGenerator.SpecialCharacters)
            {
                if (valueToVerify == (char)item)
                {
                    return UnitTestResult.Passed;
                }
            }

            return UnitTestResult.Failed;
        }

        private static UnitTestResult VerifySpecialCharacters(char[] valueToVerify)
        {
            // Trying to validate that there are only special values in
            // an array makes things a bit more complicated. This was my solution.

            #region Step One

            // Make an array of Failed UnitTestResults the same size as the one we are validating. This way we have a
            // record for each character in the array. This makes each index in the array a miniature unit test.

            var outcomeArray = new UnitTestResult[valueToVerify.Length];

            for (var i = 0; i < outcomeArray.Length; i++)
            {
                outcomeArray[i] = UnitTestResult.Failed;
            }

            #endregion

            #region Step Two

            // Compare every index in the arrayToVeryify to the special characters on the SpecialCharacters list in the CharacterGenerator.
            // If the index matches on of the characters on the list, it swaps the same index in the outcomeArray to a Passed result.
            // This goes on until every index is compared.

            for (var i = 0; i < valueToVerify.Length; i++)
            {
                foreach (var character in CharacterGenerator.SpecialCharacters)
                {
                    if (valueToVerify[i] == character)
                    {
                        outcomeArray[i] = UnitTestResult.Passed;
                    }
                }
            }

            #endregion

            #region Step Three

            // We go through the outcomeArray to see if there are any Failed UnitTestResults. If there's even just one Failed result,
            // this entire test will fail.
            foreach (var unitTestResult in outcomeArray)
            {
                if (unitTestResult == UnitTestResult.Failed)
                {
                    return unitTestResult;
                }

            } 

            #endregion

            // Finally, if there were no Failed UnitTestResults in the outcomeArray, we show that the unit test was successfully passed.
            return UnitTestResult.Passed;
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