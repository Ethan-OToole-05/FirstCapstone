using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseMenuTests
    {
        private static ProductInventory inventory = new ProductInventory();
        private PurchaseMenu purchaseMenu = new PurchaseMenu(inventory);
        [TestMethod]
        public void writeMenuHappyPathTest()
        {
            string[] menuOptions = { "first", "second", "third" };
            Assert.IsTrue(purchaseMenu.WriteMenu(menuOptions));
        }
        [TestMethod]
        public void writeMenuMoreOptionsTest()
        {
            string[] moreMenuOptions = { "first", "second", "third", "fourth", "fifth" };
            Assert.IsTrue(purchaseMenu.WriteMenu(moreMenuOptions));
        }
        [TestMethod]
        public void writeMenuNullTest()
        {
            string[] nullMenuOptions = null;
            Assert.IsTrue(purchaseMenu.WriteMenu(nullMenuOptions));
        }
        [TestMethod]
        public void printInventoryHappyPath()
        {
            Assert.IsTrue(purchaseMenu.PrintProductInventory(inventory));
        }

    }
}
