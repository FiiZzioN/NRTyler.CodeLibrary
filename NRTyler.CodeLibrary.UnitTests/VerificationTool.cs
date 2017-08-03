// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-28-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.UnitTests
{
    /// <summary>
    /// The <see cref="VerificationTool{T}"/> class verifies and validates whether a single value, or multiple items generated in an array, are within the set constraints.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VerificationTool<T> where T : struct, IComparable<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VerificationTool{T}"/> class.
        /// </summary>
        private VerificationTool()
        {
            ResetTestResult();
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="VerificationTool{T}"/> class.
		/// </summary>
		/// <param name="paramBundle">Takes a <see cref="ParameterBundle{T}"/> object containing the constraints that the numeric value generated was held to.</param>
		/// <param name="valueToVerify">The value that's to be verified.</param>
		public VerificationTool(ParameterBundle<T> paramBundle, T valueToVerify) 
			: this(paramBundle.MinValue, paramBundle.MaxValue, valueToVerify)
		{

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="VerificationTool{T}"/> class.
		/// </summary>
		/// <param name="paramBundle">Takes a <see cref="ParameterBundle{T}"/> object containing the constraints that the array generation was held to.</param>
		/// <param name="arrayToVerify">The array that's to be verified.</param>
		public VerificationTool(ParameterBundle<T> paramBundle, T[] arrayToVerify) 
			: this(paramBundle.MinValue, paramBundle.MaxValue, arrayToVerify)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerificationTool{T}"/> class with values set manually.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="valueToVerify">The value that's to be verified.</param>
        public VerificationTool(T minValue, T maxValue, T valueToVerify) : this()
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.ValueToVerify = valueToVerify;
            VerifyNumericValue();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerificationTool{T}"/> class with values set manually.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="arrayToVerify">The array that's to be verified.</param>
        public VerificationTool(T minValue, T maxValue, T[] arrayToVerify) : this()
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.ArrayToVerify = arrayToVerify;
            VerifyArrayValues();
        }

        public VerificationTool(T multipleValues) : this()
        {
            this.ValueToVerify = multipleValues;
            //VerifyNumberBuilder();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the numeric value to verify.
        /// </summary>
        public T ValueToVerify { get; set; }

        /// <summary>
        /// Gets or sets the array to verify.
        /// </summary>
        public T[] ArrayToVerify { get; set; }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public T MinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        public T MaxValue { get; set; }

        /// <summary>
        /// Gets a value indicating whether the test was a success.
        /// </summary>
        public UnitTestResult TestResult { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Verifies whether the values that were generated in the array are within the set constraints.
        /// </summary>
        /// <returns>TestResult.</returns>
        public UnitTestResult VerifyArrayValues()
        {
            ResetTestResult();

            foreach (var item in this.ArrayToVerify)
            {
				if (item.CompareTo(MinValue) < 0 || item.CompareTo(MaxValue) > 0)
					return this.TestResult = UnitTestResult.Failed;
            }

            return this.TestResult = UnitTestResult.Passed;
        }

        /// <summary>
        /// Verifies whether the numeric value that was generated is within the set constraints.
        /// </summary>
        /// <returns>TestResult.</returns>
        public UnitTestResult VerifyNumericValue()
        {
            ResetTestResult();

            if (ValueToVerify.CompareTo(MinValue) < 0 || ValueToVerify.CompareTo(MaxValue) > 0)
				return this.TestResult = UnitTestResult.Failed;

            return this.TestResult = UnitTestResult.Passed;
        }

        /// <summary>
        /// Resets the test result.
        /// </summary>
        private void ResetTestResult()
        {
            this.TestResult = UnitTestResult.YetToRun;
        }

        #endregion
    }
}