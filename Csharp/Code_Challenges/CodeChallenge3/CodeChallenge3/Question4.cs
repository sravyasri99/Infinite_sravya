using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class Calculator
    {
        
        public delegate int Operation(int a, int b);
        
        public static int Functionality(Operation op, int x, int y)
        {
            return op(x, y);
        }
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
    }
    class Question4
    {
        static void Main()
        {
            
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n=======The Final Results are========");
            Console.WriteLine($"Addition: {Calculator.Functionality(Calculator.Add, num1, num2)}");
            Console.WriteLine($"Subtraction: {Calculator.Functionality(Calculator.Subtract, num1, num2)}");
            Console.WriteLine($"Multiplication: {Calculator.Functionality(Calculator.Multiply, num1, num2)}");
            Console.Read();
        }
    }
}
