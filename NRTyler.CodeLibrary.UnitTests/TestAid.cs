// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 10-09-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-09-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.IO;

namespace NRTyler.CodeLibrary.UnitTests
{
    /// <summary>
    /// Useful properties to save time and aid in UnitTest creation.
    /// </summary>
    public static class TestAid
    {
        /// <summary>
        /// Gets the current location that this UnitTest's '.dll' file is located.
        /// </summary>
        public static string CurrentLocation { get; } = Environment.CurrentDirectory;

        /// <summary>
        /// Gets the location where documents / folder tests take place.
        /// </summary>
        public static string DocumentTestLocation { get; } = $"{CurrentLocation}/DocumentTests";

        /// <summary>
        /// Gets the location where file tests take place.
        /// </summary>
        public static string FileTestLocation { get; } = $"{CurrentLocation}/FileTests";

        /// <summary>
        /// Removes the specified directory if it already exists because of a previous test.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <param name="deleteEverything">If set to true, every subdirectory and file in the specified path will also be deleted.</param>
        public static void RemoveDirectoryFromPreviousTest(string path, bool deleteEverything = false)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, deleteEverything);
            }
        }
    }
}