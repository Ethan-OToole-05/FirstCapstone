using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {

        //Create a interface to navigate through each menu.

        private Dictionary<string, Product> ProductInventory { get; set; } = new Dictionary<string, Product>();

        private Dictionary<Product, int> ProductSold { get; set; } = new Dictionary<Product, int>();




    }
}
