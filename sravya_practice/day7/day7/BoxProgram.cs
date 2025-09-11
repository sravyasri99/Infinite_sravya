using System;

namespace day7
{
    class Box
    {
        public int length;
        public static Box operator +(Box b1, Box b2)
        {
            Box temp = new Box();
            temp.length = b1.length + b2.length;
            return temp;
        }
    }
    class BoxProgram
    {
        static void Main()
        {
            Box b1 = new Box();
            b1.length = 3;
            Box b2 = new Box();
            b2.length = 4;

            Box b3 = b1 + b2;
            Console.WriteLine("The overall length of two boxes is: {0} ",b3.length);
            Console.Read();
        }
    }
}
