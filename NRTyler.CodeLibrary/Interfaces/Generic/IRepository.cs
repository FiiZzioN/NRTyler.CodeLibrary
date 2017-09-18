// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-13-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
	/// <summary>
	/// Indicates that a class can serialize and deserialize abjects.
	/// </summary>
	public interface IRepository<T>
	{
	    /// <summary>
	    /// Gets the outer <see cref="Exception"/> error message.
	    /// </summary>
        string OuterMessage { get; }

	    /// <summary>
	    /// Gets the inner <see cref="Exception"/> error message.
	    /// </summary>
        string InnerMessage { get; }

        /// <summary>
        /// Serializes the object to a file in binary format using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to the specified location and mode.</param>
        /// <param name="obj">The <see cref="object"/> to be serialized.</param>
        void Serialize(Stream stream, T obj);

	    /// <summary>
	    /// Deserializes a file saved in binary format using the specified <see cref="Stream"/>.
	    /// </summary>
	    /// <param name="stream">The <see cref="Stream"/> to the specified file and mode.</param>
	    /// <returns>The deserialized object.</returns>
        T Deserialize(Stream stream);
	}
}