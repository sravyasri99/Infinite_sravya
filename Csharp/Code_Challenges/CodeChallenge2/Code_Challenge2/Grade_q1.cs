using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge2
{
    public abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }
        public abstract bool IsPassed(double grade);
    }

    public class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
            : base(name, studentId, grade)
        {
        }

        public override bool IsPassed(double grade)
        {
            return grade >= 70.0;
        }
    }

    public class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
            : base(name, studentId, grade)
        {
        }

        public override bool IsPassed(double grade)
        {
            return grade >= 80.0;
        }

    }
    class Grade_q1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the class of the Student type like Undergraduate or Graduate: ");
            string className = Console.ReadLine();

            Console.Write("Enter the name of the Student: ");
            string name = Console.ReadLine();

            Console.Write("Enter the ID of the Student: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter grade: ");
            double grade = Convert.ToDouble(Console.ReadLine());

            Student student;

            if (className == "Undergraduate")
            {
                student = new Undergraduate(name, id, grade);
            }
            else if (className == "Graduate")
            {
                student = new Graduate(name, id, grade);
            }
            else
            {
                Console.WriteLine("Enter the correct class of the Student");
                return;
            }
            string result = student.IsPassed(student.Grade) ? "Passed" : "Failed";
            Console.WriteLine($"Name of the Student: {student.Name}, of class: {className}, is: {result}");
   
            Console.Read();
        }
    }
}
