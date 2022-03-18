using bookish.Models;
using bookish.Models.Database;
using bookish.Repositories;

namespace bookish.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAllAuthors();
        public void CreateAuthor(AuthorDbModel author);
        public void DeleteAuthor(int id);
    }
    public class AuthorService : IAuthorService
    {
        private IAuthorRepo _authors;

        public AuthorService(IAuthorRepo authors)
        {
            _authors = authors;
        }
        public List<Author> GetAllAuthors()
        {
            var authors = new List<Author>();
            var dbAuthors = _authors.GetAllAuthors();
            foreach (var dbAuthor in dbAuthors)
            {
                authors.Add(
                    new Author{
                        Id = dbAuthor.Id,
                        Name = dbAuthor.Name,
                    }
                );
            }
            return authors;
        }
        public void CreateAuthor(AuthorDbModel author)
        {
            _authors.CreateAuthor(author);
        }
        public void DeleteAuthor(int id)
        {
            _authors.DeleteAuthor(id);
        }
    }
}