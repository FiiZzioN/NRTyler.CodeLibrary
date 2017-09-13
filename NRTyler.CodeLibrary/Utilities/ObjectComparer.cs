// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-05-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-07-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// ReSharper disable SuggestBaseTypeForParameter

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Holds methods to aid in comparing objects to one anther.
    /// </summary>
    public static class ObjectComparer
    {
        #region Not Working

        /*
        /// <summary>
        /// Preforms a comparison of an <see cref="object"/>'s properties
        /// to another <see cref="object"/>'s properties.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare.</param>
        /// <param name="item">The <see cref="object"/> to compare against.</param>
        /// <returns>If the objects are equal, return true, otherwise returns false.</returns>
        public static bool Compare(this object obj, object item)
        {
            if (ReferenceEquals(obj, item)) return true;
            if (obj == null || item == null) return false;

            // Compare two object's type, return false if they are different.
            if (obj.GetType() != item.GetType()) return false;

            var result = true;

            try
            {
                // Get all properties of obj and compare each other
                foreach (var property in obj.GetType().GetProperties())
                {
                    var objValue = property.GetValue(obj);
                    var itemValue = property.GetValue(item);

                    if (!objValue.Equals(itemValue)) result = false;
                }
            }
            catch (Exception e)
            {
                e.LogCompleteExceptionInfo();
                throw;
            }

            return result;
        }

        /// <summary>
        /// Preforms a deep comparison of an <see cref="object"/>'s properties, and their properties, 
        /// and their properties, etc... (using recursion) to another <see cref="object"/>'s properties.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare.</param>
        /// <param name="item">The <see cref="object"/> to compare against.</param>
        /// <returns>If the objects are equal, return true, otherwise returns false.</returns>
        public static bool DeepCompare(this object obj, object item)
        {
            if (ReferenceEquals(obj, item)) return true;
            if (obj == null || item == null) return false;

            // Compare two object's type, return false if they are different.
            if (obj.GetType() != item.GetType()) return false;

            // Properties of type: int, double, DateTime, etc... are not classes, they're structs.
            if (!obj.GetType().IsClass) return obj.Equals(item);

            var result = true;

            // Get all properties of obj and compare each other
            foreach (var property in obj.GetType().GetProperties())
            {
                var objValue  = property.GetValue(obj);
                var itemValue = property.GetValue(item);

                // Recursion
                if (!objValue.Compare(itemValue)) result = false;
            }

            return result;
        }
        */

        #endregion

        /// <summary>
        /// Compares an <see cref="object" /> against the <see cref="object" /> that invoked this method.
        /// The comparison is accomplished by serializing both objects, converting them to a byte array,
        /// and then comparing the arrays against one another.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type" /> of <see cref="object" /> we're comparing.</typeparam>
        /// <param name="objectOne">An <see cref="object" /> to compare.</param>
        /// <param name="objectTwo">An <see cref="object" /> to compare against.</param>
        /// <returns>If the objects contain the same values, this returns true. Otherwise this returns false.</returns>
        /// <exception cref="ArgumentException">The type being compared must be serializable!</exception>
        public static bool CompareObject<T>(this T objectOne, T objectTwo)
        {
            // The type of object being compared must be serializable.
            if (!typeof(T).IsSerializable)
            {
                try
                {
                    throw new ArgumentException("The type being compared must be serializable!");
                }
                catch (Exception e)
                {
                    e.LogCompleteExceptionInfo();
                    throw;
                }
            }

            // Don't compare a null object, if an object is null, return false.
            if (Object.ReferenceEquals(objectOne, null) || Object.ReferenceEquals(objectTwo, null))
            {
                return false;
            }

            // Setup our primary objects to complete the task.
            var binaryFormater  = new BinaryFormatter();
            var objectOneStream = new MemoryStream();
            var objectTwoStream = new MemoryStream();

            // Initializing here so the compare method can reach the arrays.
            byte[] objectOneArray;
            byte[] objectTwoArray;

            using (objectOneStream)
            using (objectTwoStream)
            {
                // Serializing the objects to their respective MemoryStream.
                binaryFormater.Serialize(objectOneStream, objectOne);
                binaryFormater.Serialize(objectTwoStream, objectTwo);

                // Converting the steams to arrays for comparisons sake.
                objectOneArray = objectOneStream.ToArray();
                objectTwoArray = objectTwoStream.ToArray();
            }

            return CompareArrays(objectOneArray, objectTwoArray);
        }

        private static bool CompareArrays(byte[] valueOne, byte[] valueTwo)
        {
            // If they're not the same length, then they obviously aren't equal.
            if (valueOne.Length != valueTwo.Length) return false;

            // Compare each index in the arrays to one-another.
            for (var i = 0; i < valueOne.Length; i++)
            {
                if (valueOne[i] != valueTwo[i]) return false;
            }

            // If they pass both checks above, then they're equal.
            return true;
        }
    }
}