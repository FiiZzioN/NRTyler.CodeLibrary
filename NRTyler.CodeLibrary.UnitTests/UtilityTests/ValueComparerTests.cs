// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 01-20-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 01-20-2018
// 
// License          : MIT License
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
    [TestClass]
    public class ValueComparerTests
    {
        [TestMethod]
        public void ValueComparer_GetLargerValueTest()
        {
            var testOne   = ValueComparer.GetLargerValue(1, 10);
            var testTwo   = ValueComparer.GetLargerValue(100, 10);
            var testThree = ValueComparer.GetLargerValue(100, 1000);

            Assert.AreEqual(10, testOne);
            Assert.AreEqual(100, testTwo);
            Assert.AreEqual(1000, testThree);
        }

        [TestMethod]
        public void ValueComparer_GetSmallerValueTest()
        {
            var testOne   = ValueComparer.GetSmallerValue(1, 10);
            var testTwo   = ValueComparer.GetSmallerValue(100, 10);
            var testThree = ValueComparer.GetSmallerValue(100, 1000);

            Assert.AreEqual(1, testOne);
            Assert.AreEqual(10, testTwo);
            Assert.AreEqual(100, testThree);
        }
    }
}