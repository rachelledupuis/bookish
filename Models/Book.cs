namespace bookish.Models
{
    public class Book
    {
        public string? Title { get; set; }

        public int YearPublished { get; set; }
        public string? Author { get; set; }

        public string? ImageUrl { get; set; }

        public string? Blurb { get; set; }
    }
}