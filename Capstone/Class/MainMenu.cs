using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class MainMenu : UserInterface
    {
        private string[] MenuOptions { get; } = { "DISPLAY INVENTORY", "MAKE PURCHASE", "EXIT" };
        private bool IsExit { get; set; } = false;
        public MainMenu(ProductInventory inventory) : base(inventory) { }
        public void startMenu(ProductInventory inventory)
        {
            WriteUmbrellaLogo();
            while (!IsExit)
            {
                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    ClearScreen();
                    WriteUmbrellaMenu();
                    WriteToScreen(@"|     '------------'");
                    WriteToScreen(@"|     * MAIN  MENU *");
                    WriteToScreen(@"|     *------------*");
                    WriteToScreen(@"|");
                    WriteToScreen(@"|   Total Funds: $0.00");
                    WriteToScreen(@"|");
                    WriteMenu(MenuOptions);
                    WriteToScreen(@"|");
                    userSelection = GetIntInput(@"\_// Please make a selection: ");
                    if (userSelection < 1 || userSelection > MenuOptions.Length)
                    {
                        WriteToScreen("Invalid Entry");
                        userSelection = GetIntInput("Please make a selection: ");
                    }
                }
                if (userSelection == 1)
                {
                    ClearScreen();
                    PrintProductInventory(inventory);
                    GetStringInput("Press any key to return: ");
                }
                if (userSelection == 2)
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu(inventory);
                    purchaseMenu.startMenu(inventory);
                }
                if (userSelection == 3)
                {
                    WriteToScreen($"Thank you for shopping with Umbrella Corporation!");
                    IsExit = true;
                }
            }
        }
        public bool PrintProductInventory(ProductInventory inventory)
        {
            if (inventory == null)
            {
                WriteToScreen("ERROR: Unable to retrieve Product Inventory");
                return true;
            }
            WriteToScreen("-----------------");
            WriteToScreen("PRODUCT INVENTORY");
            WriteToScreen("-----------------");
            foreach (KeyValuePair<string, Product> kvp in Inventory.Inventory)
            {
                string key = kvp.Key;
                string name = kvp.Value.Name;
                string amount = kvp.Value.ProductAmount.ToString();
                string outOfStock = "";
                if (kvp.Value.IsOutOfStock)
                {
                    outOfStock = "OUT OF STOCK";
                }
                WriteToScreen($"{amount} {name.PadRight(20)}{outOfStock}");
            }
            WriteToScreen("");
            return true;
        }

    }
}
