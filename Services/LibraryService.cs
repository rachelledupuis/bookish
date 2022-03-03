using bookish;
using bookish.Models;
using bookish.Repositories;

namespace bookish.Services
{
    public class LibraryService
    {
        private BookRepo _books = new BookRepo();
        private AuthorRepo _authors = new AuthorRepo();
        private LibraryRepo _library = new LibraryRepo();

        public List<Library> GetAllBookCopies()
        {
            var library = new List<Library>();
            var dbLibrary = _library.GetAllBookCopies();
            foreach (var dbBookCopy in dbLibrary)
            {
                library.Add(
                    new Library{
                        Id = dbBookCopy.Id,
                        Isbn = dbBookCopy.Book.Isbn,
                        Title = dbBookCopy.Book.Title,
                        Author = dbBookCopy.Book.Author.Name,
                    }
                );
            }
            return library;
        }


    }
}