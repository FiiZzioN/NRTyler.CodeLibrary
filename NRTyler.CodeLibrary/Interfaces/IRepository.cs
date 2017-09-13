// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-21-2017
//
// License          : MIT License
// ***********************************************************************

using System.IO;
using NRTyler.CodeLibrary.Annotations;

namespace NRTyler.CodeLibrary.Interfaces
{
	/// <summary>
	/// Indicates that a class can serialize and deserialize abjects.
	/// </summary>
	public interface IRepository
	{
		/// <summary>
		/// Serializes the object to a file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		void Serialize(Stream stream, [NotNull] object obj);

		/// <summary>
		/// Deserializes a file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		object Deserialize(Stream stream);
	}
}