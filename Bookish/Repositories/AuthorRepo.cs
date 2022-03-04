using bookish.Models.Database;

namespace bookish.Repositories
{
        public interface IAuthorRepo
        {
            public List<AuthorDbModel> GetAllAuthors();
        }
    public class AuthorRepo : IAuthorRepo
    {


        public List<AuthorDbModel> GetAllAuthors()
        {
            return new List<AuthorDbModel>
            {
                new AuthorDbModel
                {
                    Id = 1,
                    Name = "Neville Shute"
                },
                new AuthorDbModel
                {
                    Id = 2,
                    Name = "F. Scott Fitzgerald"
                }
            };
        }
    }
}