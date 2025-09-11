using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4
{
    
    class MethodParameters
    {
        //call by value
        public static void SimpleValueMethod(int j)
        {
            j = 100;
            Console.WriteLine("j value is " + j);
        }
        //call by ref
        public static void SimpleReference(ref int j)
        {
            j = 100;
            Console.WriteLine("j value is " + j);
        }
        // using out
        public static int Calculate(int n1, int n2, out int sum, out int product)
        {
            sum = n1 + n2; //output value
            product = n1 * n2; //output value
            return n1 - n2;  // return value
        }
    }
    class Tester
    {
        static void Main()
        {
            int i = 10;
            MethodParameters.SimpleValueMethod(i);
            Console.WriteLine("i value is {0}", i);
            Console.WriteLine("---------------------");
            MethodParameters.SimpleReference(ref i);
            Console.WriteLine("I value is {0}", i);
            Console.WriteLine("----------out parameters--");
            int total, prod, difference;
            difference = MethodParameters.Calculate(10, 10, out total, out prod);
            Console.WriteLine("the sum is {0} and the product is {1} the difference is{2}", total, prod, difference);
            Console.Read();
        }
      
    }
}
