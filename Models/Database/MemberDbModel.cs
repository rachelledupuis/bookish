namespace bookish.Models.Database
{
    public class MemberDbModel
    {
        public int Id { get; set; }
        public string? Member { get; set; }

        public string? Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}