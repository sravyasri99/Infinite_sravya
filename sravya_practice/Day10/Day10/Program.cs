using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        delegate void Print(int v);
        static void Main(string[] args)
        {
            int i = 100;
            Print p = delegate (int x)
            {
                x += i;
                Console.WriteLine("we are inside the anonymous method {0}", x);
            };

            p(10);

            

            //Types of delegates example
            Console.WriteLine("----------Predicate delegate type--------");

            Predicate<string> chkupper = delegate (string s)
             {
                 return s.Equals(s.ToUpper());
             };

            bool res = chkupper("HELLO DELEGATE");
            Console.WriteLine(res);
            res = chkupper("Hello Delegate");
            Console.WriteLine(res);

            Console.WriteLine("----------Function Delegates-----");
            Func<int> getRandomNumber = delegate ()
            {
                Random r = new Random();
                return r.Next(1, 100);
            };

            Console.WriteLine("----------Action Delegate-------");
            Action<int> actiondel = delegate (int n)
            {
                Console.WriteLine(n + 5);
            };
            actiondel(5);

            // With Lambda
            Action<int> addaction = n => Console.WriteLine(n + 10);
            addaction(15);

            Console.WriteLine("----------------------------------");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Predicate<int> oddnums =  delegate (int n)
            {
                return n % 2 != 0;
            };
            int[] result = Array.FindAll(numbers, oddnums);
            foreach(int item in result)
            {
                Console.WriteLine(item);
            }


            Predicate<int> oddnumss = x => x % 2 != 0;
            Console.WriteLine(oddnums(3));

            Predicate<int> oddlist = x => x % 2 != 0;
            int[] finalres = Array.FindAll(numbers, oddlist);
            foreach (int item in finalres)
            {
                Console.WriteLine(item);
            }

            Func<int, int, int> product = delegate (int n1, int n2)
            {
                return n1 * n2;
            };
            Console.WriteLine(product(2, 5));

            Func<int, int, int> productm = (n1, n2) => n1 * n2;
            Console.WriteLine(productm(2, 5));

            Console.Read();

        }
    }
}
