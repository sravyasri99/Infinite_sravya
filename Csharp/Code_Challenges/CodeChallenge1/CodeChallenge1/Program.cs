using System;


namespace CodeChallenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // program.Remove_Character();
            program.Exchange_Characters();
            //program.Largest();
        }

        public void Remove_Character()
        {
            Console.WriteLine("Enter any word/string");
            string word = Console.ReadLine();
            Console.WriteLine("Enter the position to remove:");
            int index = Convert.ToInt32(Console.ReadLine());
            string result = word.Substring(0, index) + word.Substring(index + 1);
            Console.WriteLine(result);
            Console.Read();
        }

        public void  Exchange_Characters()
        {
            Console.WriteLine("Enter the string");
            string word = Console.ReadLine();
            if(word.Length < 2)
            {
                Console.WriteLine(word);
            }
            else
            {
                Char first = word[0];
                Char last = word[word.Length - 1];
                Console.WriteLine( last + word.Substring( 1, word.Length -2 ) + first);
            }
            Console.Read();

        }

        public void Largest()
        {
            int[] arr = new int[3];
            Console.WriteLine("Enter three numbers");
            for(int i= 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int largest=arr[0];
            foreach(int k in arr)
            {
                if(k > largest)
                {
                    largest = k;
                }
            }
            Console.WriteLine("The largest is: {0}",largest);
            Console.Read();
        }

    }
}
