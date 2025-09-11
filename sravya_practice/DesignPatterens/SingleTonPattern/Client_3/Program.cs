using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleTonPattern;

namespace Client_3
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleTonClass trainingdot = SingleTonClass.GetInstance();
            {
                trainingdot.Show("This is donet training on design patterns client 3..");
                Console.Read();
            }
        }
    }
}
