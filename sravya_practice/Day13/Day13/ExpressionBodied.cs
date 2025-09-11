using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Day13
{
    class Test
    {

    }
    class ExpressionBodied
    {
        public static int Year = 2016;

        public int Squarearea(int side) => side * side;
        public int Arithmetics(int a, int b) => ((a + b) + (a - b) + (a * b) + (a / b));
        
        static void Main()
        {
            Console.WriteLine(LeapYear());
            Console.WriteLine("***********************************");
            ExpressionBodied eb = new ExpressionBodied();
            int i = 6;
            int a = 5, b = 5;
            Console.WriteLine(eb.Squarearea(i));
            Thread.Sleep(2000);
            Console.WriteLine(eb.Arithmetics(15, 5));

            Console.ReadKey();
        }

        //public static string LeapYear()
        //{
        //    return "\n Is " + Year + " a Leap Year ? " + DateTime.IsLeapYear(Year);

        //}

        //with expression bodied member
        //public static string LeapYear()=> "\n Is " + Year + " a Leap Year ? " + DateTime.IsLeapYear(Year);
        //2.
        public static string LeapYear() => $"Is {Year} a Leap Year :" + DateTime.IsLeapYear(Year);

    }
}
