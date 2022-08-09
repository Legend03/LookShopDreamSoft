using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IEmployeesService
{
    Task<List<ViewModel.Employee>> GetAll();
    Task<Employees?> GetById(int employeeId);
    Task Create(Employees employee);
    Task Update(Employees employee);
    Task Delete(int employeeId);
}

public class EmployeesService : IEmployeesService
{
    private readonly AppDbContext _db;

    public EmployeesService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ViewModel.Employee>> GetAll() =>
        await _db.Employees
            .Join(_db.Departments, e => e.DepartmentId, d => d.Id, (e, d) => new ViewModel.Employee
            {
                Id = e.Id, 
                Name = e.Name,
                Surname = e.Surname,
                Patronymic = e.Patronymic,
                PhoneNumber = e.PhoneNumber,
                Mail = e.Mail,
                DepartmentName = d.Name
            }).ToListAsync();

    public async Task<Employees?> GetById(int employeeId) =>
        await _db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == employeeId);

    public async Task Create(Employees employee)
    {
        await _db.Employees.AddAsync(employee);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Employees employer)
    {
        _db.Employees.Update(employer);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int employeeId)
    {
        _db.Employees.Remove(new Employees() { Id = employeeId });
        await _db.SaveChangesAsync();
    }
}
