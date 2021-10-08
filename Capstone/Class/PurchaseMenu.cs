using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    class PurchaseMenu : ConsoleService
    {
        //public ConsoleService UserInterface { get; } = new ConsoleService();
        //public List<string> MenuOptions { get; } = new List<string>();
        //public ProductInventory Inventory { get; private set; }

        public Product SelectedProduct { get; private set; }
        public decimal MoneyFed { get; private set; } = 0;
        public string[] MenuArray { get; } = { "Feed Money", "Select Product", "Finish Transaction" };
        public bool TransactionComplete { get; set; } = false;

        public PurchaseMenu(ProductInventory inventory) : base(inventory)
        {
            WriteToScreen("***Purchase Menu***");

            while (!TransactionComplete)
            {
                //MenuOptions.Add("1. Feed Money");
                //MenuOptions.Add("2. Select Product");
                //MenuOptions.Add("3. Finish Transaction");
                //int userSelection = GetIntInput("Please make a selection: ");

                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    WriteToScreen(WriteMenu(MenuArray[0], MenuArray[1], MenuArray[2]));
                    userSelection = GetIntInput("Please make a selection: ");
                    //format error (try block)
                }
                if (userSelection == 1)
                {
                    WriteToScreen($"Total Funds: {MoneyFed}");
                    WriteToScreen("Please enter amount to add: ");
                    decimal money = decimal.Parse(Console.ReadLine());
                    WriteToScreen($"Total Funds: {FeedMoney(money)}");
                }
                if (userSelection == 2)
                {
                    SelectedProduct = SelectItem(Inventory);
                    WriteToScreen($"Item Dispensed: {SelectedProduct.Name}, {SelectedProduct.Price}");
                    WriteToScreen($"{DispenseProduct(SelectedProduct)}");
                    WriteToScreen($"Remaining Funds: {Checkout(SelectedProduct)}");
                }
                if (userSelection == 3)
                {
                    WriteToScreen($"Change Returned: {Checkout(SelectedProduct)}");
                    WriteToScreen(DispenseChange(MoneyFed));
                    WriteToScreen($"Thank you for shopping with Umbrella Corp!");
                    //todo send user to main menu
                }

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
        //public ProductInventory PrintProductInventory()
        //{
        //    ProductInventory inventory = new ProductInventory();
        //    return inventory;
        //}

        public Product SelectItem(ProductInventory inventory)
        {
            //try
            //{
            ProductInventory Inventory = inventory;
            foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
            {
                WriteToScreen($"{kvp.Key} : {kvp.Value.Name} : {kvp.Value.Price}");
            }
            string userSelection = "";
            while(!Inventory.Inventory.ContainsKey(userSelection) || Inventory.Inventory[userSelection].IsOutOfStock)
            {
                WriteToScreen("Please make your selection: ");
                userSelection = Console.ReadLine().ToUpper();
                if (!Inventory.Inventory.ContainsKey(userSelection) || Inventory.Inventory[userSelection].IsOutOfStock)
                {
                    WriteToScreen("Sorry, that product is not available.");
                }
            }
            SelectedProduct = Inventory.Inventory[userSelection];
            return SelectedProduct;
            //}
            //catch(Exception e)
            //{
            //    ui.WriteToScreen("Sorry, please try again...");
            //    return SelectedProduct;
            //}
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
        public string DispenseChange(decimal moneyFed)
        {
            int cents = (int)(moneyFed * 100);
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            string output = "$Dispensed ";
            while(cents - 25 >= 0)
            {
                quarters++;
                cents -= 25;
            }

            if(quarters > 0)
            {
                output += $"{quarters} quarters";
            }
            while(cents - 10 >= 0)
            {
                dimes++;
                cents -= 10;
            }

            if (dimes > 0)
            {
                output += $"{dimes} dimes";
            }

            while (cents - 5 >= 0)
            {
                nickels++;
                cents -= 5;
            }
            if (nickels > 0)
            {
                output += $"{nickels} nickels";
            }

            pennies += cents;
            if (pennies > 0)
            {
                output += $"{pennies} pennies";
            }

            MoneyFed = 0;
            TransactionComplete = true;
            
            return output;
        }   
    }
}
