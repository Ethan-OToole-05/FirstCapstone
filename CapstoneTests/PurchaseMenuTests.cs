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
        public void WriteMenuHappyPathTest()
        {
            string[] menuOptions = { "first", "second", "third" };
            Assert.IsTrue(purchaseMenu.WriteMenu(menuOptions));
        }
        [TestMethod]
        public void WriteMenuMoreOptionsTest()
        {
            string[] moreMenuOptions = { "first", "second", "third", "fourth", "fifth" };
            Assert.IsTrue(purchaseMenu.WriteMenu(moreMenuOptions));
        }
        [TestMethod]
        public void WriteMenuNullTest()
        {
            string[] nullMenuOptions = null;
            Assert.IsTrue(purchaseMenu.WriteMenu(nullMenuOptions));
        }
        [TestMethod]
        public void PrintInventoryHappyPath()
        {
            Assert.IsTrue(purchaseMenu.PrintProductInventory(inventory));
        }
        [TestMethod]
        public void FeedMoneyHappyPathTest()
        {
            decimal money = 4;
            decimal expected = 4;
            decimal actual = purchaseMenu.FeedMoney(money);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FeedMoneyOver9000Test()
        {
            decimal money = 9001;
            decimal expected = 0;
            decimal actual = purchaseMenu.FeedMoney(money);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FeedMoneyNegativeTest()
        {
            decimal money = -5;
            decimal expected = 0;
            decimal actual = purchaseMenu.FeedMoney(money);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DispenseHappyPathTest()
        {
            purchaseMenu.FeedMoney(20);
            Product selectedProduct = new Product("Test Crunch", 19.99M, "Healthbar", "B8");
            Assert.IsTrue(purchaseMenu.DispenseProduct(selectedProduct));
        }
        [TestMethod]
        public void DispenseCantAffordTest()
        {
            Product selectedProduct = new Product("Jaw Cracker", 1.04M, "Chip", "B9");
            Assert.IsFalse(purchaseMenu.DispenseProduct(selectedProduct));
        }
        [TestMethod]
        public void DispenseNullTest()
        {
            Product selectedProduct = null;
            Assert.IsFalse(purchaseMenu.DispenseProduct(selectedProduct));
        }
    }
}
