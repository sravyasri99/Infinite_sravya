using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Question2_Files
    {
        static void Main()
        {
            string dirPath = @"C:\Infinite_training\Csharp\Assignments\Assignment6\Assignment6";
            DirectoryInfo dinfo = new DirectoryInfo(dirPath);

            if(dinfo.Exists)
            {
                dinfo.Create();
                Console.WriteLine("Directory created.");
            }
            else
            {
                Console.WriteLine("Directory already exists.");
            }
            string filePath = Path.Combine(dirPath, "TestFile.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            string[] infolines = new string[2];

            for(int i=0; i<infolines.Length; i++)
            {
                Console.WriteLine($"Enter the Line {i + 1}:");
                infolines[i] = Console.ReadLine();
            }

            using (StreamWriter writer = fileInfo.CreateText())
            {
                foreach (string line in infolines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("\nData entered successfully into the file.");
            Console.Read();
        }
    }
}
