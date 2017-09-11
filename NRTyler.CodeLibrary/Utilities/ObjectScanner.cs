// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-03-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Reflection;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Holds methods that aid in finding out information about a given <see cref="object"/>.
    /// </summary>
    public static class ObjectScanner
    {
        /// <summary>
        /// Finds out if a given <see cref="object" /> contains a field of the specified <see cref="Type" />.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="object"/> we're scanning</typeparam>
        /// <param name="item">The <see cref="object" /> to scan.</param>
        /// <param name="type">The field <see cref="Type" /> we're scanning for.</param>
        /// <returns>Whether the <see cref="object" /> contains a field of the specified <see cref="Type" />.</returns>
        public static bool ContainsFieldType<T>(this T item, Type type)
        {
            var itemType = item.GetType();

            foreach (var field in itemType.GetRuntimeFields())
            {
                if (field.FieldType == type)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds out if a given <see cref="object"/> contains a property of the specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="object"/> we're scanning</typeparam>
        /// <param name="item">The <see cref="object"/> to scan.</param>
        /// <param name="type">The property <see cref="Type"/> we're scanning for.</param>
        /// <returns>Whether the <see cref="object"/> contains a property of the specified <see cref="Type"/>.</returns>
        public static bool ContainsPropertyType<T>(this T item, Type type)
        {
            var itemType = item.GetType();

            foreach (var property in itemType.GetRuntimeProperties())
            {
                if (property.PropertyType == type)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds out if a given <see cref="object"/> contains either a field or property of the specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="object"/> we're scanning</typeparam>
        /// <param name="item">The <see cref="object"/> to scan.</param>
        /// <param name="type">The property <see cref="Type"/> we're scanning for.</param>
        /// <returns>Whether the <see cref="object"/> contains a field or property of the specified <see cref="Type"/>.</returns>
        public static bool ContainsFieldOrPropertyType<T>(this T item, Type type)
        {
            var fieldCheck    = item.ContainsFieldType(type);
            var propertyCheck = item.ContainsPropertyType(type);

            return fieldCheck || propertyCheck;
        }

        /// <summary>
        /// Finds out if a given <see cref="object"/> contains an interface of the specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="object"/> we're scanning</typeparam>
        /// <param name="item">The <see cref="object"/> to scan.</param>
        /// <param name="type">The interface <see cref="Type"/> we're scanning for.</param>
        /// <returns>Whether the <see cref="object"/> contains an interface of the specified <see cref="Type"/>.</returns>
        public static bool ImplementsInterface<T>(this T item, Type type)
        {
            var itemType = item.GetType();

            try
            {
                foreach (var interfaces in itemType.GetInterfaces())
                {
                    if (interfaces == type)
                    {
                        return true;
                    }
                }
            }
            catch (TargetInvocationException e)
            {
                e.LogExceptionInfo();
            }

            return false;
        }
    }
}