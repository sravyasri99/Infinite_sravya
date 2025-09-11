using System;


namespace day7
{
    class Operators
    {
        static void Main(string[] args)
        {
            int a = 36, b = 3;

            Console.WriteLine("-----------------Arithmetic Operators-----------");
            Console.WriteLine($" a + b = {a + b} ");
            Console.WriteLine($" a - b = {a - b} ");
            Console.WriteLine($" a * b = {a * b} ");
            Console.WriteLine($" a / b = {a / b} ");
            Console.WriteLine($" a % b = {a % b} ");

            Console.WriteLine("-----------------Relational Operators-----------");
            Console.WriteLine($" a > b = {a > b}");
            Console.WriteLine($" a >= b = {a >= b}");

            Console.WriteLine("-----------------Logical Operators-----------");
            bool x = true, y = false;

            Console.WriteLine($" x && y = {x && y}");
            Console.WriteLine($" x || y = {x || y}");
            Console.WriteLine($" !x = {!x}");

            Console.WriteLine("----------------Assignment operators----------");
            int num = 5;
            num += 3;
            Console.WriteLine($"+=3,num:{ num}");
            num -= 3;
            Console.WriteLine($"-=3,num:{ num}");





        }
    }
}
