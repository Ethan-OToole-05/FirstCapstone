using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    class MainMenuTests
    {
        static ProductInventory inventory = new ProductInventory();
        private MainMenu mainMenu = new MainMenu(inventory);
    }
}
