using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void productStockHappyPathTest()
        {
            string name = "Candy Bar";
            decimal price = 1.5M;
            string type = "candy";
            string slotLocation = "A0";
            Product testProduct = new Product(name, price, type, slotLocation);
            int expected = 5;
            Assert.AreEqual(testProduct.ProductAmount, expected);
            Assert.IsFalse(testProduct.IsOutOfStock);
        }
        [TestMethod]
        public void productOutOfStockTest()
        {
            string name = "Candy Bar";
            decimal price = 1.5M;
            string type = "candy";
            string slotLocation = "A0";
            Product testProduct = new Product(name, price, type, slotLocation);
            testProduct.ProductAmount = 0;
            Assert.IsTrue(testProduct.IsOutOfStock);
        }
        [TestMethod]
        public void productNullNegativeTest()
        {
            string name = null;
            decimal price = -2;
            string type = null;
            string slotLocation = null;
            Product nullProduct = new Product(name, price, type, slotLocation);
            decimal expectedPrice = 0;
            Assert.AreEqual(expectedPrice, nullProduct.Price);
            Assert.IsNotNull(nullProduct.Name);
            Assert.IsNotNull(nullProduct.Type);
            Assert.IsNotNull(nullProduct.SlotLocation);
        }
    }
}
