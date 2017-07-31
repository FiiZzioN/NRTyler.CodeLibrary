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
using System.Collections.Generic;

namespace NRTyler.CodeLibrary.Utilities.Assistants
{
	/// <summary>
	/// When passing or returning a value, this checks to see if it's an 'approved type'. If it's not an 
	/// 'approved type', an <see cref="ArgumentException"/> is thrown, otherwise it fall straight through.
	/// </summary>
	public static class TypeValidator
	{
		/// <summary>
		/// Gets or sets the list that holds the approved type(s).
		/// </summary>
		public static List<Type> ApprovedTypes { get; set; }

		/// <summary>
		/// Gets a value indicating whether the type passed was on the 'ApprovedTypes' list.
		/// </summary>
		public static bool CorrectType { get; private set; }


		/// <summary>
		/// Compare the type that's passed to the list of 'ApprovedTypes'. If the passed type is not on the
		/// list, an <see cref="ArgumentException"/> will be thrown, otherwise it will fall straight through.
		/// </summary>
		/// <param name="type">The type to compare.</param>
		/// <exception cref="ArgumentException"></exception>
		public static void ValidateType(Type type)
		{
			CorrectType = false;

			foreach (var i in ApprovedTypes)
			{
				if (type == i) CorrectType = true;
			}

			if (!CorrectType)
				throw new ArgumentException($"The type, '{type}' , is not valid for this operation. Try a different type.");
		}
	}
}