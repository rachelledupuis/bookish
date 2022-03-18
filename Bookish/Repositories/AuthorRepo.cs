using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace bookish.Repositories
{
    public interface IAuthorRepo
    {
        public List<AuthorDbModel> GetAllAuthors();
        public void CreateAuthor(AuthorDbModel author);
        public void DeleteAuthor(int id);
    }
    public class AuthorRepo : IAuthorRepo
    {

        private BookishContext context = new BookishContext();
        public List<AuthorDbModel> GetAllAuthors()
        {
            return context.Authors.ToList();
        }
        public void CreateAuthor(AuthorDbModel author)
        {
            var newAuthorEntry = context.Authors.Add(author).Entity;
            context.SaveChanges();
        }
        public void DeleteAuthor(int id)
        {
            var author = context.Authors.Single(author => author.Id == id);
            context.Authors.Remove(author);
            context.SaveChanges();
        }
    }
}