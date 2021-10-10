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
        public bool WriteMenu(string[] menuOptions)
        {
            string output = "";
            if(menuOptions != null)
            {
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    output += $"\n{i + 1}. {menuOptions[i]}";
                }
            }
            WriteToScreen(output);
            return true;
        }
        public bool PrintProductInventory()
        {
            WriteToScreen("PRODUCT SELECTION");
            WriteToScreen("-----------------");
            try
            {
                foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
                {
                    string key = kvp.Key;
                    string name = kvp.Value.Name;
                    string price = $"{kvp.Value.Price:C2}";
                    if (kvp.Value.IsOutOfStock)
                    {
                        price = "OUT OF STOCK";
                    }
                    WriteToScreen($"{key} : {name.PadRight(20)}{price}");
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
            if(inventory == null)
            {
                WriteToScreen("ERROR: Unable to retrieve Product Inventory");
                return true;
            }
            WriteToScreen("PRODUCT INVENTORY");
            WriteToScreen("-----------------");
            foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
            {
                string key = kvp.Key;
                string name = kvp.Value.Name;
                string amount = kvp.Value.ProductAmount.ToString();
                string outOfStock = "";
                if(kvp.Value.IsOutOfStock)
                {
                    outOfStock = "OUT OF STOCK";
                }
                WriteToScreen($"{amount} {name.PadRight(20)}{outOfStock}");
            }
            WriteToScreen("");
            return true;
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
                return -1;
            }
        }
        public decimal GetMoneyInput(string prompt)
        {
            Console.Write(prompt);
            string entry = Console.ReadLine();
            try
            {
                decimal entryM = decimal.Parse(entry);
                return entryM;
            }
            catch (Exception e)
            {
                WriteToScreen("Invalid entry, please enter a cash amount.");
                return 0;
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
