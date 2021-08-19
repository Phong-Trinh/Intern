using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void importValue(out double firstNum, out double secondNum, out char operation)
        {
            Console.WriteLine("Please enter the first number: ");
            while (true)
            {
                if (Double.TryParse(Console.ReadLine(), out firstNum) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number,   try enter the first number again: ");
                }
            }
            Console.WriteLine("Please enter the second number: ");
            while (true)
            {
                if (Double.TryParse(Console.ReadLine(), out secondNum) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number,   try enter the second number again: ");
                }
            }
            Console.WriteLine("Press '+' to sum : ");
            Console.WriteLine("Press '-' to subtract : ");
            Console.WriteLine("Press '*' to multiply : ");
            Console.WriteLine("Press '/' to divide : ");
            Console.WriteLine("Please enter the operation: ");
            while (true)
            {
                if (Char.TryParse(Console.ReadLine(), out operation) == true)
                {
                    if ((operation != '-') && (operation != '*') && (operation != '/') && (operation != '+'))
                    {
                        Console.WriteLine("Please try to enter the operation again: ");
                    }
                    else break;
                }
                else
                    Console.WriteLine("Please try to enter the operation again: ");
            }
        }
        static void calculate(char operation, double firstNum, double secondNum)
        {
            switch (operation)
            {
                case '+':
                    {
                        Console.Write(firstNum + secondNum);
                        break;
                    }
                case '-':
                    {
                        Console.Write(firstNum - secondNum);
                        break;
                    }
                case '*':
                    {
                        Console.Write(Math.Round(firstNum * secondNum, 2));
                        break;
                    }
                case '/':
                    {
                        if (secondNum == 0) Console.WriteLine("Invalid calculation");
                        else
                            Console.Write(Math.Round(firstNum / secondNum, 2));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid operation");
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            char operation;
            double firstNum;
            double secondNum;
            while (true)
            {
                importValue(out firstNum, out secondNum, out operation);
                Console.Clear();
                Console.WriteLine("The first number is:   " + firstNum);
                Console.WriteLine("The second number is:   " + secondNum);
                Console.WriteLine("Result is: ");
                calculate(operation, firstNum, secondNum);
                Console.WriteLine("\n\n\tDo you want to restart?    Press 'n' to restart");
                char n = char.Parse(Console.ReadLine());
                if (n == 'n')
                {
                    operation = ' ';
                    firstNum = 0;
                    secondNum = 0;
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
