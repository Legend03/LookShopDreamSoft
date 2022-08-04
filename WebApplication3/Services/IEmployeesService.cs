using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IEmployeesService
{
    Task<IEnumerable<Employees>> GetAll();
    Task<Employees?> GetById(int userId);
}

public class EmployeesService : IEmployeesService
{
    private readonly AppDbContext _db;

    public EmployeesService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Employees>> GetAll() => 
        await _db.Employees
            .Include(u => u.Role)
            .ToListAsync();

    public async Task<Employees?> GetById(int employeeId) =>
        await _db.Employees
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == employeeId);
}
