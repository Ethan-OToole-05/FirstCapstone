using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class ProductInventory
    {
        public Dictionary<string, Product> Inventory { get; } = new Dictionary<string, Product>();

        public ProductInventory()
        {
            string filePath = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(filePath, fileName);
            if (!File.Exists(fullPath))
            {
                filePath.Replace(@"\bin\Debug\netcoreapp3.1", "");
                fullPath = Path.Combine(filePath, fileName);
            }
            while (!File.Exists(fullPath)) 
            {
                Console.WriteLine("ERROR: Could not locate inventory file.");
                Console.WriteLine("Please enter the full path to the file: ");
                filePath = Console.ReadLine();
                fullPath = Path.Combine(filePath, fileName);
            }
            try
            {
                using (StreamReader dataInput = new StreamReader(fullPath))
                {
                    while(!dataInput.EndOfStream)
                    {
                        string[] productArray = dataInput.ReadLine().Split("|");
                        Product tempProduct = new Product(productArray[1], decimal.Parse(productArray[2]), productArray[3], productArray[0]);
                        Inventory.Add(productArray[0], tempProduct);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("File not found. Please restart the app.");
            }
        }
    }
}
