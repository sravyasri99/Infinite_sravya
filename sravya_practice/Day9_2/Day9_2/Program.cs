using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_2
{
    public delegate T Trans<T>(T arg);
    public delegate int Arithmetic(int x, int y);

    class Util
    {
        public static void Transform<T>(T[] values, Trans<T> targ)
        {
            for(int i=0;i<values.Length;i++)
            {
                values[i] = targ(values[i]);
            }
            
        }
    }
    class Program
    {
       // public static void Transform<T>(T[] values, )
       //example for passing delegates as an arguemnt to fuction or methos

        static void Main(string[] args)
        {
            DoOperation(10, 2,Multiply);
            DoOperation(10, 2, Divide);

        }

        public static void DoOperation(int a, int b, Arithmetic adel)
        {
            int z = adel(a, b);
            Console.WriteLine(z);
        }

        static int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        static int Divide(int a1, int a2)
        {
            return a1 / a2;
        }
    }
}
