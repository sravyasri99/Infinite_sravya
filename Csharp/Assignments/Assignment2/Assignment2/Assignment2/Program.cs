using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Swap_Two_Numbers();
            //Number_Display();
            //Day_Of_Number();
            //Arrays_Programs.Array_avg_max_min();
            //Arrays_Programs.Array_Marks_Functions();
            //Arrays_Programs.Copy_Array();
            //strings_programs.Length_of_String();
            //strings_programs.Revesr_of_String();
            strings_programs.Strings_same_or_not();
            Console.Read();
        }
        public static void Swap_Two_Numbers()
        {
            Console.WriteLine("Enter the 1st number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before Swaping the numbers are {0} and {1}", num1, num2);
            //(num1, num2) = (num2, num1);
            //Console.WriteLine("After Swaping the numbers are {0} and {1}", num1, num2);
            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("After Swaping the numbers are {0} and {1}", num1, num2);
        }

        public static void Number_Display()
        {
            Console.WriteLine("Enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            repeat(num);
            Console.WriteLine();
            repeat(num);
            void repeat(int number)
            {
                Console.WriteLine("{0} {0} {0} {0}",number);
                Console.WriteLine("{0}{0}{0}{0}", number);
            }
        }

        public static void Day_Of_Number()
        {
            Console.WriteLine("Enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            switch(number)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
            }
        }
    }

    class Arrays_Programs
    {
        public static void  Array_avg_max_min()
        {
            int[] arr = new int[5];
            int sum = 0;
            float average;
            Console.WriteLine("Enter the elements of the array");
            for(int i=0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int min_array = arr[0];
            int max_array = arr[0];
            foreach(int j in arr)
            {
                sum += j;
                if (j < min_array)
                {
                    min_array = j;
                }
                        
            }
            foreach(int k in arr)
            {
                if (k > max_array)
                {
                    max_array = k;
                }
            }
            average =(float) sum / arr.Length;
            Console.WriteLine("Average values of array elements are: {0}", average);
            Console.WriteLine("Minimum and Maximum values of an array are: {0} and {1}", min_array, max_array);
        }
        public static void Array_Marks_Functions()
        {
            int[] arr = new int[5];
            int total = 0;
            float average;
            Console.WriteLine("Enter the elements of the array");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int min_array = arr[0];
            int max_array = arr[0];
            foreach (int j in arr)
            {
                total += j;
                if (j < min_array)
                {
                    min_array = j;
                }

            }
            foreach (int k in arr)
            {
                if (k > max_array)
                {
                    max_array = k;
                }
            }
            average = (float)total / arr.Length;
            Console.WriteLine("The sum of all elements in array are :{0}", total);
            Console.WriteLine("Average values of array elements are: {0}", average);
            Console.WriteLine("Minimum and Maximum values of an array are: {0} and {1}", min_array, max_array);
            Console.WriteLine("The ascending order of the array elements are:");
            Array.Sort(arr);
            foreach(int c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The decending order of the array elements are:");
            Array.Reverse(arr);
            foreach (int k in arr)
            {
                Console.Write(k + " ");
            }
        }

        public  static void Copy_Array()
        {
            int[] arr = new int[5];
            int[] copy_arr = new int[5];
            Console.WriteLine("Enter the elements of the array");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Before copying");
            foreach(int c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            Console.WriteLine("After copying");
            for (int i = 0; i < arr.Length; i++)
            {
                copy_arr[i] = arr[i];
            }
            foreach (int c in arr)
            {
                    Console.Write(c + " ");
            }
         
        }
    }

    class strings_programs
    {
        public static void Length_of_String()
        {
            Console.WriteLine("Enter any word");
            string str = Console.ReadLine();
            Console.WriteLine("The length of word is {0}", str.Length);
        }
        public static void Revesr_of_String()
        {
            Console.WriteLine("Enter any word");
            string str = Console.ReadLine();
            char[] word = str.ToCharArray();
            Array.Reverse(word);
            string reversed = new string(word);
            Console.WriteLine("The reverse of word is {0}", reversed);
        }
        public static void Strings_same_or_not()
        {
            Console.WriteLine("Enter 1st string");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter 2nd string");
            string str2 = Console.ReadLine();
            if(str1 == str2)
            {
                Console.WriteLine("The two strings are same");
            }
            else
            {
                Console.WriteLine("The two strings are  not same");
            }
        }
    }
}
