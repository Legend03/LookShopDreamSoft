using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModel.Department;

namespace WebApplication3.Services
{
    public interface IDepartmentsService
    {
        Task<IEnumerable<DepartmentViewModel?>> GetDepartments();
        Task<Departments?> GetById(int? departmentId);
        Task Create(Departments department);
        Task Update(Departments department);
        Task Delete(int departmentId);
    }

    public class DepartmentsService : IDepartmentsService
    {
        private readonly AppDbContext _db;

        public DepartmentsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DepartmentViewModel?>> GetDepartments() =>
            await _db.Departments.Include(b => b.Branch)
                .Select(d => new DepartmentViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Location = d.Location,
                    BranchName = d.Branch.Name,
                    ParentDepartmentName = d.ParentDepartment.Name
                }).ToListAsync();

        public async Task<Departments?> GetById(int? departmentId) =>
            await _db.Departments.AsNoTracking().FirstOrDefaultAsync(u => u.Id == departmentId);


        public async Task Create(Departments department)
        {
            await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Departments department)
        {
            _db.Departments.Update(department);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int departmentId)
        {
            _db.Departments.Remove(new Departments { Id = departmentId });
            await _db.SaveChangesAsync();
        }
    }
}