using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    class SteamFan : Fan
    {
        public override string GetFanType()
        {
            return "Steam Fan";
        }

        public override int GetPrice()
        {
            Console.SetCursorPosition(30, 5 + Line++);
            Console.Write("Please enter how much capacity:  ");
            CatchInput.CatchInput(out _capacity, 63, 5+Line - 1);
            GetCapacity();
            return _capacity * 400;
        }
        public override int GetCapacity()
        {
            return _capacity;
        }
    }
}
