// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 01-05-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 01-05-2018
// 
// License          : MIT License
// ***********************************************************************

namespace NRTyler.CodeLibrary.Interfaces.Generic
{
    /// <summary>
    /// Indicates that a repository implements the standard Create, Retrieve, Update, and Delete methods. 
    /// </summary>
    /// <typeparam name="T">The type that this repository is meant to work with.</typeparam>
    public interface ICrudRepository<T> where T : class
    {
        /// <summary>
        /// Creates the specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/>.</param>
        void Create(T obj);

        /// <summary>
        /// Retrieves an <see cref="object"/> with the specified key.
        /// </summary>
        /// <param name="key">The <see cref="object"/>'s key.</param>
        /// <returns>T.</returns>
        T Retrieve(string key);

        /// <summary>
        /// Updates the specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/>.</param>
        void Update(T obj);

        /// <summary>
        /// Deletes the <see cref="object"/> with the specified key.
        /// </summary>
        /// <param name="key">The <see cref="object"/>'s key.</param>
        void Delete(string key);

    }
}