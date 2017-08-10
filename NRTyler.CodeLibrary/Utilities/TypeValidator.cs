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
using System.Collections;
using System.Collections.Generic;

namespace NRTyler.CodeLibrary.Utilities
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
		public static IList ApprovedTypes { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the type passed was on the 'ApprovedTypes' list.
		/// </summary>
		public static bool CorrectType { get; private set; }

		/// <summary>
		/// Compare the type that's passed to the list of 'ApprovedTypes'. If the passed type is not on the
		/// list, an <see cref="ArgumentException"/> will be thrown, otherwise it will fall straight through.
		/// </summary>
		/// <param name="approvedTypes">An <see cref="IList"/> containing the approved types.</param>
		/// <param name="type">The type to compare.</param>
		/// <param name="exceptionMessage">The message that you want the <see cref="ArgumentException"/> to include.</param>
		/// <exception cref="ArgumentException"></exception>
		public static void ValidateType(IList approvedTypes, Type type, string exceptionMessage)
		{
			CorrectType   = false;		
			ApprovedTypes = approvedTypes;

			if (ApprovedTypes.Contains(type)) CorrectType = true;

			if (!CorrectType)
				throw new ArgumentException(exceptionMessage);
		}

		/// <summary>
		/// Compare the type that's passed to the list of 'ApprovedTypes'. If the passed type is not on the
		/// list, an <see cref="ArgumentException"/> will be thrown, otherwise it will fall straight through.
		/// </summary>
		/// <param name="approvedTypes">An <see cref="IList"/> containing the approved types.</param>
		/// <param name="type">The type to compare.</param>
		/// <exception cref="ArgumentException"></exception>
		public static void ValidateType(IList approvedTypes, Type type)
		{
			ValidateType(approvedTypes, type, $"The type, '{type}' , is not valid for this operation. Try a different type.");
		}
	}
}