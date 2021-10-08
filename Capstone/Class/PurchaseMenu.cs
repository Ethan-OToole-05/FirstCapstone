using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    class PurchaseMenu : Menu
    {
        public ConsoleService UserInterface { get; } = new ConsoleService();
        public List<string> MenuOptions { get; } = new List<string>();
        public decimal MoneyFed { get; private set; } = 0;
        public ProductInventory Inventory { get; private set; }
        public Product SelectedProduct { get; private set; }
        
        public PurchaseMenu(ConsoleService ui)
        {
            UserInterface = ui;
            ui.WriteToScreen("***Purchase Menu***");

            MenuOptions.Add("1. Feed Money");
            MenuOptions.Add("2. Select Product");
            MenuOptions.Add("3. Finish Transaction");
            
            foreach(string option in MenuOptions)
            {
                ui.WriteToScreen(option);
            }

            ui.WriteToScreen("Please make a selection: ");
            int userSelection = int.Parse(Console.ReadLine());
            while (userSelection < 1 || userSelection > 4)
            {
                foreach (string option in MenuOptions)
                {
                    ui.WriteToScreen(option);
                }

                ui.WriteToScreen("Please make a selection: ");
                userSelection = int.Parse(Console.ReadLine());
            }
            if (userSelection == 1)
            {
                ui.WriteToScreen($"Total Funds: {MoneyFed}");
                ui.WriteToScreen("Please enter amount to add: ");
                decimal money = decimal.Parse(Console.ReadLine());
                ui.WriteToScreen($"Total Funds: {FeedMoney(money)}");
            }
            if (userSelection == 2 && SelectItem(ui))
            {
                ui.WriteToScreen($"Item Dispensed: {SelectedProduct.Name}, {SelectedProduct.Price}");
                ui.WriteToScreen($"{DispenseProduct(SelectedProduct)}");
                ui.WriteToScreen($"Remaining Funds: {Checkout(SelectedProduct)}");
            }
            if (userSelection == 3)
            {
                ui.WriteToScreen($"Change Returned: {MoneyFed}");
                MoneyFed = 0;
                ui.WriteToScreen($"Thank you for shopping with Umbrella Corp!");
                //todo return change in coins
                //todo send user to main menu
            }
        }

        public decimal FeedMoney(decimal money)
        {
            if(money > 0)
            {
                MoneyFed += money;
            }
            return MoneyFed;
        }

        //should be in base class Menu:
        public ProductInventory PrintProductInventory()
        {
            ProductInventory inventory = new ProductInventory();
            return inventory;
        }

        public bool SelectItem(ConsoleService ui)
        {
            try
            {
                ProductInventory Inventory = new ProductInventory();
                foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
                {
                    ui.WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : {kvp.Value.Price}");
                }
                string userSelection = "";
                while(!Inventory.Inventory.ContainsKey(userSelection) || Inventory.Inventory[userSelection].IsOutOfStock)
                {
                    ui.WriteToScreen("Sorry, your current selection is unavailable.");
                    ui.WriteToScreen("Please make your selection: ");
                    userSelection = Console.ReadLine();   
                }
                SelectedProduct = Inventory.Inventory[userSelection];
                return true;
            }
            catch(Exception e)
            {
                ui.WriteToScreen("Sorry, please try again...");
                return false;
            }
        }
        public decimal Checkout(Product selectedProduct)
        {
            if(MoneyFed >= selectedProduct.Price)
            {
                MoneyFed -= selectedProduct.Price;
            }
            return MoneyFed;
        }
        public string DispenseProduct(Product selectedProduct)
        {
            string output = "";
            if(!selectedProduct.IsOutOfStock)
            {
                selectedProduct.ProductAmount--;
            }
            //todo generate audit log entry
            //todo update sales report
            if (SelectedProduct.Type.ToLower() == "chip")
            {
                output = "Crunch Crunch, Yum!";
            }
            if (SelectedProduct.Type.ToLower() == "candy")
            {
                output = "Munch Munch, Yum!";
            }
            if (SelectedProduct.Type.ToLower() == "drink")
            {
                output = "Glug Glug, Yum!";
            }
            if (SelectedProduct.Type.ToLower() == "gum")
            {
                output = "Chew Chew, Yum!";
            }
            return output;
        }
        public decimal DispenseChange(decimal moneyFed)
        {
            int cents = (int)(moneyFed * 100);
            int counter = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            while(cents - 25 > 0)
            {
                counter++;
            } 
            

            return MoneyFed;
        }
    }
}
