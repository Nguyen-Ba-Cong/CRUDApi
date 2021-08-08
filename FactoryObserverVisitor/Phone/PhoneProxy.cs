using Factory.Human;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Phone
{
    class PhoneProxy : IPhone
    {
        private IPhone _phone;
        private American _american;
        public PhoneProxy(American american)
        {
            _american = american;
        }
        public void CheckCanBuy()
        {
            if (_american.MoneyHas >= 400000)
            {
                _phone = new SamSung();
                _phone.CheckCanBuy();
            }
            else
            {
                Console.WriteLine("Sorry " + _american.UserName + ", you don't have enought, See you again");
            }
        }

        public string GetDetail()
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public string PayBy(American american)
        {
            throw new NotImplementedException();
        }

        public string PayBy(VietNamese vietnamese)
        {
            throw new NotImplementedException();
        }

        public void PayCheck(string s)
        {
            throw new NotImplementedException();
        }

        public void Register(American vietNamese)
        {
            throw new NotImplementedException();
        }
    }
}
