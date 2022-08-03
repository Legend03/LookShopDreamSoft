namespace WebApplication3.Models
{
    public class Branches
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }

        public int MainOfficeId { get; set; }
    }
}
