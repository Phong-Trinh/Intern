using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    internal class CustomerInfor : IOutFile
    {
        private string _customerID;
        private string _customerName;
        private string _customerPhoneNumbers;
        private string _customerAdress;
        public void PrintInfor(ref int line)
        {
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Customer information: " + _customerID + " " + _customerName + " "+_customerPhoneNumbers + " "+_customerAdress );
        }
        public void ToStringFile(string[] k, int line)
        {
            k[line++] = ("Customer information: id: " + _customerID + ", name: " + _customerName + ", phone: " + _customerPhoneNumbers + ", adress: " + _customerAdress);
        }
        public void GetCustomerInfor()
        {
            InputErrors catchInput = new InputErrors();
            int line = 7;
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter customer ID: ");
            catchInput.CatchInput(out _customerID, 46, 5 + line - 1);
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter customer name: ");
            _customerName = Console.ReadLine();
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter customer phone numbers: ");
            _customerPhoneNumbers = Console.ReadLine();
            Console.SetCursorPosition(28, 5 + line++);
            Console.Write("Enter customer adress: ");
            _customerAdress = Console.ReadLine();
        }

        public void ToStringFile(string[] k, ref int line)
        {
            throw new NotImplementedException();
        }
    }
}
