using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.BL
{
    public class Cell
    {
        public char value;
        public int x;
        public int y;
        public Cell() { }

        public Cell(char value,int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        public char getValue(char value)
        {
            return value;
        }
        public void setValue(char value)
        {
            this.value = value;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool isPacmanPresent()
        {
            if(value == 'P')
            {
                return true;
            }
            return false;
        }
        public bool isGhostPresent(char ghost)
        {
            if(value == ghost)
            {
                return true;
            }
            return false;
        }
    }
}
