using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookStore = new BookStore();

            while (true)
            {
                Console.WriteLine("\nSimple Book Store");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List Books");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddBook(bookStore);
                        break;
                    case "2":
                        ListBooks(bookStore);
                        break;
                    case "3":
                        SearchBooks(bookStore);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddBook(BookStore bookStore)
        {
            Console.Write("Enter book title: ");
            var title = Console.ReadLine();
            Console.Write("Enter book author: ");
            var author = Console.ReadLine();
            Console.Write("Enter book price: ");
            var price = decimal.Parse(Console.ReadLine());

            bookStore.AddBook(new Book(title, author, price));
            Console.WriteLine("Book added successfully.");
        }

        static void ListBooks(BookStore bookStore)
        {
            Console.WriteLine("\nAvailable Books:");
            foreach (var book in bookStore.GetBooks())
            {
                Console.WriteLine(book);
            }
        }

        static void SearchBooks(BookStore bookStore)
        {
            Console.Write("Enter book title to search: ");
            var title = Console.ReadLine();
            var foundBooks = bookStore.SearchBooks(title);

            if (foundBooks.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books found with the given title.");
            }
        }
    }

    class BookStore
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public IEnumerable<Book> SearchBooks(string title)
        {
            return _books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }
    }

    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public decimal Price { get; }

        public Book(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}, ${Price}";
        }
    }
}