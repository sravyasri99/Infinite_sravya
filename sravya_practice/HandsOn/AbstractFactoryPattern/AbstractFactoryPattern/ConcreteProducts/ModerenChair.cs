using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class ModerenChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Its an Moderen Chair");
        }
    }
}
