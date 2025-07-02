using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"The Book Name is: {BookName}, The Author Name is: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Books[] booksArray = new Books[5];

        public Books this[int index]
        {
            get { return booksArray[index];}
            set { booksArray[index] = value; }
        }
    }
    class IndexersProgram
    {
        public static void Main()
        {
            BookShelf shelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter Book Name for book {i + 1}: ");
                string bookName = Console.ReadLine();

                Console.Write($"Enter Author Name for book {i + 1}: ");
                string authorName = Console.ReadLine();

                shelf[i] = new Books(bookName, authorName);
            }
            Console.WriteLine();
            Console.WriteLine("The Total Books in the shelf are:");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
            Console.Read();
        }
    }
}
