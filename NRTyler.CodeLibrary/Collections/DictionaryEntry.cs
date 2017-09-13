// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-20-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-05-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;

namespace NRTyler.CodeLibrary.Collections
{
	/// <summary>
	/// <see cref="DictionaryEntry{TKey,TValue}"/> is meant to help facilitate the serialization
	/// and/or deserialization of a dictionary when using XML formatted files.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <remarks>Works exactly like the <see cref="DictionaryEntry"/> struct.
	/// The only difference is that this struct is strongly typed.
	/// </remarks>
	[Serializable]
	[XmlRoot("DictionaryEntry")]
	public struct DictionaryEntry<TKey, TValue>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DictionaryEntry{TKey,TValue}"/> struct.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public DictionaryEntry(TKey key, TValue value) : this()
		{
			this.Key   = key;
			this.Value = value;
		}

		/// <summary>
		/// Gets or sets the <see cref="Dictionary{TKey,TValue}"/> entry's key.
		/// </summary>
		public TKey Key { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Dictionary{TKey,TValue}"/> entry's value.
		/// </summary>
		public TValue Value { get; set; }

        /*
	    #region Implementation of IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

	    public void ReadXml(XmlReader reader)
	    {
	        reader.MoveToContent();

	        if (!reader.IsEmptyElement)
	            Key = (TKey)Convert.ChangeType(reader.GetAttribute(nameof(Key)), TypeCode.Object);

	        reader.MoveToContent();

            if (!reader.IsEmptyElement)
	            Value = (TValue)Convert.ChangeType(reader.GetAttribute(nameof(Value)), TypeCode.Object);

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
	    {
	        writer.WriteAttributeString(nameof(Key), Key.ToString());
	        writer.WriteAttributeString(nameof(Value), Value.ToString());
        }

        #endregion
        */
    }
}