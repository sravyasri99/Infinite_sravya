using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day10
{
    class ThreadsDemo
    {
        static void Main()
        {
            Thread t = Thread.CurrentThread;

            t.Name = "main Thread";
            Console.WriteLine("tHE ECECUTING THREAD IS {0} ALSO {1}",t.Name, Thread.CurrentThread);

            Method1();
            Method2();
            Method3();

            Console.Read();

        }
        static void Method1()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Method 1..: " + i);
            }
        }

        static void Method2()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Method 2..: " + i);
                if (i == 3)
                {
                    Console.WriteLine("Branching off to do database operations...");

                    //we will put the thread to sleep for 10 secs
                    Thread.Sleep(10000);
                    Console.WriteLine("Database Operations completed..");
                }
            }
        }
        static void Method3()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Method 3..: " + i);
            }
        }
}
