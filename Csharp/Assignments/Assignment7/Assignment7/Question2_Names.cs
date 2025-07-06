using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Question2_Names
    {
        static void Main()
        {
            string[] names = new string[3];
            Console.WriteLine("Enter any three different names:");
            for(int i=0; i<names.Length; i++)
            {
                names[i] = Console.ReadLine();
            }

            var result = from name in names
                         where name.StartsWith("a", StringComparison.OrdinalIgnoreCase) && name.EndsWith("m", StringComparison.OrdinalIgnoreCase)
                         select name;

            Console.WriteLine("\nNames starting with 'a' and ending with 'm' are :");
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }
    }
}
