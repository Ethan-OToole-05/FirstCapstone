using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{

    //I need to make a 'shell' of a menu to inherit it into the other menus
    //I need to read the input.
    //I need to 



    public class Menu
    {

        public string Options { get; set; }

        public string Choices(string output)
        {
            output = "(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit";
            Console.WriteLine(output);
            string input = Console.ReadLine();
            if(input.Contains('1'))
            {

            }
            return input;
            
        }

    }
}
