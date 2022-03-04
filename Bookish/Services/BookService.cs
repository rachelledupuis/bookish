using bookish;
using bookish.Models;
using bookish.Repositories;

namespace bookish.Services
{

    public interface IBookService
    {
        public List<Book> GetAllBooks();
    }
    public class BookService : IBookService
    {
        private IBookRepo _books;
        // private AuthorRepo _authors = new AuthorRepo();

        public BookService(IBookRepo books)
        {
            _books = books;
        }
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            var dbBooks = _books.GetAllBooks();
            foreach (var dbBook in dbBooks)
            {
                books.Add(
                    new Book{
                        Title = dbBook.Title,
                        YearPublished = dbBook.YearPublished,
                        Author = dbBook.Author.Name,
                        ImageUrl = dbBook.ImageUrl,
                        Blurb = dbBook.Blurb
                    }
                );
            }
            return books;
        }


    }
}