using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethodDesignPatteren.Implementors;

namespace FactoryMethodDesignPatteren
{
    public class PlatinumFactory : NewCreditCardFactory
    {
        protected override ICreditCardNew MakeProduct()
        {
            ICreditCardNew PCard = new Platinum();
            return PCard;
        }
    }
}
