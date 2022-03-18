using bookish;
using bookish.Models;
using bookish.Models.Database;
using bookish.Models.Request;
using bookish.Repositories;

namespace bookish.Services
{

    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public BookDbModel CreateBook(CreateBookRequest book);
        public void DeleteBook(int id);
    }
    public class BookService : IBookService
    {
        private IBookRepo _books;

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
        public BookDbModel CreateBook(CreateBookRequest book)
        {
            return _books.CreateBook(book);
        }
        public void DeleteBook(int id)
        {
            _books.DeleteBook(id);
        }
    }
}