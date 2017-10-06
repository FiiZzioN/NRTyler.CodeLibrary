// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 10-05-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-06-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Holds extension methods pertaining to the <see cref="IEnumerable{T}"/> <see langword="interface"/>.
    /// </summary>
    public static class IEnumerableEx
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}" /> collection to an <see cref="ObservableCollection{T}" />.
        /// This is useful for when you need to display a collections's item(s) on a UI.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type" /> that's being used.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}" /> collection to convert to an <see cref="ObservableCollection{T}" />.</param>
        /// <param name="allowDictionary">If set to true, when an <see cref="IDictionary"/> is passed, a <see cref="NotSupportedException"/> won't be thrown.</param>
        /// <returns>Returns an <see cref="ObservableCollection{T}" /> containing the same item(s) that the <see cref="IEnumerable{T}" /> collection contained.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="IEnumerable{T}" /> source cannot be null!</exception>
        /// <exception cref="NotSupportedException"><see cref="IDictionary" /> cannot be converted to an <see cref="ObservableCollection{T}" /></exception>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source, bool allowDictionary = false)
        {
            // Ensure that the source meets these basic criteria before returning the ObservableCollection.
            #region Basic Criteria

            // Can't convert something that's null!
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "The IEnumerable<T> source cannot be null!");
            }

            // If "allowDictionary" is true, then we never reach the IDictionary check.
            if (!allowDictionary)
            {
                if (source is IDictionary)
                {
                    throw new NotSupportedException("IDictionary cannot be converted to an ObservableCollection<T>");
                }
            }

            // If an IList<T> contains zero items, then there's nothing to convert.
            if (source is IList<T> list)
            {
                if (list.Count <= 0) return null;
            } 

            #endregion

            return new ObservableCollection<T>(source);
        }
    }
}