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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
    [TestClass]
    public class ObjectCopierTests
    {
        [TestMethod]
        public void ObjectsAreEqual()
        {
            // Arrange
            var testObject      = new TestObject();
            var testObjectClone = testObject.Clone();

            var expected = true;

            // Act
            var actual = testObjectClone.Equals(testObject, testObjectClone);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotSerializable()
        {
            // Arrange
            // Not Serializable object.
            var testObject      = new EmptyObject();
            var testObjectClone = testObject.Clone();

            var expected = true;

            // Act
            var actual = "Empty because it can be";

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}