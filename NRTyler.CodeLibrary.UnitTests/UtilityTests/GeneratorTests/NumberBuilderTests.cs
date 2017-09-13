// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-03-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests.GeneratorTests
{
    public class NumberBuilderTests
    {
        #region Strings



        #endregion

        #region Doubles



        #endregion

        #region Tandems



        #endregion

        #region VerifyResults

        private static UnitTestResult VerifyArray<T>(ParameterBundle<T> paramBundle, T[] arrayToVerify) where T : struct, IComparable<T>
		{
            var arrayVerification = new VerificationTool<T>(paramBundle, arrayToVerify);

            return arrayVerification.TestResult;
        }

        private static UnitTestResult VerifyValue<T>(ParameterBundle<T> paramBundle, T valueToVerify) where T : struct, IComparable<T>
		{
            var valueVerification = new VerificationTool<T>(paramBundle, valueToVerify);

            return valueVerification.TestResult;
        }

        #endregion
    }
}