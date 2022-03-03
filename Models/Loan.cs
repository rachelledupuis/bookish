namespace bookish.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public string? BookId { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }
    }
}