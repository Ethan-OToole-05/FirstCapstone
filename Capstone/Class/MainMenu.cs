using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class MainMenu : UserInterface
    {
        public new string[] MenuOptions { get; } = { "Display Vending Machine Items", "Purchase", "Exit" };
        public bool IsExit { get; set; } = false;
        public MainMenu(ProductInventory inventory) : base(inventory)
        {
            while(!IsExit)
            {
                WriteToScreen("*** MAIN MENU ***");
                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    WriteToScreen(WriteMenu(MenuOptions));
                    userSelection = GetIntInput("Please make a selection: ");
                }
                if (userSelection == 1)
                {
                    PrintProductInventory(inventory);
                }
                if (userSelection == 2)
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu(inventory);
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
