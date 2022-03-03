using bookish.Models.Database;

namespace bookish.Repositories
{
    public class LoanRepo
    {

        private BookishContext _context = new BookishContext();

        public List<LoanDbModel> GetAllLoans()
        {
            return _context.Loans.ToList();
        }
    }
}