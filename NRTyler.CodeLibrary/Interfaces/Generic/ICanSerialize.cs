// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 10-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-26-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
    /// <summary>
    /// Indicates than an <see cref="object"/> can be serialized.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the <see cref="object"/>.</typeparam>
    public interface ICanSerialize<T>
    {
        /// <summary>
        /// Serializes the <see cref="object"/> to a file using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to the specified location and what <see cref="FileMode"/> it's using.</param>
        /// <param name="obj">The <see cref="object"/> being serialized.</param>
        void Serialize(Stream stream, T obj);
    }
}