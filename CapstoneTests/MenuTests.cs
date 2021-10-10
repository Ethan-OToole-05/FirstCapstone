using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    public class MenuTests
    {
        private static ProductInventory inventory = new ProductInventory();
        private UserInterface ui = new UserInterface(inventory);
        [TestMethod]
        public void writeMenuHappyPathTest()
        {
            string[] menuOptions = { "first", "second", "third" };
            string expected = $"/n1. first/n2. second/n3. third";
            string actual = ui.WriteMenu(menuOptions);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void writeMenuMoreOptionsTest()
        {
            string[] moreMenuOptions = { "first", "second", "third", "fourth", "fifth" };
            string expected = $"/n1. first/n2. second/n3. third/n4. fourth/n5. fifth";
            string actual = ui.WriteMenu(moreMenuOptions);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void writeMenuNullTest()
        {
            string[] nullMenuOptions = null;
            string expected = "";
            string actual = ui.WriteMenu(nullMenuOptions);
            Assert.AreEqual(expected, actual);
        }
    }
}
