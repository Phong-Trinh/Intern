using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    abstract class Fan : IProductInfor
    {
        protected InputErrors CatchInput = new InputErrors();
        protected int Line = 17;
        public int _capacity { get; set; }
        public abstract int GetPrice();
        public abstract string GetFanType();
        public string GetProductType()
        {
             return "Fan";
        }
    }   
}
