
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class Products
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class ProductFilter
    {
        public Expression<Func<Products, bool>> FilterCriteria { get; set; }

        static void Main()
        {
            var filter = new ProductFilter
            {
                FilterCriteria = p => p.Price < 100
            };

            var products = new List<Products>
            {
                new Products{Name= "Pens", Price = 50},
                new Products{Name= "Pencils", Price = 10},
                new Products{Name= "Memory Cards", Price = 550},
                new Products{Name= "USB", Price = 250},
            };

            var lesspricedproducts = products.AsQueryable().Where(filter.FilterCriteria).ToList();

            foreach (var item in lesspricedproducts)
            {
                Console.WriteLine($"Less Priced Products {item.Name} and its Price {item.Price}");
            }
            Console.WriteLine("------Few more Examples of Expression Trees------");
            Expr1();
            Console.WriteLine("********************");
            Expr2();
            Console.WriteLine("********************");
            Expr3();
            Console.Read();
        }

        static void Expr1()
        {
            Expression<Func<int, bool>> check = num => num < 10;
            Func<int, bool> expdel = check.Compile();

            Console.WriteLine(expdel(15));
            Console.WriteLine(expdel(5));
        }

        static void Expr2()
        {
            BinaryExpression be1 = Expression.Power(Expression.Constant(2d), Expression.Constant(3d));

            //lambda for the expression
            Expression<Func<double>> explambda = Expression.Lambda<Func<double>>(be1);

            //compile the lambda
            Func<double> expdel = explambda.Compile();

            double result = expdel();
            Console.WriteLine(" 2 raised to the power of 3 is {0}", result);

        }

        static void Expr3()
        {
            ParameterExpression baseParameter = Expression.Parameter(typeof(double), "basevalue");
            ParameterExpression exponentParameter = Expression.Parameter(typeof(double), "expovalue");

            BinaryExpression powerExpresion = Expression.Power(baseParameter, exponentParameter);

            Expression<Func<double, double, double>> lambda = Expression.Lambda<Func<double, double, double>>(powerExpresion, baseParameter, exponentParameter);

            Func<double, double, double> compiled = lambda.Compile();

            double result = compiled(2, 3);

            Console.WriteLine("2 raised to the power of 3 is {0}", result);

        }

        static void Exp4()
        {
            ParameterExpression n1 = Expression.Parameter(typeof(int), "n1");
            ParameterExpression n2 = Expression.Parameter(typeof(int), "n2");

            ParameterExpression[] parameters = new ParameterExpression[] { n1, n2 };

            BinaryExpression exprbody = Expression.Add(n1, n2);

            Expression<Func<int, int, int>> expr = Expression.Lambda<Func<int, int, int>>(exprbody, parameters);

            Func<int, int, int> compiledexpr = expr.Compile();

            int res = compiledexpr(10, 20);
            Console.WriteLine("Expression using API result in  {0}", res);


        }
    }
}
