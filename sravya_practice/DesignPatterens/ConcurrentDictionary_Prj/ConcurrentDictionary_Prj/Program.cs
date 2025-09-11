using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentDictionary_Prj
{
    class Program
    {
        static Dictionary<string, int> _mydic = new Dictionary<string, int>();

        static ConcurrentDictionary<string, int> _mycondic = new ConcurrentDictionary();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(InsertData));
            Thread t2 = new Thread(new ThreadStart(InsertData));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            t1 = new Thread(new ThreadStart(InsertDataConcurrent));
            t2 = new Thread(new ThreadStart(InsertDataConcurrent));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine($"Results in the dictionary object : {_mydic.Values.Count}");
            Console.WriteLine("************************************");


        }
        static void InsertData()
        {
            for(int i=0;i<100;i++)
            {
                _mydic.Add
            }
        }
        static void InsertDataConcurrent()
        {
            for(int i = 0; i<100; i++)
            {
                _mycondic.TryAdd
            }
        }
    }
}
