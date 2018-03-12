// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 03-12-2018
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 03-12-2018
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using NRTyler.CodeLibrary.EventArgs;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.Collections
{
    /// <summary>
    /// Works exactly the same as the default <see cref="List{T}"/>, but has an added feature. That feature is an 
    /// exposed event that anyone can listen to, and is called when anything is added to or removed from the list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <seealso cref="System.Collections.Generic.List{T}" />
    [Serializable]
    public class AlertList<T> : List<T>
    {
        /// <summary>Adds an object to the end of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
        /// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.Generic.List`1" />. The value can be <see langword="null" /> for reference types.</param>
        public new void Add(T item)
        {
            base.Add(item);

            var array = new T[] { item };
            OnListChanged(array);
        }

        /// <summary>Adds the elements of the specified collection to the end of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1" />. The collection itself cannot be <see langword="null" />, but it can contain elements that are <see langword="null" />, if type T is a reference type.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="collection" /> is <see langword="null" />.</exception>
        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            OnListChanged(collection);
        }

        /// <summary>Removes all elements from the <see cref="T:System.Collections.Generic.List`1" />.</summary>
        public new void Clear()
        {
            var list = new List<T>();
            list.AddRange(this);

            base.Clear();

            OnListChanged(list);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.List`1" />.</summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.List`1" />. The value can be <see langword="null" /> for reference types.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="item" /> is successfully removed; otherwise, <see langword="false" />.  This method also returns <see langword="false" /> if <paramref name="item" /> was not found in the <see cref="T:System.Collections.Generic.List`1" />.</returns>
        public new bool Remove(T item)
        {
            var returnedValue = base.Remove(item);

            var array = new T[] { item };
            OnListChanged(array);

            return returnedValue;
        }

        /// <summary>Removes all the elements that match the conditions defined by the specified predicate.</summary>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> delegate that defines the conditions of the elements to remove.</param>
        /// <returns>The number of elements removed from the <see cref="T:System.Collections.Generic.List`1" /> .</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="match" /> is <see langword="null" />.</exception>
        public new int RemoveAll(Predicate<T> match)
        {
            var list = base.FindAll(match);
            var returnedValue = base.RemoveAll(match);

            OnListChanged(list);

            return returnedValue;
        }

        /// <summary>Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than 0.-or-
        /// <paramref name="index" /> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count" />.</exception>
        public new void RemoveAt(int index)
        {
            var item  = base[index];
            var array = new T[] { item };

            base.RemoveAt(index);
            OnListChanged(array);
        }

        /// <summary>Removes a range of elements from the <see cref="T:System.Collections.Generic.List`1" />.</summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than 0.-or-
        /// <paramref name="count" /> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1" />.</exception>
        public new void RemoveRange(int index, int count)
        {
            var list = new List<T>();
            for (var i = index; i <= ((index + count) - 1); i++)
            {
                list.Add(base[i]);
            }

            base.RemoveRange(index, count);
            OnListChanged(list);
        }

        /*

            /// <summary>Reverses the order of the elements in the entire <see cref="T:System.Collections.Generic.List`1" />.</summary>
            public new void Reverse()
            {
                base.Reverse();
                OnListChanged();
            }

            /// <summary>Reverses the order of the elements in the specified range.</summary>
            /// <param name="index">The zero-based starting index of the range to reverse.</param>
            /// <param name="count">The number of elements in the range to reverse.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// <paramref name="index" /> is less than 0.-or-
            /// <paramref name="count" /> is less than 0. </exception>
            /// <exception cref="T:System.ArgumentException">
            /// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1" />. </exception>
            public new void Reverse(int index, int count)
            {
                base.Reverse(index, count);
                OnListChanged();
            }

            /// <summary>Sorts the elements in the entire <see cref="T:System.Collections.Generic.List`1" /> using the default comparer.</summary>
            /// <exception cref="T:System.InvalidOperationException">The default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" /> cannot find an implementation of the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface for type <paramref name="T" />.</exception>
            public new void Sort()
            {
                base.Sort();
                OnListChanged();
            }

            /// <summary>Sorts the elements in the entire <see cref="T:System.Collections.Generic.List`1" /> using the specified comparer.</summary>
            /// <param name="comparer">The <see cref="T:System.Collections.Generic.IComparer`1" /> implementation to use when comparing elements, or <see langword="null" /> to use the default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" />.</param>
            /// <exception cref="T:System.InvalidOperationException">
            /// <paramref name="comparer" /> is <see langword="null" />, and the default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" /> cannot find implementation of the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface for type <paramref name="T" />.</exception>
            /// <exception cref="T:System.ArgumentException">The implementation of <paramref name="comparer" /> caused an error during the sort. For example, <paramref name="comparer" /> might not return 0 when comparing an item with itself.</exception>
            public new void Sort(IComparer<T> comparer)
            {
                base.Sort(comparer);
                OnListChanged();
            }

            /// <summary>Sorts the elements in a range of elements in <see cref="T:System.Collections.Generic.List`1" /> using the specified comparer.</summary>
            /// <param name="index">The zero-based starting index of the range to sort.</param>
            /// <param name="count">The length of the range to sort.</param>
            /// <param name="comparer">The <see cref="T:System.Collections.Generic.IComparer`1" /> implementation to use when comparing elements, or <see langword="null" /> to use the default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" />.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// <paramref name="index" /> is less than 0.-or-
            /// <paramref name="count" /> is less than 0.</exception>
            /// <exception cref="T:System.ArgumentException">
            /// <paramref name="index" /> and <paramref name="count" /> do not specify a valid range in the <see cref="T:System.Collections.Generic.List`1" />.-or-The implementation of <paramref name="comparer" /> caused an error during the sort. For example, <paramref name="comparer" /> might not return 0 when comparing an item with itself.</exception>
            /// <exception cref="T:System.InvalidOperationException">
            /// <paramref name="comparer" /> is <see langword="null" />, and the default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" /> cannot find implementation of the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface for type <paramref name="T" />.</exception>
            public new void Sort(int index, int count, IComparer<T> comparer)
            {
                base.Sort(index, count, comparer);
                OnListChanged();
            }

            /// <summary>Sorts the elements in the entire <see cref="T:System.Collections.Generic.List`1" /> using the specified <see cref="T:System.Comparison`1" />.</summary>
            /// <param name="comparison">The <see cref="T:System.Comparison`1" /> to use when comparing elements.</param>
            /// <exception cref="T:System.ArgumentNullException">
            /// <paramref name="comparison" /> is <see langword="null" />.</exception>
            /// <exception cref="T:System.ArgumentException">The implementation of <paramref name="comparison" /> caused an error during the sort. For example, <paramref name="comparison" /> might not return 0 when comparing an item with itself.</exception>
            public new void Sort(Comparison<T> comparison)
            {
                base.Sort(comparison);
                OnListChanged();
            }

        */

        /// <summary>
        /// Occurs when anything is added to or removed from the list.
        /// </summary>
        public event EventHandler<ListChangedEventArgs<T>> ListChanged;

        /// <summary>
        /// Called when anything is added to or removed from the list.
        /// </summary>
        protected void OnListChanged(IEnumerable<T> itemsChanged)
        {
            ListChanged?.Invoke(this, new ListChangedEventArgs<T>(itemsChanged));
        }
    }
}