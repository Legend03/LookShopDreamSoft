using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ListOfEmployees()
    {
        return View(await _employeesService.GetAll());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Employees());
    }

    [HttpPost]
    public IActionResult Create(Employees employees)
    {
        _employeesService.Create(employees);
        return RedirectToAction("ListOfEmployees");
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<IActionResult> Update(int employeeId)
    {
        return View(await _employeesService.GetById(employeeId));
    }

    [HttpPost]
    public IActionResult Update(Employees employee)
    {
        if (!_employeesService.Update(employee).IsFaulted) return RedirectToAction("ListOfEmployees");
        ModelState.AddModelError("", "Нет такого отдела!");
        return View(employee);
    }

    public IActionResult Delete(int employeeId)
    {
        _employeesService.Delete(employeeId);
        return RedirectToAction("ListOfEmployees");
    }
}