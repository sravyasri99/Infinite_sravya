﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Implementors;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the type of card from the user
            string cardType = "MoneyBack";
            ICreditCard cardDetails = CreditCardFactory.GetCreditCard(cardType);

            //based on the card type we will create appropriate objects
            //if(cardType == "MoneyBack")
            //{
            //    cardDetails = new MoneyBack();
            //}
            //else if(cardType == "Platinum")
            //{
            //    cardDetails = new Platinum();
            //}
            //else if(cardType=="Titanium")
            //{
            //    cardDetails = new Titanium();
            //}
            if (cardDetails != null)
            {
                Console.WriteLine("Card type : " + cardDetails.GetCardType());
                Console.WriteLine("Credit Limit : " + cardDetails.GetCardLimit());
                Console.WriteLine("Annual Charges : " + cardDetails.GetAnnualChargee());

            }
            else
            {
                Console.WriteLine("Invalid card type");
            }
            Console.Read();

            
        }
    }
}
