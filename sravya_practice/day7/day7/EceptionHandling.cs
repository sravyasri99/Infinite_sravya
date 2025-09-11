using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class EceptionHandling
    {
        static void Main()
        {
            int a = 10, b = 0;
            try
            {
                int result = a / b;
                Console.WriteLine(result);
                string[] books = { "odi", "test", "t20" };
                Console.WriteLine(books[3]);
            }

            catch(DivideByZeroException ex)
            {
                //Console.WriteLine(ex);
                // Console.WriteLine(ex.Message); // PRE DEFINED ERROR MESSAGE
                Console.WriteLine("the message block");
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //catch (Eception ex)
            //{
            //    Console.WriteLine("OOPS");
            //}

            finally
            {
                Console.WriteLine("Thank you !!");
            }

        }
    }
}
