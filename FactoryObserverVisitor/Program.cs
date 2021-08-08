using Factory.Human;
using System;

namespace Factory.Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            //using factory design pattern to get phone Detail from Phone Factory
            IPhone phone = PhoneFactory.GetPhone("SamSung");
            Console.WriteLine("--------");
            //using visitor design pattern
            IHuman vietNamese = new VietNamese();
            IHuman american = new American();
            IPhone nokia = new Nokia();
            IPhone samsung = new SamSung();
            vietNamese.Pay(nokia);
            vietNamese.Pay(samsung);
            american.Pay(nokia);
            american.Pay(samsung);
            Console.WriteLine("--------");
            //using observer to update status of samsung.
            SamSung sam = new SamSung("Out of Stock");
            American a = new American("Peter", sam, 500000);
            American b = new American("Tom", sam, 300000);
            Console.WriteLine("Sam sung current state: " + sam.GetAvailability());
            sam.SetAvailability("Available");
            Console.WriteLine("--------");
            //using proxy to block customer don't have enought money
            PhoneProxy pp1 = new PhoneProxy(a);
            pp1.CheckCanBuy();
            PhoneProxy pp2 = new PhoneProxy(b);
            pp2.CheckCanBuy();
        }
    }
}
