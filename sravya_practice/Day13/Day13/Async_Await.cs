using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    class Async_Await
    {
        static void Main()
        {
            addAsync();
            Console.Read();
        }

        async static Task addAsync()
        {
            try
            {
                int[] arr = new int[3];
                arr[6] = 10;
            }
            catch(Exception e)
            {
                await ExceptionOccurred();
                Console.WriteLine("Handled Error ..");
            }
            finally
            {
                await ReleasingResources();
                Console.WriteLine("Closing Application");
            }
        }
        async static Task ExceptionOccurred()
        {
            await Task.Delay(1000);

            Console.WriteLine("Arrau Exception Occured");
        }

        async static Task ReleasingResources()
        {
            Console.WriteLine("All Occupied resources Released");
        }
        

    }
}
