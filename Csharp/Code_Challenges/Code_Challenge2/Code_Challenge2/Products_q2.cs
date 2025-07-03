using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge2
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
    class Products_q2
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Enter details for 10 products:");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Product {i + 1}:");

                Console.Write("Enter Product ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                products.Add(new Product { ProductId = id, ProductName = name, Price = price });
            }

            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));

            var sortedProducts = products;

            Console.WriteLine("\nThe Sorted Products are:");
           

            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"The Product ID: {p.ProductId}, Name: {p.ProductName}, Price: {p.Price}");
            }
            Console.Read();
        }
    }
}
