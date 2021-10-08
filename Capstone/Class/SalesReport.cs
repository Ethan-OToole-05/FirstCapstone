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
    {


        public void WritingReports()
        {
            string directory = Directory.GetCurrentDirectory();
            string textFile = "Log.txt";
            string pathToReport = Path.Combine(directory, textFile);

            try
            {
                using(StreamWriter sw = new StreamWriter(pathToReport))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.Flush();
                    sw.Close();
                    
                }
                
            } catch(Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
            
        }





        /*public void WritingReports ()
        {
            try
            {
                DirectoryInfo[] cDirs = new DirectoryInfo("C:\\").GetDirectories();
                StreamWriter sw = new StreamWriter("SalesReports.txt"))
                {
                    foreach (DirectoryInfo dir in cDirs)
                    {
                        sw.WriteLine()
                    }
                }
            }
        }*/


    }
}
