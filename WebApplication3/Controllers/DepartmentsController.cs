using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        //[Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Index() =>
            View(await _departmentsService.GetDepartments());

        //[Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Details(int departmentId) =>
            View(await _departmentsService.GetById(departmentId));

        //[Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create() =>
            View(new Departments());

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Departments department)
        {
            if (department.ParentDepartmentId != null &&
                await _departmentsService.GetById(department.ParentDepartmentId) == null)
            {
                ModelState.AddModelError("ParentDepartmentId", "Нет такого отдела!");
                return View(department);
            }
            else
            {
                await _departmentsService.Create(department);
                return RedirectToAction("Index", "Departments");
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Departments department)
        {
            await _departmentsService.Delete(department.Id);
            return RedirectToAction("Index", "Departments");
        }

        //[Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int departmentId) =>
            View(await _departmentsService.GetById(departmentId));

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Departments department)
        {
            if (department.ParentDepartmentId != null &&
                await _departmentsService.GetById(department.ParentDepartmentId) == null)
            {
                ModelState.AddModelError("ParentDepartmentId", "Нет такого отдела!");
                return View(department);
            }
            else
            {
                await _departmentsService.Update(department);
                return RedirectToAction("Index", "Departments");
            }
        }
    }
}