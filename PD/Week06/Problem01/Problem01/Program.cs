using Problem01.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            string path = @"F:\2nd Semester\OOP\PD\Week06\Maze.txt";
            Grid maze = new Grid(24, 71, path);
            maze.printMaze();
            Console.Read();
        }
    }
}
