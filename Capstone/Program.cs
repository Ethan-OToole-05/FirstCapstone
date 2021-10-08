using System;
using Capstone.Class;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductInventory inventory = new ProductInventory();
            ConsoleService ui = new ConsoleService(inventory);


            PurchaseMenu purchaseMenu = new PurchaseMenu(inventory);

        }
    }
}


