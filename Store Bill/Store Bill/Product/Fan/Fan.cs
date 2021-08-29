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
        protected int Line = 20;
        protected int _capacity;
        public abstract int GetPrice();
        public abstract string GetFanType();
        public virtual int GetCapacity()
        {
            return 0;
        }
        public string GetProductType()
        {
             return "Fan";
        }
    }   
}
