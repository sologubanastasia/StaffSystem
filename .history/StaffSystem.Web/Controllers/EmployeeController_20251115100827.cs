namespace StaffSystem.Web.Controllers;
using StaffSystem.Application.Services;
using StaffSystem.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
public class EmployeeController : Controller
{
    private IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index(string? department, string? position, string? name)
    {
        ViewBag.CurrentDepartment = department;
        ViewBag.CurrentPosition = position;
        ViewBag.CurrentName = name;

        var employees = _service.GetFiltered(department, position, name);

        return View(employees);
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var employee = _service.GetById(id);

        if(employee is null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EmployeeDto dto)
    {
        if(!ModelState.IsValid)
        {
            return View(dto);
        }

        _service.Update(dto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }
        
        var employee = _service.GetById(id);
        return View(employee);
    }

    [HttpGet]
    [ActionName("Export")]
    public IActionResult Export(string? filterType, string? filterValue) // Приймаємо універсальні фільтри
    {
        // 1. Ініціалізація параметрів для сервісу
        string? department = null;
        string? position = null;
        string? name = null;

        // 2. Мапування параметрів фільтрації з URL
        if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(filterValue))
        {
            switch (filterType)
            {
                case "Department":
                    department = filterValue;
                    break;
                case "Position":
                    position = filterValue;
                    break;
                case "Name":
                    name = filterValue;
                    break;
            }
        }
        
        // 3. Отримання відфільтрованих даних
        var employees = _service.GetFiltered(department, position, name);

        var stream = new MemoryStream();

        // 4. Експорт у потік
        _service.ExportToTxt(employees, stream);

        // 5. Скидаємо позицію для коректного читання
        stream.Seek(0, SeekOrigin.Begin);

        // 6. Повернення файлу
        return File(stream, MediaTypeNames.Text.Plain, $"salary_report_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
    }
}