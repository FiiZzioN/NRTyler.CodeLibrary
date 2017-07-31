// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-31-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-31-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Interfaces
{
	/// <summary>
	/// This interface combines both the <see cref="IFormatProvider"/> and <see cref="ICustomFormatter"/> interfaces to create a single reference point when making custom formats.
	/// </summary>
	/// <seealso cref="System.IFormatProvider" />
	/// <seealso cref="System.ICustomFormatter" />
	public interface ICustomFormatProvider : IFormatProvider, ICustomFormatter
	{
		// Nothing to see under the hood here. This interface is used to help
		// make the process of creating a format just a tad bit easier since 
		// everything is all under one hood. If you understand how inheritance
		// works, then you'll know that this won't affect how methods interact
		// with this type.
	}
}