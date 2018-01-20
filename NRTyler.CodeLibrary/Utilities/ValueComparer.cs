// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 01-20-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 01-20-2018
// 
// License          : MIT License
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Holds methods that help the user get either the smaller or larger of two values.
    /// </summary>
    public static class ValueComparer
    {
        /// <summary>
        /// Gets the smaller value of the two specified values.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value to compare. Must be a <see langword="struct"/>
        /// and implement the <see cref="IComparable{T}"/> interface.
        /// </typeparam>
        /// <param name="valueOne">The first value to compare.</param>
        /// <param name="valueTwo">The second value to compare.</param>
        public static T GetSmallerValue<T>(T valueOne, T valueTwo) where T : struct, IComparable<T>
        {
            // Less Than Zero = This object precedes the object specified by the CompareTo method in the sort order.
            return valueOne.CompareTo(valueTwo) < 0 ? valueOne : valueTwo;
        }

        /// <summary>
        /// Gets the larger value of the two specified values.
        /// </summary>
        /// <typeparam name="T">
        /// The type of value to compare. Must be a <see langword="struct"/>
        /// and implement the <see cref="IComparable{T}"/> interface.
        /// </typeparam>
        /// <param name="valueOne">The first value to compare.</param>
        /// <param name="valueTwo">The second value to compare.</param>
        public static T GetLargerValue<T>(T valueOne, T valueTwo) where T : struct, IComparable<T>
        {
            // Greater Than Zero = This current instance follows the object specified by the CompareTo method argument in the sort order.
            return valueOne.CompareTo(valueTwo) > 0 ? valueOne : valueTwo;
        }
    }
}