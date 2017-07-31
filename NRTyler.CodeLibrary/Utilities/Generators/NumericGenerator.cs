// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-31-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections.Generic;
using NRTyler.CodeLibrary.ExtensionMethods;
using NRTyler.CodeLibrary.Utilities.Assistants;

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
		public static int Integer(int minValue, int maxValue)
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
	    public static double Double(double minValue, double maxValue)
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
	    public static byte Byte(byte minValue, byte maxValue)
	    {
		    VerifyParameters(minValue, maxValue);

		    return Randomizer.Byte(minValue, maxValue);
	    }

	    /// <summary>
	    /// Ensures that a method has been passed a type that it can work with.
	    /// </summary>
	    /// <param name="type">The type to check against.</param>
	    private static void ValidateType(Type type)
	    {
			TypeValidator.ApprovedTypes = ApprovedTypes;
			TypeValidator.ValidateType(type);
	    }

		#endregion

	    /// <summary>
	    /// Generates a random, positive numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <exception cref="ArgumentException"></exception>
	    public static T GenerateValue<T>()
	    {
			ValidateType(typeof(T));

		    if (typeof(T) == typeof(double))
		    {
				dynamic dynamicDouble = Double(0, System.Double.MaxValue);
			    return dynamicDouble;
		    }

		    if (typeof(T) == typeof(byte))
		    {
				dynamic dynamicByte = Byte(0, System.Byte.MaxValue);
			    return dynamicByte;
			}

			dynamic dynamicInt = Integer(0, Int32.MaxValue);
		    return dynamicInt;
	    }

		/// <summary>
		/// Generates a random, positive numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
		/// </summary>
		/// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
		/// <param name="maxValue">The maximum value to generate.</param>
		/// <exception cref="ArgumentException"></exception>
		public static T GenerateValue<T>(T maxValue)
	    {
		    dynamic maximum = maxValue;
		    return GenerateValue(0, maximum);
	    }

		/// <summary>
		/// Generates a random numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
		/// </summary>
		/// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
		/// <param name="minValue">The minimum value to generate.</param>
		/// <param name="maxValue">The maximum value to generate.</param>
		/// <exception cref="ArgumentException"></exception>
		public static T GenerateValue<T>(T minValue, T maxValue)
	    {
		    ValidateType(typeof(T));
		    VerifyParameters(minValue, maxValue);

		    dynamic maximum = maxValue;
			dynamic minimum = minValue;

		    if (typeof(T) == typeof(double)) return Double(minimum, maximum);

		    if (typeof(T) == typeof(byte)) return Byte(minimum, maximum);

			return Integer(minimum, maximum);
		}

	    /// <summary>
	    /// Generates a random numeric value. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
	    /// <param name="paramBundle">The <see cref="ParameterBundle{T}"/> object to use for generation.</param>
	    /// <exception cref="ArgumentException"></exception>
	    public static T GenerateValue<T>(ParameterBundle<T> paramBundle)
	    {
		    return GenerateValue(paramBundle.MinValue, paramBundle.MaxValue);
	    }

	    /// <summary>
	    /// Generates an array of random, positive numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
	    /// <param name="arraySize">The size of the array.</param>
	    /// <exception cref="ArgumentException"></exception>
	    public static T[] GenerateArray<T>(int arraySize)
	    {
			ValidateType(typeof(T));

		    if (typeof(T) == typeof(double))
		    {
			    dynamic dynamicDouble = GenerateArray(0, System.Double.MaxValue, arraySize);
			    return dynamicDouble;
		    }

		    if (typeof(T) == typeof(byte))
		    {
			    dynamic dynamicByte = GenerateArray(0, System.Byte.MaxValue, arraySize);
			    return dynamicByte;
		    }

		    dynamic dynamicInt = GenerateArray(0, System.Int32.MaxValue, arraySize);
		    return dynamicInt;
	    }

	    /// <summary>
	    /// Generates an array of random, positive numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
	    /// <param name="maxValue">The maximum value to generate..</param>
	    /// <param name="arraySize">The size of the array.</param>
	    /// <exception cref="ArgumentException"></exception>
	    public static T[] GenerateArray<T>(T maxValue, int arraySize)
	    {
		    dynamic maximum = maxValue;
		    return GenerateArray(0, maximum, arraySize);
	    }

	    /// <summary>
	    /// Generates an array of random numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
	    /// </summary>
	    /// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
	    /// <param name="minValue">The minimum value to generate.</param>
	    /// <param name="maxValue">The maximum value to generate..</param>
	    /// <param name="arraySize">The size of the array.</param>
	    /// <exception cref="ArgumentException"></exception>
	    public static T[] GenerateArray<T>(T minValue, T maxValue, int arraySize)
	    {
		    ValidateType(typeof(T));
		    VerifyParameters(minValue, maxValue, arraySize);

		    dynamic minimum = minValue;
		    dynamic maximum = maxValue;

		    var array = new T[arraySize];

		    for (var i = 0; i < array.Length; i++)
		    {
			    array[i] = GenerateValue(minimum, maximum);
		    }

		    return array;
	    }

		/// <summary>
		/// Generates an array of random numeric values. Valid types include <see cref="byte"/>, <see cref="int"/>, and <see cref="double"/>.
		/// </summary>
		/// <typeparam name="T">Must be a <see cref="byte"/>, <see cref="int"/>, or <see cref="double"/>.</typeparam>
		/// <param name="paramBundle">The <see cref="ParameterBundle{T}"/> object to use for generation.</param>
		/// <exception cref="ArgumentException"></exception>
		public static T[] GenerateArray<T>(ParameterBundle<T> paramBundle)
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
		public static Tuple<T,T[]> TandemGeneration<T>(ParameterBundle<T> paramBundle)
        {
			VerifyParameters(paramBundle);

            dynamic dynamicBundle = paramBundle;

            var value = GenerateValue(dynamicBundle.MinValue, dynamicBundle.MaxValue);
	        var array = GenerateArray(dynamicBundle.MinValue, dynamicBundle.MaxValue, dynamicBundle.ArraySize);

            return new Tuple<T, T[]>(value, array);
        }

		#region VerifyParameter Methods

		/// <summary>
		/// Verifies that a method's <see cref="ParameterBundle{T}"/> was entered correctly and is capable of generating valid value(s).
		/// </summary>
		/// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static void VerifyParameters<T>(ParameterBundle<T> paramBundle)
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
		private static void VerifyParameters<T>(T minValue, T maxValue, int arraySize = 0)
	    {
			// Converting the parameters to a dynamic value allows them to be compared.
		    dynamic minimum = minValue;
		    dynamic maximum = maxValue;

			// Makes sure the minimum is less than the maximum.
			if (minimum > maximum)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(minValue)}' cannot be greater than its '{nameof(maxValue)}'!");

			// An array cannot be less than zero.
		    if (arraySize < 0)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(arraySize)}' cannot be less than zero!");
	    }

		#endregion

		#region Depreciated Methods

	    #region Integer Methods

	    /* Depreciated

			    /// <summary>
			    /// Returns a random positive integer.
			    /// </summary>
			    /// <returns>System.Int32.</returns>
			    public static int Integer()
			    {
				    return Randomizer.Next();
			    }

			    /// <summary>
			    /// Returns a random positive integer that is less than the specified maximum.
			    /// </summary>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <returns>System.Int32.</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static int Integer(int maxValue)
			    {
				    VerifyParameters(maxValue);

				    return Randomizer.Next(maxValue);
			    }


			    /// <summary>
			    /// Returns a random positive integer array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="arraySize">The amount of item(s) in the array.</param>
			    /// <returns>System.Int32[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static int[] IntegerArray(int arraySize)
			    {
				    VerifyParameters(arraySize);

				    var array = new int[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Randomizer.Next();
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random positive integer array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <param name="arraySize">The amount of item(s) in the array.</param>
			    /// <returns>System.Int32[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static int[] IntegerArray(int maxValue, int arraySize)
			    {
				    VerifyParameters(maxValue, arraySize);

				    var array = new int[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Randomizer.Next(maxValue);
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random integer array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="minValue">The minimum value.</param>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <param name="arraySize">The amount of item(s) in the array.</param>
			    /// <returns>System.Int32[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static int[] IntegerArray(int minValue, int maxValue, int arraySize)
			    {
				    VerifyParameters(minValue, maxValue, arraySize);

				    var array = new int[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Randomizer.Next(minValue, maxValue);
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random integer that is within the specified range.
			    /// </summary>
			    /// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
			    /// <returns>System.Int32.</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static int Integer(ParameterBundle<int> paramBundle)
			    {
				    VerifyParameters(paramBundle);

				    return Integer(paramBundle.MinValue, paramBundle.MaxValue);
			    }

			    /// <summary>
			    /// Returns a random integer array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
			    /// <returns>System.Int32[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static int[] IntegerArray(ParameterBundle<int> paramBundle)
			    {
				    VerifyParameters(paramBundle);

				    return IntegerArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
			    }

	    */

	    #endregion

	    #region Double Methods

	    /* Depreciated

			    /// <summary>
			    /// Returns a double ranging between 0.0 and 1.0.
			    /// </summary>
			    /// <returns>System.Double.</returns>
			    public static double Double()
			    {
				    return Randomizer.NextDouble();
			    }

			    /// <summary>
			    /// Returns a double that's less than the specified maximum.
			    /// </summary>
			    /// <returns>System.Double.</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static double Double(double maxValue)
			    {
				    VerifyParameters(maxValue);

				    return Randomizer.NextDouble(0, maxValue);
			    }

			    /// <summary>
			    /// Returns a random positive double array with item(s) ranging between 0.0 and 1.0.
			    /// </summary>
			    /// <param name="arraySize">The amount item(s) that should be in the array.</param>
			    /// <returns>System.Double[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static double[] DoubleArray(int arraySize)
			    {
				    VerifyParameters(arraySize);

				    var array = new double[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Double();
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random positive double array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <param name="arraySize">The amount item(s) that should be in the array.</param>
			    /// <returns>System.Double[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static double[] DoubleArray(double maxValue, int arraySize)
			    {
				    VerifyParameters(maxValue, arraySize);

				    var array = new double[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Double(maxValue);
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random double array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="minValue">The minimum value.</param>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <param name="arraySize">The amount item(s) that should be in the array.</param>
			    /// <returns>System.Double[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static double[] DoubleArray(double minValue, double maxValue, int arraySize)
			    {
				    VerifyParameters(minValue, maxValue, arraySize);

				    var array = new double[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Double(minValue, maxValue);
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random double that's within the specified range.
			    /// </summary>
			    /// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
			    /// <returns>System.Double.</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static double Double(ParameterBundle<double> paramBundle)
			    {
				    VerifyParameters(paramBundle);

				    return Double(paramBundle.MinValue, paramBundle.MaxValue);
			    }

			    /// <summary>
			    /// Returns a random double array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
			    /// <returns>System.Double[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static double[] DoubleArray(ParameterBundle<double> paramBundle)
			    {
				    VerifyParameters(paramBundle);

				    return DoubleArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
			    }

			    */

	    #endregion

	    #region Byte Methods

	    /* Depreciated

			    /// <summary>
			    /// Returns a random byte ranging between 0 and 255.
			    /// </summary>
			    /// <returns>System.Byte.</returns>
			    public static byte Byte()
			    {
				    return Randomizer.Byte(byte.MinValue, byte.MaxValue);
			    }

			    /// <summary>
			    /// Returns a random byte that's between 0 and the specified maximum value.
			    /// </summary>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <returns>System.Byte.</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static byte Byte(byte maxValue)
			    {
				    VerifyParameters(maxValue);

				    return Randomizer.Byte(byte.MinValue, maxValue);
			    }

			    /// <summary>
			    /// Returns a random byte array that contains item(s) between 0 and 255.
			    /// </summary>
			    /// <param name="arraySize">The amount item(s) that should be in the array.</param>
			    /// <returns>System.Byte[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static byte[] ByteArray(int arraySize)
			    {
				    VerifyParameters(arraySize);

				    var array = new byte[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Byte();
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random byte array that contains item(s) between 0 and the specified maximum value.
			    /// </summary>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <param name="arraySize">The amount item(s) that should be in the array.</param>
			    /// <returns>System.Byte[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static byte[] ByteArray(byte maxValue, int arraySize)
			    {
				    VerifyParameters(maxValue, arraySize);

				    var array = new byte[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Byte(maxValue);
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random byte array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="minValue">The minimum value.</param>
			    /// <param name="maxValue">The maximum value.</param>
			    /// <param name="arraySize">The amount item(s) that should be in the array.</param>
			    /// <returns>System.Byte[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static byte[] ByteArray(byte minValue, byte maxValue, int arraySize)
			    {
				    VerifyParameters(minValue, maxValue, arraySize);

				    var array = new byte[arraySize];

				    for (var i = 0; i < array.Length; i++)
				    {
					    array[i] = Byte(minValue, maxValue);
				    }

				    return array;
			    }

			    /// <summary>
			    /// Returns a random byte that's within the specified range.
			    /// </summary>
			    /// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
			    /// <returns>System.Byte.</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static byte Byte(ParameterBundle<byte> paramBundle)
			    {
				    VerifyParameters(paramBundle);

				    return Randomizer.Byte(paramBundle.MinValue, paramBundle.MaxValue);
			    }


			    /// <summary>
			    /// Returns a random byte array that contains item(s) within the specified range.
			    /// </summary>
			    /// <param name="paramBundle">A <see cref="ParameterBundle{T}"/> object that holds the values that are used to generate the random values.</param>
			    /// <returns>System.Byte[].</returns>
			    /// <exception cref="ArgumentOutOfRangeException"></exception>
			    public static byte[] ByteArray(ParameterBundle<byte> paramBundle)
			    {
				    VerifyParameters(paramBundle);

				    return ByteArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
			    }

	    */

	    #endregion

	    #endregion
	}
}
