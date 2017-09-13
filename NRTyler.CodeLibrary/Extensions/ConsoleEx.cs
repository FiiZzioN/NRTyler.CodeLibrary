// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-21-2017
//
// License          : MIT License
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Extensions
{
	/// <summary>
	/// Holds wrapper methods for the <see cref="Console"/> class.
	/// </summary>
	public static class ConsoleEx
	{
		/// <summary>
		/// Adds the "Press any key to continue" closing message so the console
		/// doesn't disappear when it reaches the bottom of the "Main" function. 
		/// </summary>
		public static void ClosingMessage()
		{
			Write("");
			Write("Press any key to continue . . .");
			Console.ReadKey(true);
		}

		/// <summary>
		/// Writes the specified value to the console.
		/// </summary>
		/// <param name="value">The value to write to the console.</param>
		public static void Write(object value)
		{
			Console.WriteLine(value);
		}
	}
}