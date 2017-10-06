// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-18-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-01-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
    /// <summary>
    /// Indicates that a class can serialize and deserialize abjects.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the <see cref="object"/>.</typeparam>
    /// <seealso cref="NRTyler.CodeLibrary.Interfaces.Generic.ICanSerialize{T}" />
    /// <seealso cref="NRTyler.CodeLibrary.Interfaces.Generic.ICanDeserialize{T}" />
    public interface IRepository<T> : ICanSerialize<T>, ICanDeserialize<T>
	{

	}
}