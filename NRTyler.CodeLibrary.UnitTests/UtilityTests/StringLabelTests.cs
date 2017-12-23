// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Attributes;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
    [TestClass]
    public class StringLabelTests
    {
        #region Enums For Tests

        private enum EnumNoLabels
        {
            LEO = 0,
            MEO = 1,
            SSO = 2,
            GTO = 3,
            GSO = 4,
        }

        private enum EnumSomeLabels
        {
            [StringLabel("Moho")]
            Moho = 0,
            [StringLabel("Eve")]
            Eve = 1,
            Kerbin = 2,
            [StringLabel("Duna")]
            Duna = 3,
            Dres = 4,
            Jool = 5,
            [StringLabel("Eeloo")]
            Eeloo = 6,
        }

        private enum EnumWithLabels
        {
            [StringLabel("Low Earth Orbit")]
            LEO = 0,
            [StringLabel("Medium Earth Orbit")]
            MEO = 1,
            [StringLabel("Sun-Synchronous Orbit")]
            SSO = 2,
            [StringLabel("Geostationary Transfer Orbit")]
            GTO = 3,
            [StringLabel("Geosynchronous Orbit")]
            GSO = 4,
        }

        private enum EnumWithLabelsComparision
        {
            [StringLabel("Low Earth")]
            LEO = 0,
            [StringLabel("Medium Earth")]
            MEO = 1,
            [StringLabel("Sun-Synchronous")]
            SSO = 2,
            [StringLabel("Geostationary Transfer")]
            GTO = 3,
            [StringLabel("Geosynchronous")]
            GSO = 4,
        }

        #endregion

        [TestMethod]
        public void GetLabelEnumTest()
        {
            // All three should return a string.
            Assert.AreEqual("Low Earth Orbit", StringLabel.GetLabel(EnumWithLabels.LEO));
            Assert.AreEqual("Sun-Synchronous Orbit", StringLabel.GetLabel(EnumWithLabels.SSO));
            Assert.AreEqual("Geosynchronous Orbit", StringLabel.GetLabel(EnumWithLabels.GSO));

            // Should receive a string value for Duna, but should get null for Kerbin.
            Assert.AreEqual("Duna", StringLabel.GetLabel(EnumSomeLabels.Duna));
            Assert.IsNull(StringLabel.GetLabel(EnumSomeLabels.Kerbin), "StringLabel.GetLabel(EnumSomeLabels.Kerbin) != null");

            // Shouldn't have a string value to return.
            Assert.IsNull(StringLabel.GetLabel(EnumNoLabels.GTO), "StringLabel.GetLabel(EnumNoLabels.GTO) != null");
        }

        [TestMethod]
        public void GetLabelCachedEnumTest()
        {
            // Adding a value to the cache and also expecting to receive this string for good measure.
            Assert.AreEqual("Medium Earth Orbit", StringLabel.GetLabel(EnumWithLabels.MEO));

            // Same name but different Enum, so we expect to get a different value.
            Assert.AreEqual("Medium Earth", StringLabel.GetLabel(EnumWithLabelsComparision.MEO));

            // Get both values as they are cached.
            Assert.AreEqual("Medium Earth Orbit", StringLabel.GetLabel(EnumWithLabels.MEO));
            Assert.AreEqual("Medium Earth", StringLabel.GetLabel(EnumWithLabelsComparision.MEO));
        }

        [TestMethod]
        public void HasLabelEnumTest()
        {
            // Should return true since it has a label.
            Assert.IsTrue(StringLabel.HasLabel(EnumWithLabels.LEO));

            // This has no label, so we should get false.
            Assert.IsFalse(StringLabel.HasLabel(EnumNoLabels.GSO));
        }

        [TestMethod]
        public void WhenNullIsAllowedTest()
        {
            // These should return 'Dres' and the second should return 'SunSynchronousOrbit' since
            // that's what both enum constants are named and they have no label stating otherwise.
            Assert.AreEqual("Dres", StringLabel.GetLabel(EnumSomeLabels.Dres, false));
            Assert.AreEqual("SSO", StringLabel.GetLabel(EnumNoLabels.SSO, false));

            // Should return null since both 'GSO' and 'Jool' have no label and we stated that null values aren't allowed.
            Assert.IsNull(StringLabel.GetLabel(EnumNoLabels.GSO, true), "StringLabel.GetLabel(EnumNoLabels.GSO, true) != null");
            Assert.IsNull(StringLabel.GetLabel(EnumSomeLabels.Jool, true), "StringLabel.GetLabel(EnumSomeLabels.Jool, true) != null");
        }

        [TestMethod]
        public void ParseTest()
        {
            // The first should return 'MEO' even though the case does not match. The second should return 'GTO' since 
            // the cases match, but should return null if the cases are changed even though everything else is the exact same.
            Assert.AreEqual(EnumWithLabels.MEO, StringLabel.ParseEnum(typeof(EnumWithLabels), "medium earth orbit"));
            Assert.AreEqual(EnumWithLabels.GTO, StringLabel.ParseEnum(typeof(EnumWithLabels), "Geostationary Transfer Orbit", false));
            Assert.AreEqual(              null, StringLabel.ParseEnum(typeof(EnumWithLabels), "geostationary transfer orbit", false));

            // The first should return null since the label doesn't match. The second return null since 
            // the case doesn't match. The third should return null since the label doesn't exist at all.
            Assert.IsNull(StringLabel.ParseEnum(typeof(EnumSomeLabels), "Mooho"));
            Assert.IsNull(StringLabel.ParseEnum(typeof(EnumSomeLabels), "eeloo", false));
            Assert.IsNull(StringLabel.ParseEnum(typeof(EnumSomeLabels), "Jool"));
        }
    }
}