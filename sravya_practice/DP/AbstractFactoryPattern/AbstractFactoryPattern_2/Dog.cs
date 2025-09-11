using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern_2
{
    public class Dog : IAinaml
    {
        public string Speak()
        {
            return "bag bag";
        }
    }
    public class Cat : IAinaml
    {
        public string Speak()
        {
            return "Meow mewow";
        }
    }
    public class Shark : IAinaml
    {
        public string Speak()
        {
            return "not talk";
        }
    }
    public class Octopus : IAinaml
    {
        public string Speak()
        {
            return "not talk";
        }
    }
}
