// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-28-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Utilities.Generators
{
	/// <summary>
	/// Class ParameterBundle.
	/// </summary>
	/// <typeparam name="T">The <see cref="Type"/> of values the <see cref="ParameterBundle{T}"/> will contain.</typeparam>
	public struct ParameterBundle<T>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterBundle{T}"/> class.
		/// </summary>
		/// <param name="maxValue">The maximum value to generate.</param>
		public ParameterBundle(T maxValue) : this()
		{
			MaxValue = maxValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterBundle{T}"/> class.
		/// </summary>
		/// <param name="minValue">The minimum value to generate.</param>
		/// <param name="maxValue">The maximum value to generate.</param>
		public ParameterBundle(T minValue, T maxValue) : this(minValue, maxValue, 0)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterBundle{T}"/> class.
		/// </summary>
		/// <param name="minValue">The minimum value to generate.</param>
		/// <param name="maxValue">The maximum value to generate.</param>
		/// <param name="arraySize">The amount of item(s) that should be in a generated array.</param>
		public ParameterBundle(T minValue, T maxValue, int arraySize) : this()
		{
			MinValue = minValue;
			MaxValue = maxValue;
			ArraySize = arraySize;
		}

		#endregion

		#region Backing Fields

		private T maxValue;
		private T minValue;
		private int arraySize;

		#endregion

		#region Properties

		/// <summary>
		/// The minimum value to generate.
		/// </summary>
		public T MinValue
		{
			get { return this.minValue; }
			set
			{
				this.minValue = value;
			}
		}

		/// <summary>
		/// The maximum value to generate.
		/// </summary>
		public T MaxValue
		{
			get { return this.maxValue; }
			set
			{
				this.maxValue = value;
			}
		}

		/// <summary>
		/// The amount of item(s) that should be in a generated array.
		/// </summary>
		public int ArraySize
		{
			get { return this.arraySize; }
			set
			{
				this.arraySize = value;
			}
		}

		#endregion
	}
}