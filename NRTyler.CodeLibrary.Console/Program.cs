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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.Console
{
	public class Program
	{
		private static void Main()
		{
		    var path = $"/:";
            
		    DirectoryEx.CreateDirectoryIfNonexistent(path);
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