using Microsoft.VisualBasic;

namespace ConsoleApp6
{
    //Class Book
    public class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public bool Availability;
        public Book(string _Title, string _Author, string _ISBN)
        {
            this.Title = _Title;
            this.Author = _Author;
            this.ISBN = _ISBN;
            this.Availability = true;
        }
    }
    //class library
    public class Library
    {
        List<Book> books = new List<Book>();

        //adding a book 
        public void Addbook(Book book)
        {
            books.Add(book);
        }
        //search for a book 
        public Book SearchBook(string searchTerm)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.Title == searchTerm)
                {
                    return book;
                }
            }
            return null;
        }
        //Borrowing a book
        public void BorrowBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null)
            {
                if (book.Availability)
                {
                    book.Availability = false;
                    Console.WriteLine($"You have borrowed {book.Title}");
                }
                else
                {
                    Console.WriteLine($"Sorry, {book.Title} is already borrowed");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, {title} is not available in the library");
            }
        }
        //Return book
        public void ReturnBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null)
            {
                if (!book.Availability)
                {
                    book.Availability = true;
                    Console.WriteLine($"You have returned {book.Title}");
                }
                else
                {
                    Console.WriteLine($"{book.Title} was not borrowed");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, {title} is not available in the library");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.Addbook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.Addbook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.Addbook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}

