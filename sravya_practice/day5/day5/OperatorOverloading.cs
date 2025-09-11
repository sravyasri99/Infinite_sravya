using System;

namespace day5
{
    class Box
    {
        public int length;
        public int breadth;

        //operator overloading


        public static Box operator +(Box box1, Box box2)
        {
            Box temp = new Box();
            temp.length = box1.length + box2.length;
            temp.breadth = box1.breadth + box2.breadth;
            return temp;
        }

        public static Box operator ++(Box bo1)
        {
            Box up = new Box();
            up.length = bo1.length + 1;
            up.breadth = bo1.breadth + 1;
            return up;
        }

        
    }
    class OperatorOverloading
    {
        static void Main()
        {
            Box b1 =  new Box();
            b1.length = 5;
            b1.breadth = 4;

            Box b2 = new Box();
            b2.length = 10;
            b2.breadth = 5;

            Box b3 = b1 + b2;
            Console.WriteLine($"The overall Length is {b3.length} and breadth is {b3.breadth}");
            b3++;
            Console.WriteLine($"the up is {b3.length}");
            Console.Read();
        }


    }
    
}
