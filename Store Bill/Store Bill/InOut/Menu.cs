using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Store_Bill
{
    class Menu
    {
        private List<Bill> listBill = new List<Bill>();
        static int BillNumber=0;
        public void MenuRim()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("\n\n\t\t\t+_+_+_+_+_+_+_+_+_+_+_+_+_+_+______+_+_+_+_+_+_+_+_+_+_+_+_+_+_+");
            int i=0;
            while (i <= 34)
            {
                Console.SetCursorPosition(25, 4+i);
                Console.Write("||");
                Console.SetCursorPosition(85, 4+i);
                Console.Write("||");
                i++;
            }
            Console.SetCursorPosition(0, i+1);
            Console.Write("\n\n\t\t\t+_+_+_+_+_+_+_+_+_+_+_+_+_+_+______+_+_+_+_+_+_+_+_+_+_+_+_+_+_+");

        }
        public void ClearDisplay(int beginLine)
        {
            int i = beginLine;
            while (i <= 32)
            {
                Console.SetCursorPosition(27, 4 + i);
                Console.Write("                                                         ");
                i++;
            }
        }
        public void HomeMenu()
        {
            InputErrors catchInput=new InputErrors();
            int N=0;
            ConsoleKeyInfo action;
            while (true)
            {
                int line = 0;
                ClearDisplay(0);
                Console.SetCursorPosition(25, 5 + line++);
                Console.WriteLine("\t\t       T-Smart Store Bill ");
                Console.SetCursorPosition(25, 5 + line++);
                Console.WriteLine("\t   ------------------+++00+++-----------------");
                Console.SetCursorPosition(25, 7 + line++);
                Console.WriteLine("\t\t     1. Import N bills");
                Console.SetCursorPosition(25, 9 + line++);
                Console.WriteLine("\t\t     2. Export N bills");
                Console.SetCursorPosition(25, 11 + line++);
                Console.WriteLine("\t\t    3. Export file");
                Console.SetCursorPosition(25, 13 + line++);
                Console.WriteLine("\t\t    4. Exit");
                Console.SetCursorPosition(25, 16 + line++);
                Console.Write("\t\t    Please enter the option: ");
                action = Console.ReadKey();
                Console.Write("\n\n");
                if (action.KeyChar == '1')
                {
                    line = 0;
                    ClearDisplay(0);
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t\t       T-Smart Store Bill ");
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t   ------------------+++00+++-----------------");
                    Console.SetCursorPosition(25, 6 + line++);
                    Console.WriteLine("\t\t       1. Import N bills");
                    Console.SetCursorPosition(25, 6 + line);
                    Console.Write("\tPlease enter how many bill you want inporting: ");
                    int k;
                    catchInput.CatchInput(out k, 78, 6 + line);                    
                    for (int i = 0; i < k; i++)
                    {
                        ClearDisplay(6 + line - 4);
                        Console.SetCursorPosition(25, 6 + line);
                        Console.WriteLine("\t\t              "+ (1+i) + "/" +k);
                        listBill.Add(new Bill());
                        listBill[N+i].GetBillInfor();
                    }
                    N += k;
                }
                else if (action.KeyChar == '2')
                {
                    line = 0;
                    ClearDisplay(0);
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t\t       T-Smart Store Bill ");
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t   ------------------+++00+++-----------------");
                    Console.SetCursorPosition(28, 5 + line);
                    Console.WriteLine("left, right arrow: next bill                  'p': exit");
                    Console.SetCursorPosition(25, 6 + line++);
                    Console.WriteLine("\t\t       2. Export N bills");
                    if (N == 0)
                    {
                        ClearDisplay(6 + line - 4);
                        Console.SetCursorPosition(45, 6 + line);
                        Console.Write("There is no bill in system...");
                        Console.ReadKey();
                    }
                    else
                    {
                        int i = 0;
                        ConsoleKeyInfo eventt;
                        while (true)
                        {
                            ClearDisplay(6 + line - 4);
                            Console.SetCursorPosition(25, 6 + line);
                            Console.WriteLine("\t\t              " + (1 + i) + "/" + N);
                            listBill[i].PrintBill();
                            eventt = Console.ReadKey();
                            if (eventt.KeyChar == 'p') break;
                            else if (eventt.Key == ConsoleKey.LeftArrow)
                            {
                                i--;
                                Task.Delay(300).Wait();
                                if (i == -1) i = N-1;
                            }
                            else if (eventt.Key == ConsoleKey.RightArrow)
                            {
                                i++;
                                Task.Delay(300).Wait();
                                if (i == listBill.Count()) i = 0;
                            }
                        }
                    }
                }
                else if (action.KeyChar == '3')
                {
                    line = 0;
                    
                    ClearDisplay(0);
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t\t       T-Smart Store Bill ");
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t   ------------------+++00+++-----------------");
                    Console.SetCursorPosition(25, 5 + line++);
                    Console.WriteLine("\t\t       3. Export File");
                    if (N == 0)
                    {
                        ClearDisplay(6 + line - 4);
                        Console.SetCursorPosition(45, 6 + line);
                        Console.Write("There is no bill in system...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.SetCursorPosition(28, 5 + line++);
                        Console.Write("Please name the file(bill.txt): ");
                        string fileName = "D:/";
                        fileName += Console.ReadLine();
                        fileName += ".txt";
                        string[] contentt = new string[20];
                        for (int i = 0; i < N; i++)
                        {
                            ClearDisplay(6 + line - 4);
                            int stringNumber = 0;
                            listBill[i].ToStringFile(contentt, stringNumber);
                            System.IO.File.AppendAllLines(fileName, contentt);
                            contentt = new string[20];
                        }
                        Console.SetCursorPosition(42, 5 + line++);
                        Console.Write("Successfully....");
                        Console.SetCursorPosition(42, 5 + line++);
                        Console.Write("The file saved at: " + fileName);
                        Console.ReadKey();
                    }
                }
                else if (action.KeyChar == '4')
                {
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
