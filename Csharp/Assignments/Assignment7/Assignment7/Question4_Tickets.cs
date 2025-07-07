using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;
using System.Threading.Tasks;

namespace Assignment7
{
    class Question4_Tickets
    {
        const double TotalFare = 500;

        static void Main()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ConcessionCalculator concessioncalculator = new ConcessionCalculator();
            concessioncalculator.CalculateConcession(name, age, TotalFare);

            Console.ReadLine();
        }
    }
}
