using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
     abstract class Shapes
    {
        public string  Prop1 { get; set; }

        public abstract float Perimeter { get; set; }
        //declar an abstract method
        public abstract int Area();

        public void DrawShape() // non abst method
        {
            Console.WriteLine("Dreawing a shape..");
        }

        public virtual void ShapeType()
        {
            Console.WriteLine("This is base type shape");
        }
    }

    class Square : Shapes
    {
        int side = 0;

        //constructor
        public Square(int n)
        {
            side = n;
        }
        public override int Area()
        {
            return side * side;
        }

        public new void DrawShape()
        {
            Console.WriteLine("Drawing a square shape");
        }

        public override void ShapeType()
        {
            base.ShapeType();
            Console.WriteLine("this is subtype square shape");
        }

        public override float Perimeter { get; set; }
    }
    class AbstractClassEg
    {
        static void Main()
        {
            Shapes shape = new Square(5);
            Console.WriteLine("Area of square = " + shape.Area());//at run time it will point to square class
            shape.DrawShape();
            shape.ShapeType();
            Console.WriteLine("-----With Sub Type Object-------");
            Square s = new Square(10);
            Console.WriteLine(s.Area());
            s.DrawShape();

            Console.Read();
        }
    }
}
