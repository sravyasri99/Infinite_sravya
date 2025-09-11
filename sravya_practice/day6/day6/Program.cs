using System;

namespace day6
{
    class Phone
    {
        public string Brand { get; set; }
        public void PhoneFeatures()
        {
            Console.WriteLine("Features of the Phone" + " " + Brand);
        }
    }

    class OnePlus: Phone
    {
        public new void PhoneFeatures()
        {
            Console.WriteLine("Features of the Phone" + " " + Brand);
        }

        public void ShowPhoneType()
        {
            Console.WriteLine("Brand in base type phone : {0}", base.Brand);
            Console.WriteLine("Brand in derived type phone : {0}", Brand);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone();
            phone.Brand = "Mobile Phone";
        }
    }
}
