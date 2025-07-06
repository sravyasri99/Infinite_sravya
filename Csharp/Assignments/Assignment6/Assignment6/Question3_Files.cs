using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Question3_Files
    {
        static void Main()
        {
            string filePath = @"C:\Infinite_training\Csharp\Assignments\Assignment6\Assignment6\TestFile.txt";
            
            if(File.Exists(filePath))
            {
                int Count = 0;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (reader.ReadLine() != null)
                    {
                        Count++;
                    }
                }
                Console.WriteLine($"The number of lines in the file is: {Count}");
            }
            else
            {
                Console.WriteLine("File does not exist at the specified path.");
            }
            Console.Read();
        }
    }
}
