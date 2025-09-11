using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Person { }

    public class Employee : Person { }

    public class Manager : Person {}
    delegate void persondelegate(Employee eobj);
    class CoContraVariance
    {
        public static void Message(Person pobj)
        {
            Console.WriteLine("hi");
        }
        static void Main()
        {
            var personobj = new Person();
            var empobj = new Employee();
            var mgrobj = new Manager();

            personobj = empobj;
            personobj = mgrobj;

            persondelegate pd = Message;

            pd(empobj);
            Console.Read();
        }
    }
}
