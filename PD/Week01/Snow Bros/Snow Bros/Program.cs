using System;
using System.Threading;
using EZInput;
using System.IO;


namespace Snow_Bros
{
    class Program
    {
        static int score = 0;
        static int nickHealth = 5;
        static int lethoHealth = 5;
        static char[,] nick = new char[6,11] {
                    {' ', ' ', ' ', ' ', '/', '`', '\\', ' ', ' ', ' ', ' '},
                    {' ', ' ', '_', '(', '^', ' ', '^', ')', '_', ' ', ' '},
                    {'.', '/', '|', ' ', ' ', 'O', ' ', ' ', '|', '\\', '.'},
                    {' ', ' ', ' ', '\\', '_', 'O', '_', '/', ' ', ' ', ' '},
                    { ' ', ' ', ' ', '|', '|', ' ', '|', '|', ' ', ' ', ' '},
                    { ' ', ' ', ' ', '/', '\\', ' ', '/', '\\', ' ', ' ', ' '}
                    };

        static char[,] letho = new char[4,5]  {
                    { ' ', '_', '_', '_', ' '},
                    { '/', '/', '_', '+', '\\'},
                    { '/', '[', '\\', ']', '\\'},
                    { '_', '/', ' ', '|', '_'}};
        static void Main(string[] args)
        {

            int nickX = 34, nickY = 3;
            int lethoX = 6, lethoY = 182;

            int[] snowX = new int[100];
            int[] snowY = new int[100];
            int snowCount = 0;

            int[] fireX = new int[100];
            int[] fireY = new int[100];
            int fireCount = 0;

            string lethoDirection = "Down";

            int timer = 0;
            int timer01 = 0;

            int moneyCount = 0;
            int foodCount = 0;


            char[,] maze = new char[43, 191];
            Console.WriteLine("First you should make the size of font smaller otherwise it will be clashed.");
            Console.ReadKey();
            readData(maze);
            printMaze(maze);

            Console.SetCursorPosition(nickY, nickX);
            printNick(nickX, nickY);
            printNickInArray(maze, nickX, nickY);
            Console.SetCursorPosition(lethoY, lethoX);
            printLetho(lethoX, lethoY);
            printLethoInArray(maze, lethoX, lethoY);
            bool gameRunning = true;
            
            while (gameRunning)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MoveNickUp(maze, ref nickX, ref nickY);
                    gravityForNick(maze, ref nickX, ref nickY);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MoveNickDown(maze, ref nickX, ref nickY);
                    gravityForNick(maze, ref nickX, ref nickY);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MoveNickLeft(maze, ref nickX, ref nickY);
                    gravityForNick(maze, ref nickX, ref nickY);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MoveNickRight(maze, ref nickX, ref nickY);
                    gravityForNick(maze, ref nickX, ref nickY);
                }
                if (Keyboard.IsKeyPressed(Key.A))
                {
                    generateSnow(ref snowX, ref snowY,ref snowCount,nickX, nickY);
                    snowCount++;
                }

