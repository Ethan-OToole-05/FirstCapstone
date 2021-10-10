using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class PurchaseMenu : UserInterface
    {
        public Product SelectedProduct { get; private set; }
        public decimal MoneyFed { get; private set; } = 0;
        public new string[] MenuOptions { get; } = { "Add Funds", "Select Product", "Checkout" };
        public bool IsTransactionComplete { get; set; } = false;
        public SalesReport Report { get; } = new SalesReport();
        public PurchaseMenu(ProductInventory inventory) : base(inventory) { }
        public void startMenu(ProductInventory inventory)
        {
            while (!IsTransactionComplete)
            {
                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    ClearScreen();
                    WriteToScreen("*** PURCHASE MENU ***");
                    WriteToScreen($"Total Funds: {MoneyFed:C2}");
                    WriteMenu(MenuOptions);
                    userSelection = GetIntInput("Please make a selection: ");
                    if (userSelection < 1 || userSelection > MenuOptions.Length)
                    {
                        WriteToScreen("Invalid Entry");
                        userSelection = GetIntInput("Please make a selection: ");
                    }
                }
                if (userSelection == 1)
                {
                    FeedMoney(GetMoneyInput("Please enter amount to add: "));
                    GetStringInput("Press any key to return: ");
                }
                if (userSelection == 2)
                {
                    WriteToScreen("");
                    if (SelectItem(Inventory))
                    {
                        DispenseProduct(SelectedProduct);
                        WriteToScreen($"Remaining Funds: {MoneyFed}");
                        GetStringInput("Press any key to return: ");
                    }
                }
                if (userSelection == 3)
                {
                    WriteToScreen($"Change Returned: {MoneyFed:C2}");
                    DispenseChange(MoneyFed);
                    GetStringInput("Press any key to return: ");
                }
            }

        }
        public decimal FeedMoney(decimal money)
        {
            if(money + MoneyFed > 20)
            {
                WriteToScreen("DECLINED: You cannot add funds above $20");
                return MoneyFed;
            }
            if(money > 0)
            {
                MoneyFed += money;
                WriteToScreen($"Funds Accepted: {money:C2}");
                WriteToScreen($"New Total Funds: {MoneyFed:C2}");
            }
            Report.FeedMoneyReport(money, MoneyFed);
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
        public bool DispenseProduct(Product selectedProduct)
        {
            decimal oldMoney = MoneyFed;
            if (MoneyFed >= selectedProduct.Price)
            {
                MoneyFed -= selectedProduct.Price;
            }
            Report.BoughtProductReport(oldMoney, MoneyFed, selectedProduct);
            WriteToScreen($"Item Dispensed: {SelectedProduct.Name}, {SelectedProduct.Price:C2}");
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
            WriteToScreen(output);
            return true;
        }
        public bool DispenseChange(decimal moneyFed)
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
            IsTransactionComplete = true;
            if(output.Equals("Dispensed "))
            {
                output += "no change";
            }
            WriteToScreen(output);
            return true;
        }   
    }
}
