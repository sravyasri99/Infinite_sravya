using System;


namespace day6
{
    class Products
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public string Name { get; set; }

        public DateTime MfgDate { get; private set; } = Convert.ToDateTime("");

        public void ShowProducts()
        {
            Console.WriteLine($"{Id}, {Name},{Price}.{MfgDate}");
        }
    }
    class ObjectInializerEg
    {
    }
}
