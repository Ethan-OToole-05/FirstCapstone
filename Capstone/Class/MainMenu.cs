using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{

    public class MainMenu : UserInterface
    {
        public ProductInventory ProductInventory { get; private set; } = new ProductInventory();
        public string[] MenuArray { get; } = { "Display Vending Machine Items", "Purchase", "Exit" };
        public bool Exit { get; set; } = false;

        public MainMenu(ProductInventory inventory) : base(inventory)
        {
            while(!Exit)
            {
                WriteToScreen("*** MAIN MENU ***");
                int userSelection = 0;
                while (userSelection < 1 || userSelection > 3)
                {
                    WriteToScreen(WriteMenu(MenuArray));
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
                    Exit = true;
                }
            }
        }
        //public string Options { get; set; }

        //public string Choices(string output)
        //{
        //    output = "---Welcome---\n(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit";
        //    Console.WriteLine(output);
        //    string input = Console.ReadLine();
        //    if(input.Contains('1'))
        //    {
        //        string dataFilePath = "C:\\Users\\Student\\workspace\\capstones\\c-capstone-module-1-team-4\\vendingmachine.csv";
        //        if (!File.Exists(dataFilePath))
        //        {
        //            throw new FileNotFoundException();
        //        }
        //        try
        //        {
        //            using (StreamReader dataInput = new StreamReader(dataFilePath))
        //            {
        //                while (!dataInput.EndOfStream)
        //                {
        //                    string[] productArray = dataInput.ReadLine().Split("|");
        //                    Product tempProduct = new Product(productArray[1], decimal.Parse(productArray[2]), productArray[3], productArray[0]);
        //                    Console.WriteLine($"{productArray[1]}|{productArray[2]}");
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Something went wrong!");
        //        }
        //    }
        //    return input;
            
        //}

    }
}
