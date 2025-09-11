using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    class Person
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void checkType(object obj)
        {
            switch(obj)
            {
                case Person p:
                    Console.WriteLine("obj is Person type:");
                    Console.WriteLine($"Nameof of the person : {p.Name}");
                    break;
                case int i:
                    Console.WriteLine("OBJ is some Integer");
                    Console.WriteLine($"value of int : {i}");
                    break;
                default:
                    Console.WriteLine("obj is some other type");
                    break;
            }
        }

        //public static string GetNumberSign(int n)
        //{
        //    //switch(n)
            //{
            //    case < 0:
            //            return "Negative Number";
            //    case 0:
            //        return "Number Zero";
            //    case >= 1:
            //        return "Positive Number";
            //}
            //return n switch
            //{
            //    < 0 => "Negative Number",
            //    0 => "Zero",
            //    >= 1 => "Positve Number"
            //};
        //}
        //public static void WriteStringLength(string str)
        //{
        //    if (str is null)
        //    {
        //        Console.WriteLine("It is a NUll string");
        //    }
        //    if (str is { Length: 0 })
        //    {
        //        Console.WriteLine("empty string");
        //        return;
        //    }
        //    if(str is { Length: 1})
        //    {
        //        Console.WriteLine("it is a string of length 1");
        //        return;
        //    }
        //    else
        //    {
        //        Console.WriteLine("string OF MORE THAN 1 LENGTH");
        //        return;
        //    }
        //}

        //positional pattern
        public struct CheckBooleanData
        {
            public bool Data1 { get; set; }
            public bool Data2 { get; set; }

            public void unWrap(out bool d1, out bool d2)
            {
                d1 = Data1;
                d2 = Data2;
            }
        }
        //positional pattern with logical  and and or
        //public static bool LogicalAnd(CheckBooleanData n1)
        //{
        //    //using switch expressions
        //    return n1 switch
        //    {
        //        (false,false) => false,
        //        (true,false) => false,
        //        (false,true) => false;
        //        (true,true) => true
        //     }
        //}
        //public static bool LogicalOR(CheckBooleanData n1)
        //{
        //    //using switch expressions
        //    switch(n1)
        //    {
        //        case (false, false) return false,
        //        case (true, false) return true,
        //        (false, true) return true;
        //        (true, true) return  true
        //    };
        //}
        static void Main(string[] args)
        {
            var Person = new Person { Name = "Sravya" };
            checkType(56);
            checkType(Person);
            checkType("Hi");

            //property pattern driver
            //WriteStringLength("CSharp");
            //WriteStringLength("");
            //WriteStringLength("A");

            
            Console.Read();
        }
    }
}
