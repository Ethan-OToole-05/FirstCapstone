using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Class;

namespace Capstone
{

    //I need to make a 'shell' of a menu to inherit it into the other menus
    //I need to read the input.
    //I need to 



    public class Menu
    {

        public string Options { get; set; }

        public string Choices(string output)
        {
            output = "---Welcome---\n(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit";
            Console.WriteLine(output);
            string input = Console.ReadLine();
            if(input.Contains('1'))
            {
                string dataFilePath = "C:\\Users\\Student\\workspace\\capstones\\c-capstone-module-1-team-4\\vendingmachine.csv";
                if (!File.Exists(dataFilePath))
                {
                    throw new FileNotFoundException();
                }
                try
                {
                    using (StreamReader dataInput = new StreamReader(dataFilePath))
                    {
                        while (!dataInput.EndOfStream)
                        {
                            string[] productArray = dataInput.ReadLine().Split("|");
                            Product tempProduct = new Product(productArray[1], decimal.Parse(productArray[2]), productArray[3]);
                            Console.WriteLine($"{productArray[1]}|{productArray[2]}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong!");
                }
            }
            return input;
            
        }

    }
}
