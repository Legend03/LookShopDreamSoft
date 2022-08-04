namespace WebApplication3.Models
{
    public class MessagesBetweenDepartments
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string? Message { get; set; }
        public DateTime Time { get; set; }
        public bool? Status { get; set; }

        //public Employees? Sender { get; set; }
        //public Employees? Recipient { get; set; }
    }
}
