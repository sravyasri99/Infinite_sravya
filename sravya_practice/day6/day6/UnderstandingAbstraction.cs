using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    abstract class Phones
    {
        public string PhoneType;

        abstract public void Work();

        public void NonAbstractMethod()
        {
            Console.WriteLine("tHIS IS PHONES NONABSTR METHOD");
        }

        public virtual void nonAbsVirtualMethod()
        {
            Console.WriteLine("tis is base virtual");
        }
    }

    class Mobile : Phones
    {
        public override void Work()
        {
            PhoneType = "Mobiles";
            Console.WriteLine("I am a Mobile Phone" + PhoneType);
        }

        public new void  NonAbstractMethod()
        {
            Console.WriteLine("tHIS IS mobile hidden METHOD");
        }

        public override void nonAbsVirtualMethod()
        {
            Console.WriteLine("this is virtual override method");
        }
    }
    class UnderstandingAbstraction
    {
        public static void Main()
        {
            Phones ph = new Mobile();
            // ph.Work();
            // ph.NonAbstractMethod();
            ph.nonAbsVirtualMethod();

            Mobile mobile = new Mobile();
            //mobile.NonAbstractMethod();
            //mobile.Work();
            mobile.nonAbsVirtualMethod();
            Console.Read();
        }
    }
}
