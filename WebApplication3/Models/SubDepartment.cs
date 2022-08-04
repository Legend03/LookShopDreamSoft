namespace WebApplication3.Models
{
    public class SubDepartment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public int ParentDepartmentId { get; set; }
        public Departments ParentDepartment { get; set; }
    }
}
