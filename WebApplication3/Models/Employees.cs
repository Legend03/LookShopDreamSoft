namespace WebApplication3.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }

        public int? DepartmentId { get; set; }
    }
}
