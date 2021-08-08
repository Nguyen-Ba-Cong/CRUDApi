using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Phone;

namespace Factory.Human
{
    interface IHuman
    {
        void Pay(IPhone phone);
        void Update(string availability);
    }
}
