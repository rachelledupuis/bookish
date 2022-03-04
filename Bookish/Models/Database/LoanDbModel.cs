namespace bookish.Models.Database
{
    public class LoanDbModel
    {
        public int Id { get; set; }

        public MemberDbModel? Member { get; set; }

        public string? BookId { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }
    }
}