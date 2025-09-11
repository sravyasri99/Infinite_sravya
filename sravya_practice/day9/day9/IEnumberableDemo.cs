using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day9
{
    class MyCollection
    {
        public static IEnumerable<int> GetEvenNumber(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }
    }
    class IEnumberableDemo
    {
        static void Main()
        {
            IEnumerable<int> nums = new List<int> { 1, 2, 4, 5, 8, 90, 67 };

            IEnumerable<int> evennum = MyCollection.GetEvenNumber(nums);

            foreach (int n in evennum)
            {
                Console.WriteLine($"EvenNumber:{n}");
            }

            IList<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Orange");
            fruits.Add("grapes");
            fruits.Remove("Orange");
            Console.Read();
        }
    }
}
