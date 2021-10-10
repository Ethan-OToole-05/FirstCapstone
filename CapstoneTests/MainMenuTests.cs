using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    public class MainMenuTests
    {
        private static ProductInventory inventory = new ProductInventory();
        private MainMenu mainMenu = new MainMenu(inventory);
        [TestMethod]
        public void writeMenuHappyPathTest()
        {
            string[] menuOptions = { "first", "second", "third" };
            Assert.IsTrue(mainMenu.WriteMenu(menuOptions));
        }
        [TestMethod]
        public void writeMenuMoreOptionsTest()
        {
            string[] moreMenuOptions = { "first", "second", "third", "fourth", "fifth" };
            Assert.IsTrue(mainMenu.WriteMenu(moreMenuOptions));
        }
        [TestMethod]
        public void writeMenuNullTest()
        {
            string[] nullMenuOptions = null;
            Assert.IsTrue(mainMenu.WriteMenu(nullMenuOptions));
        }
    }
}
