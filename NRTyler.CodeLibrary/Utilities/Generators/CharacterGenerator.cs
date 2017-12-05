// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 11-29-2017
//
// License          : MIT License
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
		private static Random Randomizer { get; } = new Random();

        /// <summary>
        /// Gets the array containing the integer values for the allowed special characters. All allowed 
        /// characters can be found on the number row on your keyboard, minus the parentheses.
        /// </summary>
        public static int[] SpecialCharacters { get; } = {33, 35, 36, 37, 38, 42, 64, 94};

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

        #region Special

        /// <summary>
        /// Returns a random special character.
        /// </summary>
        /// <returns>A random special character.</returns>
        public static char Special()
        {
            var index = Randomizer.Next(0, SpecialCharacters.Length);

            return (char)SpecialCharacters[index];
        }

        /// <summary>
        /// Returns an array of random special characters.
        /// </summary>
        /// <param name="arraySize">The amount of item(s) in the array.</param>
        /// <returns>An array of random special characters.</returns>
        public static char[] SpecialArray(int arraySize)
        {
            var array = new char[arraySize];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Special();
            }

            return array;
        }

        #endregion

        #region Character

        /// <summary>
        /// Returns a random Uppercase, Lowercase or Special character.
        /// </summary>
        /// <param name="allowSpecialCharacters">
        /// If set to <see langword="true"/>, special characters 
        /// are allowed to be returned alongside regular characters. 
        /// </param>
        /// <returns>A random regular or special character depending on your choice.</returns>
        public static char Character(bool allowSpecialCharacters = false)
        {
            var diceRoll = allowSpecialCharacters ? Randomizer.Next(0, 3) : Randomizer.Next(0, 2);

            // Special Options
            if (allowSpecialCharacters)
            {
                switch (diceRoll)
                {
                    // Default is essentially "case 0"
                    default:
                        return Upper();
                    case 1:
                        return Lower();
                    case 2:
                        return Special();

                }
            }
            
            // Standard Options
            switch (diceRoll)
            {
                // Default is essentially "case 0"
                default:
                    return Upper();
                case 1:
                    return Lower();
            }
        }

        /// <summary>
        /// Returns an array consisting of random Uppercase, Lowercase or Special characters.
        /// </summary>
        /// <param name="arraySize">The amount of item(s) in the array.</param>
        /// <param name="allowSpecialCharacters">
        /// If set to <see langword="true"/>, special characters 
        /// are allowed to be returned alongside regular characters. 
        /// </param>
        /// <returns>
        /// An array consisting of random regular characters, or consisting
        /// of both random and special characters depending on your choice.
        /// </returns>
        public static char[] CharacterArray(int arraySize, bool allowSpecialCharacters = false)
        {
            var array = new char[arraySize];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Character(allowSpecialCharacters);
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