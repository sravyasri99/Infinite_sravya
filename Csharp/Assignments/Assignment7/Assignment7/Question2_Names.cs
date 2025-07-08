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
            Console.WriteLine("Enter how many names you want to test:");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] names = new string[n];
            Console.WriteLine("Enter any  different names:");
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
