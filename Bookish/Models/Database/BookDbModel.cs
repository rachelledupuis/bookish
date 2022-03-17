namespace bookish.Models.Database
{
    public class BookDbModel
    {
        public int Id { get; set; }
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? Blurb { get; set; }
        public int? YearPublished { get; set; }
        public string? ImageUrl { get; set; }
        public AuthorDbModel? Author { get; set; }

        public BookDbModel() { }
    }
}