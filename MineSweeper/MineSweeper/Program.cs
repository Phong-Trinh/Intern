using System;
using System.Threading;
namespace MineSweeper
{
    class Program
    {
        static char importOption()
        {
            ConsoleKeyInfo option;
            while (true)
            {
                option = Console.ReadKey();
                if (option.KeyChar == '1' || option.KeyChar == '0') return option.KeyChar;
            }
        }
        static void initializeBoom(int[] boomX, int[] boomY, int boomNum, int[,] mineMatrix, int[,] statusMatrix)
        {
            int i = 0;
            for (int j = 0; j < 9; j++)
                for (int k = 0; k < 9; k++)
                {
                    statusMatrix[j, k] = 0;
                    mineMatrix[j, k] = 0;
                }
            Random randomBox = new Random();
            while (i < boomNum)
            {
                boomX[i] = randomBox.Next(0, 9);
                boomY[i] = randomBox.Next(0, 9);
                if (i == 0)
                {
                    mineMatrix[boomX[i], boomY[i]] = 9;
                    i++;
                }
                else
                for(int j=0;  j<i;j++)
                {
                        if ((boomX[i] == boomX[j]) && (boomY[i] == boomY[j])) break;
                        else if(j == i-1)
                        {
                            mineMatrix[boomX[i], boomY[i]] = 9;
                            i++;
                            break;
                        }
                }
            }
        }
        static void consolePrint(int boomNum, int[,] mineMatrix, int[,] statusMatrix, int openX, int openY)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n\t\t----------------MINESWEEPER--------------");
            Console.WriteLine("  \t\t\t 0  1  2  3  4  5  6  7  8");
            for(int i=0;i<9;i++)
            {
                Console.Write("\n\t\t"+i+"\t");
                for (int j = 0; j < 9; j++)
                {
                    if(i == openX && j == openY)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else 
                    { Console.BackgroundColor = ConsoleColor.Black; }
                    if (statusMatrix[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" I ", Console.BackgroundColor);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (statusMatrix[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(" F ", Console.BackgroundColor, Console.ForegroundColor);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (statusMatrix[i, j] == 2)
                        if (mineMatrix[i, j] == 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" X ", Console.BackgroundColor);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (mineMatrix[i, j] == 0) Console.Write(" - ", Console.BackgroundColor);
                        else Console.Write(" " + mineMatrix[i, j] + " ", Console.BackgroundColor);
                    if (i == openX && j == openY)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                if (i == 1) Console.Write("\t\tBoom Number:   " + boomNum);
                if (i == 2) Console.Write("\t\t 'o': to open the box");
                if (i == 3) Console.Write("\t\t 'f': to take a flag  ");
                if (i == 4) Console.Write("\t\t 'w','a','s','d': to move");
                if (i == 5) Console.Write("\t\t 'e': exit");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n\t\t----------------~~~~~~~~~~---------------");
            Console.Write("Please choose one function:   ");
            Thread.Sleep(0);
        }
        static void openBox(int row, int col, int[,] mineMatrix, int[,] statusMatrix, ref int openedBox)
        {
            int count = 0;
            statusMatrix[row, col] = 1;
            // Check is this the number box?
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                   if((i != 0 || j != 0) && row +i>-1 && col+j>-1 && row+i<9 && col+j<9)
                        if (mineMatrix[row + i, col + j] == 9) count++;
            if (count == 0)
            {
                statusMatrix[row, col] = 2;
                openedBox++;
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        if ((i != 0 || j != 0) && row + i > -1 && col + j > -1 && row + i < 9 && col + j < 9)
                        {
                            if (statusMatrix[row + i, col + j] == 0)
                            openBox(row + i, col + j, mineMatrix, statusMatrix, ref openedBox);
                        }
            }
            else
            {
                statusMatrix[row, col] = 2;
                openedBox++;
                mineMatrix[row, col] = count;
            }
        }
        static void playingGame()
        {
            // save value matrix
            int[,] mineMatrix = new int[9, 9];
            //save status matrix
            int[,] statusMatrix = new int[9, 9];
            int[] boomX = new int[10];
            int[] boomY = new int[10];
            int boomNum = 10;
            int openedBox = 0;
            bool isOver = false;
            int openX = 0, openY =0;
            ConsoleKeyInfo action;
            initializeBoom(boomX, boomY, boomNum, mineMatrix, statusMatrix);
            while (!isOver)
            {
                consolePrint(boomNum, mineMatrix, statusMatrix, openX, openY);
                while (true)
                {
                    action = Console.ReadKey();
                    Console.Write("\n\n");
                    if (action.KeyChar == 'e')
                    {
                        Console.Write("Game's over         ~~ You've opened " + openedBox +"boxes");
                        isOver = true;
                        break;
                    }
                    else if (action.KeyChar == 'a')
                    {
                        openY--;
                        if (openY == -1) openY = 8;
                        break;
                    }
                    else if (action.KeyChar == 'w')
                    {
                        openX--;
                        if (openX == -1) openX = 8;
                        break;
                    }
                    else if (action.KeyChar == 's')
                    {
                        openX++;
                        if (openX == 9) openX = 0;
                        break;
                    }
                    else if (action.KeyChar == 'd')
                    {
                        openY++;
                        if (openY == 9) openY = 0;
                        break;
                    }
                    else if(action.KeyChar == 'o')
                    {
                        if (statusMatrix[openX, openY] == 2 || statusMatrix[openX, openY] == 4) { Console.WriteLine("This box's already opened or flaged!"); Console.ReadKey(); }
                        else if (mineMatrix[openX, openY] == 9)
                        {
                            for (int i = 0; i < boomNum; i++) { statusMatrix[boomX[i], boomY[i]] = 2; mineMatrix[boomX[i], boomY[i]] = 9; }
                            consolePrint(boomNum, mineMatrix, statusMatrix, openX, openY);
                            isOver = true;
                            openedBox++;
                            Console.WriteLine("\n You lose      Total opened boxes:" + openedBox);
                            Console.ReadKey();
                        }
                        else
                        {
                            openBox(openX, openY, mineMatrix, statusMatrix, ref openedBox);
                            if (openedBox == 71)    
                            {
                                isOver = true;
                                for (int i = 0; i < boomNum; i++) { statusMatrix[boomX[i], boomY[i]] = 2; mineMatrix[boomX[i], boomY[i]] = 9; }
                                consolePrint(boomNum, mineMatrix, statusMatrix, openX, openY);
                                Console.WriteLine("\n WIN!      Total opened boxes:" + "71");
                                Console.ReadKey();
                            }
                        }
                        break;
                    }
                    else if (action.KeyChar == 'f')
                    {
                        if (statusMatrix[openX, openY] == 4) statusMatrix[openX, openY] = 0;
                        else if (statusMatrix[openX, openY] == 0) statusMatrix[openX, openY] = 4;
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            char option;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\t\t\t\t\tHello, Welcome to MineSweeper 9x9!");
                Console.WriteLine("\n\t\t\t\t\t---------------OoO----------------");
                Console.WriteLine("\n\n\t\t\t\t\t\t    1. New game");
                Console.WriteLine("\n\t\t\t\t\t\t    0. Exit");
                Console.Write("\n\t\t\t\t\t      Please choose the option:    ");
                switch (option = importOption())
                {
                    case '1':
                        {
                            playingGame();
                            break;
                        }
                    case '0':
                        {
                            Console.Clear();
                            Console.WriteLine("See you again");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        }
                }
                }    
        }
    }
}
