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
	public static class TypeValidator
	{
		public static List<Type> ApprovedTypes { get; set; }

		public static bool CorrectType { get; private set; } = false;


		public static void ValidateType(Type type)
		{
			foreach (var i in ApprovedTypes)
			{
				if (type == i) CorrectType = true;
			}

			if (!CorrectType) throw new ArgumentException($"The type, '{type}' , is not valid for this operation. Try a different type.");
		}
	}
}