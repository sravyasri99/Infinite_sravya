using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon_Caching
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleTonCache cache = SingleTonCache.GetINstance();

            //1. add some data to the cache
            Console.WriteLine("Adding Keys and Values to the cache----");
            Console.WriteLine($"Adding EID as Key to the cache : {cache.Add("ID1", 101)}");
            Console.WriteLine($"Adding EID as Key to the cache : {cache.Add("ID2", 102)}");
            Console.WriteLine($"Adding EID as Key to the cache : {cache.Add("ID3", 103)}");

            Console.WriteLine($"Adding EName as another key to the cache : {cache.Add("EName1", "Sowmya")}");
            Console.WriteLine($"Adding EName as another key to the cache : {cache.Add("EName2", "Sravya")}");
            Console.WriteLine($"Adding EName as another key to the cache : {cache.Add("EName3", "Sai Satya")}");


            Console.WriteLine("Fetching Data from the collection");
            Console.WriteLine($"Getting Employee ID from cache : {cache.Get("EID")}");
            Console.WriteLine($"Getting Employee Name from cache : {cache.Get("Ename1")}");

            //3.calling add or update
            Console.WriteLine($"Adding the existing key to check AddorUpdate() : {cache.AddOrUpdate("EID1", 101)}");

            ////remove a key
            Console.WriteLine("\nRemoving ket from cache");

            Console.WriteLine($"Removing ID 101 : {cache.Remove("EID2")}");
            Console.WriteLine($"Getting Employee ID from cache : {cache.Get("EID1")}");

            var allitems = cache.GetAll();
            foreach(var items in allitems)
            {
                Console.WriteLine($"key : {items.Key} and value : {items.Value}");
            }
            Console.Read();
           
        }
    }
}
