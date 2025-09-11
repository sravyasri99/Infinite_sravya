using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    class IteratorsEg
    {
        public static IEnumerable<string> GetData()
        {
            List<String> colors = new List<string>() { "Red", "Blue", "Green", "Rose" };

            foreach(var items in colors)
            {
                yield return items;
            }
        }

        //example for yield with retunr and break
        public static void IEnumerable<int>GetRandomYears()
        {
            int year;
            while(true)
            {
                Random random = new Random();
                year = random.Next(2000, 2025);
                if(year %4 ==0)
                {
                    Console.WriteLine($"Leap Year {year} Encountered");
                    yield break;
                }
                yield return year;
            }
            Console.WriteLine("Methos done..");
        }
        static void Main()
        {
            IEnumerable<string> retColors = GetData();

            foreach(var i in retColors )
            {
                Console.WriteLine(i);
            }
            foreach(int yr in GetRandomYear)
        }
    }
}
