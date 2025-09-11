using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DI_Unity.ConcreteModules;

namespace DI_Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer uc = new UnityContainer();

            uc.RegisterType<IProducts, DataLayer>();
            uc.RegisterType<IOrders, OrderClass>();

            //invoking the DI enabled methods
            BusinessLayer.BusinessLogic bl = uc.Resolve<BusinessLayer.BusinessLogic>();

            bl.Insert();
            Console.Read();
        }
    }
}
