using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY12
{
    class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static List<Student> GetStudents()
        {
            List<Student> stdlist = new List<Student>()
            {
                new Student{id = 101, Name = "Nivin", Email="Nivi@gmail.com" },
                new Student{id = 102, Name = "sravy", Email="sravy@gmail.com" },
            };
            //Student s1 = new Student { id = 101, Name = "sravya", Email = "sravya@gmail.com" };
            return stdlist;

        }
        class LambdaExpressions
        {
            static void Main()
            {
                List<int> numbers = new List<int> { 36, 71, 12, 15, 29, 18, 27, 17, 9, 34 };

                var square = numbers.Select(n => n * n);

                foreach (var v in square)
                {
                    Console.Write("{0} ", v);
                }
                Console.WriteLine();
                Console.WriteLine("Numbers divisible by 3 are");

                var divisiblebythree = numbers.Select(n => n % 3 == 0);

                foreach (var t in divisiblebythree)
                {
                    Console.Write("{0} ", t);
                }
                Console.WriteLine();
                Student s = new Student();
                


                Console.Read();
            }
        }
    }
}
