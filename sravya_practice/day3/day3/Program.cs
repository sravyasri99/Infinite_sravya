using System;


namespace day3
{
    class ArraysEg
    {
        public static void SingleDimension()
        {
            int[] arr = new int[] { 2, 6, 55, 35, 88 };
            Console.WriteLine("single dimension array");
            Console.WriteLine(arr.Rank);
            foreach(int n in arr)
            {
                Console.WriteLine(n);
            }
        }
        public static void TwoDimension()
        {
            Console.WriteLine("Two dimension array");
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine(arr[1, 2]);
            Console.WriteLine(arr.Length + " " + arr.Rank);
            for(int i=0; i<2; i++)
            {
                for(int j=0;j<3;j++)
                {
                    Console.WriteLine(arr[i, j] + " ");

                }
                Console.WriteLine();
            }

        }
        public static void JaggedArrays()
        {
            Console.WriteLine("Jagged_Arrays");
            int[][] myjagg = new int[2][];
            myjagg[0] = new int[3];
            myjagg[1] = new int[2];
            myjagg[0][0] = 2;
            myjagg[0][1] = 1;
            myjagg[0][2] = 3;

            myjagg[1][0] = 4;
            myjagg[1][1] = 9;

            int[][] jagg2 =
            {
                new int[] {22,33,44},
                new int[] {66,77},
                new int[] {55,11}
            };
            Console.WriteLine(jagg2.Length);
            for(int i=0; i<jagg2.Length;i++)
            {
                Console.WriteLine("number of elements in the row of " + i + "are" + jagg2[i].Length);
                for(int j=0;j<jagg2[i].Length;j++)
                {
                    Console.Write(jagg2[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArraysEg.SingleDimension();
            ArraysEg.TwoDimension();
            ArraysEg.JaggedArrays();
            Console.Read();
        }
    }
}
