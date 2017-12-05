// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-10-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-10-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using NRTyler.CodeLibrary.Attributes;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Extension method(s) for the <see cref="StringLabel"/> class.
    /// </summary>
    public static class StringEnumEx
    {
        /// <summary>
        /// Gets the <see cref="StringLabelAttribute"/> that's applied to the specified <see cref="Enum"/> member.
        /// </summary>
        /// <param name="enumeration">The <see cref="Enum"/> member to analyzed.</param>
        /// <returns>The <see langword="string"/>  value associated via a <see cref="StringLabelAttribute" />, if not found returns null.</returns>
        public static string GetStringValue(this Enum enumeration)
        {
            return StringLabel.GetLabel(enumeration);
        }
    }
}