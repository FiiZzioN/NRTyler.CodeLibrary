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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using NRTyler.CodeLibrary.Interfaces.Generic;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Holds essential methods that help with the serialization and deserialization of objects.
    /// </summary>
    public class Repository<T> : IRepository<T>
    {
        #region Static Methods

        /// <summary>
        /// Serializes the <see cref="object"/> to a file in binary format using
        /// the specified <see cref="Stream"/> using a basic serialization process.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to the specified location and mode.</param>
        /// <param name="obj">The <see cref="object" /> to be serialized.</param>
        /// <exception cref="System.ArgumentNullException">The <see cref="object"/> being serialized cannot be null!</exception>
        /// <exception cref="System.ArgumentException">The <see cref="object"/> being serialized must be serializable!</exception>
        public static void StaticSerialization(Stream stream, T obj)
        {
            // Checking to see if the object is valid. It cannot be null and it MUST be serializable.
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "The object being serialized cannot be null!");

            if (!obj.GetType().IsSerializable)
                throw new ArgumentException("The object being serialized must be serializable! Who would've guessed!", nameof(obj));

            var binaryFormatter = new BinaryFormatter();

            using (stream)
            {
                try
                {
                    // Serialize object using the specified stream.
                    binaryFormatter.Serialize(stream, obj);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (SecurityException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Deserializes a file saved in a binary format using the specified <see cref="Stream"/>  using a basic deserialization process.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to the specified file and mode.</param>
        /// <returns>The deserialized <see cref="object"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <see cref="Stream"/> being used cannot be null!</exception>
        public static T StaticDeserialization(Stream stream)
        {
            // Checking to see if the stream is null.
            if (stream == null)
                throw new ArgumentNullException(nameof(stream), "The stream being used cannot be null!");

            var binaryFormatter = new BinaryFormatter();
            var obj = default(T);

            using (stream)
            {
                try
                {
                    // Deserialize object using the specified stream.
                    obj = (T)binaryFormatter.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (SecurityException e)
                {
                    Console.WriteLine(e);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                }

                return obj;
            }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Serializes the <see cref="object"/> to a file in binary format 
        /// using the specified <see cref="Stream" />. This method can be overridden.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to the specified location and mode.</param>
        /// <param name="obj">The <see cref="object" /> to be serialized.</param>
        /// <exception cref="System.ArgumentNullException">The <see cref="object"/> being serialized cannot be null!</exception>
        /// <exception cref="System.ArgumentException">The <see cref="object"/> being serialized must be serializable!</exception>
        public virtual void Serialize(Stream stream, T obj)
        {
            // Checking to see if the object is valid. It cannot be null and it MUST be serializable.
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "The object being serialized cannot be null!");

            if (!obj.GetType().IsSerializable)
                throw new ArgumentException("The object being serialized must be serializable! Who would've guessed!", nameof(obj));

            var binaryFormatter = new BinaryFormatter();

            using (stream)
            {
                try
                {
                    // Serialize object using the specified stream.
                    binaryFormatter.Serialize(stream, obj);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (SecurityException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Deserializes a file saved in a binary format using the specified <see cref="Stream"/>. This method can be overridden.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to the specified file and mode.</param>
        /// <returns>The deserialized <see cref="object"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <see cref="Stream"/> being used cannot be null!</exception>
        public virtual T Deserialize(Stream stream)
        {
            // Checking to see if the stream is null.
            if (stream == null)
                throw new ArgumentNullException(nameof(stream), "The stream being used cannot be null!");

            var binaryFormatter = new BinaryFormatter();
            var obj = default(T);

            using (stream)
            {
                try
                {
                    // Deserialize object using the specified stream.
                    obj = (T)binaryFormatter.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (SecurityException e)
                {
                    Console.WriteLine(e);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                }

                return obj;
            }
        }
        #endregion
    }
}