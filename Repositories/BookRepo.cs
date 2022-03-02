using bookish.Models.Database;

namespace bookish.Repositories
{
    public class BookRepo
    {
        public List<BookDbModel> GetAllBooks()
        {
            return new List<BookDbModel>
            {
                new BookDbModel
                {
                    Id = 1,
                    Isbn = "9781842323007",
                    Title = "A Town Like Alice"
                }
            };
        }
    }
}