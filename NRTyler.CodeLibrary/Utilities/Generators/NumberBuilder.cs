﻿// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 06-24-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 06-29-2017
//
// License          : GNU General Public License v3.0
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
            var diceRoll = NumericGenerator.Integer(0, 2);
            return CoreBuilder(amount, Convert.ToBoolean(diceRoll));
        }

        /// <summary>
        /// Builds a randomly signed value with a random amount of digits. Returns the value as a string.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string RandomString()
        {
            var maxAmountOfDigits = 308;
            var diceRoll          = NumericGenerator.Integer(0, 2);
            var amount            = NumericGenerator.Integer(maxAmountOfDigits);

            return CoreBuilder(amount, Convert.ToBoolean(diceRoll));
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

        public static Tuple<string, double> PositiveTandem(int amount)
        {
            return ArrangeValues(PositiveString(amount));
        }

        public static Tuple<string, double> NegativeTandem(int amount)
        {
            return ArrangeValues(NegativeString(amount));
        }

        public static Tuple<string, double> RandomlySignedTandem(int amount)
        {
            return ArrangeValues(RandomlySignedString(amount));
        }

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
                var randomInteger = NumericGenerator.Integer(0, 10);
                stringBuilder.Append(randomInteger);
            }

            // Inserts a hyphen at the beginning of the string if the user wants a negative number.
            // If negativeValue is false, then it just falls through.
            if (negativeValue) stringBuilder.Insert(0, "-");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Takes a randomly built <see cref="string"/> and places it into a <see cref="Tuple{T1,T2}"/> as both a <see cref="string"/> and an <see cref="int"/>.
        /// </summary>
        /// <param name="coreValue">The string that you would like to return as multiple types.</param>
        /// <returns>Tuple&lt;System.String, System.Double&gt;.</returns>
        private static Tuple<string, double> ArrangeValues(string coreValue)
        {
            return new Tuple<string, double>(coreValue, Double.Parse(coreValue));
        }

        #endregion
    }
}