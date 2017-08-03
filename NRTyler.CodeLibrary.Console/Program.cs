// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.Console
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-28-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.Console
{
	public class Program
	{
		private static void Main()
		{
			Write(NumberBuilder.PositiveString(10));
		}

		/// <summary>
		/// Writes the specified value to the console.
		/// </summary>
		/// <param name="value">The value to write to the console.</param>
		private static void Write(object value)
		{
			System.Console.WriteLine(value);
		}
	}
}