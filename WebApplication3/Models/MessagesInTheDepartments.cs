namespace WebApplication3.Models
{
    public class MessagesInTheDepartments
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string? Message { get; set; }
        public DateTime Time { get; set; }
        public bool? Status { get; set; }

        public Employees? Sender { get; set; }
    }
}
