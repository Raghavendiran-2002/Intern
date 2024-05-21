using UnderstandingLINQ.Model;

namespace UnderstandingLINQ
{
    internal class Program
    {
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
            }
        }
        void PrintTitleIdAndQuantity()
        {
            pubsContext context = new pubsContext();
          
            var books = context.Sales.GroupBy(s => s.TitleId, s => s, (titleId, sales) => new {TitleId = titleId,Sales = sales.ToList()}).ToList();
            foreach(var book in books)
            {
                Console.Write(book.TitleId);
                foreach(var qua in book.Sales)
                {
                    Console.WriteLine(" - " + qua.Qty);
                }
            }
        }
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintTitleIdAndQuantity();
        }
    }
}




