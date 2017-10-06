// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 09-18-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-18-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using NRTyler.CodeLibrary.Interfaces.Generic;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.Abstract
{
    /// <summary>
    /// A base class that holds helpful properties and essential methods that help any class having to deal with the serialization and deserialization of objects.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of <see cref="object"/> this repository will be working with.</typeparam>
    /// <seealso cref="NRTyler.CodeLibrary.Interfaces.Generic.IRepository{T}" />
    public abstract class BaseRepository<T> : IRepository<T>
    {
        /// <summary>
        /// Gets the outer <see cref="Exception"/> error message.
        /// </summary>
        public virtual string OuterMessage { get; protected set; } = String.Empty;

        /// <summary>
        /// Gets the inner <see cref="Exception"/> error message.
        /// </summary>
        public virtual string InnerMessage { get; protected set; } = String.Empty;

        #region Implementation of IRepository<T>

        /// <summary>
        /// Serializes the <see cref="object"/> to a file in binary format using the specified <see cref="Stream" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream">The <see cref="Stream" /> to the specified location and mode.</param>
        /// <param name="obj">The <see cref="object" /> to be serialized.</param>
        /// <exception cref="System.ArgumentNullException">The <see cref="object"/> being serialized cannot be null!</exception>
        /// <exception cref="System.ArgumentException">The <see cref="object"/> being serialized must be serializable! Who would've guessed!</exception>
        public virtual void Serialize(Stream stream, T obj)
        {
            var binaryFormatter = new BinaryFormatter();

            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "The object being serialized cannot be null!");

            if (!obj.GetType().IsSerializable)
                throw new ArgumentException("The object being serialized must be serializable! Who would've guessed!", nameof(obj));

            using (stream)
            {
                try
                {
                    binaryFormatter.Serialize(stream, obj);
                }
                catch (SerializationException e)
                {
                    ErrorLog(e);
                    throw;
                }
                catch (SecurityException e)
                {
                    ErrorLog(e);
                }
                catch (Exception e)
                {
                    ErrorLog(e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Deserializes a file saved in binary format using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to the specified file and mode.</param>
        /// <returns>The deserialized object.</returns>
        public virtual T Deserialize(Stream stream)
        {
            var binaryFormatter = new BinaryFormatter();
            var obj = default(T);

            using (stream)
            {
                try
                {
                    obj = (T)binaryFormatter.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    ErrorLog(e);
                    throw;
                }
                catch (SecurityException e)
                {
                    ErrorLog(e);
                }
                catch (ArgumentNullException e)
                {
                    ErrorLog(e);
                }

                return obj;
            }
        }

        #endregion

        /// <summary>
        /// Handles logging any exceptions that may occur and also updates the publicly accessible error messages.
        /// </summary>
        /// <param name="exception">The exception that's being logged.</param>
        protected virtual void ErrorLog(Exception exception)
        {
            var info     = exception.LogExceptionInfo();
            OuterMessage = info.Item1;
            InnerMessage = info.Item2;
        }
    }
}