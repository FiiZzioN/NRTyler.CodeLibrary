// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-21-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace NRTyler.CodeLibrary.Extensions
{
	/// <summary>
	/// Holds extension methods for the <see cref="IEnumerable{T}"/> interface.
	/// </summary>
	public static class EnumerableCollectionEx
	{
		/// <summary>
		/// Removes duplicates from a collection that implement the <see cref="IEnumerable{T}"/>interface.
		/// </summary>
		/// <typeparam name="T">The type of the inbound collection.</typeparam>
		/// <param name="enumerableCollection">A collection that is enumerable.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		public static IEnumerable<T> RemoveDuplicates<T>(this IEnumerable<T> enumerableCollection)
		{
			return enumerableCollection.Distinct().ToList();
		}
	}
}