// ***********************************************************************
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
using System.Diagnostics;
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
        /// <returns>Returns the input value in the current cultures title case.</returns>
        public static string ToTitleCase(this string value)
		{
			if (value == null) return null;

			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
		}

        /// <summary>
        /// Returns the input value in a culture-independent (invariant) title case.
        /// </summary>
        /// <param name="value">The value that's to be converted.</param>
        /// <returns>Returns the input value in a culture-independent (invariant) title case.</returns>
        public static string ToInvariantTitleCase(this string value)
		{
			if (value == null) return null;

			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
		}

	    /// <summary>
	    /// Insures that if the incoming value is <see langword="null"/>, empty, or consists of only whitespace characters, 
	    /// a valid default string will be applied in its place. If the incoming value is valid, then it returns the incoming value.
	    /// </summary>
	    /// <param name="incomingValue">The incoming value.</param>
	    /// <param name="stringIfInvalid">The string to return if the incoming value is not valid.</param>
	    public static string HandleNullOrWhiteSpace(this string incomingValue, string stringIfInvalid = "Invalid String")
	    {
	        return String.IsNullOrWhiteSpace(incomingValue) ? stringIfInvalid : incomingValue;
	    }

        /// <summary>
        /// Starts a new line after the specified character. This will happen every time the character is found. 
        /// Returns <see langword="null"/> if the incoming string is <see langword="null"/>.
        /// </summary>
        /// <param name="incomingString">The incoming string.</param>
        /// <param name="character">The character that indicates when to start a new line should begin.</param>
        public static string NewLineAfterCharacter(this string incomingString, char character = '@')
        {
            return incomingString?.Replace(character, '\n');
	    }
    }
}