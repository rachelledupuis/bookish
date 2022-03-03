namespace bookish.Models.Database
{
    public class LibraryDbModel
    {
        public int Id { get; set; }
        public BookDbModel? Book { get; set; }
    }
}