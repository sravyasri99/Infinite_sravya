using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    class Tuples
    {
        static void Main()
        {
            //var values = new List<double>() { 10, 20, 30, 40, 50 };
            //1. With Tuple OBJECTS
            //Tuple<int, double> t = Calculate(values);
            //Console.WriteLine($"There are {t.Item1} values and their sum is {t.Item2}");

            //2. Without tuple
            //var result = Calculate(values);
            //Console.WriteLine($"There are {result.Item1} values and their sum is {result.Item2}");
            //Console.WriteLine($"There are {result.count} values and their sum is {result.Item2}");
            var values = new List<int> { 10, 5, 15 };
            var res = CalculateMinMaxAvg(values);
            Console.WriteLine($"Minimum value {res.min} Maximum value {res.max} average value {res.avg}");
            Console.Read();
        }
        //static Tuple<int, double> Calculate(List<double> val)
        //{
        //    //int count = 0;
        //    //double total = 0.0;
        //    //foreach(var v in val)
        //    //{
        //    //    count++;
        //    //    total += v;
        //    //}

        //    ////creating an object of the tuple class by calling a create Method

        //    //Tuple<int, double> ret_tuple = Tuple.Create(count, total);

        //    ////return the tuple

        //    //return ret_tuple;
        //}
        //static (int count,double ) Calculate(IEnumerable<double>val)
        //{
        //    int count = 0;
        //    double total = 0.0;
        //    foreach (var v in val)
        //    {
        //        count++;
        //        total += v;
        //    }

        //}
        static (int count, double total) Calculate(IEnumerable<double> val)
        {
            int count = 0;
            double total = 0.0;
            foreach (var v in val)
            {
                count++;
                total += v;
            }
            return (count, total);
        }

        static (int min, int max, double avg) CalculateMinMaxAvg(IEnumerable<int> values)
        {
            int min = values.Min();
            int max = values.Max();
            double avg = values.Average();

            return (min, max, avg);


        }


    }
}
