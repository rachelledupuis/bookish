using bookish;
using bookish.Models;
using bookish.Repositories;

namespace bookish.Services
{
    public class BookService
    {
        private BookRepo _books = new BookRepo();
        private AuthorRepo _authors = new AuthorRepo();

        public List<Book> GetAllBooks()
        {
        var books = new List<Book>();
        var dbBooks = _books.GetAllBooks();
        var dbAuthors = _authors.GetAllAuthors();
        foreach (var dbBook in dbBooks)
        {
            var author = dbAuthors.Find(a => a.Id == dbBook.AuthorId);
            books.Add(
                new Book{
                    Title = dbBook.Title,
                    YearPublished = dbBook.YearPublished,
                    Author = author.Name,
                    ImageUrl = dbBook.ImageUrl,
                    Blurb = dbBook.Blurb
                }
            );
        }
        return books;
        }


    }
}