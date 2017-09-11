// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-10-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-10-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using NRTyler.CodeLibrary.Attributes;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Extension method(s) for the <see cref="StringEnum"/> class.
    /// </summary>
    public static class StringEnumEx
    {
        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        /// <param name="enumeration">The enumeration to analyze.</param>
        /// <returns>String value associated via a <see cref="StringValueAttribute" /> attribute, if not found returns null.</returns>
        public static string GetStringValue(this Enum enumeration)
        {
            return StringEnum.GetStringValue(enumeration);
        }
    }
}