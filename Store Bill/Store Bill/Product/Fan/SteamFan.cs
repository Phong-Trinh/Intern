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
            int battery;
            CatchInput.CatchInput(out battery, 63, 5+Line - 1);
            _capacity = battery;
            return _capacity * 400;
        }
    }
}
