using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public bool isOutOfStock { get; set; }
        public int ProductAmount { get; set; }

        public Product(string name, double price, string type)
        {
            Name = name;
            Price = price;
            Type = type;

        }

    }
}
