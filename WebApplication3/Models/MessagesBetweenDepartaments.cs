namespace WebApplication3.Models
{
    public class MessagesBetweenDepartaments
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string? Message { get; set; }
        public DateTime Time { get; set; }
        public string? Status { get; set; }
    }
}
