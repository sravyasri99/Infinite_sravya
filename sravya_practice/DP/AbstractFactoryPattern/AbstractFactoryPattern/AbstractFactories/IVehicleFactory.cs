using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    interface IVehicleFactory
    {
        //abstract products 1 and 2
        IBike CreateBike();
        ICar CreateCar();
    }
}
