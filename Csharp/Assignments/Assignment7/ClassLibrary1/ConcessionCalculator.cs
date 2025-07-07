using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ConcessionCalculator
    {
        public void CalculateConcession(string name, int age, double totalFare)
        {
            if (age <= 5)
            {
                Console.WriteLine($"{name}, Little Champs Free Ticket");
            }
            else if (age > 60)
            {
                double concession = totalFare * 0.30;
                double AfterConcession = totalFare - concession;
                Console.WriteLine($"{name}, Senior Citizen Fare is : {AfterConcession}");
            }
            else
            {
                Console.WriteLine($"{name}, Ticket Booked and the Fare is : {totalFare}");
            }
        }
    }
}
