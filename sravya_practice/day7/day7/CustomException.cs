using System;

namespace day7
{
    class CustomException
    {
        public static void Withdraw(int amount)
        {
            if(amount < 50000)
            {
                Console.WriteLine("ok");
            }
            else
            {
                throw new DailyLimitExceededException("The daily limit was exceeded");
            }
        }

        static void Main()
        {
            try
            {
                Withdraw(60000);
            }

            catch(DailyLimitExceededException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
