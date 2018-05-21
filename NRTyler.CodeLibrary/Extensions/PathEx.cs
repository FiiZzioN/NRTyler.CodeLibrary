// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 10-09-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 05-21-2018
//
// License          : MIT License
// ***********************************************************************

using System.IO;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Wrapper for the <see langword="static"/> <see cref="Path"/> class. 
    /// </summary>
    public class PathEx
    {
        /// <summary>
        /// Indicates whether the specified path contains an invalid character.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>If the path contains an invalid character, returns <see langword="true"/>, otherwise return <see langword="false"/>.</returns>
        public static bool HasInvalidCharacters(string path)
        {
            foreach (var invalidPathChar in Path.GetInvalidPathChars())
            {
                // If the path contains an invalid character, return true.
                if (path.Contains(invalidPathChar.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}