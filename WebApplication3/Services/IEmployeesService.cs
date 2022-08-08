using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Services;

public interface IEmployeesService
{
    Task<List<ViewModel.Employee>> GetAll();
    Task<ViewModel.Employee?> GetById(int employeeId);
    Task Create(Employees employee);
    bool Update(Employee employee);
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

    public async Task<ViewModel.Employee?> GetById(int employeeId) =>
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
            })
            .FirstOrDefaultAsync(e => e.Id == employeeId);

    public async Task Create(Employees employee)
    {
        var countMail = await _db.Employees.Where(e => e.Mail == employee.Mail).ToListAsync();
        if (countMail.Count == 0)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }
        await _db.SaveChangesAsync();
    }

    public bool Update(Employee employee)
    {
        var department = _db.Departments.FirstOrDefaultAsync(d => d.Name == employee.DepartmentName);
        if(department.Result == null)
        {
            return false;
        }
        var temp = _db.Employees.Update(new Employees()
        {
            Id = employee.Id,
            Name = employee.Name,
            Surname = employee.Surname,
            Patronymic = employee.Patronymic,
            PhoneNumber = employee.PhoneNumber,
            Mail = employee.Mail,
            DepartmentId = department?.Result.Id
        });
        _db.SaveChanges();
        return true;
    }

    public async Task Delete(int employeeId)
    {
        _db.Employees.Remove(new Employees() { Id = employeeId });
        await _db.SaveChangesAsync();
    }
}
