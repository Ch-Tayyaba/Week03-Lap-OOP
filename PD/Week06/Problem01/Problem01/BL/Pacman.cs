using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.BL
{
    public class Pacman
    {
        public int x;
        public int y;
        public int score;
        public Grid mazeGrid;

        public Pacman(int x, int y, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazeGrid;
        }
    }
}
