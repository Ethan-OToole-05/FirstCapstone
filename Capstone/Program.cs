using System;
using Capstone.Class;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductInventory inventory = new ProductInventory();
            MainMenu mainMenu = new MainMenu(inventory);
            mainMenu.startMenu(inventory);
        }
    }
}


