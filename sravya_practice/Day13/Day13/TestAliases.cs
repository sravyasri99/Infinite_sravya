extern alias Lib1;
extern alias Lib2;
using System;
//using LibPrj1;
//using LibPrj2;



namespace Day13
{
    class TestAliases
    {
        
        static void Main()
        {
            //Lib1.LibPrj1.LibClass lc1 = new Lib1.LibPrj1.LibClass();
            //Lib2.LibPrj2.LibClass lc2 = new Lib2.LibPrj2.LibClass();

            //LibPrj1.LibClass lc = new LibPrj1.LibClass();
            //lc.Method1;

            Lib1.LibPrj1.LibClass._m2 = 5;
            Lib2.LibPrj2.LibClass._m1 = 10;
            Console.WriteLine(Lib1.LibPrj1.LibClass._m2 + Lib2.LibPrj2.LibClass._m1);



            Console.Read();
        }
    }
}
