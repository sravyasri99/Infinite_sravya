using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY12
{
    class QueryExpressions
    {
        static void Main(string[] args)
        {
            int[] intval = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> oddvalues = from v in intval
                                         where (v % 2) != 0
                                         select v;
            foreach(int x in oddvalues)
            {
                Console.WriteLine(x);
            }
  
            IEnumerable<Student> stdobj = from student in Student.GetStudents()
                                          where student.Name.EndsWith("n")
                                          select student;
            foreach(var s in stdobj)
            {
                Console.WriteLine($"{s.id} {s.Name} {s.Email}");
            }

            var stdname = from s in Student.GetStudents()
                          where s.id == 102
                          select s.Name;
            foreach (var name in stdname)
            {
                Console.WriteLine(name);
            }

            

            Console.Read();


        }
    }

    //class Student
    //{
    //    public int id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }

    //    public static List<Student> GetStudents()
    //    {
    //        List<Student> stdlist = new List<Student>()
    //        {
    //            new Student{id = 101, Name = "Nivin", Email="Nivi@gmail.com" },
    //            new Student{id = 102, Name = "sravy", Email="sravy@gmail.com" },
    //        };
    //        //Student s1 = new Student { id = 101, Name = "sravya", Email = "sravya@gmail.com" };
    //        return stdlist;
            
    //    }
    }

