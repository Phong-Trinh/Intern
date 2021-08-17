using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            char operation;
            double num1;
            double num2;
            while (true)
            {
                Console.WriteLine("Please enter the first number: ");
                while (true)
                {
                    if (Double.TryParse(Console.ReadLine(), out num1) == true)
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
                    if (Double.TryParse(Console.ReadLine(), out num2) == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number,   try enter the second number again: ");
                    }
                }
                Console.WriteLine("Please enter the operation: ");
                while(true)
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
                Console.Clear();
                Console.WriteLine("The first number is:   " + num1);
                Console.WriteLine("The second number is:   " + num2);
                Console.WriteLine("Result is: ");
                switch (operation)
                {
                    case '+':
                        {
                            Console.Write(num1 + num2);
                            break;
                        }
                    case '-':
                        {
                            Console.Write(num1 - num2);
                            break;
                        }
                    case '*':
                        {
                            Console.Write(Math.Round(num1 * num2, 2));
                            break;
                        }
                    case '/':
                        {
                            if (num2 == 0) Console.WriteLine("Invalid calculation");
                            else
                                Console.Write(Math.Round(num1 / num2, 2));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid operation");
                            break;
                        }
                }
                Console.WriteLine("\n\n\tDo you want to restart?    Press 'n' to restart");
                char n = char.Parse(Console.ReadLine());
                if (n == 'n')
                {
                    operation = ' ';
                    num1 = 0;
                    num2 = 0;
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
