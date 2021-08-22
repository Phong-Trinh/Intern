using System;

namespace ConsoleApp2
{
    class Program
    {
        static int fiboCallBack(int i)
        {
            if (i == 2 || i == 1) return 1;
            else return fiboCallBack(i - 1) + fiboCallBack(i - 2);
        }
        static void figureOut(int numFibo, char waySolve)
        {
            int fibo = 1;
            int temporary = 1;
            switch (waySolve)
            {
                case '1':
                    {
                        int temporary1;
                        for (int i = 1; i <= numFibo; i++)
                        {
                            if (i == 2 || i == 1) fibo = 1;
                            else
                            {
                                temporary1 = fibo;
                                fibo += temporary;
                                temporary = temporary1;
                            }
                        }
                        break;
                    }
                case '2':
                    {
                        int[] fiboArr = new int[numFibo];
                        fiboArr[0] = 1;
                        if (numFibo >= 2)
                        {
                            fiboArr[1] = 1;
                            if(numFibo > 2)
                            for (int i = 2; i < numFibo; i++)
                            {
                                    fiboArr[i] = fiboArr[i - 1] + fiboArr[i - 2];
                            }
                        }
                        fibo = fiboArr[numFibo - 1];
                        break;
                    }
                case '3':
                    {
                        fibo = fiboCallBack(numFibo);
                        break;
                    }
            }
            Console.WriteLine(fibo);
        }
        static void Main(string[] args)
        {
            int numFibo;
            char waySolve;
            while (true)
            {
                Console.WriteLine("FIBONACCI PROGRAM~~");
                Console.Write("Enter number of fibonacci number: ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out numFibo) == true)
                    {
                        if (numFibo <= 0) Console.Write("Invalid number,   try enter your number again: ");
                        else
                            break;
                    }
                    else
                    {
                        Console.Write("Invalid number,   try enter your number again: ");
                    }
                }
                Console.Write("Choose the way to solve('1','2','3'):  ");
                while (true)
                {
                    if (Char.TryParse(Console.ReadLine(), out waySolve) == true)
                    {
                        if ((waySolve != '1') && (waySolve != '2') && (waySolve != '3'))
                        {
                            Console.Write("Please try again: ");
                        }
                        else break;
                    }
                    else
                        Console.WriteLine("Please try again: ");
                }
                Console.Clear();
                Console.Write("You choose way" + waySolve + " and your result is: ");
                figureOut(numFibo, waySolve);
                Console.Write("Do you want to try it again? Press 'n' to do it");
                ConsoleKeyInfo restart= Console.ReadKey();
                if (restart.KeyChar == 'n')
                {
                    numFibo = -1;
                    waySolve = 'P';
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nEnd you program");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}