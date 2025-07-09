using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class Question3
    {
        static void Main()
        {
            string filePath = @"C:\Infinite_training\Csharp\Code_Challenges\CodeChallenge3\CodeChallenge3\Sample.txt"; 
            Console.Write("Enter the text you want to append to the file: ");
            string userInput = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(userInput);
                }

                Console.WriteLine($"\nText successfully appended to '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.Read();
        }
    }
}
