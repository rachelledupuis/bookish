using bookish.Models;
using bookish.Repositories;

namespace bookish.Services
{
    public class LoanService
    {
        private LoanRepo _loans = new LoanRepo();

        private MemberRepo _members = new MemberRepo();

        public List<Loan> GetAllLoans()
        {
            var loans = new List<Loan>();
            var dbLoans = _loans.GetAllLoans();

            foreach (var loan in dbLoans)
            {
                loans.Add(
                    new Loan{
                        Id = loan.Id,
                        MemberId = loan.Member.Id,
                        BookId = loan.BookId,
                        DueDate = loan.DueDate,
                        IsReturned = loan.IsReturned
                    }
                );
            }
            return loans;
        }
    }
}