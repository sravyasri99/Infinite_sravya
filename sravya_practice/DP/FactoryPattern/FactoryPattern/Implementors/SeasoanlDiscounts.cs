using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Abstractions;

namespace FactoryPattern.Implementors
{
    public class SeasoanlDiscounts : IDiscounts
    {
        public double GetPrice(int Price)
        {
            return 0.90 * Price;
        }
    }
}
