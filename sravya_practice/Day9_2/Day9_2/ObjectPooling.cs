using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_2
{
    class StudentFactory
    {
        static int MaxPoolSize = 3;
        static readonly Queue objPool = new Queue();
    }
    class Student
    {
        public static int objcounter = 0;

       public string FirstName { get; set; }
        public string LastName {get; set;}
        public string Class {get; set;}
        public Student()
        {

        }
    }
    class ObjectPooling
    {
    }
}
