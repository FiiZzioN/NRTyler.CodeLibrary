﻿// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 11-29-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.Utilities.Generators
{
    /// <summary>
    /// From single digits too arrays of any size, the <see cref="NumericGenerator"/> holds various methods to generate random <see cref="int"/>, <see cref="double"/>, and <see cref="byte"/> values.
    /// </summary>
    public static class NumericGenerator
    {
		// Instantiating a class-wide randomizer makes sure that if a user calls multiple generation methods
		// simultaneously, you don't get the same number since it stays on the same thread when it was called.
        private static Random Randomizer = new Random();

		// When calling any generation methods, they must be one of these types. If you want 
		// to add support for other types, go right ahead. Personally, I'm fine with just 
		// casting the return values should I need a different type.
		private static List<Type> ApprovedTypes = new List<Type> { typeof(byte), typeof(int), typeof(double) };

		#region Base Methods

		// These methods are the foundation of the class. All generation 
		// methods call at least one of these during execution.

		/// <summary>
		/// Returns a random integer that is within the specified range.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>System.Int32.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static int Integer(int minValue, int maxValue)
	    {
		    VerifyParameters(minValue, maxValue);

		    return Randomizer.Next(minValue, maxValue);
	    }

		/// <summary>
		/// Returns a random double that's within the specified range.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>System.Double.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static double Double(double minValue, double maxValue)
	    {
		    VerifyParameters(minValue, maxValue);

		    return Randomizer.NextDouble(minValue, maxValue);
	    }

		/// <summary>
		/// Returns a random byte that's within the specified range.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>System.Byte.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static byte Byte(byte minValue, byte maxValue)
	    {
		    VerifyParameters(minValue, maxValue);

		    return Randomizer.NextByte(minValue, maxValue);
	    }

	    /// <summary>
	    /// Ensures that a method has been passed a type that it can work with.
	    /// </summary>
	    /// <param name="type">The type to check against.</param>
	    public static void ValidateType(Type type)
	    {
		    var errorMessage = $"The type, '{type}' , is not valid for this operation. Try a different type.";

			TypeValidator.ValidateType(ApprovedTypes, type, errorMessage);
	    }

		#endregion

	    /// <summary>
	    /// Generates a random, positive numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <exception cref="ArgumentException"></exception>
	    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
	    public static T GenerateValue<T>() where T : struct, IComparable<T>
		{
			ValidateType(typeof(T));

			if (typeof(T) == typeof(byte))
			{
				var byteValue = Byte(0, System.Byte.MaxValue);

				return (T)Convert.ChangeType(byteValue, TypeCode.Byte);
			}

			if (typeof(T) == typeof(double))
			{
				var doubleValue = Double(0, System.Double.MaxValue);

				return (T)Convert.ChangeType(doubleValue, TypeCode.Double);
			}

			var integerValue = Integer(0, Int32.MaxValue);

			return (T)Convert.ChangeType(integerValue, TypeCode.Int32);
	    }

		/// <summary>
		/// Generates a random numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
		/// </summary>
		/// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
		/// <param name="minValue">The minimum value to generate.</param>
		/// <param name="maxValue">The maximum value to generate.</param>
		/// <exception cref="ArgumentException"></exception>
		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
		public static T GenerateValue<T>(T minValue, T maxValue) where T : struct, IComparable<T>
		{
			ValidateType(typeof(T));
			VerifyParameters(minValue, maxValue);

			if (typeof(T) == typeof(byte))
			{
				var byteMinimum = Convert.ToByte(minValue);
				var byteMaximum = Convert.ToByte(maxValue);
				var byteValue   = Byte(byteMinimum, byteMaximum);

				return (T)Convert.ChangeType(byteValue, TypeCode.Byte);
			}

			if (typeof(T) == typeof(double))
			{
				var doubleMinimum = Convert.ToDouble(minValue);
				var doubleMaximum = Convert.ToDouble(maxValue);
				var doubleValue   = Double(doubleMinimum, doubleMaximum);

				return (T)Convert.ChangeType(doubleValue, TypeCode.Double);
			}

			var integerMinimum = Convert.ToInt32(minValue);
			var integerMaximum = Convert.ToInt32(maxValue);
			var integerValue   = Integer(integerMinimum, integerMaximum);

			return (T)Convert.ChangeType(integerValue, TypeCode.Int32);
		}

	    /// <summary>
	    /// Generates a random numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
	    /// <param name="paramBundle">The <see cref="ParameterBundle{T}"/> object to use for generation.</param>
	    /// <exception cref="ArgumentException"></exception>
	    public static T GenerateValue<T>(ParameterBundle<T> paramBundle) where T : struct, IComparable<T>
		{
		    return GenerateValue(paramBundle.MinValue, paramBundle.MaxValue);
	    }

		/// <summary>
		/// Generates an array of random, positive numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
		/// </summary>
		/// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
		/// <param name="arraySize">The size of the array.</param>
		/// <exception cref="ArgumentException"></exception>
		public static T[] GenerateArray<T>(int arraySize) where T : struct, IComparable<T>
		{
			ValidateType(typeof(T));
			VerifyParameters(0, 0, arraySize);

			T[] genericArray;

			#region ByteArray

			if (typeof(T) == typeof(byte))
			{
				var byteArray = GenerateArray((byte)0, System.Byte.MaxValue, arraySize);
				genericArray = new T[byteArray.Length];

				// Copy values from the 'byteArray' to the 'genericArray'.
				for (var i = 0; i < byteArray.Length; i++)
				{
					genericArray[i] = (T)Convert.ChangeType(byteArray[i], typeof(T));
				}

				return genericArray;
			}

			#endregion

			#region DoubleArray

			if (typeof(T) == typeof(double))
			{
				var doubleArray = GenerateArray(0, System.Double.MaxValue, arraySize);
				genericArray = new T[doubleArray.Length];

				// Copy values from the 'doubleArray' to the 'genericArray'.
				for (var i = 0; i < doubleArray.Length; i++)
				{
					genericArray[i] = (T)Convert.ChangeType(doubleArray[i], typeof(T));
				}

				return genericArray;
			}

			#endregion

			#region IntegerArray

			var integerArray = GenerateArray(0, Int32.MaxValue, arraySize);
			genericArray = new T[integerArray.Length];

			// Copy values from the 'integerArray' to the 'genericArray'.
			for (var i = 0; i < integerArray.Length; i++)
			{
				genericArray[i] = (T)Convert.ChangeType(integerArray[i], typeof(T));
			}

			return genericArray;

			#endregion
		}

	    /// <summary>
	    /// Generates an array of random numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
	    /// <param name="minValue">The minimum value to generate.</param>
	    /// <param name="maxValue">The maximum value to generate..</param>
	    /// <param name="arraySize">The size of the array.</param>
	    /// <exception cref="ArgumentException"></exception>
	    public static T[] GenerateArray<T>(T minValue, T maxValue, int arraySize) where T : struct, IComparable<T>
		{
		    ValidateType(typeof(T));
		    VerifyParameters(minValue, maxValue, arraySize);

		    var array = new T[arraySize];

		    for (var i = 0; i < array.Length; i++)
		    {
			    array[i] = GenerateValue(minValue, maxValue);
		    }

		    return array;
	    }

		/// <summary>
		/// Generates an array of random numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
		/// </summary>
		/// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
		/// <param name="paramBundle">The <see cref="ParameterBundle{T}"/> object to use for generation.</param>
		/// <exception cref="ArgumentException"></exception>
		public static T[] GenerateArray<T>(ParameterBundle<T> paramBundle) where T : struct, IComparable<T>
		{
			return GenerateArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
	    }

		/// <summary>
		/// Generates a random numeric value, and an array of random numeric values of the same type. The values are generated using the information passed by a <see cref="ParameterBundle{T}" /> object.
		/// </summary>
		/// <typeparam name="T">This can be any numeric type, such as an <see cref="int" />, <see cref="double" />, or <see cref="byte" />.</typeparam>
		/// <param name="paramBundle">A <see cref="ParameterBundle{T}" /> object that holds the values that are used to generate the random values.</param>
		/// <returns>Tuple&lt;T, T[]&gt;.</returns>
		/// <exception cref="ArgumentException"></exception>
		public static Tuple<T,T[]> TandemGeneration<T>(ParameterBundle<T> paramBundle) where T : struct, IComparable<T>
		{
			VerifyParameters(paramBundle);

            var value = GenerateValue(paramBundle.MinValue, paramBundle.MaxValue);
	        var array = GenerateArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

            return new Tuple<T, T[]>(value, array);
        }

		#region VerifyParameter Methods

		/// <summary>
		/// Verifies that a method's <see cref="ParameterBundle{T}"/> was entered correctly and is capable of generating valid value(s).
		/// </summary>
		/// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static void VerifyParameters<T>(ParameterBundle<T> paramBundle) where T : struct, IComparable<T>
		{
			VerifyParameters(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
		}

		/// <summary>
		/// Verifies that a method's parameters were entered correctly and are capable of generating valid value(s).
		/// </summary>
		/// <typeparam name="T">The <see cref="Type"/> of the values being passed.</typeparam>
		/// <param name="minValue">The minimum value to generate.</param>
		/// <param name="maxValue">The maximum value to generate.</param>
		/// <param name="arraySize">The amount of item(s) that should be in the array.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static void VerifyParameters<T>(T minValue, T maxValue, int arraySize = 0) where T : IComparable<T>
		{
			// Makes sure the minimum is less than the maximum.
			//  < 0 = This object precedes the object specified by the CompareTo method in the sort order.
			// == 0 = This current instance occurs in the same position in the sort order as the object specified by the CompareTo method argument.
			//  > 0 = This current instance follows the object specified by the CompareTo method argument in the sort order.
			if (minValue.CompareTo(maxValue) > 0)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(minValue)}' cannot be greater than its '{nameof(maxValue)}'!");

			// An array cannot be less than zero.
		    if (arraySize < 0)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(arraySize)}' cannot be less than zero!");
	    }

		#endregion
	}
}
