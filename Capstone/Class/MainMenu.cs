using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class MainMenu : UserInterface
    {
        public new string[] MenuOptions { get; } = { "Display Inventory", "Make Purchase", "Exit" };
        public bool IsExit { get; set; } = false;
        public MainMenu(ProductInventory inventory) : base(inventory) { }
        public void startMenu(ProductInventory inventory)
        {
            while (!IsExit)
            {
                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    ClearScreen();
                    WriteToScreen("*** MAIN MENU ***");
                    WriteToScreen("Total Funds: $0.00");
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
                    WriteToScreen($"Thank you for shopping with Umbrella Corp!");
                    IsExit = true;
                }
            }
        }
    }
}
