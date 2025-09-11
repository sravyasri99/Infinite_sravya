using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPatteren
{
    public abstract class NewCreditCardFactory
    {
        protected abstract ICreditCardNew MakeProduct();
        public ICreditCardNew CreateProduct()
        {
            //call the MakeProduct which will create and return the appropriate product
            ICreditCardNew creditCard = this.MakeProduct();
            return creditCard;
        }
    }
}
