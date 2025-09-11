using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethodDesignPatteren.Implementors;

namespace FactoryMethodDesignPatteren
{
    public class TitaniumFactory : NewCreditCardFactory
    {
        protected override ICreditCardNew MakeProduct()
        {
            ICreditCardNew TCard = new Titanium();
            return TCard;
        }
    }
}
