// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-03-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-03-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace NRTyler.CodeLibrary.Utilities.Assistants
{
	/// <summary>
	/// Used to alert the user via the console/output screen should something not match. 
	/// This is mainly used in cases where a unit test has multiple asserts and needs to know which one failed, if any.
	/// </summary>
	public static class UnitTestAlert
	{
		/// <summary>
		/// If the values aren't equal, then you get alerted via the console/output screen. If the values match, nothing happens.
		/// </summary>
		/// <typeparam name="T">The type of item to compare</typeparam>
		/// <param name="valueOne">The first value to compare</param>
		/// <param name="valueTwo">The second value to compare.</param>
		/// <param name="message">The message to print to the console/output screen.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static void CollectionAlert<T>(ICollection<T> valueOne, ICollection<T> valueTwo, string message = "Collections aren't equal!")
		{
			if (valueOne == null)    throw new ArgumentNullException(nameof(valueOne), "Value cannot be null");
			if (valueTwo == null)    throw new ArgumentNullException(nameof(valueTwo), "Value cannot be null");
			if (valueOne.Count <= 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(valueOne));
			if (valueTwo.Count <= 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(valueTwo));

			if (valueOne.Equals(valueTwo))
			{
				Write(message);
			}
		}

		/// <summary>
		/// If the values aren't equal, then you get alerted via the console/output screen. If the values match, nothing happens.
		/// </summary>
		/// <typeparam name="T">The type of item to compare</typeparam>
		/// <param name="valueOne">The first value to compare</param>
		/// <param name="valueTwo">The second value to compare.</param>
		/// <param name="message">The message to print to the console/output screen.</param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void EqualityAlert<T>(T valueOne, T valueTwo, string message = "Values aren't equal!")
		{
			if (valueOne == null) throw new ArgumentNullException(nameof(valueOne), "Value cannot be null");
			if (valueTwo == null) throw new ArgumentNullException(nameof(valueTwo), "Value cannot be null");

			if (!valueOne.Equals(valueTwo))
			{
				Write(message);
			}
		}

		/// <summary>
		/// Writes the specified value to the console.
		/// </summary>
		/// <param name="value">The value to write to the console.</param>
		private static void Write(object value)
		{
			Console.WriteLine(value);
		}
	}
}