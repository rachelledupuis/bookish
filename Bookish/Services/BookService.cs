using bookish;
using bookish.Models;
using bookish.Models.Database;
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
                        Title = dbBook?.Title,
                        YearPublished = dbBook?.YearPublished,
                        Author = new AuthorDbModel{
                            Name = dbBook?.Author?.Name
                            },
                        ImageUrl = dbBook?.ImageUrl,
                        Blurb = dbBook?.Blurb
                    }
                );
            }
            return books;
        }
        /* public BookDbModel CreateBook(BookDbModel createBook)
        {
            var newAuthor = new AuthorDbModel();

            if (createBook.Author != null)
            {
                newAuthor.Add(
                    new AuthorDbModel
                    {
                        Name = createBook.Author.Name,
                    }
                );
            }

            var newBook = _books.CreateBook(
                new BookDbModel
                {
                    Isbn = createBook.Isbn,
                    Title = createBook.Title,
                    ImageUrl = createBook.ImageUrl,
                    Blurb = createBook.Blurb,
                    Author = createBook.Author,
                    YearPublished = createBook.YearPublished,
                }
            );

            return new BookDbModel(newBook);
        } */
    }
}