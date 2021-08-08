using Factory.Human;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Phone
{
    class Nokia : IPhone
    {
        private List<IHuman> customers = new List<IHuman>();
        private string _availability { get; set; }
        public Nokia()
        {

        }
        public Nokia(string availability)
        {
            _availability = availability;
        }
        public void CheckCanBuy()
        {
            Console.WriteLine("You are welcome");
        }

        public string GetDetail()
        {
            return "Nokia Phone";
        }

        public void Notify()
        {
            foreach (IHuman human in customers)
            {
                human.Update(_availability);
            }
        }

        public string PayBy(VietNamese vietnamese)
        {
            PayCheck("300 USD");
            return "300 USD";
        }

        public string PayBy(American american)
        {
            PayCheck("100 USD");
            return "100 USD";
        }
        public void PayCheck(string s)
        {
            Console.WriteLine("Pay " + s + " for " + GetDetail());
        }
        public void Register(American american)
        {
            customers.Add(american);
        }
    }
}
