// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Stephen Inglish
// Created          : 02-22-2008
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-13-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NRTyler.CodeLibrary.Utilities
{
	/// <summary>
	/// Provides a method for performing a deep copy of an <see cref="object"/>. Binary serialization is used to perform the copy.
	/// </summary>
	public static class ObjectCopier
	{
        /// <summary>
        /// Performs a deep copy of the object. The object must be serializable.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="object"/> being copied.</typeparam>
        /// <param name="obj">The <see cref="object"/> to copy.</param>
        /// <returns>A copy of the <see cref="object"/> that was targeted.</returns>
        /// <exception cref="ArgumentException">The <see cref="Type"/> must be serializable.</exception>
        public static T CopyObject<T>(this T obj)
		{
			if (!typeof(T).IsSerializable)
			{
				throw new ArgumentException("The type being copied must be serializable!", nameof(obj));
			}

			// Don't serialize a null object, just return the default of that object.
			if (Object.ReferenceEquals(obj, null))
			{
				return default(T);
			}

			var binaryFormatter = new BinaryFormatter();
			var memoryStream    = new MemoryStream();

			using (memoryStream)
			{
			    binaryFormatter.Serialize(memoryStream, obj);
				memoryStream.Seek(0, SeekOrigin.Begin);

				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}
	}
}