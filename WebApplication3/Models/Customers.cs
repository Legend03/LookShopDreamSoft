namespace WebApplication3.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public int? Balance { get; set; }
        public string? Password { get; set; }

        public ICollection<Bugs>? Bubs { get; set; }
    }
}
