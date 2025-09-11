using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace day11
{
    class ThreadSynEg
    {
        static Thread t1, t2;
        static void Main()
        {
            //Thread t1 = new Thread(Func1);
            //t1.Start();
            //Thread t2 = new Thread(Func2);
            //t2.Start();
            //t1.Join();
            //t2.Join();
            //syn using locks
            ThreadSynEg tse = new ThreadSynEg();
            Console.WriteLine(" Threading Using Locks ---");
            t1 = new Thread(new ThreadStart(tse.DisplayNumbers));
            t1.Name = "Thread 1";

            t2 = new Thread(new ThreadStart(tse.DisplayNumbers));
            t2.Name = "Thread 2";
        }

        public void Func1()
        {
            Console.WriteLine("Thread 2 is executed");
        }

        public void Func2()
        {
            Console.WriteLine("Thread 1 is executed");
        }

        public void DisplayNumbers()
        {
            lock(this)
            {
                for(int i =0;i<=5;i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("i = {0} of Thread {1} ", i, Thread.CurrentThread.Name);
                }
            }
        }

    }
}
