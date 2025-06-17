using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            //pg.Integers_Equal_Or_Not();
            //pg.Num_Positive_Or_Negative();
            //pg.Operations();
            //pg.Multiplication_Table();
            pg.Integer_Sum_Or_TrippleSum();
        }
        public void Integers_Equal_Or_Not()
        {
            Console.WriteLine("Enter 1st a number");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number");
            int j = Convert.ToInt32(Console.ReadLine());
            if (i == j)
            {
                Console.WriteLine($"{i} and {j} are equal");
            }
            else
                Console.WriteLine($"{i} and {j} are not equal");
            Console.Read();
        }
        public void Num_Positive_Or_Negative()
        {
            Console.WriteLine("Enter any number");
            int num = Convert.ToInt32(Console.ReadLine());
            if ( num > 0)
            {
                Console.WriteLine($"{num} is a Positive number");
            }
            else
            {
                Console.WriteLine($"{num} is a negative number");
            }
            Console.Read();
        }
        public void Operations()
        {
            Console.WriteLine("Enter 1st number");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operation to be performed");
            string operation = Console.ReadLine();
            Console.WriteLine("Enter 2nd number");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int result;
            switch(operation)
            {
                case "+":
                    result = number1 + number2;
                    Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    break;
                case "-":
                    result = number1 - number2;
                    Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    break;
                case "*":
                    result = number1 * number2;
                    Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    break;
                case "/":
                    result = number1 / number2;
                    Console.WriteLine($"{number1} {operation} {number2} = {result}");
                    break;
            }
            Console.ReadLine();
        }
        public void Multiplication_Table()
        {
            Console.WriteLine("Enter a numner");
            int number = Convert.ToInt32(Console.ReadLine());
            int result;
            for( int i = 0; i<=10; i++)
            {
                result = number * i;
                Console.WriteLine($"{number} * {i} = {result}");
            }
            Console.ReadLine();
        }
        public  void Integer_Sum_Or_TrippleSum()
        {
            Console.WriteLine("Enter 1st number");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int result = fun(number1,number2);
            Console.WriteLine($"the result is {result}");
            Console.ReadLine();
            int fun(int num1, int num2)
            {
                if (number1 != number2)
                {
                    return number1 + number2;
                }
                else
                {
                    return 3 * (number1 + number2);
                }
            }
            
        }
    }
}
