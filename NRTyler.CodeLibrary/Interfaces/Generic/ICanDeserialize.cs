// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 10-01-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-01-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
    /// <summary>
    /// Indicates than an <see cref="object"/> can be deserialized.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the <see cref="object"/>.</typeparam>
    public interface ICanDeserialize<T>
    {
        /// <summary>
        /// Deserializes a file saved in binary format using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to the specified file and mode.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialize(Stream stream);
    }
}