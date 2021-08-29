using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    interface IOutFile
    {
        void ToStringFile(string[] k, int line);
    }
}
