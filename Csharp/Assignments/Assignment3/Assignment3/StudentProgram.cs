using System;

namespace Assignment3
{
    class Student
    {
        public int RollNo;
        public string Name;
        public int Class;
        public string Semester;
        public string Branch;
        public int sum = 0;
        public float Average;
        public string Result;

        public int[] marks = new int[5];

        public Student(int rollno, string name, int clas, string semester, string branch)
        {
            RollNo = rollno;
            Name = name;
            Class = clas;
            Semester = semester;
            Branch = branch;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter the " + marks.Length + " subjects marks");
            for(int i=0; i<marks.Length; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());

            }
        }

        public void DisplayResult()
        {
            foreach(int c in marks)
            {
                sum += c;
            }
            Average = (float)sum / marks.Length; 
        }

        public void CheckResult()
        {
            foreach(int k in marks)
            {
                if(k <35)
                {
                    Result = "Failed";
                    break;
                }
                else if(Average < 50)
                {
                    Result = "Failed";
                    break;
                }
                else
                {
                    Result = "Passed";
                }
            }
        }

        public void DisplayData()
        {
            DisplayResult();
            CheckResult();
            Console.WriteLine("===========================");
            Console.WriteLine("The roll number of the student is: " + RollNo);
            Console.WriteLine("The Name of the Student is: " +  Name);
            Console.WriteLine("The Class of the Student is: "+ Class);
            Console.WriteLine("The Semester of the Student is: "+ Semester);
            Console.WriteLine("The Branch of the Student is: "+ Branch);
            Console.Write("The marks scored by the student in 5 subjects are: ");
            foreach(int j in marks)
            {
                Console.Write(j+" ");
            }
            Console.WriteLine();
            Console.WriteLine("The average of the marks is: " + Average);
            Console.WriteLine("The Result of the student is: " + Result);
            Console.Read();

        }

    }
    class StudentProgram
    {
        static void Main()
        {
            Student student = new Student(45,"Sravya",10,"2nd","ECE");
            student.GetMarks();
            student.DisplayData();


        }
    }
}
