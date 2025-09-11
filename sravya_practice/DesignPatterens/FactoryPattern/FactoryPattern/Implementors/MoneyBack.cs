using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Implementors
{
    public class MoneyBack : ICreditCard
    {
        public float GetAnnualChargee()
        {
            return 500.0f;
        }
        public string GetCardType()
        {
            return "MoneyBack";
        }
        public int GetCardLimit()
        {
            return 200;
        }
    }
}
