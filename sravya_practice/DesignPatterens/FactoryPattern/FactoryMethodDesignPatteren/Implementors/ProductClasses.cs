using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPatteren.Implementors
{
    class ProductClasses
    {
    }

    public class MoneyBack : ICreditCardNew
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
    public class Platinum : ICreditCardNew
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
    public class Titanium : ICreditCardNew
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

