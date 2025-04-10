using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.BL
{
    public class Ghost
    {
        public int x;
        public int y;
        public string direction;
        public char character;
        public float speed;
        public char previousItem;
        public float deltaChange;
        public Grid mazeGrid;

        public Ghost(int x, int y, char character, string direction, float speed, char previousItem, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.character = character;
            this.direction = direction;
            this.speed = speed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;
        }
        public void setDirection(string direction)
        {
            this.direction = direction;
        }
        public string getDirection()
        {
            return direction;
        }
        public void remove()
        {

        }
        public void draw()
        {

        }
        public char getCharacter()
        {
            return character;
        }
        public void changeDelta()
        {
            deltaChange = deltaChange + speed;
        }
        public float getDelta()
        {
            return deltaChange;
        }
        public void setDeltaZero()
        {
            deltaChange = 0;
        }
        public void move()
        {
            changeDelta();
            if(Math.Floor(getDelta()) == 1)
            {
                if(character == 'H')
                {
                    moveHorizontal();
                }
                setDeltaZero();
            }
        }
        public void moveHorizontal()
        {

        }
        public void moveVertical()
        {

        }
        public int generateRandom()
        {
            return 0;
        }
        public void moveRandom()
        {

        }
        public void moveSmart()
        {

        }
        public double calculateDistance(Cell current, Cell pacmanLocation)
        {
            return 0;
        }
    }
}
