using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Implementors
{
    class Titanium : ICreditCard
    {
        public float GetAnnualChargee()
        {
            return 1500.0f;
        }

        public int GetCardLimit()
        {
            return 25000;
        }

        public string GetCardType()
        {
            return "Titanium";
        }
    }
}
