// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 11-03-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 11-08-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using NRTyler.CodeLibrary.Interfaces.Generic;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// A base class that can be used on its own, or to provide a solid foundation for
    /// any repository planning on using the <see cref="DataContractSerializer" /> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type" /> of the <see cref="object" /> being dealt with.</typeparam>
    /// <seealso cref="NRTyler.CodeLibrary.Interfaces.Generic.IRepository{T}" />
    public class DataContractXmlRepository<T> : IRepository<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContractXmlRepository{T}"/> class.
        /// </summary>
        public DataContractXmlRepository() 
            : this(null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContractXmlRepository{T}"/> class.
        /// </summary>
        /// <param name="dataContractSerializerSettings">The data contract serializer settings that the <see cref="DataContractSerializer"/> will use.</param>
        public DataContractXmlRepository(DataContractSerializerSettings dataContractSerializerSettings) 
            : this(dataContractSerializerSettings, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContractXmlRepository{T}"/> class.
        /// </summary>
        /// <param name="dataContractSerializerSettings">The data contract serializer settings that the <see cref="DataContractSerializer"/> will use.</param>
        /// <param name="xmlWriterSettings">The XML writer settings that the <see cref="System.Xml.XmlWriter"/> will use.</param>
        public DataContractXmlRepository(DataContractSerializerSettings dataContractSerializerSettings, XmlWriterSettings xmlWriterSettings) 
            : this(dataContractSerializerSettings, xmlWriterSettings, null) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="DataContractXmlRepository{T}"/> class.
        /// </summary>
        /// <param name="dataContractSerializerSettings">The data contract serializer settings that the <see cref="DataContractSerializer"/> will use.</param>
        /// <param name="xmlWriterSettings">The XML writer settings that the <see cref="System.Xml.XmlWriter"/> will use.</param>
        /// <param name="xmlReaderSettings">The XML reader settings that the <see cref="System.Xml.XmlReader"/> will use.</param>
        public DataContractXmlRepository(DataContractSerializerSettings dataContractSerializerSettings, XmlWriterSettings xmlWriterSettings, XmlReaderSettings xmlReaderSettings)
        {
            InitializeClass(dataContractSerializerSettings, xmlWriterSettings, xmlReaderSettings);
        }

        #endregion

        #region Fields

        private DataContractSerializerSettings dcSerializerSettings;
        private XmlWriterSettings writerSettings;
        private XmlReaderSettings readerSettings;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the data contract serializer.
        /// </summary>
        protected virtual DataContractSerializer DCSerializer { get; set; }

        /// <summary>
        /// Gets or sets the data contract serializer settings that are used by a <see cref="DataContractSerializer"/>.
        /// </summary>
        protected virtual DataContractSerializerSettings DCSerializerSettings
        {
            get
            {
                return this.dcSerializerSettings ?? (this.dcSerializerSettings = new DataContractSerializerSettings());                 
            }
            set { this.dcSerializerSettings = value; }
        }

        /// <summary>
        /// Gets or sets the XML writer that's used to write '.xml' files. 
        /// Be aware that if this isn't set to an instance of the <see cref="XmlWriter"/> 
        /// class before attempting to be used, a <see cref="NullReferenceException"/> will be thrown!
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// If this isn't set to an instance of the <see cref="XmlWriter"/> class 
        /// before attempting to be used, a <see cref="NullReferenceException"/> will be thrown!
        /// </exception>
        protected virtual XmlWriter Writer { get; set; }

        /// <summary>
        /// Gets or sets the XML writer settings that are used by an <see cref="System.Xml.XmlWriter"/>.
        /// </summary>
        protected virtual XmlWriterSettings WriterSettings
        {
            get
            {
                return this.writerSettings ?? (this.writerSettings = new XmlWriterSettings());
            }
            set { this.writerSettings = value; }
        }

        /// <summary>
        /// Gets or sets the XML reader that's used to read '.xml' files. 
        /// Be aware that if this isn't set to an instance of the <see cref="XmlReader"/> 
        /// class before attempting to be used, a <see cref="NullReferenceException"/> will be thrown!
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// If this isn't set to an instance of the <see cref="XmlReader"/> class 
        /// before attempting to be used, a <see cref="NullReferenceException"/> will be thrown!
        /// </exception>
        protected virtual XmlReader Reader { get; set; }

        /// <summary>
        /// Gets or sets the XML reader settings that are used by an <see cref="System.Xml.XmlReader"/>.
        /// </summary>
        protected virtual XmlReaderSettings ReaderSettings
        {
            get
            {
                return this.readerSettings ?? (this.readerSettings = new XmlReaderSettings());
            }
            set { this.readerSettings = value; }
        }

        #endregion

        /// <summary>
        /// Serializes the <see cref="object" /> to a file using the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to the specified location and what <see cref="FileMode" /> it's using.</param>
        /// <param name="obj">The <see cref="object" /> being serialized.</param>
        /// <exception cref="ArgumentNullException">stream - The stream being used can't be null!</exception>
        /// <exception cref="ArgumentNullException">obj - The object being serialized can't be null!</exception>
        public virtual void Serialize(Stream stream, T obj)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream), "The stream being used can't be null!");
            if (obj == null) throw new ArgumentNullException(nameof(obj), "The object being serialized can't be null!");

            using (stream)
            {
                try
                {
                    DCSerializer.WriteObject(stream, obj);
                }
                catch (InvalidDataContractException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Deserializes a file using the specified <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to the specified file and what <see cref="FileMode" /> it's using.</param>
        /// <returns>The deserialized <see cref="object" />.</returns>
        /// <exception cref="ArgumentNullException">stream - The stream being used can't be null!</exception>
        public virtual T Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream), "The stream being used can't be null!");

            using (stream)
            {
                return (T)DCSerializer.ReadObject(stream);
            }
        }
        
        /// <summary>
        /// The method that's used in the constructors to initialize the class.
        /// </summary>
        /// <param name="dataContractSerializerSettings">The data contract serializer settings that the <see cref="DataContractSerializer"/> will use.</param>
        /// <param name="writerSettings">The XML writer settings that the <see cref="XmlWriter"/> will use.</param>
        /// <param name="readerSettings">The XML reader settings that the <see cref="XmlReader"/> will use.</param>
        private void InitializeClass(DataContractSerializerSettings dataContractSerializerSettings, XmlWriterSettings writerSettings, XmlReaderSettings readerSettings)
        {
            #region Null Checks
            
            // Done this way so lazy loading is still actually useful.

            if (dataContractSerializerSettings != null)
            {
                DCSerializerSettings = dataContractSerializerSettings;
            }

            if (writerSettings != null)
            {
                WriterSettings = writerSettings;
            }

            if (readerSettings != null)
            {
                ReaderSettings = readerSettings;
            } 
            #endregion

            // If we don't explicitly specify the settings that the DataContractSerializer will use, then let it use its own settings.
            if (dataContractSerializerSettings == null)
            {
                DCSerializer = new DataContractSerializer(typeof(T));
                return;
            }

            DCSerializer = new DataContractSerializer(typeof(T), DCSerializerSettings);
        }
    }
}