// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 12-22-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-22-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
    /// <summary>
    /// Interface that holds the basic properties and methods required to
    /// make a repository that utilizes the <see cref="DataContractSerializer"/>.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the <see cref="object"/> being serialized.</typeparam>
    /// <seealso cref="NRTyler.CodeLibrary.Interfaces.Generic.IRepository{T}" />
    public interface IDataContractRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Gets or sets the data contract serializer.
        /// </summary>
        DataContractSerializer DCSerializer { get; set; }
    }
}