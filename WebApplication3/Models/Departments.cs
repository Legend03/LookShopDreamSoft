namespace WebApplication3.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public int? BranchId { get; set; }
        public Branches? Branch { get; set; }
        public ICollection<Employees>? Employees { get; set; }
        public int? ParentDepartmentId { get; set; }
        public Departments? ParentDepartment { get; set; }
    }
}
