using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Employees model)
    {
        if (ModelState.IsValid)
        {
            var employee = await _context.Employees
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Mail == model.Mail && u.Password == model.Password);
            var customer = await _context.Customers
                .FirstOrDefaultAsync(u => u.Mail == model.Mail && u.Password == model.Password);
            if (employee != null)
            {
                await Authenticate(employee);

                return RedirectToAction("Index", "Employees");
            }
            else if(customer != null)
            {
                await Authenticate(customer);

                return RedirectToAction("Index", "Customers");
            }
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }
        return View(model);
    }

    private async Task Authenticate(Employees employees)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, employees.Mail!),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, employees.Role!.Name!)
        };
        
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    private async Task Authenticate(Customers employees)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, employees.Mail!),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, "Customer")
        };

        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}