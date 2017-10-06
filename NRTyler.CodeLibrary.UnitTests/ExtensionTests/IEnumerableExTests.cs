// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 10-06-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 10-06-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Extensions;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.ExtensionTests
{
    [TestClass]
    public class IEnumerableExTests
    {
        [TestMethod]
        public void ArrayToObservableCollection()
        {
            // Arrange
            var array = new [] {1, 2, 4, 8, 16, 32};

            var expected = new ObservableCollection<int> {1, 2, 4, 8, 16, 32};

            // Act
            var actual = array.ToObservableCollection();

            // Assert
            CollectionAssert.AreEqual(expected, actual);            
        }

        [TestMethod]
        public void CatchEmptyList()
        {
            var list = new List<int>();

            // List is empty, so we should receive a null value.
            Assert.IsNull(list.ToObservableCollection());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CatchNullSource()
        {
            // Arrange
            Dictionary<string, int> dictionary = null;

            dictionary.ToObservableCollection();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void CatchDictionary()
        {
            // Arrange
            var dictionary = new Dictionary<string, int> {{"One", 1}, {"Two", 2}, {"Three", 3}};


            dictionary.ToObservableCollection();
        }

        [TestMethod]
        public void AllowDictionary()
        {
            // Arrange
            var dictionary = new Dictionary<string, int> {{"One", 1}, {"Two", 2}, {"Three", 3}};

            var expected = new ObservableCollection<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("One", 1),
                new KeyValuePair<string, int>("Two", 2),
                new KeyValuePair<string, int>("Three", 3)
            };

            // Act
            var actual = dictionary.ToObservableCollection(true);

            // Assert
            Assert.AreEqual(true, expected.CompareObject(actual));
        }
    }
}