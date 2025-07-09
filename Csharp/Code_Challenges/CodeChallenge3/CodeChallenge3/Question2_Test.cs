using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class Box
    {
        public int length;
        public int breadth;

        public static Box operator +(Box box1, Box box2)
        {
            Box temp = new Box();
            temp.length = box1.length + box2.length;
            temp.breadth = box1.breadth + box2.breadth;
            return temp;
        }
    }
    class Question2_Test
    {
        static void Main()
        {
            Box b1 = new Box();
            Console.WriteLine("Enter the Length of the Box1:");
            b1.length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Breadth of the Box1:");
            b1.breadth = Convert.ToInt32(Console.ReadLine()); 

            Box b2 = new Box();
            Console.WriteLine("\nEnter the Length of the Box2:");
            b2.length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Breadth of the Box2:");
            b2.breadth = Convert.ToInt32(Console.ReadLine());

            Box b3 = b1 + b2;
            Console.WriteLine($"\nThe overall Length is : {b3.length} and breadth is : {b3.breadth}, of the Box Object 3");
            Console.Read();
        }
    }
}
