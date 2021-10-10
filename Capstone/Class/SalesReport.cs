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
    {//Need money and money feeding MoneyFed
        public bool FeedMoneyReport(decimal moneyFed, decimal totalMoney)
        {
            string directory = Directory.GetCurrentDirectory();
            string textFile = "Log.txt";
            string pathToReport = Path.Combine(directory, textFile);

            try
            {
                using (StreamWriter sw = new StreamWriter(pathToReport, true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY ${moneyFed} ${totalMoney}");
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
            return true;
        }
        public bool BoughtProductReport(decimal moneyFed, decimal totalMoney, Product product)
        {
            string directory = Directory.GetCurrentDirectory();
            string textFile = "Log.txt";
            string pathToReport = Path.Combine(directory, textFile);

            try
            {
                using (StreamWriter sw = new StreamWriter(pathToReport, true))
                {
                    sw.WriteLine($"{DateTime.Now} ${product.Name} ${product.SlotLocation} ${moneyFed} ${totalMoney}");



                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
            return true;
        }

        //public void WritingReports()
        //{
        //    string directory = Directory.GetCurrentDirectory();
        //    string textFile = "Log.txt";
        //    string pathToReport = Path.Combine(directory, textFile);

        //    try
        //    {
        //        using(StreamWriter sw = new StreamWriter(pathToReport))
        //        {
        //            sw.WriteLine(DateTime.Now);
                    
        //        }
                
        //    } catch(Exception e)
        //    {
        //        Console.WriteLine("Something went wrong");
        //    }
            
        //}


    }
}
