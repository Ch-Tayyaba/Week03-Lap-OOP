using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    class Angle
    {
        public List<int> degree = new List<int>();
        public List<float> minute = new List<float>();
        public List<char> direction = new List<char>();

        public Angle()
        {

        }
        public Angle(List<int> degree, List<float> minute, List<char> direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }
        public void ToDegreeAndMinute(string angle)
        {
            for(int idx = 0; idx < angle.Length; idx++)
            {
                if(angle[idx] == '\u00b0')
                {
                    
                }
            }
        }
        public Angle takeInput()
        {
            List<int> degree = new List<int>();
            List<float> minute = new List<float>();
            List<char> direction = new List<char>();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Latitude's Degree: ");
            degree[0] = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minute: ");
            minute[0] = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            direction[0] = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Longitude's Degree: ");
            degree[1] = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minute: ");
            minute[1] = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction: ");
            direction[1] = char.Parse(Console.ReadLine());
            Angle b = new Angle(degree, minute, direction);
            return b;
        }
    }
}
