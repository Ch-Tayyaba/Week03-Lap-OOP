using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace Game
{
    public class GameGrid
    {
        public GameCell[,] grid;
        public int rows;
        public int cols;

        public GameGrid(string fileName, int rows, int cols)
        {
            grid = new GameCell[rows,cols];
            this.rows = rows;
            this.cols = cols;
            loadGrid(fileName);

        }
        public GameGrid()
        {

        }
        private void loadGrid(string fileName)
        {
            StreamReader fp = new StreamReader(fileName);
            string record = null;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < cols; x++)
                {
                    GameCell g = new GameCell(row,x,record[x]);
                    grid[row , x] = g;

                }
                Console.WriteLine();
                row++;
            }
            fp.Close();
        }
        public GameCell getCell(int X, int Y)
        {
            return grid[X, Y];
        }
        public void printMaze()
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    GameCell cell = getCell(x, y);
                    GameCell.printCell(cell);
                }

            }
        }
    }
}
