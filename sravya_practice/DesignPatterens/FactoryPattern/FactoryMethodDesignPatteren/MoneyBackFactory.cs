using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethodDesignPatteren.Implementors;

namespace FactoryMethodDesignPatteren
{
    public class MoneyBackFactory : NewCreditCardFactory
    {
        protected override ICreditCardNew MakeProduct()
        {
            ICreditCardNew MCard = new MoneyBack();
            return MCard;
        }
    }
}
