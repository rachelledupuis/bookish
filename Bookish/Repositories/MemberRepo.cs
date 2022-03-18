using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace bookish.Repositories
{
    public interface IMemberRepo
    {
        public List<MemberDbModel> GetAllMembers();
        public void CreateMember(MemberDbModel member);
        public void DeleteMember(int id);
    }
    public class MemberRepo : IMemberRepo
    {
        private BookishContext context = new BookishContext();
        public List<MemberDbModel> GetAllMembers()
        {
            return context.Members.ToList();
        }
        public void CreateMember(MemberDbModel member)
        {
            var newMemberEntry = context.Members.Add(member).Entity;
            context.SaveChanges();
        }
        public void DeleteMember(int id)
        {
            var member = context.Members.Single(member => member.Id == id);
            context.Members.Remove(member);
            context.SaveChanges();
        }
    }
}