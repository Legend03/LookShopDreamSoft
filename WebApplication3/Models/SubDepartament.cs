namespace WebApplication3.Models
{
    public class SubDepartament
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public int ParentDepartmentId { get; set; }

    }
}
