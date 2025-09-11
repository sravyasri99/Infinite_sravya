using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IFurnitureFactory vintagefactory = new VintageFurnitureFactory();

            IChair vintagechair = vintagefactory.CreateChair();
            vintagechair.SitOn();

            ISofa vintagesofa = vintagefactory.CreateSofa();
            vintagesofa.LayOn();

            IFurnitureFactory moderenfactory = new ModerenFurnitureFactory();

            IChair moderenchair = moderenfactory.CreateChair();
            moderenchair.SitOn();

            ISofa moderensofa = moderenfactory.CreateSofa();
            moderensofa.LayOn();

            Console.Read();
        }
    }
}
