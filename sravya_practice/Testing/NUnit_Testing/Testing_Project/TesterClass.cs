using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using NUnit_Testing;

namespace Testing_Project
{
    [TestFixture]
    public class TesterClass
    {
        Account acc;
        [SetUp]
        public void ArrangeData()
        {
            //arranage
            acc = new Account("12345");
        }
            
       [Test]
       public void TestDepositMethod()
       {
            
            //act
            acc.Deposit(1000);

            //assert
            ClassicAssert.AreEqual(1000, acc.checkBalance());
       }
        public void TestWithdraw() // non testable method
        {
            acc.Withdraw(50);
        }
        [Test]
        public void TestWithdrawal_ExceptionWhen_lessFunds()
        {
            ClassicAssert.Throws<Exception>(TestWithdraw);
        }


    }
}
