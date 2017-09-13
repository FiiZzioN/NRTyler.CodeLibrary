﻿// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-17-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-21-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Globalization;

namespace NRTyler.CodeLibrary.Extensions
{
	/// <summary>
	/// Holds extension methods for the <see cref="String"/> class.
	/// </summary>
	public static class StringEx
	{
		/// <summary>
		/// Returns the input value in the current cultures title case.
		/// </summary>
		/// <param name="value">The value that's to be converted.</param>
		/// <returns>System.String.</returns>
		public static string ToTitleCase(this string value)
		{
			if (value == null) return null;

			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}

		/// <summary>
		/// Returns the input value in a culture-independent (invariant) title case.
		/// </summary>
		/// <param name="value">The value that's to be converted.</param>
		/// <returns>System.String.</returns>
		public static string ToInvariantTitleCase(this string value)
		{
			if (value == null) return null;

			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
		}

		/// <summary>
		/// Insures that a field meant to be a title will never be null.
		/// </summary>
		/// <param name="incomingValue">The incoming value.</param>
		/// <param name="backingField">The backing field that's meant to be a title.</param>
		public static void TitleInsurance(this string incomingValue, ref string backingField)
		{
			if (String.IsNullOrWhiteSpace(incomingValue))
			{
				var titleIfNull = "Invalid Title";
				if (backingField == titleIfNull) return;

				backingField = titleIfNull;
				return;
			}

			backingField = incomingValue;
		}
	}
}