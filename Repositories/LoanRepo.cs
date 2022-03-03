using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;
namespace bookish.Repositories
{
    public class LoanRepo
    {

        private BookishContext _context = new BookishContext();

        public List<LoanDbModel> GetAllLoans()
        {
            return _context.Loans.Include(l => l.Member).ToList();
        }
    }
}