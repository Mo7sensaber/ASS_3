using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_3
{
    public class LibraryEngine
    {
        public delegate string BookFunctionDelegate(Book B);
        public static void ProcessBooks(List<Book> BList, BookFunctionDelegate fPtr)
        {
            foreach (Book B in BList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
        public static void ProcessBooks(List<Book> BList, Func<Book, string> fPtr, string additionalParam = "")
        {
            foreach (Book B in BList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
