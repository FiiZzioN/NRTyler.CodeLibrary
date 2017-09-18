﻿// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : CodeBureau
// Created          : 07-27-2015
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-18-2017
//
// License          : MIT License
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Attributes
{
    /// <summary>
    /// The <see cref="StringValueAttribute"/> allows an <see cref="Enum"/> to be assigned or referenced by a <see cref="string"/> using the <see cref="Attribute"/> class.
    /// </summary>
    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public StringValueAttribute(string value)
        {
            this._value = value;
        }

        /// <summary>
        /// The <see cref="string"/> value that was assigned.
        /// </summary>
        private string _value;

        /// <summary>
        /// Gets the <see cref="string"/> value that was assigned.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get { return this._value; }
        }

    }
}