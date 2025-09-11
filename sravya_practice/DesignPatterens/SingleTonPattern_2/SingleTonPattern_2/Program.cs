using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPattern_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UserSession.usobj.Initialize("SravyaSri", new[] { "Admin", "User" });

            Console.WriteLine(UserSession.usobj.UserName);

            UserSession.usobj.Clear();
        }
    }
}
