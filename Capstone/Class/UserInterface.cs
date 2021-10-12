using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class UserInterface
    {
        private string[] MenuOptions { get; }
        public ProductInventory Inventory { get; }
        
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

                    output = $"|    {i + 1}. {menuOptions[i]}";
                    WriteToScreen(output);
                }
            }
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
        public void WriteUmbrellaLogo()
        {
            string filePath = Environment.CurrentDirectory;
            string txtImgFile = "TextImages\\umbrellaLogo.txt";
            string fullPath = Path.Combine(filePath, txtImgFile);
            if (!File.Exists(fullPath))
            {
                filePath.Replace(@"\bin\Debug\netcoreapp3.1", "");
                fullPath = Path.Combine(filePath, txtImgFile);
            }
            try
            {
                using(StreamReader sr = new StreamReader(fullPath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        WriteToScreen(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("UMBRELLA CORPORATION");
                Console.WriteLine("**VENDO-MATIC  800**");
                Console.WriteLine();
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void WriteUmbrellaMenu()
        {
            string filePath = Environment.CurrentDirectory;
            string txtImgFile = "TextImages\\halfUmbrella.txt";
            string fullPath = Path.Combine(filePath, txtImgFile);
            if (!File.Exists(fullPath))
            {
                filePath.Replace(@"\bin\Debug\netcoreapp3.1", "");
                fullPath = Path.Combine(filePath, txtImgFile);
            }
            try
            {
                using (StreamReader stream = new StreamReader(fullPath))
                {
                    while (!stream.EndOfStream)
                    {
                        string line = stream.ReadLine();
                        WriteToScreen(line);
                    }
                }
            }
            catch (Exception e)
            {
                WriteToScreen(" * brought to you by UMBRELLA CORP * ");
            }
        }
    }
}
