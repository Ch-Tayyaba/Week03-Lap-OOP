using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            Angle a = new Angle();
            
            int option;
            option = menu();
            do
            {
                if (option == 1)
                {
                    Ship p = new Ship();
                    p = (p.takeInput());
                    ships.Add(p);
                    a = a.takeInput();
                    
                }


            }
            while (option < 6);
            Console.Read();
        }
        static int menu()
            {
                int option;
                Console.WriteLine("1.Add Ship");
                Console.WriteLine("2. View Ship Position");
                Console.WriteLine("3.View Ship serial number");
                Console.WriteLine("4.Change Ship Position");
                Console.WriteLine("5.Exit");
                option = int.Parse(Console.ReadLine());
                return option;
            }
        
        


    }
}
