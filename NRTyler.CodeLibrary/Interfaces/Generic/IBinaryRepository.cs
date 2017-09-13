// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-05-2017
//
// License          : MIT License
// ***********************************************************************

using System.IO;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
	/// <summary>
	/// Indicates that a class can serialize and deserialize abjects in a binary format.
	/// </summary>
	/// <typeparam name="T">The type of <see cref="object"/> being serialized.</typeparam>
	public interface IBinaryRepository<T>
	{
		/// <summary>
		/// Serializes the object to a file in binary format using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		void Serialize(Stream stream, T obj);

		/// <summary>
		/// Deserializes a file saved in binary format using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		T Deserialize(Stream stream);
	}
}