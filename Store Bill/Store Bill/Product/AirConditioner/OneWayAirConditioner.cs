using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    class OneWayAirConditioner : AirConditioner
    {
        private int _productPrice;
        public override string GetAirConditionerType()
        {
            return "One way";
        }

        public override int GetPrice()
        {
            GetInverter();
            if (_inverter == true) _productPrice = 1500;
            else _productPrice = 1000;
            return _productPrice;
        }
    }
}
