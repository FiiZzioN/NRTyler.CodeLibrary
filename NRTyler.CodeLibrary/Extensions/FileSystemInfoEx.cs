// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 05-27-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 05-27-2018
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Wrapper for the <see cref="FileSystemInfo"/> base class. 
    /// </summary>
    public static class FileSystemInfoEx
    {
        /// <summary>
        /// Gets the name of the <see cref="FileInfo" /> or <see cref="DirectoryInfo" /> object without the extension being at the end.
        /// </summary>
        /// <param name="fileSystemInfo">
        /// The <see cref="FileInfo" /> or <see cref="DirectoryInfo" /> object whose name you're trying to retrieve.
        /// </param>
        /// <param name="comparisonType">
        /// The rules that'll be used to find the extension that needs to be removed.
        /// </param>
        /// <exception cref="ArgumentException">Thrown if "comparisonType" is not a valid <see cref="StringComparison"/> value.</exception>
        public static string GetNameWithoutExtension(this FileSystemInfo fileSystemInfo, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var itemName  = fileSystemInfo.Name;
            var extension = fileSystemInfo.Extension;

            var extensionIndex = itemName.IndexOf(extension, comparisonType);

            return itemName.Remove(extensionIndex, extension.Length);
        }
    }
}