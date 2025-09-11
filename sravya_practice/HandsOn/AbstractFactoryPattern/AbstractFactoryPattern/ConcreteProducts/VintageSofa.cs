using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class VintageSofa : ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("Its an Vintage Sofa");
        }
    }
}
