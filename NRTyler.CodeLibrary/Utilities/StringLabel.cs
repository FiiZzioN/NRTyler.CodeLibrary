// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 10-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-01-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections;
using NRTyler.CodeLibrary.Attributes;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Contains method that aid in dealing with <see cref="Enum"/> constants that have a <see cref="StringLabelAttribute"/> applied to it.
    /// </summary>
    public sealed class StringLabel
    {
        /// <summary>
        /// Gets the cached labels. If you dig up a label, try to cache it. The heavy-lifting has 
        /// already been done, so there's no need to do it again. This aids the program's performance.
        /// </summary>
        // ReSharper disable once StaticMemberInGenericType
        private static Hashtable CachedLabels { get; } = new Hashtable();

        /// <summary>
        /// Gets the label that was applied to the member.
        /// </summary>
        /// <param name="member">The member that the <see cref="StringLabelAttribute"/> is applied to.</param>
        /// <returns>If the member has a <see cref="StringLabelAttribute"/> applied to it, the label will be returned. Otherwise, this returns null.</returns>
        public static string GetLabel(Enum member)
        {
            string labelOutput = null;

            // Check to see if the specified member is in the cache.
            if (CachedLabels.ContainsKey(member))
            {
                // If the member is in the cache and it's a 'StringLabelAttribute', return its' label.
                if (CachedLabels[member] is StringLabelAttribute cachedLabel)
                {
                    labelOutput = cachedLabel.Label;
                    return labelOutput;
                }
            }

            // Get the StringLabelAttribute applied to the member.
            var attributes = StringLabel.GetStringLabelAttribute(member);

            if (attributes.Length > 0 && attributes[0] is StringLabelAttribute stringLabelAttribute)
            {
                // Add attribute to the cache.
                CachedLabels.Add(member, attributes[0]);
                
                // Apply the label to the outbound field.
                labelOutput = stringLabelAttribute.Label;
            }

            return labelOutput;
        }

        /// <summary>
        /// Gets the <see cref="StringLabelAttribute"/> should the member have one to begin with.
        /// </summary>
        /// <param name="member">The member to gather the attributes from.</param>
        /// <returns>
        /// An <see cref="object"/> array should the member have a <see cref="StringLabelAttribute"/>
        /// applied to it. If it doesn't have one applied, the returned array will be empty.
        /// </returns>
        private static object[] GetStringLabelAttribute(Enum member)
        {
            // Getting the type we're working with, and finding the specified member in that type.
            var memberType = member.GetType();
            var memberInfo = memberType.GetMember(member.ToString());

            return memberInfo[0].GetCustomAttributes(typeof(StringLabelAttribute), false);
        }

        /// <summary>
        /// Determines whether a member has a <see cref="StringLabelAttribute"/> label.
        /// </summary>
        /// <returns>
        /// Returns true if the member has a <see cref="StringLabelAttribute"/> 
        /// label, otherwise this returns false.
        /// </returns>
        public static bool HasLabel(Enum member)
        {
            var output = false;

            // Get the StringLabelAttribute applied to the member.
            var attibutes = StringLabel.GetStringLabelAttribute(member);

            // If we get attribute from the member and it's a 
            // StringLabelAttribute, then it obviously has a label.
            if (attibutes.Length > 0 && attibutes[0] is StringLabelAttribute)
            {
                output = true;
            }

            return output;
        }
    }
}