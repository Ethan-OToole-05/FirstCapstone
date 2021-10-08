﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class ConsoleService
    {
        public List<string> MenuOptions { get; } = new List<string>();
        public ProductInventory Inventory { get; private set; }
        
        public ConsoleService(ProductInventory inventory)
        {
            Inventory = inventory;
        }

        public string WriteMenu(string optionOne, string optionTwo, string optionThree)
        {
            MenuOptions.Add($"1. {optionOne}");
            MenuOptions.Add($"2. {optionTwo}");
            MenuOptions.Add($"3. {optionThree}");

            return $"\n1. {optionOne}\n2. {optionTwo}\n3. {optionThree}";
        }

        public bool PrintProductInventory()
        {
            WriteToScreen("");
            WriteToScreen("*** PRODUCT SELECTION ***");
            WriteToScreen("");
            try
            {
                foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
                {
                    WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : {kvp.Value.Price}");
                }
                WriteToScreen("");
                return true;
            }
            catch(Exception e)
            {
                WriteToScreen("Oops. Something went wrong...");
                return false;
            }
        }

        public bool PrintProductInventory(ProductInventory inventory)
        {
            WriteToScreen("");
            WriteToScreen("*** AVAILABLE PRODUCTS ***");
            WriteToScreen("");
            try
            {
                foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
                {
                    if(!kvp.Value.IsOutOfStock)
                    {
                        WriteToScreen($"{kvp.Value.ProductAmount} {kvp.Value.Name}");
                    }
                    else
                    {
                        WriteToScreen($"{kvp.Value.ProductAmount} {kvp.Value.Name} : OUT OF STOCK");
                    }
                }
                WriteToScreen("");
                return true;
            }
            catch (Exception e)
            {
                WriteToScreen("Oops. Something went wrong...");
                return false;
            }
        }

        public string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            string entry = Console.ReadLine();
            return entry;
        }

        public int GetIntInput(string prompt)
        {
            Console.Write(prompt);
            string entry = Console.ReadLine();
            try
            {
                int entryInt = int.Parse(entry);
                return entryInt;
            }
            catch (Exception e)
            {
                throw new FormatException($"Cannot parse {entry} into an integer.");
            }
        }

        public void WriteToScreen(string output)
        {
            Console.WriteLine(output);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
