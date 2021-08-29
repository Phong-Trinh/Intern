using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    abstract class AirConditioner : IProductInfor
    {
        protected InputErrors CatchInput = new InputErrors();
        protected int Line = 17;
        protected bool _inverter;
        protected string _airConditionerType;
        public abstract int GetPrice();
        public string GetProductType()
        {
             return "Air Conditioner";
        }
        public string GetInverter()
        {
            Console.SetCursorPosition(30, 5 + Line++);
            Console.Write("Inverter technology(1-Yes/2-No): ");
            int check;
            CatchInput.CatchInput(out check, 62, 5 + Line - 1, 2);
            if (check == 1) { _inverter = true; return "Have Interver"; }
            else { _inverter = false; return "No Interver";}
        }
        public abstract string GetAirConditionerType();
        public virtual string GetDeodorant()
        {
            return "No deodorant";
        }
        public virtual string GetAntiBacterial()
        {
            return "No deodorant";
        }
    }
}
