﻿using System;
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
            //fetch the regular bikea nd car details
            IVehicleFactory regularfactory = new RegularVehicleFactory();

            IBike regularbike = regularfactory.CreateBike();
            regularbike.GetDetails();

            ICar regularcar = regularfactory.CreateCar();
            regularcar.GetDetails();

            //
            IVehicleFactory sportsfactory = new SportsVehicleFactory();

            IBike sportsbike = sportsfactory.CreateBike();
            sportsbike.GetDetails();

            ICar sportscar = sportsfactory.CreateCar();
            sportscar.GetDetails();

            Console.Read();

        }
    }
}
