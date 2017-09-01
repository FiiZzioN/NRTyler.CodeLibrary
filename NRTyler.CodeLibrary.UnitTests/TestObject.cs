// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 09-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-01-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Collections;

namespace NRTyler.CodeLibrary.UnitTests
{
    /// <summary>
    /// A test object used in unit tests.
    /// </summary>
    /// <seealso cref="System.Collections.IEnumerable" />
    [Serializable]
    internal class TestObject : IEnumerable
    {
        private string fieldOne = "This is a test";
        private int fieldTwo    = 12;

        public string FieldOne
        {
            get { return this.fieldOne; }
            set { this.fieldOne = value; }
        }

        public int FieldTwo
        {
            get { return this.fieldTwo; }
            set { this.fieldTwo = value; }
        }

        public IEnumerator GetEnumerator()
        {
            var array = new[] { FieldOne, FieldTwo.ToString() };

            foreach (var item in array)
            {
                yield return item;
            }
        }

        public bool Equals(TestObject x1, TestObject x2)
        {
            if (Object.ReferenceEquals(x1, x2)) return true;

            if (x1 == null || x2 == null) return false;

            return x1.FieldOne == x2.FieldOne && x1.FieldTwo == x2.FieldTwo;
        }
    }
}