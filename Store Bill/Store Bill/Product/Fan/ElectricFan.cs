using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    class ElectricFan : Fan
    {
        private int _baterry;
        public override int GetPrice()
        {
            Console.SetCursorPosition(30, 5 + Line++);
            Console.Write("Please enter how much capacity:  ");
            CatchInput.CatchInput(out _baterry, 63, 5+Line - 1);
            return _baterry * 500;
        }
        public override int GetCapacity()
        {
            return _baterry;
        }
        public override string GetFanType()
        {
            return "Electric Fan";
        }
    }
}
