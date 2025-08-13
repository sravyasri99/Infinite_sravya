using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MiniProject; 

namespace MiniPrjTesting
{
        [TestFixture]
        public class UserTests
        {
            [Test]
            public void Login_AsAdmin_WithCorrectPassword()
            {
                var input = new StringReader("admin1\nadmin123\n");
                Console.SetIn(input);

                var um = new UserManager();
                string role = um.LoginForTest("Admin");

                Assert.That(role, Is.EqualTo("Admin"));
            }

            [Test]
            public void Login_AsCustomer_WithCorrectId()
            {
                var input = new StringReader("cust1\n");
                Console.SetIn(input);

                var um = new UserManager();
                string role = um.LoginForTest("Customer");

                Assert.That(role, Is.EqualTo("Customer"));
            }

            [Test]
            public void Login_WithInvalidUser_ShouldReturnInvalid()
            {
                var input = new StringReader("unknownUser\n");
                Console.SetIn(input);

                var um = new UserManager();
                string role = um.LoginForTest("Customer");

                Assert.That(role, Is.EqualTo("Invalid"));
            }

            [Test]
            public void Login_AsAdmin_WithWrongPassword_ShouldReturnInvalid()
            {
                var input = new StringReader("admin1\nwrongpass\n");
                Console.SetIn(input);

                var um = new UserManager();
                string role = um.LoginForTest("Admin");

                Assert.That(role, Is.EqualTo("Invalid"));
            }

            [Test]
            public void Login_WithWrongRole_ShouldReturnInvalid()
            {
                var input = new StringReader("cust1\n");
                Console.SetIn(input);

                var um = new UserManager();
                string role = um.LoginForTest("Admin"); // Expecting Admin, but user is Customer

                Assert.That(role, Is.EqualTo("Invalid"));
            }
        }
    }
