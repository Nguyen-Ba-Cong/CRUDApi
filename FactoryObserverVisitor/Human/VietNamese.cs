using Factory.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Human
{
    public class VietNamese : IHuman
    {
        public string UserName { get; set; }
        public int MoneyHas;
        public void Pay(IPhone phone)
        {
            Console.Write("I am VietNamese and I ");
            phone.PayBy(this);
        }

        public void Update(string availability)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + availability);
        }
    }
}
