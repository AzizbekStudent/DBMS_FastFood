using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            TempData["RepositoryName"] = _repository?.GetType()?.Name;

            var list = await _repository.GetAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            try
            {
                int id = await _repository.CreateAsync(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(emp);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            try
            {
                await _repository.UpdateAsync(emp);
                return RedirectToAction("Details", new { id = emp.employee_ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(emp);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var emp = await _repository.GetByIdAsync(id);
                await _repository.DeleteAsync(emp);
            }
            catch (Exception ex)
            {
                TempData["DeleteErrors"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
