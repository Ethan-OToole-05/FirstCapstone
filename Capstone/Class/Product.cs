﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public bool IsOutOfStock { get; set; }
        public int ProductAmount { get; set; }

        public Product(string name, decimal price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
            ProductAmount = 5;
            IsOutOfStock = false;
        }
    }
}
