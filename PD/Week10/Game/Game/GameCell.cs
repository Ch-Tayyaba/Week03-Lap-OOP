using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameCell
    {
        public int x;
        public int y;
        public GameObject currentGameObject;
        public GameGrid gameGrid;
        public GameCell(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            setValue(ch);

        }
        public GameCell(int x, int y, GameGrid grid)
        {

        }
        public void nextCell(GameDirection direction)
        {

        }
        public static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.y, cell.x);
            Console.Write(cell.currentGameObject.displayCharacter);
        }
        public void setValue(char ch)
        {
            currentGameObject = new GameObject();
            currentGameObject.displayCharacter = ch;
        }
    }
}
