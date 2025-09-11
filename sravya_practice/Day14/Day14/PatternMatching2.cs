using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Shape
    {
        public const float PI = 3.14f;

    }
    public class Circle : Shape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    public class Rectangle : Shape
    {
        public double Length { get; }
        public double Breadth { get; }
        public Rectangle(double l, double b)
        {
            Length = l;
            Breadth = b;
        }
    }
    public class Triangle : Shape
    {
        public double Base { get; }
        public double Height { get; }
        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
   

    class PatternMatching2
    {
        //public static void DisplayArea(Shape shape)
        //{
        //    if(shape is Circle)
        //    {
        //        Circle c= (Circle)shape;
        //        Console.WriteLine("Area of Circle is :" + c.Radius * c.Radius * Shape.PI);
        //    }
        //}
        public static void DisplayArea(Shape shape)
        {
            switch(shape)
            {
                case Rectangle r when r.Length == r.Breadth:
                    Console.WriteLine("Area of square is : " + r.Length * r.Breadth);
                    break;
                case Circle c:
                    Console.WriteLine("Area of Circle is : " + c.Radius);
                    break;
            }
        }
        static void Main()
        {
            Circle circle = new Circle(4);
            DisplayArea(circle);
        }
    }
}
