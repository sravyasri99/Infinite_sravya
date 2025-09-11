using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
   
    class Program
    {
        static void Main()
        {
            int Cost = 200;
            int items = 5;
            double discount = 10;
            int total = Cost * items;
            double AfterDiscount = total * (discount / 100);
            double TotalAmount = total - AfterDiscount;

            Console.WriteLine("The amount is : {0}", TotalAmount);
            Console.Read();

        }
    }
}
