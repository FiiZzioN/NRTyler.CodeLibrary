// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-10-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-23-2017
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
    public static class StringLabelEx
    {
        /// <summary>
        /// Gets the label from the <see cref="StringLabelAttribute"/> that's applied to this <see cref="Enum"/> member. 
        /// If a <see cref="StringLabelAttribute"/> hasn't been applied a <see langword="null"/> value will be returned.
        /// </summary>
        /// <param name="enumeration">The <see cref="Enum"/> member to analyze.</param>
        /// <returns>The <see langword="string"/>  value associated via a <see cref="StringLabelAttribute" />, if not found then this returns null.</returns>
        public static string GetLabel(this Enum enumeration)
        {
            return StringLabel.GetLabel(enumeration);
        }
    }
}