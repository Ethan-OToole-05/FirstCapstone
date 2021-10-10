using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    class PurchaseMenu : UserInterface
    {
        public Product SelectedProduct { get; private set; }
        public decimal MoneyFed { get; private set; } = 0;
        public string[] MenuArray { get; } = { "Feed Money", "Select Product", "Finish Transaction" };
        public bool TransactionComplete { get; set; } = false;

        public SalesReport salesReport = new SalesReport();

        public decimal oldMoney = 0;

        public PurchaseMenu(ProductInventory inventory) : base(inventory)
        {
            WriteToScreen("***Purchase Menu***");

            while (!TransactionComplete)
            {
                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    WriteToScreen(WriteMenu(MenuArray[0], MenuArray[1], MenuArray[2]));
                    WriteToScreen($"Total Funds: {MoneyFed}");
                    userSelection = GetIntInput("Please make a selection: ");
                }
                if (userSelection == 1)
                {
                    WriteToScreen("Please enter amount to add: ");
                    decimal money = decimal.Parse(Console.ReadLine());
                    FeedMoney(money);
                }
                if (userSelection == 2)
                {
                    if(SelectItem(Inventory))
                    {
                        WriteToScreen($"Item Dispensed: {SelectedProduct.Name}, {SelectedProduct.Price}");
                        WriteToScreen($"{DispenseProduct(SelectedProduct)}");
                        WriteToScreen($"Remaining Funds: {Checkout(SelectedProduct)}");
                    }
                }
                if (userSelection == 3)
                {
                    WriteToScreen($"Change Returned: {MoneyFed}");
                    WriteToScreen(DispenseChange(MoneyFed));
                }

            }
        }

        public decimal FeedMoney(decimal money)
        {
            if(money + MoneyFed > 160)
            {
                WriteToScreen("DECLINED: You cannot add funds above $160.00");
                return MoneyFed;
            }
            if(money > 0)
            {
                MoneyFed += money;
            }
            salesReport.FeedMoneyReport(money, MoneyFed);
            
            return MoneyFed;

        }
        public bool SelectItem(ProductInventory inventory)
        {
            PrintProductInventory();
            string userSelection = "";
            while(!Inventory.Inventory.ContainsKey(userSelection) || Inventory.Inventory[userSelection].IsOutOfStock || Inventory.Inventory[userSelection].Price > MoneyFed)
            {
                userSelection = GetStringInput("Please make your selection: ").ToUpper();
                if (!Inventory.Inventory.ContainsKey(userSelection) || Inventory.Inventory[userSelection].IsOutOfStock)
                {
                    WriteToScreen("Sorry, that selection is not available.");
                    return false;
                }
                else if (Inventory.Inventory[userSelection].Price > MoneyFed)
                {
                    WriteToScreen("Not enough funds.");
                    return false;
                }
            }
            SelectedProduct = Inventory.Inventory[userSelection];
            return true;
        }
        public decimal Checkout(Product selectedProduct)
        {
            oldMoney = MoneyFed;
            if(MoneyFed >= selectedProduct.Price)
            {
                MoneyFed -= selectedProduct.Price;
            }
            salesReport.BoughtProductReport(oldMoney, MoneyFed, selectedProduct);
            return MoneyFed;
        }
        public string DispenseProduct(Product selectedProduct)
        {
            string output = "";
            if(!selectedProduct.IsOutOfStock)
            {
                selectedProduct.ProductAmount--;
            }
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
            string output = "Dispensed ";
            while(cents - 25 >= 0)
            {
                quarters++;
                cents -= 25;
            }

            if(quarters > 0)
            {
                output += $"{quarters} quarters ";
            }
            while(cents - 10 >= 0)
            {
                dimes++;
                cents -= 10;
            }

            if (dimes > 0)
            {
                output += $"{dimes} dimes ";
            }

            while (cents - 5 >= 0)
            {
                nickels++;
                cents -= 5;
            }
            if (nickels > 0)
            {
                output += $"{nickels} nickels ";
            }

            pennies += cents;
            if (pennies > 0)
            {
                output += $" {pennies} pennies";
            }

            MoneyFed = 0;
            TransactionComplete = true;
            
            return output;
        }   
    }
}
