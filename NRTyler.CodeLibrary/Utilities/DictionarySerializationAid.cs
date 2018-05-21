// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-03-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-03-2017
//
// License          : MIT License
// ***********************************************************************

using System.Collections;
using System.Collections.Generic;
using NRTyler.CodeLibrary.Collections;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// <see cref="DictionarySerializationAid"/>is meant to help facilitate the serialization
    /// and/or deserialization of a dictionary when using XML formatted files.
    /// </summary>
    public static class DictionarySerializationAid
    {
        /// <summary>
        /// Takes an <see cref="IDictionary"/>'s key and value, and then creates a new <see cref="DictionaryEntry{TKey, TValue}"/>
        /// object using those values. The DictionaryEntry is then added to an <see cref="IEnumerable{T}"/> collection. 
        /// </summary>
        /// <typeparam name="TKey">The key's type.</typeparam>
        /// <typeparam name="TValue">The values's type.</typeparam>
        /// <param name="dictionary"> 
        /// The <see cref="IDictionary"/> whose <see cref="KeyValuePair{TKey,TValue}"/>'s will be
        /// converted into a <see cref="DictionaryEntry{TKey, TValue}"/> enumerable collection.
        /// </param>
        /// <returns>IEnumerable&lt;DictionaryEntry&lt;TKey, TValue&gt;&gt;.</returns>
        /// <remarks>This is done for each <see cref="KeyValuePair{TKey,TValue}"/> in the <see cref="IDictionary{TKey,TValue}"/>.</remarks>
        public static IEnumerable<DictionaryEntry<TKey, TValue>> DictionaryToEntryList<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var entryList = new List<DictionaryEntry<TKey, TValue>>();

            foreach (var i in dictionary)
            {
                var key = i.Key;
                var value = i.Value;
                var entry = new DictionaryEntry<TKey, TValue>(key, value);

                entryList.Add(entry);
            }

            return entryList;
        }

        /// <summary>
        /// Takes an <see cref="IEnumerable{T}"/> collection of <see cref="DictionaryEntry{TKey, TValue}"/> objects. The object's key 
        /// and value are taken, and then those values are added to a <see cref="Dictionary{TKey,TValue}"/>. Once fully iterated 
        /// through the <see cref="IEnumerable{T}"/> collection, the <see cref="IDictionary{TKey,TValue}"/> is returned.
        /// </summary>
        /// <typeparam name="TKey">The key's type.</typeparam>
        /// <typeparam name="TValue">The values's type.</typeparam>
        /// <param name="list">
        /// The list whose <see cref="DictionaryEntry{TKey, TValue}"/>'s will be converted into an <see cref="IDictionary{TKey,TValue}"/>.
        /// </param>
        /// <returns>IDictionary&lt;TKey, TValue&gt;.</returns>
        /// <remarks>This is done for each <see cref="DictionaryEntry{TKey, TValue}"/> in the <see cref="IEnumerable{T}"/> collection.</remarks>
        public static IDictionary<TKey, TValue> EntryListToDictionary<TKey, TValue>(this IEnumerable<DictionaryEntry<TKey, TValue>> list)
        {
            var dictionary = new Dictionary<TKey, TValue>();

            foreach (var i in list)
            {
                var key   = i.Key;
                var value = i.Value;

                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }
}