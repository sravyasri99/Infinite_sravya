using System;


namespace day5
{
    class shape
    {
        protected float R, L, B;

        public virtual float Area()
        {
            return 3.14f * R * R;
        }

        public virtual float Circumference()
        {
            return 2 * 3.14f * R;
        }
    }

    class Rectangle : shape
    {
        public void GetLB()
        {
            Console.WriteLine("Enter the length:");
            L = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the breadth:");
            B = float.Parse(Console.ReadLine());
        }

        public override float Area()
        {
            return L * B;
        }

        public override float Circumference()
        {
            return 2 * (L + B);
        }
    }

    class Circle : shape
    {
        public void GetRadius()
        {
            Console.WriteLine("Enter radius:");
            R = float.Parse(Console.ReadLine());
        }

        public override float Area()
        {
            return 11.45f;
        }
    }
    class OverridingEg
    {
        static void Main()
        {
            //Rectangle rectangle = new Rectangle();
            //Console.WriteLine("the area of rectangle is: {0}", rectangle.Area());
            //Console.WriteLine("the circumference of the rectangle is: {0}", rectangle.Circumference());
            //Console.Read();
            //Circle circle = new Circle();

            shape shap = new shape();
            Console.WriteLine(shap.Area());
            Console.WriteLine(shap.Circumference());

            shap = new Rectangle(); //co variance
            Console.WriteLine(shap.Area());
            Console.WriteLine(shap.Circumference());
            Console.Read();

            shap = new Circle();
            Console.WriteLine(shap.Area());
            Console.WriteLine(shap.Circumference());
            Console.Read();
        }
    }
}
