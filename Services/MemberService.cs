using bookish.Models;
using bookish.Repositories;

namespace bookish.Services
{
    public class MemberService
    {
        private MemberRepo _members = new MemberRepo();

        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();

            var dbMembers = _members.GetAllMembers();

            foreach(var member in dbMembers)
            {
                members.Add(
                    new Member{
                        Id = member.Id,
                        Name = member.Name,
                        BirthDate = member.BirthDate,
                        Email = member.Email
                    }
                );
            };

            return members;
        }
    }
}