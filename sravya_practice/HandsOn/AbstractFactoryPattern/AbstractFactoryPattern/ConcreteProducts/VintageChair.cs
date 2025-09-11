using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class VintageChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("It is an Vintage Chair");
        }
    }
}
