using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
namespace Store_Bill
{
    class Bill : IOutFile
    {
        private string _billID;
        private CustomerInfor _customerInfor =new CustomerInfor();
        private List<DetailBill> _detailBill = new List<DetailBill>();
        private DateTime _dateCreated;
        private int _billPrice = 0;
        public void PrintBill(int deNum)
        {
            int line = 6;
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Bil infornation: " + _billID + " "+ _dateCreated+" "+_billPrice);
            _customerInfor.PrintInfor(ref line);
            Console.SetCursorPosition(28, 5 + 1+line++);
            Console.Write("List detail bills:         up,down arrow to see more");
            for(int i= deNum;i<= deNum+5;i++)
            {
                if(i < _detailBill.Count)
                _detailBill[i].PrintDetailPrice(ref line);
            }
        }
        public int GetDetailBillNumbers()
        {
            return _detailBill.Count();
        }
        public void ToStringFile(string[] k, int line)
        {
            k[line++] = ("Bil infornation: id: " + _billID + ", date: " + _dateCreated + ", total: " + _billPrice);
            _customerInfor.ToStringFile(k, line++);
            k[line++] = ("List detail bills: ");
            foreach (DetailBill product in _detailBill)
            {
                product.ToStringFile(k, line++);
                line++;
            }
        }
        public void GetBillInfor()
        {
            InputErrors catchInput = new InputErrors();
            int line = 5;
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter bill ID: ");
            catchInput.CatchInput(out _billID, 42, 5 + line - 1);
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter date(dd/mm/yyyy): ");
            catchInput.CatchInput(out _dateCreated, 52, 5 + line - 1);
            _customerInfor.GetCustomerInfor();
            line += 6;
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter detail bill numbers: ");
            int billNumber;
            catchInput.CatchInput(out billNumber, 55, 5 + line-1);
            Menu menu = new Menu();
            for(int i=0;i<billNumber;i++)
            {
                menu.ClearDisplay(line+2);
                Console.SetCursorPosition(28, 5 + line);
                Console.Write((i+1)+"||");
                _detailBill.Add(new DetailBill());
                _detailBill[i].GetInfor();
                if(i < billNumber -1) Console.ReadKey();
            }
            BillPrice();
            line = 26;
            Console.SetCursorPosition(58, 5 + line++);
            Console.Write("Total price:  " + _billPrice);
            Console.ReadKey();
        }
        public void BillPrice()
        {
            foreach (DetailBill product in _detailBill)
            {
                _billPrice += product.TotalPrice();
            }    
        }
    }
}
