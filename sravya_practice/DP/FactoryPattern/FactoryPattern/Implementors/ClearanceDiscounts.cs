using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Abstractions;

namespace FactoryPattern.Implementors
{
    public class ClearanceDiscounts : IDiscounts
    {
        public double GetPrice(int Price)
        {
            return 0.70 * Price;
        }
    }
}
