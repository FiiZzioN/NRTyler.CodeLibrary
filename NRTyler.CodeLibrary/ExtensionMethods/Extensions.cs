// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-28-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace NRTyler.CodeLibrary.ExtensionMethods
{
    /// <summary>
    /// the <see cref="Extensions"/> class holds all extension methods in this namespace.
    /// </summary>
    public static class Extensions
    {
        #region System.Random

        /// <summary>
        /// Returns a random double that's within the specified range.
        /// </summary>
        /// <param name="Randomizer">The randomizer to work from.</param>
        /// <param name="MinValue">The minimum value.</param>
        /// <param name="MaxValue">The maximum value.</param>
        /// <returns>System.Double.</returns>
        /// <remarks>Extension Method.</remarks>
        public static double NextDouble(this Random Randomizer, double MinValue, double MaxValue)
        {
            return Randomizer.NextDouble() * (MaxValue - MinValue) + MinValue;
        }

        /// <summary>
        /// Returns a random byte that's within the specified range.
        /// </summary>
        /// <param name="Randomizer">The randomizer to work from.</param>
        /// <param name="MinValue">The minimum value.</param>
        /// <param name="MaxValue">The maximum value.</param>
        /// <returns>System.Byte.</returns>
        /// <remarks>Extension Method.</remarks>
        public static byte NextByte(this Random Randomizer, byte MinValue, byte MaxValue)
        {
            return Convert.ToByte(Randomizer.Next(MinValue, MaxValue));
        }

        #endregion

        #region System.Collections.Generic

        /// <summary>
        /// Removes duplicates from a collection that implement the <see cref="IEnumerable{TSource}"/>interface.
        /// </summary>
        /// <typeparam name="TSource">The type of the inbound collection.</typeparam>
        /// <param name="enumerableCollection">A collection that is enumerable.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IEnumerable<TSource> enumerableCollection)
        {
            return enumerableCollection.Distinct().ToList();
        }

        #endregion
    }
}
