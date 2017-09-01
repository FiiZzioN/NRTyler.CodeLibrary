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
            var testObject = new TestObject();
            var testObjectClone = testObject.Clone();

            var expected = true;

            // Act
            var actual = testObjectClone.Equals(testObject, testObjectClone);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}