namespace WebApplication3.Models
{
    public class Bugs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }

        public ICollection<Customers>? CustomerId { get; set; }
        public int DepartmentId { get; set; }
        public Departments? Department { get; set; }

    }
}
