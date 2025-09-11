using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    interface IName
    {
        string Name { get; set; }  //decl of property 
    }

    class Employee : IName
    {
        public string Name { get; set; }
    }

    class Company : IName
    {
        // private string companyname { get; set; }  //class property
        private string companyname;
        public int _age { get; set; } = 21;

        public string Name
        {
            get { return companyname; }
            set { companyname = value; }
        }
    }
    class Interfaces_with_Properties
    {
    }
}
