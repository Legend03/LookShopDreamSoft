using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IDepartmentsService
    {
        Task<IEnumerable<Departments?>> GetDepartments();
        Task<Departments?> GetById(int departmentId);
        Task Create(Departments department);
        Task Update(Departments department);
        Task Remove(int departmentId);
    }

    public class DepartmentsService : IDepartmentsService
    {
        private readonly AppDbContext _db;

        public DepartmentsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Departments?>> GetDepartments() =>
            await _db.Departments.ToListAsync();

        public async Task<Departments?> GetById(int departmentId) =>
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

        public async Task Remove(int departmentId)
        {
            _db.Departments.Remove(new Departments { Id = departmentId });
            await _db.SaveChangesAsync();
        }
    }
}