using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8
{
    class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string StudentCourse { get; set; }
        public int StudentMark { get; set; }

        List<Student> studentsList = new List<Student>();

        internal void AddStudent(Student student)
        {
            studentsList.Add(student);
        }

        //Display the student

        internal List<Student> DisplayStudent()
        {
            return studentsList;
        }

        //Get student by course

        //internal List<Student> GetStudentsByCourse(string course)
        //{
        //    return 
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> booksList = new List<string>();

            Student student = new Student();

            //Add the student

            student.AddStudent(new Student { StudentId = 1, StudentName = "sravy", StudentCourse = "ECE", StudentMark = 98 });
            student.AddStudent(new Student { StudentId = 1, StudentName = "sri", StudentCourse = "cse", StudentMark = 97 });

            //dispaly the student
            // studentData = student.DisplayStudent();
            //foreach(var item in studentData)
            //{
            //    Console.WriteLine($"ID:{item.StudentId + " "+item.StudentName + " " }")
            //}

        }
    }
}
