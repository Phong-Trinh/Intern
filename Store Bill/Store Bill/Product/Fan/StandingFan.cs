using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    class StandingFan : Fan
    {
        public override int GetPrice()
        {
            return 500;
        }
        public override string GetFanType()
        {
            return "Standing Fan";
        }
    }
}
