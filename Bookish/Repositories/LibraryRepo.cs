using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;
namespace bookish.Repositories
{
    public class LibraryRepo
    {

        private BookishContext _context = new BookishContext();

        public List<LibraryDbModel> GetAllBookCopies()
        {
            return _context.Library.Include(b => b.Book).ToList();
        }
    }
}