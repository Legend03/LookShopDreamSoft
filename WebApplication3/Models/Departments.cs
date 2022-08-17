using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Departments
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название отдела!")]
        [Display(Name = "Название отдела")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Не указан адрес отдела!")]
        [Display(Name = "Адрес отдела")]
        public string? Location { get; set; }
        [Required(ErrorMessage = "Не указан Id филиала!")]
        [Display(Name = "Id филиала")]
        public int? BranchId { get; set; }
        public Branches? Branch { get; set; }
        public ICollection<Employees>? Employees { get; set; }
        [Display(Name = "Родительский отдел")]
        public int? ParentDepartmentId { get; set; }
        public Departments? ParentDepartment { get; set; }
    }
}
