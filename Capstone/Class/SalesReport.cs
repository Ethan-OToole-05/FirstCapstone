using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone.Class
{
    /*--TODO--
     * We need to audit each purchase which might be in purchase menu.
     * We need to write down the time for each action performed:
     * Time feed money
     * Items purchased each
     * And time we gave them their change back
     * Generate each line in a file called 'Log.txt'
     */ 
    

    public class SalesReport
    {//Report on time money was fed and how much was fed.
        public bool FeedMoneyReport(decimal moneyFed, decimal totalMoney)
        {
            string directory = Environment.CurrentDirectory;
            string textFile = "Log.txt";
            string pathToReport = Path.Combine(directory, textFile);
            if (!File.Exists(textFile))
            {
                File.Create(textFile);
                using (StreamWriter write = File.CreateText(textFile))
                {
                    write.WriteLine("NEW AUDIT LOG");
                    write.WriteLine("-------------");
                }
            }
                try
                {
                    using (StreamWriter sw = new StreamWriter(pathToReport, true))
                    {
                        sw.WriteLine($"{DateTime.Now} FEED MONEY {moneyFed:C2} : {totalMoney:C2}");

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong");
                    return false;
                }
                return true;          
        }
        public bool BoughtProductReport(decimal moneyFed, decimal totalMoney, Product product)
        {
            string directory = Directory.GetCurrentDirectory();
            string textFile = "Log.txt";
            string pathToReport = Path.Combine(directory, textFile);
            if (!File.Exists(textFile))
            {
                File.Create(textFile);
                using (StreamWriter write = File.CreateText(textFile))
                {
                    write.WriteLine("NEW AUDIT LOG");
                    write.WriteLine("-------------");
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToReport, true))
                {
                    sw.WriteLine($"{DateTime.Now} PURCHASE {product.Name} {product.SlotLocation} {moneyFed:C2} : {totalMoney:C2}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                return false;
            }
            return true;
        }
        public bool DispensedChangeReport(decimal moneyFed)
        {
            string directory = Directory.GetCurrentDirectory();
            string textFile = "Log.txt";
            string pathToReport = Path.Combine(directory, textFile);
            if (!File.Exists(textFile))
            {
                File.Create(textFile);
                using (StreamWriter write = File.CreateText(textFile))
                {
                    write.WriteLine("NEW AUDIT LOG");
                    write.WriteLine("-------------");
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToReport, true))
                {
                    sw.WriteLine($"{DateTime.Now} DISPENSED CHANGE {moneyFed:C2}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                return false;
            }
            return true;
        }
    }
}
