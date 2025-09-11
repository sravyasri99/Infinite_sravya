using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class ModerenFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModerenChair();
        }

        public ISofa CreateSofa()
        {
            return new ModerenSofa();
        }
    }
}
