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