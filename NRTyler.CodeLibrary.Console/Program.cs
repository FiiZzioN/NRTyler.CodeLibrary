// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.Console
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 11-29-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Extensions;
using NRTyler.CodeLibrary.Utilities;
using NRTyler.CodeLibrary.Utilities.Generators;

namespace NRTyler.CodeLibrary.Console
{
    public class Program
    {
        private static void Main()
        {
            try
            {
                var value = StringLabel.ParseEnum(typeof(UnitTestResult), "passed");

                if (value == null) throw new ArgumentException();

                Write($"Returned Enum: '{value}'");
                Write(null);
            }
            catch (Exception)
            {
                Write("Returned Value Was Null.");
                Write(null);
            }
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