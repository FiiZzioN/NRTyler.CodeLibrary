// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Stephen Inglish
// Created          : 02-22-2008
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-07-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NRTyler.CodeLibrary.Utilities
{
	/// <summary>
	/// Provides a method for performing a deep copy of an object.
	/// Binary Serialization is used to perform the copy.
	/// </summary>
	/// <remarks>
	/// Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
	/// </remarks>
	public static class ObjectCopier
	{
        /// <summary>
        /// Performs a deep copy of the object. The object must be serializable.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        /// <exception cref="ArgumentException">The <see cref="Type"/> must be serializable.</exception>
        public static T Clone<T>(this T source)
		{
			if (!typeof(T).IsSerializable)
			{
				throw new ArgumentException("The type being copied must be serializable!", nameof(source));
			}

			// Don't serialize a null object, simply return the default for that object.
			if (Object.ReferenceEquals(source, null))
			{
				return default(T);
			}

			var formatter = new BinaryFormatter();
			var stream    = new MemoryStream();

			using (stream)
			{
				formatter.Serialize(stream, source);
				stream.Seek(0, SeekOrigin.Begin);

				return (T)formatter.Deserialize(stream);
			}
		}
	}
}