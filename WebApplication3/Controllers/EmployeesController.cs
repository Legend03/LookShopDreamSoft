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

    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<IActionResult> Detail(int userId)
    {
        return View(await _employeesService.GetById(userId));
    }
}