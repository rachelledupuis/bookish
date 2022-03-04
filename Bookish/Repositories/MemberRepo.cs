using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace bookish.Repositories
{
    public class MemberRepo
    {

        private BookishContext _context = new BookishContext();
        public List<MemberDbModel> GetAllMembers()
        {
            return _context.Members.ToList();
        }
    }
}