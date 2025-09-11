using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Implementors
{
    class Platinum : ICreditCard
    {
        public float GetAnnualChargee()
        {
            return 2000.0f;
        }

        public int GetCardLimit()
        {
            return 30000;
        }

        public string GetCardType()
        {
            return "Platinum Plus";
        }
    }
}
