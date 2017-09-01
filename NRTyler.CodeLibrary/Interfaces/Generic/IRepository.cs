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

using System.IO;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
	/// <summary>
	/// Indicates that a class can serialize and deserialize abjects.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T>
	{
		#region XML

		/// <summary>
		/// Serializes the object to an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		void SerializeToXML(Stream stream, T obj);

		/// <summary>
		/// Deserializes an XML file using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		T DeserializeFromXML(Stream stream);

		#endregion

		#region Binary

		/// <summary>
		/// Serializes the object to a file in binary format using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified location and mode.</param>
		/// <param name="obj">The object to be serialized.</param>
		void SerializeToBinary(Stream stream, T obj);

		/// <summary>
		/// Deserializes a file saved in binary format using the specified stream.
		/// </summary>
		/// <param name="stream">The stream to the specified file and mode.</param>
		/// <returns>The deserialized object.</returns>
		T DeserializeFromBinary(Stream stream);

		#endregion
	}
}