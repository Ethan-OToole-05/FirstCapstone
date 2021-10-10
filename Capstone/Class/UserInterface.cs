using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class UserInterface
    {
        public string[] MenuOptions { get; }
        public ProductInventory Inventory { get; set; }
        
        public UserInterface(ProductInventory inventory)
        {
            Inventory = inventory;
        }
        public string WriteMenu(string[] menuOptions)
        {
            string output = "";
            try
            {
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    output += $"\n{i + 1}. {menuOptions[i]}";
                }
            }
            catch(NullReferenceException)
            {
                WriteToScreen("Menu cannot be retrieved, please restart the app.");
            }
            return output;
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
                    if(kvp.Value.IsOutOfStock)
                    {
                        WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : OUT OF STOCK");
                    }
                    else
                    {
                        WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : {kvp.Value.Price:C2}");
                    }
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
                    if(kvp.Value.IsOutOfStock)
                    {
                        WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : OUT OF STOCK");
                    }
                    else
                    {
                        WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : {kvp.Value.ProductAmount}");
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
            WriteToScreen(prompt);
            string entry = Console.ReadLine();
            try
            {
                int entryInt = int.Parse(entry);
                return entryInt;
            }
            catch (Exception e)
            {
                WriteToScreen("Invalid entry, please enter a number.");
                return -1;
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
