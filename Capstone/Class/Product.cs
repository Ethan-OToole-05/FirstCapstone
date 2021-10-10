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
                if (ProductAmount < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string SlotLocation { get; set; }

        public Product(string name, decimal price, string type, string slotLocation)
        {
            Name = name != null ? name : "";
            Type = type != null ? type : "";
            SlotLocation = slotLocation != null ? slotLocation : "";
            ProductAmount = 5;
            if(price < 0)
            {
                price = 0;
            }
            Price = price;
        }
    }
}
