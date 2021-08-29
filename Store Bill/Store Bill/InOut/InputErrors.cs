using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Store_Bill
{
    class InputErrors
    {
        public bool CatchInput(out int k, int row, int col)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out k) == true)
                {
                    return true;
                }
                else
                {
                    Console.SetCursorPosition(row, col);
                    Console.Write(" Error");
                    Thread.Sleep(420);
                    Console.SetCursorPosition(row, col);
                    Console.Write("      ");
                    Console.SetCursorPosition(row, col);
                }
            }
        }
        public bool CatchInput(out DateTime k, int row, int col)
        {
            while (true)
            {
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out k) == true)
                {
                    return true;
                }
                else
                    Console.SetCursorPosition(row, col);
                {
                    Console.SetCursorPosition(row, col);
                    Console.Write(" Error          ");
                    Thread.Sleep(420);
                    Console.SetCursorPosition(row, col);
                    Console.Write("                ");
                    Console.SetCursorPosition(row, col);
                }
            }
        }
        public bool CatchInput(out int k, int row, int col, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out k) == true && k >0 && k<= max)
                {
                    return true;
                }
                else
                {
                    Console.SetCursorPosition(row, col);
                    Console.Write(" Error   ");
                    Thread.Sleep(420);
                    Console.SetCursorPosition(row, col);
                    Console.Write("         ");
                    Console.SetCursorPosition(row, col);
                }
            }
        }
    }
}
