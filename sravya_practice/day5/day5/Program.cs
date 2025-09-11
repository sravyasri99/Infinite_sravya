using System;


namespace day5
{
    class Student
    {
        private string Rollno;
        private string Name;
        private string Class;

        public void GetData()
        {
            Console.WriteLine("Enter roll no:");
            Rollno = Console.ReadLine();
            Console.WriteLine("Enter name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter class:");
            Class = Console.ReadLine();
        }
        public void PutData()
        {
            Console.WriteLine("The name of the student : {0}", Name);
            Console.WriteLine("Roll no  = " + Rollno);
            Console.WriteLine("Class " + Class);
        }
    }
    class Marks : Student
    {
        protected int[] a = new int[5];

        public void GetMarks()
        {
            for(int i=0; i<a.Length; i++)
            {
                Console.Write("Enter subject {0} Marks :", i + 1);
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void PutMarks()
        {
            for(int i=0; i<a.Length; i++)
            {
                Console.WriteLine("Marks in Subject {0} is {1}", i + 1, a[i]);
            }
        }
    }

    class Results : Marks
    {
        int Totalmarks = 0;

        public void GetResults()
        {
            for(int i=0; i<a.Length; i++)
            {
                Totalmarks = Totalmarks + a[i];
            }
        }

        public void PutResults()
        {
            Console.WriteLine("========= Results =========");
            PutData();
            PutMarks();
            Console.WriteLine("Total Marks = " + Totalmarks);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Results results = new Results();
            results.GetData();
            results.GetMarks();
            results.GetResults();
            results.PutResults();

            Console.Read();
        }
    }
}
