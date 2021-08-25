using System;

namespace ConsoleApp2
{
    public abstract class Fibonacci
    {
        public abstract int FigureOut(int i);
    }
    public class Way1 : Fibonacci
    {
        public override int FigureOut(int i)
        {
            if (i == 2 || i == 1) return 1;
            else return FigureOut(i - 1) + FigureOut(i - 2);
        }
    }
    public class Way2 : Fibonacci
    {
        public override int FigureOut(int numFibo)
        {
            int fibo = 1;
            int temporary = 1;
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
            return fibo;
        }
    }
    public class Way3 : Fibonacci
    {
        public override int FigureOut(int numFibo)
        {
            int fibo = 1;
            int temporary = 1;
            int[] fiboArr = new int[numFibo];
            fiboArr[0] = 1;
            if (numFibo >= 2)
            {
                fiboArr[1] = 1;
                if (numFibo > 2)
                    for (int i = 2; i < numFibo; i++)
                    {
                        fiboArr[i] = fiboArr[i - 1] + fiboArr[i - 2];
                    }
            }
            fibo = fiboArr[numFibo - 1];
            return fibo;
        }
    }
    class Program
    {
        static void figureOut(int numFibo, char waySolve)
        {
            switch (waySolve)
            {
                case '1':
                    {
                        Fibonacci way1 = new Way1();
                        numFibo =way1.FigureOut(numFibo);
                        break;
                    }
                case '2':
                    {
                        Fibonacci way2 = new Way2();
                        numFibo = way2.FigureOut(numFibo);
                        break;
                    }
                case '3':
                    {
                        Fibonacci way3 = new Way3();
                        numFibo = way3.FigureOut(numFibo);
                        break;
                    }
            }
            Console.WriteLine(numFibo);
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