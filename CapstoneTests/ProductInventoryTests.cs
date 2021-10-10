using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    public class ProductInventoryTests
    {
        private static ProductInventory inventory = new ProductInventory();
        private MainMenu menu = new MainMenu(inventory);
        public void inventoryHappyPathTest()
        {
            Assert.IsNotNull(inventory);
        }
        [TestMethod]
        public void printInventoryHappyPath()
        {
            Assert.IsTrue(menu.PrintProductInventory(inventory));
        }
        private static ProductInventory nullInventory = null;
        private MainMenu nullMenu = new MainMenu(nullInventory);
        [TestMethod]
        public void printInventoryNullTest()
        {
            Assert.IsTrue(nullMenu.PrintProductInventory(nullInventory));
        }

    }
}
