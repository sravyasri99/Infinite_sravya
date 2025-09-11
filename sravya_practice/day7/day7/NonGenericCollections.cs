using System;
using System.Collections;

namespace day7
{
    class NonGenericCollections
    {
        static void ArrayListProg()
        {
           // ArrayList al = new ArrayList();

        }

        static void HashtableDemo()
        {
            Hashtable ht = new Hashtable();

            ht.Add("Nithi", "A");
            ht.Add("sai", "B");
            foreach(DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
        static void Main()
        {

        }
    }
}
