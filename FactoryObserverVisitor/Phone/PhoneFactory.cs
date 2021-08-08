using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Phone
{
    class PhoneFactory
    {
        public static IPhone GetPhone(string name)
        {
            IPhone phone = null;
            if (name == "SamSung")
            {
                phone = new SamSung();
            }
            else if (name == "Nokia")
            {
                phone = new Nokia();
            }
            Console.WriteLine(phone.GetDetail());
            return phone;
        }
    }
}
