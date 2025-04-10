using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUsingConstructors
{
    class Program
    {
        static int option;
        static void Main(string[] args)
        {
            List<UserInfo> user = new List<UserInfo>();
            
            do
            {
                Console.Clear();
                option = MainMenu();
                if(option == 1)
                {

                }
                if (option == 2)
                {

                }
                if (option == 3)
                {

                }
                if (option == 4)
                {

                }
                if (option == 5)
                {

                }
            } while (option < 6);
        }
        static int MainMenu()
        {
            Console.WriteLine("1.Create your information.");
            Console.WriteLine("2.View your information.");
            Console.WriteLine("3.Update your information.");
            Console.WriteLine("4.Delete your information.");
            Console.WriteLine("5.Exit.");
            Console.Write("Enter Option.");
            option = int.Parse(Console.ReadLine()); 
            return option;
        }
    }
}
