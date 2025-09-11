using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_2
{
    class PersonDescription
    {
        public string Firstname, Lastname;

        public PersonDescription(String f, string l)
        {
            this.Firstname = f;
            this.Lastname = l;
        }
    }

    class Person
    {
        public int Age;
        public PersonDescription desc; //composition

        public Person(int a, string fn, string ln)
        {
            Age = a;
            desc = new PersonDescription(fn, ln);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person pcopy = new Person(this.Age, desc.Firstname, desc.Lastname);
            return pcopy;
        }
    }
    class DeepvsShallow
    {
        static void Main()
        {
            Person p1 = new Person(21, "Sravya", "Ommi");
            Person p2 = (Person)p1.ShallowCopy();

        }
    }
}
