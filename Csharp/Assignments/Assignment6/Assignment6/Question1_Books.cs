using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
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
            Console.WriteLine($"The Name of the Book is: {BookName}, The Author is: {AuthorName}");
        }
    }
    public class BookShelf
    {
        Books[] books = new Books[5];
        public Books this[int index]
        {
            get { return books[index];}
            set { books[index] = value; }
        }
    }
    
    class Question1_Books
    {
        static void Main()
        {
            BookShelf bookShelf = new BookShelf();
            for(int i=0; i<5; i++)
            {
                Console.WriteLine($"\nEnter the details of the Book {i + 1}: ");
                Console.WriteLine("Enter the Book Name: ");
                string bookName = Console.ReadLine();
                Console.WriteLine("Enter the Name of the Author: ");
                string authorName = Console.ReadLine();

                bookShelf[i] = new Books(bookName, authorName);
            }
            Console.WriteLine("\n The Total Books Are: ");
            for(int i=0; i<5; i++)
            {
                bookShelf[i].Display();
            }
            Console.Read();
        }
    }
}
