using System;

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
                        else 
                        {
                            mineMatrix[boomX[i], boomY[i]] = 9;
                            i++;
                            break;
                        }
                }
            }
        }
        static void consolePrint(int boomNum, int[,] mineMatrix, int[,] statusMatrix)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t----------------MINESWEEPER--------------");
            Console.WriteLine("  \t\t\t0  1  2  3  4  5  6  7  8");
            for(int i=0;i<9;i++)
            {
                Console.Write("\n\t\t"+i+"\t");
                for (int j = 0; j < 9; j++)
                {
                    if (statusMatrix[i, j] == 0) Console.Write("I  ");
                    else if(statusMatrix[i, j] == 4) Console.Write("F  ");
                    else if (statusMatrix[i, j] == 2) 
                        if (mineMatrix[i,j] == 9) Console.Write("X  ");
                        else if (mineMatrix[i, j] == 0) Console.Write("-  ");
                        else Console.Write(mineMatrix[i, j]+"  ");
                }
                if (i == 1) Console.Write("\t\tBoom Number:   " + boomNum);
                if (i == 2) Console.Write("\t\t 'o': to open the box");
                if (i == 3) Console.Write("\t\t 'f': to take a flag  ");
                if (i == 4) Console.Write("\t\t 'e': exit");
            }
            Console.WriteLine("\n\n\t\t----------------~~~~~~~~~~---------------");
            Console.Write("Please choose one function:   ");
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
                        if (((i == 0 && j != 0)||(i != 0 && j ==0)) && row + i > -1 && col + j > -1 && row + i < 9 && col + j < 9)
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
            int row, col;
            int openedBox = 0;
            bool isOver = false;
            ConsoleKeyInfo action;
            initializeBoom(boomX, boomY, boomNum, mineMatrix, statusMatrix);
            while (!isOver)
            {
                consolePrint(boomNum, mineMatrix, statusMatrix);
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
                    else if(action.KeyChar == 'o')
                    {                   
                        Console.Write("Please enter row you want to open: ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out row) == true && row < 9 && row >= 0)
                                break;
                            else
                                Console.Write("Try again: ");
                        }
                        Console.Write("Please enter colum you want to open: ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out col) == true && col < 9 && col >= 0)
                                break;
                            else
                                Console.Write("Try again: ");
                        }
                        if (statusMatrix[row, col] == 2 || statusMatrix[row, col] == 4) { Console.WriteLine("This box's already opened or flaged!"); Console.ReadKey(); }
                        else if (mineMatrix[row, col] == 9)
                        {
                            for (int i = 0; i < boomNum; i++) { statusMatrix[boomX[i], boomY[i]] = 2; mineMatrix[row, col] = 9; }
                            consolePrint(boomNum, mineMatrix, statusMatrix);
                            isOver = true;
                            openedBox++;
                            Console.WriteLine("\n You lose      Total opened boxes:" + openedBox);
                            Console.ReadKey();
                        }
                        else openBox(row, col, mineMatrix, statusMatrix, ref openedBox);
                        if(openedBox == 9*9)
                        {
                            isOver = true;
                            Console.WriteLine("\n WIN!      Total opened boxes:" + openedBox);
                            Console.ReadKey();
                        }
                        break;
                    }
                    else if (action.KeyChar == 'f')
                    {
                        Console.Write("Please enter row you want to take flag: ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out row) == true && row < 9 && row >=0)
                                break;
                            else
                                Console.Write("Try again: ");
                        }
                        Console.Write("Please enter colum you want to take flag: ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out col) == true && col < 9 && col >= 0)
                                break;
                            else
                                Console.Write("Try again: ");
                        }
                        if (statusMatrix[row, col] == 4) statusMatrix[row, col] = 0;
                        else if (statusMatrix[row, col] == 0) statusMatrix[row, col] = 4;
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
                Console.WriteLine("\n\t\tHello, Welcome to MineSweeper 9x9!");
                Console.WriteLine("\n\t1. New game");
                Console.WriteLine("\n\t0. Exit");
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
