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

namespace NRTyler.CodeLibrary.Utilities.Generators
{
    /// <summary>
    /// <see cref="CharacterGenerator"/> generates random uppercase or lowercase characters.
    /// </summary>
    public static class CharacterGenerator
    {
	    // Instantiating a class-wide randomizer makes sure that if a user calls multiple generation methods
	    // simultaneously, you don't get the same number since it stays on the same thread when it was called.
		private static Random Randomizer = new Random();

        #region Upper

        /// <summary>
        /// Returns a random Uppercase letter.
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char Upper()
        {
            return (char)Randomizer.Next(65, 91);
        }

        /// <summary>
        /// Returns an array of random Uppercase letters.
        /// </summary>
        /// <param name="arraySize">The amount of item(s) in the array.</param>
        /// <returns>System.Char[].</returns>
        public static char[] UpperArray(int arraySize)
        {
            var array = new char[arraySize];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Upper();
            }

            return array;
        }

        #endregion

        #region Lower

        /// <summary>
        /// Returns a random Lowercase letter.
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char Lower()
        {
            return (char)Randomizer.Next(97, 123);
        }

        /// <summary>
        /// Returns an array of random Lowercase letters.
        /// </summary>
        /// <param name="arraySize">The amount of item(s) in the array.</param>
        /// <returns>System.Char[].</returns>
        public static char[] LowerArray(int arraySize)
        {
            var array = new char[arraySize];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Lower();
            }

            return array;
        }

        #endregion

        #region Character

        /// <summary>
        /// Returns a random Uppercase or Lowercase letter.
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char Character()
        {
            var diceRoll = Randomizer.Next(0, 2);
            switch (diceRoll)
            {
                default:
                    return Upper();
                case 0:
                    return Lower();
            }
        }

        /// <summary>
        /// Returns an array of random Uppercase or Lowercase letters.
        /// </summary>
        /// <param name="arraySize">The amount of item(s) in the array.</param>
        /// <returns>System.Char[].</returns>
        public static char[] CharacterArray(int arraySize)
        {
            var array = new char[arraySize];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Character();
            }

            return array;
        }

        #endregion

        #region Old Code
        /*
        
        Proud of this as this is a technical way of getting a result,
        but it's not as elegant or efficient. Saved here as a memory.

        public static char CharacterBackup()
        {
            var list = new List<int>();

            // Adds the integers that correlate to both the 
            // lower and upper case letters of the alphabet.
            for (var i = 65; i < 123; i++)
            {
                list.Add(i);
            }

            // Removes the integers that correlate 
            // to these characters: [ \ ] ^ _ `
            for (var i = 91; i < 97; i++)
            {
                list.Remove(i);
            }

            var value = Randomizer.Next(51);

            return (char)list[value];
        }
        */
        #endregion
    }
}