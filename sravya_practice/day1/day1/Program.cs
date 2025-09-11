using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //fun();
            //Program pg = new Program();
            //pg.CheckGrade();
            //pg.CheckGradeSwitch();
            //Console.ReadLine();
            IterationStatements Iti = new IterationStatements();
            Iti.WhileLoop();
            Console.WriteLine("************************");
            Iti.DoWhile();
            Console.WriteLine("***************************");

            Console.Read();
        }
        public static void fun()
        {
            int ? ticketsonsale = null;
            int availabletickets;
            if (ticketsonsale == null)
            {
                availabletickets = 0;
            }
            else
                availabletickets = ticketsonsale.Value;
            Console.WriteLine($"HI{ticketsonsale} AND {availabletickets}");
        }
        public void CheckGrade()
        {
            char grade;
            Console.WriteLine("Enter grade");
            grade = Convert.ToChar(Console.ReadLine());
            if (grade == 'o')
                Console.WriteLine("outstanding");
            else if (grade == 'a')
                Console.WriteLine("verygood");
            else
                Console.WriteLine("NOT VALID");
        }
        public void CheckGradeSwitch()
        {
            char grade;
            Console.WriteLine("Enter grade");
            grade = Convert.ToChar(Console.ReadLine());
            switch (grade)
            {
                case 'a':
                case 'A':
                    Console.WriteLine("outstandind");
                    break;
                case 'b':
                case 'B':
                    Console.WriteLine("very good");
                    break;
                case 'o':
                case 'O':
                    Console.WriteLine("good");
                    break;
            }
        }
    }
    class IterationStatements
    {
        public void WhileLoop()
        {
            int i = 1;
            while(i<5)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        public void DoWhile()
        {
            int i = 1;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 5);
        }
        public void ForLoop()
        {
            int tot = 3;
            for(; i <= 5; i++)
            {
                tot += i;
            }
            Console.WriteLine($"total is{tot}");
        }
    }
}
