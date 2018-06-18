// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 05-21-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 05-21-2018
// 
// License          : MIT License
// ***********************************************************************

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Wrapper for the <see langword="static"/> <see cref="File"/> class. 
    /// </summary>
    public class FileEx
    {
        /// <summary>
        /// Checks to see if the specified file is the same type as the specified 
        /// extension. Returns <see langword="true"/> if the file's extension is 
        /// the same as the one specified, otherwise, this will return <see langword="false"/>.
        /// </summary>
        /// <param name="filePath">The path of the file that's being checked.</param>
        /// <param name="desiredExtension">The extension that the file should be compared against.</param>
        public static bool CheckFileExtension(string filePath, string desiredExtension)
        {
            return CheckFileExtension(filePath, new[] { $"{desiredExtension}" });
        }

        /// <summary>
        /// Checks to see if the specified file is the same type as one of the extensions in 
        /// the specified collection. Returns <see langword="true"/> if the file's extension 
        /// is specified in the collection, otherwise, this will return <see langword="false"/>.
        /// </summary>
        /// <param name="filePath">The path of the file that's being checked.</param>
        /// <param name="desiredExtensions">A collection of extensions that the file should be compared against.</param>
        public static bool CheckFileExtension(string filePath, IEnumerable<string> desiredExtensions)
        {
            var fileExtension = Path.GetExtension(filePath);

            return desiredExtensions.Contains(fileExtension);
        }
    }
}