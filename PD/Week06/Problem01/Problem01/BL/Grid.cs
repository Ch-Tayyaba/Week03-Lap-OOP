using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.BL
{
    public class Grid
    {
        public Cell[,] maze;
        public int rowSize;
        public int colSize;

        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = new Cell[this.rowSize, this.colSize];
            StreamReader f = new StreamReader(path);
            string record;
            for (int row = 0; row < rowSize; row++)
            {
                record = f.ReadLine();
                for(int col = 0; col < colSize-1; col++)
                {
                    int x = row;
                    int y = col;
                    char value = record[col];
                    maze[row, col] = new Cell(value,x, y);
                }
            }
        }
        public void printMaze()
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize-1; col++)
                {
                    Console.Write(maze[row, col].value);
                }
                Console.WriteLine();
            }
        }
        public Cell getLeftCell(Cell c)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (maze[row, col] == c && row > 0)
                    {
                        return maze[row - 1, col];
                    }
                }
            }
            return null;
        }
        public Cell getRightCell(Cell c)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (maze[row, col] == c && row < rowSize-1)
                    {
                        return maze[row + 1, col];
                    }
                }
            }
            return null;
        }
        public Cell getUpCell(Cell c)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (maze[row, col] == c && col > 0)
                    {
                        return maze[row , col-1];
                    }
                }
            }
            return null;
        }
        public Cell getDownCell(Cell c)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (maze[row, col] == c && col < colSize - 2)
                    {
                        return maze[row , col+1];
                    }
                }
            }
            return null;
        }
        public Cell findPacman()
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (maze[row, col].value == 'P')
                    {
                        return maze[row , col];
                    }
                }
            }
            return null;
        }
        public Cell findGhost(char ghost)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize - 1; col++)
                {
                    if (maze[row, col].value == ghost)
                    {
                        return maze[row, col];
                    }
                }
            }
            return null;
        }


    }
}
