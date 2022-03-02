using bookish;
using bookish.Models;
using bookish.Repositories;

namespace bookish.Services
{
    public class BookService
    {
        private BookRepo _books = new BookRepo();

        public List<Book> GetAllBooks()
        {
        var books = new List<Book>();
        var dbBooks = _books.GetAllBooks();
        foreach (var dbBook in dbBooks)
        {
            books.Add(
                new Book{
                    Title = dbBook.Title,
                }
            );
        }
        return books;
        }


    }
}