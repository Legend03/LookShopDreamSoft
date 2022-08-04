using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Branches> Branches { get; set; }
    public DbSet<Bugs> Bugs { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<MessagesBetweenDepartments> MessagesBetweenDepartment { get; set; }
    public DbSet<MessagesInTheDepartments> MessagesInTheDepartment { get; set; }
}