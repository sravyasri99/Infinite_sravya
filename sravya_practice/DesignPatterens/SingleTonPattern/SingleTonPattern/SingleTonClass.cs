using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPattern
{
    public  sealed class SingleTonClass
    {
        //private field to increment a counter every time object is created
        private static int counter = 0;

        private static SingleTonClass spobj = null;

        public static SingleTonClass GetInstance()
        {
            if(spobj == null)
            {
                spobj = new SingleTonClass();
               
            }
            return spobj;
        }

        private SingleTonClass()
        {
            counter++;
            Console.WriteLine("Counter Value :" + counter.ToString());
        }
        public void Show(string msg)
        {
            Console.WriteLine(msg);
        }

       
    }
}
