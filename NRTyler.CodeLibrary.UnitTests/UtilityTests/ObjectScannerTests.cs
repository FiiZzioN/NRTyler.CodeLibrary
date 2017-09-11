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

using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
    [TestClass]
    public class ObjectScannerTests
    {
        #region Fields

        [TestMethod]
        public void FieldsTrue()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = true;

            // Act
            var actual = testObject.ContainsFieldType(typeof(int));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FieldsFalse()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = false;

            // Act
            var actual = testObject.ContainsFieldType(typeof(double));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoFields()
        {
            // Arrange
            var testObject = new EmptyObject();

            var expected = false;

            // Act
            var actual = testObject.ContainsFieldType(typeof(long));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Properties

        [TestMethod]
        public void PropertiesTrue()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = true;

            // Act
            var actual = testObject.ContainsPropertyType(typeof(string));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertiesFalse()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = false;

            // Act
            var actual = testObject.ContainsPropertyType(typeof(short));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoProperties()
        {
            // Arrange
            var testObject = new EmptyObject();

            var expected = false;

            // Act
            var actual = testObject.ContainsPropertyType(typeof(float));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Interfaces

        [TestMethod]
        public void ScanInterfacesTrue()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = true;

            // Act
            var actual = testObject.ImplementsInterface(typeof(IEnumerable));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScanInterfacesFalse()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = false;

            // Act
            var actual = testObject.ImplementsInterface(typeof(IDictionary));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScanInterfacesNoInterfaces()
        {
            // Arrange
            var testObject = new EmptyObject();

            var expected = false;

            // Act
            var actual = testObject.ImplementsInterface(typeof(IEnumerator));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Fields and Properties

        [TestMethod]
        public void FieldsOrPropertiesTrue()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = true;

            // Act
            var actual = testObject.ContainsFieldOrPropertyType(typeof(int));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FieldsOrPropertiesFalse()
        {
            // Arrange
            var testObject = new TestObject();

            var expected = false;

            // Act
            var actual = testObject.ContainsFieldType(typeof(double));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoFieldsorProperties()
        {
            // Arrange
            var testObject = new EmptyObject();

            var expected = false;

            // Act
            var actual = testObject.ContainsFieldType(typeof(long));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

    }

    internal struct EmptyObject
    {
    }
}
