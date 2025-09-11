using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class ModerenSofa : ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("Its an Moderen Sofa");
        }
    }
}
