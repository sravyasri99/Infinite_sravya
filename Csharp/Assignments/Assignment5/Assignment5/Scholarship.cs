using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class ScholarshipNotApplicableException : ApplicationException
    {
        public ScholarshipNotApplicableException(string message) : base(message)
        {
        }
    }
    class Scholarship
    {
        public double  Merit(int marks, double fees)
        {
            double scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = 0.20 * fees;
                return scholarshipAmount;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.30 * fees;
                return scholarshipAmount;

            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.50 * fees;
                return scholarshipAmount;
            }
            else
            {
                throw new ScholarshipNotApplicableException("The Student is not Eligible for the Scholarship due to less Marks");
            }
        }
    }

    public class ScholarshipMain
    {
        static void Main()
        {
            Scholarship scholarship = new Scholarship();

            Console.Write("Enter marks of the student: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter fees amount of the Student: ");
            double fees = Convert.ToDouble(Console.ReadLine());

            try
            {
                double scholarshipAmount = scholarship.Merit(marks, fees);
                Console.WriteLine($"Scholarship Amount of the Student is : {scholarshipAmount}");
            }
            catch (ScholarshipNotApplicableException exc)
            {
                Console.WriteLine($"Exception: {exc.Message}");
            }
            Console.Read();
        }

    }
}
