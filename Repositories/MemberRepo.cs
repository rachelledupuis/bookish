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
            // return new List<MemberDbModel>
            // {
                // new MemberDbModel
                // {
                //     Id = 1,
                //     Name = "Rachelle Dupuis",
                //     Email = "rachelle.dupois@softwire.com",
                //     BirthDate = new DateTime(1993,1,1)
                // },
                // new MemberDbModel
                // {
                //     Id = 2,
                //     Name = "Sam James",
                //     Email = "sam.james@softwire.com",
                //     BirthDate = new DateTime(1991,1,1)
                // }
            // };
        }
    }
}