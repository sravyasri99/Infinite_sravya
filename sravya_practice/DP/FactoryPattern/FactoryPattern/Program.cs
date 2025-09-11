using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Abstractions;
using FactoryPattern.Implementors;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the price");
            int Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the card type:");
            string cardtype = Console.ReadLine();
            IDiscounts discounts = null;
            if(cardtype == "SeasonalDiscounts")
            {
                discounts = new Implementors.SeasoanlDiscounts();
            }
            else if(cardtype == "MembershipDiscounts")
            {
                discounts = new Implementors.MembershipDiscounts();
            }
            else if (cardtype == "ClearanceDiscounts")
            {
                discounts = new Implementors.ClearanceDiscounts();
            }
            if (discounts != null)
            {
                Console.WriteLine($"The amount is {discounts.GetPrice(Price)}");
            }
            else
            {
                Console.WriteLine("iNVALID");
            }
            Console.Read();
        }
    }
}
