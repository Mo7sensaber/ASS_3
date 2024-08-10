namespace ASS_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part1
            List<Book> bookList = new List<Book>()

            {
                new Book("123", "Book1", new string[] { "Author1", "Author2" }, DateTime.Now, 10.5m),
                new Book("456", "Book2", new string[] { "Author3" }, DateTime.Now.AddYears(-1), 15.0m)
            };

            LibraryEngine.ProcessBooks(bookList, new LibraryEngine.BookFunctionDelegate(BookFunctions.GetTitle));
            LibraryEngine.ProcessBooks(bookList, BookFunctions.GetAuthors);
            LibraryEngine.ProcessBooks(bookList, delegate (Book B)
            {
                return B.ISBN;
            });
            LibraryEngine.ProcessBooks(bookList, B => B.PublicationDate.ToShortDateString());

            #endregion
            #region part 2
            bool exists = bookList.Exists(b => b.Price > 12.0m);
            Console.WriteLine($"Exists (Price > 12.0): {exists}");

            Book found = bookList.Find(b => b.ISBN == "123");
            Console.WriteLine($"Find (ISBN == \"123\"): {found.Title}");

            List<Book> foundAll = bookList.FindAll(b => b.Authors.Length > 1);
            Console.WriteLine("FindAll (Authors.Length > 1): " + string.Join(", ", foundAll));

            int index = bookList.FindIndex(b => b.Title == "Book2");
            Console.WriteLine($"FindIndex (Title == \"Book2\"): {index}");

            Book lastFound = bookList.FindLast(b => b.PublicationDate.Year < DateTime.Now.Year);
            Console.WriteLine($"FindLast (PublicationDate.Year < Now.Year): {lastFound.Title}");

            int lastIndex = bookList.FindLastIndex(b => b.Price > 10);
            Console.WriteLine($"FindLastIndex (Price > 10): {lastIndex}");

            Console.WriteLine("ForEach (Print Titles):");
            bookList.ForEach(b => Console.WriteLine(b.Title));

            bool allPublishedThisYear = bookList.TrueForAll(b => b.PublicationDate.Year == DateTime.Now.Year);
            Console.WriteLine($"TrueForAll (Published This Year): {allPublishedThisYear}");

            #endregion   }
        }
    }
}