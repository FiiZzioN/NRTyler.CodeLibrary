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
using NRTyler.CodeLibrary.WPF;

namespace NRTyler.CodeLibrary.Console
{
    public class Program
    {
        [STAThreadAttribute]
        private static void Main()
        {
            var test = new CustomMessageBox();

            test.Show();

            List<string> tester = null;

            try
            {
                tester.Add("This is a Test");
            }
            catch (Exception e)
            {
                e.ShowExceptionMessageBox(ExceptionMessageType.Debug);
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