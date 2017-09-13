// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-01-2017
//
// License          : MIT License
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Extensions
{
	/// <summary>
	/// Holds extension methods for the <see cref="Random"/> class.
	/// </summary>
	public static class RandomEx
	{
		/// <summary>
		/// Returns a random double that's within the specified range.
		/// </summary>
		/// <param name="randomizer">The randomizer to work from.</param>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>System.Double.</returns>
		/// <remarks>Extension Method.</remarks>
		public static double NextDouble(this Random randomizer, double minValue, double maxValue)
		{
			return randomizer.NextDouble() * (maxValue - minValue) + minValue;
		}

		/// <summary>
		/// Returns a random byte that's within the specified range.
		/// </summary>
		/// <param name="randomizer">The randomizer to work from.</param>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>System.Byte.</returns>
		/// <remarks>Extension Method.</remarks>
		public static byte NextByte(this Random randomizer, byte minValue, byte maxValue)
		{
			return Convert.ToByte(randomizer.Next(minValue, maxValue));
		}

	}
}