// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 09-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-03-2017
//
// License          : MIT License
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
            var testObjectClone = testObject.CopyObject();

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
            // Not a Serializable object.
            var testObject      = new EmptyObject();
            var testObjectClone = testObject.CopyObject();

            var expected = true;

            // Act
            var actual = "Empty because it can be";

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}