using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace bookish.Repositories
{
    public interface IBookRepo
    {
        public List<BookDbModel> GetAllBooks();
    }

    public class BookRepo : IBookRepo
    {
        private BookishContext context = new BookishContext();
        public List<BookDbModel> GetAllBooks()
        {
            return context.Books.Include(b => b.Author).ToList();
            {
                
            };
        }
    }
}