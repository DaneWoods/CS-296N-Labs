using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonSite.Models
{
    public class BookCollection
    {
        private static List<BookDetails> books = new List<BookDetails>();
        private static BookDetails b1 = new BookDetails();
        private static BookDetails b2 = new BookDetails();

        public static IEnumerable<BookDetails> Library
        {
            get
            {
                if (IsEmpty())
                {
                    Initialize();
                    books.Sort((title1, title2) => title1.Title.CompareTo(title2.Title));
                }
                return books;
            }
        }

       private static void Initialize()
       {
            b1.Title = "A Brief History of Time";
            b1.Author = "Stephen Hawking";
            b2.Title = "The Universe in a Nutshell";
            b2.Author = "Stephen Hawking";
            books.Add(b1);
            books.Add(b2);
       }

       private static bool IsEmpty()
       {
           bool empty;
           if (books.Count == 0)
           {
               empty = true;
               return empty;
           }
           else
           {
               empty = false;
               return empty;
           }
       }
    }
}
