namespace bookish.Models.Database
{
    public class AuthorBookDbModel
    {
        public int? Id { get; set; }
        public int AuthorId { get; set; }

        public int Isbn { get; set; }
    }
}