// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 10-08-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-09-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;

namespace NRTyler.CodeLibrary.Extensions
{
    /// <summary>
    /// Wrapper for the <see langword="static"/> <see cref="Directory"/> class. 
    /// </summary>
    public class DirectoryEx
    {
        /// <summary>
        /// Creates a directory in the path specified if it's found to be nonexistent.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>Returns a <see cref="DirectoryInfo"/> <see cref="object"/> to the specified path.</returns>
        /// <exception cref="IOException">The specified path is actually a file, or the network name isn't known.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">Gets thrown if the path contains invalid character(s).</exception>
        /// <exception cref="ArgumentNullException">The path provided cannot be null, empty, or consist of only white-space characters.</exception>
        /// <exception cref="PathTooLongException">The specified path cannot exceed the system-defined maximum length of 248 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="NotSupportedException">The specified path contains a colon thats not part of a drive label ("C:\").</exception>
        public static DirectoryInfo CreateDirectoryIfNonexistent(string path)
        {
            // Checks the specified path to see if it contains invalid character(s).
            CheckPathForInvalidCharacters(path);

            if (!Directory.Exists(path))
            {
                // Do this if it doesn't exist.
                Directory.CreateDirectory(path);
            }

            return new DirectoryInfo(path);
        }

        /// <summary>
        /// Checks a directory's path for invalid characters; if there's an invalid character an <see cref="ArgumentException"/> is thrown.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentException">Gets thrown if the path contains invalid character(s).</exception>
        private static void CheckPathForInvalidCharacters(string path)
        {
            // All of the invalid characters found in the path.
            var invalidCharacterList = new List<char>();

            foreach (var invalidPathChar in Path.GetInvalidPathChars())
            {
                // If the path contains an invalid character, then it gets added to the list.
                if (path.Contains(invalidPathChar.ToString()))
                {
                    invalidCharacterList.Add(invalidPathChar);
                }
            }

            // The logic to execute if the path contains just one invalid character.
            if (invalidCharacterList.Count == 1)
            {
                throw new ArgumentException($"The path provided contained an invalid character. The invalid character was: '{invalidCharacterList[0]}'");
            }

            // The logic to execute if the path contains more than one invalid character.
            if (invalidCharacterList.Count > 1)
            {
                var characters = String.Empty;

                foreach (var entry in invalidCharacterList)
                {
                    // Checking to see if it's the first character in the string. If it's indeed the first, then we 
                    // don't want to being the string with a space BEFORE the invalid character. If the string already
                    // contains a character, then we add a comma to separate the characters, and then add the new character.
                    //! Make sure we keep the false check FIRST so we don't double up the first time we go through the loop.
                    if (!String.IsNullOrWhiteSpace(characters))
                    {
                        characters += $", '{entry}'";
                    }
                    if (String.IsNullOrWhiteSpace(characters))
                    {
                        characters += $"'{entry}'";
                    }
                }

                throw new ArgumentException($"The path provided contained invalid characters. The invalid characters were: {characters}");
            }
        }
    }
}