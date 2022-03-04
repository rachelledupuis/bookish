using bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace bookish.Repositories
{
    public interface IBookRepo
    {
        public List<BookDbModel> GetAllBooks();
    }

    public class BookRepo : IBookRepo
    {
        private BookishContext _context = new BookishContext();
        public List<BookDbModel> GetAllBooks()
        {
            return _context.Books.Include(b => b.Author).ToList();
            {
                /* new BookDbModel
                {
                    Id = 1,
                    Isbn = "9781842323007",
                    Title = "A Town Like Alice",
                    Blurb = "A Town Like Alice (United States title: The Legacy) is a romance novel by Nevil Shute, published in 1950 when Shute had newly settled in Australia.",
                    YearPublished = 1950,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f9/TownLikeAlice.jpg",
                    AuthorId = 1
                },
                new BookDbModel
                {
                    Id = 2,
                    Isbn = "9780743273565",
                    Title = "Great Gatsby",
                    Blurb = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.",
                    YearPublished = 1925,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/The_Great_Gatsby_Cover_1925_Retouched.jpg/440px-The_Great_Gatsby_Cover_1925_Retouched.jpg",
                    AuthorId = 2
                } */
            };
        }
    }
}