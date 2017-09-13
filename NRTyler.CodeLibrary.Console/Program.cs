// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.Console
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-01-2017
//
// License          : MIT License
// ***********************************************************************

using System.Collections.Generic;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.Console
{
	public class Program
	{
		private static void Main()
		{
			var dictionary = new Dictionary<string, int>();

			dictionary.Add("One",   1);
			dictionary.Add("Two",   2);
			dictionary.Add("Three", 3);
			dictionary.Add("Four",  4);
			dictionary.Add("Five",  5);

			ConsoleEx.ClosingMessage();

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