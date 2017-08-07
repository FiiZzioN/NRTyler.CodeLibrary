// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-07-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-07-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.Utilities
{
	/// <summary>
	/// We all need an item that'll make an unbiased decision for us; let this be yours!
	/// </summary>
	public static class Dice
	{
		/// <summary>
		/// Roll a pair of "dice" to decide what should be done. Returns are zero based indexed.
		/// For the dice to work there has to be at least two choices!
		/// </summary>
		/// <param name="choices">The amount of items that you need to choose from.</param>
		/// <returns>System.Int32.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static int Roll(int choices = 2)
		{
			if (choices < 2)
				throw new ArgumentOutOfRangeException($"{nameof(choices)}", "For the dice to work there has to be at least two choices!");

			return NumericGenerator.GenerateValue(0, choices);
		}
	}
}