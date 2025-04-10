using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    class Ship
    {
        public string srNumber;
        public List<string> location = new List<string>();

        public Ship()
        {

        }
        public Ship(string srNumber)
        {
            this.srNumber = srNumber;
        }
        public Ship(string srNumber , List<string> location)
        {
            this.srNumber = srNumber;
            this.location = location;
        }
        public Ship takeInput()
        {
            Console.Write("Enter Ship Number: ");
            string shipNumber = Console.ReadLine();
            Ship a = new Ship(shipNumber);
            return a;
        }
        public void takeLocation(Angle a)
        {
            location[0] = a.degree[0] + "\u00b0" + a.minute[0] + "'" + a.direction[0];
            location[1] = a.degree[1] + "\u00b0" + a.minute[1] + "'" + a.direction[1];
        }
    }
}
