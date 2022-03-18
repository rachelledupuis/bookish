using bookish.Models;
using bookish.Models.Database;
using bookish.Repositories;

namespace bookish.Services
{
    public interface IMemberService
    {
        public List<Member> GetAllMembers();
        public void CreateMember(MemberDbModel member);
        public void DeleteMember(int id);
    }
    public class MemberService : IMemberService
    {
        private IMemberRepo _members;
        public MemberService(IMemberRepo members)
        {
            _members = members;
        }

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
        public void CreateMember(MemberDbModel member)
        {
            _members.CreateMember(member);
        }
        public void DeleteMember(int id)
        {
            _members.DeleteMember(id);
        }
    }
}