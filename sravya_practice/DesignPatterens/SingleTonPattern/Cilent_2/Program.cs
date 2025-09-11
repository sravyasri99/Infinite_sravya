using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleTonPattern;

namespace Cilent_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleTonClass training = SingleTonClass.GetInstance();
            {
                training.Show("This is donet training on design patterns client2..");
                Console.Read();
            }
        }
    }
}
