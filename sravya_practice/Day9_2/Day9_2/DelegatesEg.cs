using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_2
{
    public delegate int CalculatorDel(int x);
    class DelegatesEg
    {
        static int p;

        public int Square(int x)
        {
            p = x * x;
            return p;
        }

        public int Triple(int q)
        {
            p = q * q * q;
            return p;
        }
        static void Main(string[] args)
        {
            DelegatesEg delegatesEg = new DelegatesEg();
            CalculatorDel cd = new CalculatorDel(delegatesEg.Square);
            // cd += prog.Triple;
            int result = cd(5);
            Console.WriteLine("Return value is {0}", result);
            cd = delegatesEg.Triple;
            Console.WriteLine(cd(5));
            cd = new CalculatorDel(delegatesEg.Triple);
            Console.Read();
        }
    }
}
