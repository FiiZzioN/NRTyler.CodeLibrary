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
using NRTyler.CodeLibrary.ExtensionMethods;

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

        #region Integer Methods

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
			VerifyParameters(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

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
            return IntegerArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
        }

        #endregion

        #region Double Methods

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
			VerifyParameters(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

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
			VerifyParameters(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

			return DoubleArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
        }

        #endregion

        #region Byte Methods

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
			VerifyParameters(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

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
			VerifyParameters(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);

			return ByteArray(paramBundle.MinValue, paramBundle.MaxValue, paramBundle.ArraySize);
        }

		#endregion

		#region Tandem Generation
		// This works, it just needs to be adapted to each other type, or it needs to be coded differently to be truly generic. I just don't see the benefit for the amount work, although simple, to do that.

		/*
        /// <summary>
        /// Generates a random numeric value, and an array of random numeric values of the same type. The values are generated using the information passed by a <see cref="GeneratorParameters{T}"/> object.
        /// </summary>
        /// <typeparam name="T">This can be any numeric type, such as an <see cref="int"/>, <see cref="double"/>, or <see cref="byte"/>.</typeparam>
        /// <param name="genParams">A <see cref="GeneratorParameters{T}"/> object that holds the values that are used to generate the random values.</param>
        /// <returns>MultipleValues&lt;T&gt;.</returns>
        public static MultipleValues<T> TandemGeneration<T>(GeneratorParameters<T> genParams)
        {
            dynamic dynamicParams = genParams;
            var multipleValues = new MultipleValues<T>();

            var integer = Double(dynamicParams.MinValue, dynamicParams.MaxValue);
            var array = DoubleArray(dynamicParams.MinValue, dynamicParams.MaxValue, dynamicParams.ArraySize);

            multipleValues.SingleValue = integer;
            multipleValues.ArrayValue = array;

            return multipleValues;
        } 
        */
		#endregion

	    #region VerifyParameter Methods

	    /// <summary>
	    /// Verifies that a method's parameters were entered correctly and are capable of generating valid value(s).
	    /// </summary>
	    /// <param name="arraySize">The amount of item(s) that should be in the array.</param>
	    /// <exception cref="ArgumentOutOfRangeException"></exception>
	    private static void VerifyParameters(int arraySize)
	    {
		    // The variable 'Zero' exists only because you can't pass an actual '0' as the minValue
		    // to another method. You also can't cast it to 'T' either. This was my way around it.
			dynamic zero = 0;

		    VerifyParameters(zero, zero, arraySize);
	    }

		/// <summary>
		/// Verifies that a method's parameters were entered correctly and are capable of generating valid value(s).
		/// </summary>
		/// <typeparam name="T">The <see cref="Type"/> of the values being passed.</typeparam>
		/// <param name="maxValue">The maximum value to generate.</param>
		/// <param name="arraySize">The amount of item(s) that should be in the array.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private static void VerifyParameters<T>(T maxValue, int arraySize = 0)
		{
			// Converting the parameters to a dynamic value allows them to be compared. The
			// variable 'Zero' exists only because you can't pass an actual '0' as the minValue
			// to another method. You also can't cast it to 'T' either. This was my way around it.
			dynamic zero = 0;
		    dynamic maximum = maxValue;

			// Makes sure the maxValue isn't negative so the generator can return its positive value.
		    if (maximum < 0)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(maxValue)}' must be greater than zero!");

		    VerifyParameters(zero, maxValue, arraySize);
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

			VerifyTypeMinMaxValues(minValue, maxValue);

			// Makes sure the minimum is less than the maximum.
			if (minimum > maximum)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(minValue)}' cannot be greater than its '{nameof(maxValue)}'!");

			// An array cannot be less than zero.
		    if (arraySize < 0)
			    throw new ArgumentOutOfRangeException($"A NumericGenerator's '{nameof(arraySize)}' cannot be less than zero!");
	    }

		/// <summary>
		/// Verifies that the minimum and maximum values input are within their respective type's minimum and maximum values. 
		/// </summary>
		/// <typeparam name="T">The <see cref="Type"/> of the values being passed.</typeparam>
		/// <param name="minValue">The minimum value to compare.</param>
		/// <param name="maxValue">The maximum value to compare.</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// </exception>
		private static void VerifyTypeMinMaxValues<T>(T minValue, T maxValue)
		{
			// Converting the parameters to a dynamic value allows them to be compared.
			dynamic minimum = minValue;
			dynamic maximum = maxValue;

			#region Integer Checks

			if (typeof(T) == typeof(int))
			{
				// Logic for minValue check.
				if (minimum < Int32.MinValue)
					throw new ArgumentOutOfRangeException($"A NumericGenerator, while generating an Integer, cannot have its '{nameof(minValue)}' less than {Int32.MinValue}");

				// Logic for maxValue check.
				if (maximum < Int32.MaxValue)
					throw new ArgumentOutOfRangeException($"A NumericGenerator, while generating an Integer, cannot have its '{nameof(maxValue)}' greater than {Int32.MaxValue}");

				return;
			}

			#endregion

			#region Double Checks

			if (typeof(T) == typeof(double))
			{
				// Logic for minValue check.
				if (minimum < System.Double.MinValue)
					throw new ArgumentOutOfRangeException($"A NumericGenerator, while generating a Double, cannot have its '{nameof(minValue)}' less than {System.Double.MinValue}");

				// Logic for maxValue check.
				if (maximum < System.Double.MaxValue)
					throw new ArgumentOutOfRangeException($"A NumericGenerator, while generating a Double, cannot have its '{nameof(maxValue)}' greater than {System.Double.MinValue}");

				return;
			}

			#endregion

			#region Byte Checks

			if (typeof(T) == typeof(byte))
			{
				// Logic for minValue check.
				if (minimum < System.Byte.MinValue)
					throw new ArgumentOutOfRangeException($"A NumericGenerator, while generating a Byte, cannot have its '{nameof(minValue)}' less than {System.Byte.MinValue}");

				// Logic for maxValue check.
				if (maximum < System.Byte.MaxValue)
					throw new ArgumentOutOfRangeException($"A NumericGenerator, while generating a Byte, cannot have its '{nameof(maxValue)}' greater than {System.Byte.MinValue}");

				return;
			}

			#endregion
		}


	    #endregion
	}
}
