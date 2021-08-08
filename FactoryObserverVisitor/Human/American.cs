using Factory.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Human
{
    public class American : IHuman
    {
        public string UserName { get; set; }
        public int MoneyHas;
        public American()
        {

        }
        public American(string userName, IPhone phone, int moneyHas)
        {
            UserName = userName;
            phone.Register(this);
            MoneyHas = moneyHas;
        }
        public void Pay(IPhone phone)
        {
            Console.Write("I am American and I ");
            phone.PayBy(this);
        }

        public void Update(string availability)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + availability);
        }
    }
}
