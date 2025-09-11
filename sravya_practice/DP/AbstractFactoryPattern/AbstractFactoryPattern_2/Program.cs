using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IAinaml animal = null;
            AnimalFactory animalfactory = null;
            string sound = null;

            Console.WriteLine("Enter the type of animal Land or Sea");
            string atype = Console.ReadLine();
            animalfactory = AnimalFactory.CreateAnimalFactory(atype);
            Console.WriteLine("Animal type choosen: " + animalfactory.GetType().)
             
        }
    }
}
