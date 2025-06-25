using System;


namespace Assignment3
{
    class SaleDetails
    {
        public int SaleNO;
        public int ProductNo;
        public int Price;
        public DateTime Dateofsale;
        public int Quantity;
        public int TotalAmount;

        public SaleDetails(int saleno, int productno, int price, DateTime dateofsale, int quant)
        {
            SaleNO = saleno;
            ProductNo = productno;
            Price = price;
            Dateofsale = dateofsale;
            Quantity = quant;

        }
        public void  Sales(int Quantity, int Price )
        {
            TotalAmount = Quantity * Price;
        }

        public static void ShowData()
        {
            Console.WriteLine("The SaleNo of the product is: {0} ", SaleNO);
            Console.WriteLine("The Product number is: {0}", ProductNo);
            Console.WriteLine("The Price of the product is: {0}", Price);
            Console.WriteLine("The Date of Sale of the product is : {0}", Dateofsale);
            Console.WriteLine("The quantity of the product is: {0}", Quantity);
            Console.WriteLine("The total amount for the Product is: {0}", TotalAmount);

        }
    }
    class SaleProgram
    {
        SaleDetails saleDetails = new SaleDetails(2,6645,2000,Convert.ToDateTime("25/06/2025"),5);
        
        
    }
}
