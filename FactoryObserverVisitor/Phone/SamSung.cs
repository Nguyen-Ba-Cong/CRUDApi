using Factory.Human;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Phone
{
    class SamSung : IPhone
    {
        private List<IHuman> customers = new List<IHuman>();
        private string _availability { get; set; }
        public SamSung()
        {

        }
        public SamSung(string availability)
        {
            _availability = availability;
        }
        public string GetAvailability()
        {
            return _availability;
        }
        public void SetAvailability(string s)
        {
            this._availability = s;
            Console.WriteLine("Availability changed from Out of Stock to Available.");
            Notify();
        }
        public string GetDetail()
        {
            return "Sam Sung Phone";
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
            PayCheck("500 USD");
            return "500 USD";
        }

        public string PayBy(American american)
        {
            PayCheck("300 USD");
            return "300 USD";
        }
        public void PayCheck(string s)
        {
            Console.WriteLine("Pay " + s + " for" + GetDetail());
        }

        public void Register(American american)
        {
            customers.Add(american);
        }

        public void CheckCanBuy()
        {
            Console.WriteLine("You are welcome");
        }
    }
}
