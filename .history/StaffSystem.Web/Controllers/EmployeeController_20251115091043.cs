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
        public IActionResult Export(string? filterType, string? filterValue)
        {
            // 1. Ініціалізація змінних для фільтрації
            string? department = null;
            string? position = null;
            string? name = null;

            // 2. Мапування параметрів фільтрації з View
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
                    // Інші типи фільтрів, якщо є
                }
            }

            // 3. Отримання відфільтрованих даних
            var employees = _service.GetFiltered(department, position, name);

            // 4. Експорт даних у потік пам'яті
            var stream = new MemoryStream();
            _service.ExportToTxt(employees, stream);
            stream.Position = 0; // Скидаємо позицію потоку на початок для читання

            // 5. Повернення файлу користувачеві
            var fileName = $"Звіт_заробітної_плати_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            
            // Повертаємо потік як файл. MIME-тип 'text/plain' для .txt
            return File(stream, "text/plain", fileName);
        }
}