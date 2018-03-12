// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 03-12-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 03-12-2018
// 
// License          : MIT License
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NRTyler.CodeLibrary.UnitTests.CollectionTests
{
    [TestClass]
    public class AlertListTests
    {
        private List<string> StockItems()
        {
            var item1 = "One";
            var item2 = "Two";
            var item3 = "Three";
            var item4 = "Four";
            var item5 = "Five";
            var item6 = "Six";

            var array = new [] {item1, item2, item3, item4, item5, item6};

            return array.ToList();
        }

        private void CheckItems(IEnumerable<string> collection)
        {
            var list = collection.ToList();

            foreach (var item in StockItems())
            {
                Assert.IsTrue(list.Contains(item));
            }
        }

        [TestMethod]
        public void AlertList_Add()
        {
            var alertList = new AlertList<string>();

            alertList.ListChanged += (sender, args) => Assert.IsTrue(args.ItemsChanged.ToList()[0] == "One");

            alertList.Add(StockItems()[0]);
        }

        [TestMethod]
        public void AlertList_AddRange()
        {
            var alertList = new AlertList<string>();

            alertList.ListChanged += (sender, args) => CheckItems(args.ItemsChanged);

            alertList.AddRange(StockItems());
        }

        [TestMethod]
        public void AlertList_Clear()
        {
            var alertList = new AlertList<string>();
            alertList.AddRange(StockItems());

            alertList.ListChanged += (sender, args) => CheckItems(args.ItemsChanged);

            alertList.Clear();
        }

        [TestMethod]
        public void AlertList_Remove()
        {
            var alertList = new AlertList<string>();
            alertList.AddRange(StockItems());

            alertList.ListChanged += (sender, args) => Assert.IsTrue(args.ItemsChanged.ToList()[0] == "Two");

            alertList.Remove(StockItems()[1]);
        }

        [TestMethod]
        public void AlertList_RemoveAll()
        {
            var alertList = new AlertList<string>();
            alertList.AddRange(StockItems());

            alertList.ListChanged += (sender, args) => CheckList(args.ItemsChanged);

            alertList.RemoveAll(RemoveThreeLetterWords);

            bool RemoveThreeLetterWords(string obj)
            {
                return obj.Split().Length <= 3;
            }

            void CheckList(IEnumerable<string> collection)
            {
                var list = collection.ToList();

                Assert.IsTrue(list.Contains("One"));
                Assert.IsTrue(list.Contains("Two"));
                Assert.IsTrue(list.Contains("Six"));
            }
        }

        [TestMethod]
        public void AlertList_RemoveAt()
        {
            var alertList = new AlertList<string>();
            alertList.AddRange(StockItems());

            alertList.ListChanged += (sender, args) => Assert.IsTrue(args.ItemsChanged.ToList()[0] == "Three");

            alertList.RemoveAt(2);
        }

        [TestMethod]
        public void AlertList_RemoveRange()
        {
            var alertList = new AlertList<string>();
            alertList.AddRange(StockItems());

            alertList.ListChanged += (sender, args) => CheckList(args.ItemsChanged);

            alertList.RemoveRange(2, 3);

            void CheckList(IEnumerable<string> collection)
            {
                var list = collection.ToList();

                Assert.IsTrue(list.Contains("Three"));
                Assert.IsTrue(list.Contains("Four"));
                Assert.IsTrue(list.Contains("Five"));

            }
        }
    }
}