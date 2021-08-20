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
                        int i = 1;
                        while (i <= numFibo)
                        {
                            if (i == 2 || i == 1) fibo = 1;
                            else
                            {
                                int temporary1 = fibo;
                                fibo += temporary;
                                temporary = temporary1;
                            }
                            i++;
                        }
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
                Console.WriteLine("FIBONACCI PROGAM~~");
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
                Console.Write("Choose the way to solve('1','2','3')~~");
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
                Console.WriteLine("You choose way" + waySolve + "and your result is: ");
                figureOut(numFibo, waySolve);
                Console.Write("doyou want to try it again? Press 'n' to do it");
                char n = char.Parse(Console.ReadLine());
                if (n == 'n')
                {
                    numFibo = -1;
                    waySolve = 'P';
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }
    }
}