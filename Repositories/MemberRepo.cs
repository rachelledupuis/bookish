using bookish.Models.Database;

namespace bookish.Repositories
{
    public class MemberRepo
    {
        public List<MemberDbModel> GetAllMembers()
        {
            return new List<MemberDbModel>
            {
                new MemberDbModel
                {
                    Id = 1,
                    Name = "Rachelle Dupuis",
                    Email = "rachelle.dupois@softwire.com",
                    BirthDate = new DateTime(1993,1,1)
                },
                new MemberDbModel
                {
                    Id = 2,
                    Name = "Sam James",
                    Email = "sam.james@softwire.com",
                    BirthDate = new DateTime(1991,1,1)
                }
            };
        }
    }
}