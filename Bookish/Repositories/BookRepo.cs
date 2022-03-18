using bookish.Models.Database;
using bookish.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace bookish.Repositories
{
    public interface IBookRepo
    {
        public List<BookDbModel> GetAllBooks();
        public BookDbModel CreateBook(CreateBookRequest book);
        public void DeleteBook(int id);
    }

    public class BookRepo : IBookRepo
    {
        private BookishContext context = new BookishContext();
        public List<BookDbModel> GetAllBooks()
        {
            return context.Books.Include(b => b.Author).ToList();
        }
        public BookDbModel CreateBook(CreateBookRequest book)
        {
            var newBook = new BookDbModel{
                Isbn = book.Isbn,
                Title = book.Title,
                YearPublished = book.YearPublished,
                ImageUrl = book.ImageUrl,
                Blurb = book.Blurb
            };
            var newBookEntry = context.Books.Add(newBook).Entity;
            var author = context.Authors.Where(a => a.Id == book.AuthorId).Single();
            newBookEntry.Author = author;
            context.SaveChanges();

            return newBookEntry;
        }
        public void DeleteBook(int id)
        {
            var book = context.Books.Single(book => book.Id == id);
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}