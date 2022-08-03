namespace WebApplication3.Models
{
    public class Departaments
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public int? BranchId { get; set; }
    }
}
