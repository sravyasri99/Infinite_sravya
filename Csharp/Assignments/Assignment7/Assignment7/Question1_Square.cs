﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Question1_Square
    {
        static void Main()
        {
            Console.WriteLine("Enter how many numbers you want to test:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("Enter any three numbers:");
            for(int i=0; i<numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            var result = from i in numbers
                         let square = i * i
                         where square > 20
                         select new { Number = i, Square = square };
            Console.WriteLine("=========OUTPUT========");
            foreach (var item in result)
            {
                Console.Write($"{item.Number} -> {item.Square}, ");
            }
            Console.Read();

        }
    }
}
