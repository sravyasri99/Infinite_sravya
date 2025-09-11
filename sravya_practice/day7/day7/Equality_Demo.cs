using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class Student
        {
        }
    class Equality_Demo
    {
        static void Main()
        {
            int x = 5, y = 5;
            Console.WriteLine(x == y);
            Console.WriteLine(x.Equals(y));

            Student s1 = new Student();
            //Student s2 = new Student();
            Student s2 = s1;

            Console.WriteLine(s1 == s2);
            Console.WriteLine(object.ReferenceEquals(s1, s2));

            string str1 = "Morning";
            string str2 = "Morning";

            Console.WriteLine($"str1 == str2 :{str1 == str2}");




        }
    }
}
