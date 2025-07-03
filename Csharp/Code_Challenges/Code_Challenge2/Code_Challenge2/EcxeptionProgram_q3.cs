using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge2
{
    public class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException(string message) : base(message)
        {
        }
    }
    class EcxeptionProgram_q3
    {
        static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberException("Number cannot be negative.");
            }
            Console.WriteLine("The Entered Number is valid: " + number);
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                int input = Convert.ToInt32(Console.ReadLine());

                CheckNumber(input);
            }
            catch (NegativeNumberException exc)
            {
                Console.WriteLine($"Exception: { exc.Message}");
            }
            Console.Read();
        }
    }
}
