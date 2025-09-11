using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_2
{
    public class Demo : IDisposable
    {

    }
    class GarbageEg
    {
        static void Main()
        {
            Console.WriteLine("Maximum number of generations : {0}", GC.GetGeneration);

        }
    }
}
