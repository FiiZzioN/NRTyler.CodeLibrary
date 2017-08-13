// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-13-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Utilities
{
	/// <summary>
	/// Contains additional physical constants than the standard <see cref="Math"/> class implements. 
	/// This is useful when dealing with physics calculations.
	/// </summary>
	public static class ExtendedMathConstants
	{
		/// <summary>
		/// Standard Gravity: 9.80665 m/s2 |
		/// The standard acceleration due to gravity. 
		/// </summary>
		/// <remarks>
		/// More info here: http://enwp.org/Standard_gravity 
		/// </remarks>
		public const double ɡ = 9.80665;

		/// <summary>
		/// Speed of Light: 299,792,458 m/s2 |
		/// The speed of light in a vacuum.
		/// </summary>
		/// <remarks>
		/// More info here: http://enwp.org/Speed_of_light 
		/// </remarks>
		public const double c = 2.99792458e8;

		/// <summary>
		/// International Standard Atmosphere: 101,325 Pa |
		/// The International Standard Atmosphere is an atmospheric model of how the 
		/// Earth's atmosphere changes over a wide range of altitudes or elevations.
		/// </summary>
		/// <remarks>
		/// More info here: http://enwp.org/International_Standard_Atmosphere
		/// </remarks>
		public const double atm = 101325;
	}
}