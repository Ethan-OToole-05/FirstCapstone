using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int ProductAmount { get; set; }
        public bool IsOutOfStock
        {
            get
            {
                if (ProductAmount > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public string SlotLocation { get; set; }

        public Product(string name, decimal price, string type, string slotLocation)
        {
            Name = name;
            Price = price;
            Type = type;
            SlotLocation = slotLocation;
            ProductAmount = 5;
        }
    }
}
