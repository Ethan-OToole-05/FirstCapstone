using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class ProductInventory
    {
        public Dictionary<string, Product> Inventory { get; set; } = new Dictionary<string, Product>();

        public ProductInventory()
        {
            //todo tests will be relative path
            //todo CurrentDirectory
            string dataFilePath = "C:\\Users\\Student\\workspace\\capstones\\c-capstone-module-1-team-4\\vendingmachine.csv";
            if (!File.Exists(dataFilePath))
            {
                throw new FileNotFoundException();
            }
            try
            {
                using (StreamReader dataInput = new StreamReader(dataFilePath))
                {
                    while(!dataInput.EndOfStream)
                    {
                        string[] productArray = dataInput.ReadLine().Split("|");
                        Product tempProduct = new Product(productArray[1], decimal.Parse(productArray[2]), productArray[3]);
                        Inventory.Add(productArray[0], tempProduct);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong!");
            }
        }
    }
}
