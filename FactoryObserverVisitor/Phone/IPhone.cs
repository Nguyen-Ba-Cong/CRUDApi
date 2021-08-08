using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Human;
namespace Factory.Phone
{
    public interface IPhone
    {
        string GetDetail();
        //string PayCheck(string s);
        string PayBy(American american);
        string PayBy(VietNamese vietnamese);

        void PayCheck(string s);

        void Register(American vietNamese);
        void Notify();

        void CheckCanBuy();

    }
}
