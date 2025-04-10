using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_oop_lab_Ship_Task
{
    class Program
    {
        class Angle
        {
            public Angle()
            {

            }
            public Angle(int degrees, float minutes, char direction)
            {
                this.degrees = degrees;
                this.minutes = minutes;
                this.direction = direction;
            }
         

            public int degrees;
            public float minutes;
            public char direction;
        }

        class Ship
        {
            public Ship()
            {

            }
            public Ship(string shipnumber)
            {
                this.shipnumber = shipnumber;
            }
            public Ship(string shipnumber, Angle shiplatitude, Angle shiplongitude)
            {
                this.shipnumber = shipnumber;
                this.shiplatitude = shiplatitude;
                this.shiplongitude = shiplongitude;
            }
            public Ship takeinfo()
            {
                string shipnumber;
                Angle a1 = new Angle();
                Angle a2 = new Angle();
                Console.WriteLine("Enter the ship number");
                shipnumber = Console.ReadLine();
                Console.WriteLine("Latitude ");
                Console.WriteLine("Enter Degrees :");
                a1.degrees = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Minutes :");
                a1.minutes = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Direction :");
                a1.direction = char.Parse(Console.ReadLine());
                Console.WriteLine("Longitude ");
                Console.WriteLine("Enter Degrees :");
                a2.degrees = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Minutes :");
                a2.minutes = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Direction :");
                a2.direction = char.Parse(Console.ReadLine());
                Ship s = new Ship(shipnumber, a1, a2);
                return s;
            }

            public void returnslocation(List<Ship> ships)
            {
                Console.WriteLine("Enter Ship Serial Number to find its position: ");
                string shipnumberofuser = Console.ReadLine();
                for (int idx = 0; idx < ships.Count; idx ++)
                {
                    if (shipnumberofuser == ships[idx].shipnumber)
                    {
                        Console.WriteLine("Ship is at" + ships[idx].shiplatitude.degrees + "*" + ships[idx].shiplatitude.minutes + "'" + ships[idx].shiplatitude.direction + " and " + ships[idx].shiplongitude.degrees + "*" + ships[idx].shiplongitude.minutes + "'" + ships[idx].shiplongitude.direction);
                    }
                }
            }

            public string returnshipnumber(List<Ship>ships)
            {
                Console.WriteLine("Ships's Latitude");
                Console.WriteLine("Enter Degrees : ");
                int degrees =int .Parse( Console.ReadLine());
                Console.WriteLine("Enter minutes : ");
                float minutes = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter direction : ");
                char direction = char.Parse(Console.ReadLine());
                Console.WriteLine("Ships's Longitude");
                Console.WriteLine("Enter Degrees : ");
                int degrees1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter minutes : ");
                float minutes1 = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter direction : ");
                char direction1 = char.Parse(Console.ReadLine());
               for(int idx = 0; idx < ships.Count; idx ++)
                {
                    if (degrees == ships[idx].shiplatitude.degrees && minutes == ships[idx].shiplatitude.minutes && direction == ships[idx].shiplatitude.direction && degrees1 == ships[idx].shiplongitude.degrees && minutes1 == ships[idx].shiplongitude.minutes && direction1 == ships[idx].shiplongitude.direction)
                    {
                        return ships[idx].shipnumber;
                    }
                }
                return null;
            }

            public void updateship(List<Ship> ships)
            {
                Console.WriteLine("Enter Ship’s serial number whose position you want to change:");
                string shipnumber = Console.ReadLine();
                for (int idx = 0; idx < ships.Count; idx ++)
                {
                    if (shipnumber == ships[idx].shipnumber)
                    {
                        Console.WriteLine("Ship Exists");
                        Console.WriteLine("Enter ship latitude : ");
                        Console.WriteLine("Enter degrees : ");
                        ships[idx].shiplatitude.degrees =int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter minutes :  ");
                        ships[idx].shiplatitude.minutes = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter direction :  ");
                        ships[idx].shiplatitude.direction = char.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ship longitude : ");
                        Console.WriteLine("Enter degrees : ");
                        ships[idx].shiplongitude.degrees = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter minutes :  ");
                        ships[idx].shiplongitude.minutes = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter direction :  ");
                        ships[idx].shiplongitude.direction = char.Parse(Console.ReadLine());
                    }
                }

            }
            public string shipnumber;
            public Angle shiplatitude;
            public Angle shiplongitude;
        }
        static void Main(string[] args)
        {

            List<Ship> ships = new List<Ship>();
            Ship b = new Ship();
            int option;
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    
                    Ship s = b.takeinfo();
                    ships.Add(s);
                    Console.ReadKey();
                    
                }
                if (option == 2)
                {
                    b.returnslocation(ships);
                    Console.ReadKey();

                }
                if (option == 3)
                {
                    string sn = b.returnshipnumber(ships);
                    Console.WriteLine("Ship's serial number is " + sn);
                    Console.ReadKey();

                }
                if (option == 4)
                {
                    b.updateship(ships);
                }
                if (option == 5)
                {
                    break;
                }

            }
            while (option < 6);
            Console.Read();
        }

        static int menu()
        {
            int option;
            Console.WriteLine("1.Add Ship");
            Console.WriteLine("2.View Ship Position");
            Console.WriteLine("3.View Ship serial number");
            Console.WriteLine("4.Change Ship Position");
            Console.WriteLine("5.Exit");
            option = int.Parse(Console.ReadLine());
            return option;
        }

    }
}
