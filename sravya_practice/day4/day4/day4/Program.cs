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

        public static int Add_Elements(params int[] arr)
        {
            int sum = 0;
            foreach(int c in arr)
            {
                sum += c;

            }
            return sum;
        }
        public static void ParamsMethod(params int[] arr)
        {
            Console.WriteLine("THE TOTAL number of values in arr are {0}", arr.Length);
            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }
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
            Console.WriteLine("-----------------parameter Array--------------");
            Console.WriteLine(MethodParameters.Add_Elements());
            Console.WriteLine(MethodParameters.Add_Elements(2, 3, 4));
            Console.WriteLine(MethodParameters.Add_Elements(1, 1));
            int[] arr = new int[2];
            arr[0] = 1;
            arr[1] = 8;
            MethodParameters.ParamsMethod(arr);
            MethodParameters.ParamsMethod(1, 2, 3, 4, 5, 6);

            Console.Read();
        }

    }
}
