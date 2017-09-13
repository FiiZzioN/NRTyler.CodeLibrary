// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-10-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Text;

namespace NRTyler.CodeLibrary.Utilities.Generators
{
    /// <summary>
    /// <see cref="NumberBuilder"/> allows the user to generate strings of random numbers with as many digits as the user specifies. Can be used to build either positive or negative numbers.
    /// </summary>
    public static class NumberBuilder
    {
	    #region Generics

	    

	    #endregion

		#region String Returns

		/// <summary>
		/// Builds a positive value with the amount of digits specified. Returns the value as a string.
		/// </summary>
		/// <param name="amount">The amount of numbers to generate.</param>
		/// <returns>System.String.</returns>
		public static string PositiveString(int amount)
        {
            return CoreBuilder(amount, false);
        }

        /// <summary>
        /// Builds a negative value with the amount of digits specified. Returns the value as a string.
        /// </summary>
        /// <param name="amount">The amount of numbers to generate.</param>
        /// <returns>System.String.</returns>
        public static string NegativeString(int amount)
        {
            return CoreBuilder(amount, true);
        }

        /// <summary>
        /// Builds a randomly signed value with the amount of digits specified. Returns the value as a string.
        /// </summary>
        /// <param name="amount">The amount of numbers to generate.</param>
        /// <returns>System.String.</returns>
        public static string RandomlySignedString(int amount)
        {
            return CoreBuilder(amount, Convert.ToBoolean(Dice.Roll()));
        }

        /// <summary>
        /// Builds a randomly signed value with a random amount of digits. Returns the value as a string.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string RandomString()
        {
            var maxAmountOfDigits = 308;
            var amount            = NumericGenerator.GenerateValue(0, maxAmountOfDigits);

            return CoreBuilder(amount, Convert.ToBoolean(Dice.Roll()));
        }

        #endregion

        #region Double Returns

        /// <summary>
        /// Builds a positive value with the amount of digits specified. Returns the value as a double.
        /// </summary>
        /// <param name="amount">The amount of numbers to generate.</param>
        /// <returns>System.Double.</returns>
        public static double PositiveDouble(int amount)
        {
            return Double.Parse(PositiveString(amount));
        }

        /// <summary>
        /// Builds a negative value with the amount of digits specified. Returns the value as a double.
        /// </summary>
        /// <param name="amount">The amount of numbers to generate.</param>
        /// <returns>System.Double.</returns>
        public static double NegativeDouble(int amount)
        {
            return Double.Parse(NegativeString(amount));
        }

        /// <summary>
        /// Builds a randomly signed value with the amount of digits specified. Returns the value as a double.
        /// </summary>
        /// <param name="amount">The amount of numbers to generate.</param>
        /// <returns>System.String.</returns>
        public static double RandomlySignedDouble(int amount)
        {
            return Double.Parse(RandomlySignedString(amount));
        }

        /// <summary>
        /// Builds a randomly signed value with a random amount of digits. Returns the value as a double.
        /// </summary>
        /// <returns>System.Double.</returns>
        public static double RandomDouble()
        {
            return Double.Parse(RandomString());
        }

		#endregion

		#region Tandem Returns

		/// <summary>
		/// Builds a positive value with the amount of digits specified. 
		/// Returns a <see cref="Tuple{T1, T2}"/> containing the value as both a <see cref="string"/> and a <see cref="double"/>.
		/// </summary>
		/// <param name="amount">The amount of numbers to generate.</param>
		/// <returns>Tuple&lt;System.String, System.Double&gt;.</returns>
		public static Tuple<string, double> PositiveTandem(int amount)
        {
            return ArrangeValues(PositiveString(amount));
        }

	    /// <summary>
	    /// Builds a negative value with the amount of digits specified. 
	    /// Returns a <see cref="Tuple{T1, T2}"/> containing the value as both a <see cref="string"/> and a <see cref="double"/>.
	    /// </summary>
	    /// <param name="amount">The amount of numbers to generate.</param>
		/// <returns>Tuple&lt;System.String, System.Double&gt;.</returns>
		public static Tuple<string, double> NegativeTandem(int amount)
        {
            return ArrangeValues(NegativeString(amount));
        }

		/// <summary>
		/// Builds a randomly signed value with the amount of digits specified. 
		/// Returns a <see cref="Tuple{T1, T2}"/> containing the value as both a <see cref="string"/> and a <see cref="double"/>.
		/// </summary>
		/// <param name="amount">The amount of numbers to generate.</param>
		/// <returns>Tuple&lt;System.String, System.Double&gt;.</returns>
		public static Tuple<string, double> RandomlySignedTandem(int amount)
        {
            return ArrangeValues(RandomlySignedString(amount));
        }

		/// <summary>
		/// Builds a randomly signed value with a random amount of digits.
		/// Returns a <see cref="Tuple{T1, T2}"/> containing the value as both a <see cref="string"/> and a <see cref="double"/>.
		/// </summary>
		/// <returns>Tuple&lt;System.String, System.Double&gt;.</returns>
		public static Tuple<string, double> RandomTandem()
        {
            return ArrangeValues(RandomString());
        }

        #endregion

        #region Foundation Methods

        /// <summary>
        /// The core that makes <see cref="NumberBuilder"/> function.
        /// </summary>
        /// <param name="amount">The amount of numbers to generate.</param>
        /// <param name="negativeValue">Whether the number should be a positive or negative value.</param>
        /// <returns>System.String.</returns>
        private static string CoreBuilder(int amount, bool negativeValue = false)
        {
            var stringBuilder = new StringBuilder();

            // Add the amount of digits specified.
            for (var i = 0; i < amount; i++)
            {
                stringBuilder.Append(NumericGenerator.GenerateValue(0, 10));
	            RemoveLeadingZero(stringBuilder);
            }

            // Inserts a hyphen at the beginning of the string if the user wants a negative number.
            if (negativeValue) stringBuilder.Insert(0, "-");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Takes a randomly built <see cref="string"/> and returns a <see cref="Tuple{T1,T2}"/> containing
        /// the value as a <see cref="string"/> and a <see cref="double"/>.
        /// </summary>
        /// <param name="coreValue">The string that you would like to return as multiple types.</param>
        /// <returns>Tuple&lt;System.String, System.Double&gt;.</returns>
        private static Tuple<string, double> ArrangeValues(string coreValue)
        {
            return new Tuple<string, double>(coreValue, Double.Parse(coreValue));
        }

		/// <summary>
		/// Removes the leading zero from a string of numbers.
		/// </summary>
		/// <param name="stringBuilder">The <see cref="StringBuilder"/> object that's being assembled.</param>
		private static void RemoveLeadingZero(StringBuilder stringBuilder)
	    {
		    if (stringBuilder == null) throw new ArgumentNullException($"{nameof(stringBuilder)} cannot be null!");

		    if (!stringBuilder.ToString().StartsWith("0")) return;

		    var builtString   = stringBuilder.ToString();
		    var randomInteger = $"{NumericGenerator.GenerateValue(1, 10)}";
		    try
		    {
				// Removes the zero in the first index and replaces it with the randomInteger.
			    stringBuilder.Replace(builtString, randomInteger, 0, 1);
		    }
		    catch (ArgumentOutOfRangeException ex)
		    {
			    Console.WriteLine(ex);
		    }
		    catch (ArgumentException ex)
		    {
			    Console.WriteLine(ex);
		    }
	    }

        #endregion
    }
}