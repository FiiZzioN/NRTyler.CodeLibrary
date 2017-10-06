// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 09-22-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-22-2017
// 
// License          : MIT License
// ***********************************************************************

using System.IO;

namespace NRTyler.CodeLibrary
{
    public class DirectoryCopier
    {
        /// <summary>
        /// Takes all files and subdirectories in a given location and copies them to a new 
        /// location. The files being copied will be removed after the coping has taken place.
        /// </summary>
        /// <param name="beginningPath">The beginning path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <param name="overwriteFiles">If set to true, any files that already exist in the destination will be overwritten.</param>
        /// <exception cref="DirectoryNotFoundException">Get's thrown if the beginning path can't be found.</exception>
        public void CopyFilesAndSubdirectories(string beginningPath, string destinationPath, bool overwriteFiles)
        {
            // Make sure the directory we're working with actually exists.
            if (!Directory.Exists(beginningPath))
                throw new DirectoryNotFoundException($"'{beginningPath}' doesn't exist or can't be found!");

            var beginningDirectory = new DirectoryInfo(beginningPath);

            // Get directories and files that will be worked with below.
            var baseDirectories = beginningDirectory.GetDirectories();
            var baseFiles = beginningDirectory.GetFiles();

            // Makes sure the destination directory exists.
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            // Copy files to the destination.
            foreach (var file in baseFiles)
            {
                var path = Path.Combine(destinationPath, file.Name);
                file.CopyTo(path, overwriteFiles);
            }

            // Copy subdirectories plus their content to the destination. Accomplished via recursion.
            foreach (var directory in baseDirectories)
            {
                var path = Path.Combine(destinationPath, directory.Name);
                CopyFilesAndSubdirectories(directory.FullName, path, overwriteFiles);
            }
        }
    }
}