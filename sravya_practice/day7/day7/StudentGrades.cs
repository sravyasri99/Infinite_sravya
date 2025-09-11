using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class StudentGrades
    {
        public static int[] arr = new int[3];


        static void Main()
        {
            StudentGrades studentGrades = new StudentGrades();
            Console.WriteLine("Enter marks of the three subjects");
            for(int i=0; i<arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            try
            {
                foreach(int c in arr)
                {
                    if(c < 0)
                    {
                        throw new FormatException("The number is not an positive value");
                    }

                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("the vlaues in range");
            }
            catch(FormatException)
            {
                Console.WriteLine("Enter integer numbers");
            }
            finally
            {
                Console.WriteLine("Grade calculation complete");
            }
        }
    }
}
