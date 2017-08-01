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
using System.Collections.Generic;
using System.IO;

namespace NRTyler.CodeLibrary.Utilities.Generators
{
    /// <summary>
    /// <see cref="NameGenerator"/> is used to generate random names to test the entry fields that your hypothetical users would fill in.
    /// </summary>
    public static class NameGenerator
    {
        private static List<string> firstNameList = new List<string>();
        private static List<string> lastNameList  = new List<string>();

        #region Name Functions

        /// <summary>
        /// Generates a random first name.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GenerateFirstName()
        {
            return GrabNames(firstNameList);
        }

        /// <summary>
        /// Generates a random middle Initial.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GenerateMiddleInitial()
        {
            return CharacterGenerator.Upper().ToString();
        }

        /// <summary>
        /// Generates a random last name.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GenerateLastName()
        {
            return GrabNames(lastNameList);
        }

        /// <summary>
        /// Generates a random full name.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GenerateFullName()
        {
            var firstName     = GenerateFirstName();
            var middleInitial = GenerateMiddleInitial();
            var lastName      = GenerateLastName();

            var fullName = $"{firstName} {middleInitial}. {lastName}";

            return fullName;
        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// Grabs a random name from a list that is passed through.
        /// </summary>
        /// <param name="list">The list from which you grab a name.</param>
        /// <returns>System.String.</returns>
        private static string GrabNames(List<string> list)
        {
            PopulateCollections();

            var index = NumericGenerator.Integer(0, list.Count);

            return $"{list[index]}";
        }

        /// <summary>
        /// Populates the first and last name collections.
        /// </summary>
        private static void PopulateCollections()
        {
            // The file name plus the extension.
            var fileName = "Names.txt";

	        var currentDir = $"{Environment.CurrentDirectory}/GeneratorSources/{fileName}";

			//ClearCollections();

			using (var reader = File.OpenText(currentDir))
            {
                // Will iterate thought a given file, split the name into first and last -
                // names, and add them to the appropriate list until we reach the end of the file.
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    var splitLine = currentLine.Split(new[] { " " }, StringSplitOptions.None);

                    firstNameList.Add(splitLine[0]);
                    lastNameList .Add(splitLine[1]);
                }
                reader.Dispose();
            }
        }

        #endregion
    }
}