                if (timer == 3)
                {
                    moveLetho(maze,ref lethoX,ref lethoY, ref lethoDirection);
                    timer = 0;
                }
                if (timer01 == 20)
                {
                    generateLethoFire(maze, fireX, fireY, ref fireCount, lethoX, lethoY);
                    timer01 = 0;
                }
                if(nickHealth <= 0 && lethoHealth > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Won The Game.");
                    Console.ReadKey();
                    break;
                }
                if (nickHealth > 0 && lethoHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over.");
                    Console.ReadKey();
                    break;
                }
                printMoney(maze, ref moneyCount);
                printFood(maze, ref foodCount);
                collisionOfFoodOrMoney(maze, nickX, nickY);
                moveSnow(maze, ref snowX, ref snowY,ref snowCount);
                moveLethoFire(maze, fireX, fireY, ref fireCount);
                collisionOfNickAndEnemies(ref nickX, ref nickY, nickX, nickY, 11, 6, lethoX, lethoY, 5, 4);
                collisionOfSnowWithLetho(maze, lethoX, lethoY);
                collisionOfFireAndNick(maze, nickX, nickY);
                printHealthAndScore();
                timer++;
                timer01++;
            }
        }
        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void readData(char[,] maze)
        {
            StreamReader fp = new StreamReader("maze.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 190; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }
        static void printNick(int nickX, int nickY)
        {
            for (int rows = 0; rows < 6; rows++)
            {
                Console.SetCursorPosition(nickY, nickX + rows);
                for (int columns = 0; columns < 11; columns++)
                {
                    Console.Write(nick[rows, columns]);
                }
            }
        }
        static void eraseNick(int nickX, int nickY)
        {
            for (int rows = 0; rows < 6; rows++)
            {
                Console.SetCursorPosition(nickY, nickX + rows);
                for (int columns = 0; columns < 11; columns++)
                {
                    Console.Write(" ");
                }
            }
        }
        static void eraseNickFromArray(char[,] maze,int nickX,int nickY)
        {
            for (int rows = 0; rows < 6; rows++)
            {
                for (int columns = 0; columns < 11; columns++)
                {
                    maze[nickX + rows, nickY + columns] = ' ';
                }
            }
        }
        static void printNickInArray(char[,] maze,int nickX, int nickY)
        {
            for (int rows = 0; rows < 6; rows++)
            {
                for (int columns = 0; columns < 11; columns++)
                {
                    maze[nickX + rows, nickY + columns] = nick[rows,columns];
                }
            }
        }
        static void MoveNickUp(char[,] maze, ref int nickX, ref int nickY)
        {
            if (maze[nickX - 2, nickY + 5] == '`')
            {
                eraseNickFromArray(maze, nickX, nickY);
                eraseNick(nickX, nickY);
                nickX = nickX - 10;
                printNickInArray(maze, nickX, nickY);
                printNick(nickX, nickY);

            }
        }
        static void MoveNickLeft(char[,] maze, ref int nickX, ref int nickY)
        {
            if (maze[nickX + 3 , nickY - 2] == ' ')
            {
                eraseNickFromArray(maze, nickX, nickY);
                eraseNick(nickX, nickY);
                nickY = nickY - 2;
                printNickInArray(maze, nickX, nickY);
                printNick(nickX, nickY);

            }
        }
        static void MoveNickRight(char[,] maze, ref int nickX, ref int nickY)
        {
            if (maze[nickX + 3, nickY + 13] == ' ')
            {
                eraseNickFromArray(maze, nickX, nickY);
                eraseNick(nickX, nickY);
                nickY = nickY + 2;
                printNickInArray(maze, nickX, nickY);
                printNick(nickX, nickY);

            }
        }
        static void MoveNickDown(char[,] maze, ref int nickX, ref int nickY)
        {
            if (maze[nickX + 6, nickY] == '_' && maze[nickX + 8 , nickY] == '`' )
            {
                eraseNickFromArray(maze, nickX, nickY);
                eraseNick(nickX, nickY);
                nickX = nickX + 10;
                printNickInArray(maze, nickX, nickY);
                printNick(nickX, nickY);

            }
        }
        static void gravityForNick(char[,] maze, ref int nickX, ref int nickY)
        {
            bool flag = true;
            while (flag)
            {
                if (maze[nickX + 6, nickY] == ' ' && maze[nickX + 6, nickY + 10] == ' ')
                {
                    eraseNickFromArray(maze, nickX, nickY);
                    eraseNick(nickX, nickY);
                    nickX = nickX + 1;
                    printNickInArray(maze, nickX, nickY);
                    printNick(nickX, nickY);
                }
                else
                {
                    flag = false;
                }
            }
        }
        static void printLetho(int lethoX, int lethoY)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                Console.SetCursorPosition(lethoY, lethoX + rows);
                for (int columns = 0; columns < 5; columns++)
                {
                    Console.Write(letho[rows, columns]);
                }
            }
        }
        static void eraseLetho(int lethoX, int lethoY)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                Console.SetCursorPosition(lethoY, lethoX + rows);
                for (int columns = 0; columns < 5; columns++)
                {
                    Console.Write(" ");
                }
            }
        }
        static void eraseLethoFromArray(char[,] maze, int lethoX, int lethoY)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                for (int columns = 0; columns < 5; columns++)
                {
                    maze[lethoX + rows, lethoY + columns] = ' ';
                }
            }
        }
        static void printLethoInArray(char[,] maze, int lethoX, int lethoY)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                for (int columns = 0; columns < 5; columns++)
                {
                    maze[lethoX + rows, lethoY + columns] = letho[rows, columns];
                }
            }
        }
        static void moveLetho(char[,] maze,ref int lethoX,ref int lethoY,ref string lethoDirection)
        {

            if (lethoDirection == "Down")
            {
                if ((maze[lethoX + 4, lethoY] == '_' )&& lethoX < 40)
                {
                    eraseLethoFromArray(maze, lethoX, lethoY);
                    eraseLetho(lethoX, lethoY);
                    lethoX = lethoX + 10;
                    printLethoInArray(maze, lethoX, lethoY);
                    printLetho(lethoX, lethoY);
                }
                else
                {
                    lethoDirection = "Up";
                }
            }
            if (lethoDirection == "Up")
            {
                if (maze[lethoX - 4, lethoY] == '`')
                {
                    eraseLethoFromArray(maze, lethoX, lethoY);
                    eraseLetho(lethoX, lethoY);
                    lethoX = lethoX - 10;
                    printLethoInArray(maze, lethoX, lethoY);
                    printLetho(lethoX, lethoY);
                }
                else
                {
                    lethoDirection = "Down";
                }
            }
        }
        static void printSnow(char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("s");
            maze[x, y] = 's';
        }
        static void eraseSnow(char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine(" ");
            maze[x, y] = ' ';
        }
        static void generateSnow(ref int[] snowX , ref int[] snowY,ref int snowCount ,int nickX, int nickY)
        {
            snowX[snowCount] = nickX + 2;
            snowY[snowCount] = nickY + 11;
            Console.SetCursorPosition(nickY + 11, nickX + 2);
            Console.WriteLine( "s");
            snowCount++;
            score++;
        }
        static void removeSnowFromArray(int index, ref int[] snowX, ref int[] snowY,ref int snowCount)
        {
            for (int x = index; x < snowCount - 1; x++)
            {
                snowX[x] = snowX[x + 1];
                snowY[x] = snowY[x + 1];
            }
            snowCount--;
        }
        static void moveSnow(char[,] maze, ref int[] snowX, ref int[] snowY,ref int snowCount)
        {
            for (int x = 0; x < snowCount; x++)
            {
                if (maze[snowX[x], snowY[x] + 1] != ' ')
                {
                    eraseSnow(maze, snowX[x], snowY[x]);
                    removeSnowFromArray(x, ref snowX, ref snowY,ref snowCount);
                }
                else
                {
                    eraseSnow(maze, snowX[x], snowY[x]);
                    snowY[x] = snowY[x] + 1;
                    printSnow(maze, snowX[x], snowY[x]);
                }

            }
        }
        static void printFire(char[,] maze,int fireX, int fireY)
        {
            Console.SetCursorPosition(fireY, fireX);
            Console.WriteLine("F");
            maze[fireX, fireY] = 'F';
        }
        static void eraseFire(char[,] maze, int fireX, int fireY)
        {
            Console.SetCursorPosition(fireY, fireX);
            Console.WriteLine(" ");
            maze[fireX, fireY] = ' ';
        }
        static void generateLethoFire(char[,] maze, int[] fireX, int[] fireY, ref int fireCount, int lethoX, int lethoY)
        {
            fireX[fireCount] = lethoX + 1;
            fireY[fireCount] = lethoY - 1;
            printFire(maze, fireX[fireCount], fireY[fireCount]);
            fireCount++;
        }
        static void moveLethoFire(char[,] maze, int[] fireX, int[] fireY,ref int fireCount)
        {
            for (int idx = 0; idx < fireCount; idx++)
            {
                if (maze[fireX[idx] - 1, fireY[idx]] == ' ')
                {
                    eraseFire(maze, fireX[idx], fireY[idx]);
                    fireY[idx] = fireY[idx] - 1;
                    printFire(maze, fireX[idx], fireY[idx]);
                }
                else
                {
                    eraseFire(maze, fireX[idx], fireY[idx]);
                }
            }
        }
        static void collisionOfNickAndEnemies(ref int nickX,ref int nickY,int playerX, int playerY, int playerWidth, int playerHeight, int enemyX, int enemyY, int enemyWidth, int enemyHeight)
        {
            int height = playerHeight - enemyHeight;
            int width = playerWidth - enemyWidth;
            if ((playerY + playerWidth == enemyY && playerX + height == enemyX) || (enemyY + enemyWidth == playerY && playerX + height == enemyX) || (enemyX + enemyHeight == playerX && playerY + width == enemyY) || (playerX + playerHeight == enemyX && playerY + width == enemyY))
            {
                eraseNick(nickX, nickY);
                nickX = 34;
                nickY = 3;
                printNick(nickX, nickY);
                if (nickHealth >= 0)
                    nickHealth--;
            }
        }
        static void collisionOfSnowWithLetho(char[,] maze, int lethoX, int lethoY)
        {
            if ( maze[lethoX , lethoY - 1] == 's')
            {
                eraseSnow(maze, lethoX, lethoY- 1);
                if (lethoHealth >= 0)
                    lethoHealth--;
            }
        }
        static void collisionOfFireAndNick(char[,] maze, int nickX, int nickY)
        {
            if (maze[nickX + 3, nickY + 11] == 'F')
            {
                if (nickHealth >= 0)
                    nickHealth--;
                eraseFire(maze, nickX + 4, nickY + 11);
            }
        }
        static void printHealthAndScore()
        {
            Console.SetCursorPosition(5, 45);
            Console.WriteLine("Score: {0}", score);
            Console.SetCursorPosition(25, 45);
            Console.WriteLine("NickHealth: {0}", nickHealth);
            Console.SetCursorPosition(45, 45);
            Console.WriteLine("LethokHealth: {0}", lethoHealth);
        }
        static void printMoney(char[,] maze, ref int moneyCount)
        {
            if (moneyCount == 1)
            {
                maze[8, 18] = '$';
                Console.SetCursorPosition(18, 8);
                Console.Write( "$");
            }
            if (moneyCount == 2)
            {
                maze[81, 18] = '$';
                Console.SetCursorPosition(81, 18);
                Console.Write("$");
            }
            if (moneyCount == 3)
            {
                maze[112, 28] = '$';
                Console.SetCursorPosition(28, 112);
                Console.Write("$");
            }
            if (moneyCount == 4)
            {
                maze[25, 38] = '$';
                Console.SetCursorPosition(38, 25);
                Console.Write("$");
            }
            if (moneyCount == 5)
            {
                maze[127, 38] = '$';
                Console.SetCursorPosition(38, 127);
                Console.Write("$");
                moneyCount = -1;
            }
            moneyCount++;
        }
        static void printFood(char[,] maze, ref int foodCount)
        {
            if (foodCount == 1)
            {
                maze[8, 18] = '@';
                Console.SetCursorPosition(18, 8);
                Console.Write("@");
            }
            if (foodCount == 2)
            {
                maze[81, 18] = '@';
                Console.SetCursorPosition(18, 81);
                Console.Write("@");
            }
            if (foodCount == 3)
            {
                maze[112, 28] = '@';
                Console.SetCursorPosition(28, 112);
                Console.Write("@");
            }
            if (foodCount == 4)
            {
                maze[25, 38] = '@';
                Console.SetCursorPosition(38, 25);
                Console.Write("@");
            }
            if (foodCount == 5)
            {
                maze[127, 38] = '@';
                Console.SetCursorPosition(38, 127);
                Console.Write("@");
                foodCount = -1;
            }
            foodCount++;
        }
        static void collisionOfFoodOrMoney(char[,] maze, int nickX, int nickY)
        { 
            if (maze[nickX + 5, nickY - 1] == '@' || maze[nickX + 5, nickY + 11] == '@')
            { 
                score = score + 5;
            }
            if (maze[nickX + 5, nickY - 1] == '$' || maze[nickX + 5, nickY + 11] == '$')
            {
                score = score + 10;
            }
            Console.SetCursorPosition(nickY - 1, nickX + 5);
            Console.Write(" ");
            Console.SetCursorPosition(nickY + 11, nickX + 5);
            Console.Write(" ");
            maze[nickX + 5, nickY - 1] = ' ';
            maze[nickX + 5, nickY + 11] = ' ';
        }

    }
}
