// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-05-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-05-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.IO;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
    /// <summary>
    /// Indicates that a class can serialize and deserialize abjects in an XML format.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="object"/> being serialized.</typeparam>
    public interface IXmlRepository<T>
    {
        /// <summary>
        /// Serializes the object to an XML file using the specified stream.
        /// </summary>
        /// <param name="stream">The stream to the specified location and mode.</param>
        /// <param name="obj">The object to be serialized.</param>
        void Serialize(Stream stream, T obj);

        /// <summary>
        /// Deserializes an XML file using the specified stream.
        /// </summary>
        /// <param name="stream">The stream to the specified file and mode.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialize(Stream stream);
    }
}