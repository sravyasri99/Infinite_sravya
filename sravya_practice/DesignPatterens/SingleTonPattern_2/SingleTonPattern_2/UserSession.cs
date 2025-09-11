using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPattern_2
{
    public class UserSession
    {
        private static readonly UserSession _userinstance = new UserSession();

        public string UserName { get; private set; }
        public string[] Roles { get; private set; }

        private UserSession() { }

        public void Initialize(string uname, string[] roles)
        {
            UserName = uname;
            Roles = roles;
        }

        public void Clear()
        {
            UserName = null;
            Roles = null;
        }

        public static UserSession usobj => _userinstance;
    }
}
