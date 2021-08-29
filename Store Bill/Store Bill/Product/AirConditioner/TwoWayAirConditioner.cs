using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    class TwoWayAirConditioner : AirConditioner
    {
        private int _productPrice = 2000;
        private bool _deodorant;
        private bool _antiBacterial;
        public override string GetAirConditionerType()
        {
            return  "Two way";
        }

        public override int GetPrice()
        {
            GetInverter();
            Console.SetCursorPosition(30, 5 + Line++);
            Console.Write("Deodorant technology(1-Yes/2-No): ");
            int check;
            CatchInput.CatchInput(out check, 63, 5 + Line - 1, 2);
            if (check == 1) _deodorant = true;
            else _deodorant = false;
            Console.SetCursorPosition(30, 5 + Line++);
            Console.Write("Antibacterial technology(1-Yes/2-No): ");
            CatchInput.CatchInput(out check, 67, 5 + Line - 1, 2);
            if (check == 1) _antiBacterial = true;
            else _antiBacterial = false;
            if (_inverter == true) _productPrice += 500;
            if (_deodorant == true) _productPrice += 500;
            if (_antiBacterial == true) _productPrice += 500;
            return _productPrice;
        }
        public override string GetAntiBacterial()
        {
            if (_antiBacterial == true)
                return "Have Antibacterial";
            else return "No Antibacterial";
        }
        public override string GetDeodorant()
        {
            if (_deodorant == true)
                return "Have Deodorant";
            else return "NO Deodorant";
        }
    }
}