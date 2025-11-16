namespace StaffSystem.Web.Controllers;
using StaffSystem.Application.Services;
using StaffSystem.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

public class ReportController : Controller
{
    private readonly IEmployeeService _service;

    public ReportController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult SalaryReport(string? filterType, string? filterValue)
    {
        // 1. Зберігаємо поточні значення для відображення у формі (ViewBag)
        ViewBag.CurrentFilterType = filterType;
        ViewBag.CurrentFilterValue = filterValue;
        
        // 2. Встановлюємо прапорець, що пошук відбувався, якщо є хоч один фільтр
        ViewBag.SearchAttempted = !string.IsNullOrEmpty(filterType) || !string.IsNullOrEmpty(filterValue);
        
        // 3. Ініціалізація параметрів для сервісу
        string? department = null;
        string? position = null;
        string? name = null;

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

        // 4. Отримуємо відфільтровані дані
        // Якщо фільтри не встановлені, GetFiltered поверне всіх працівників.
        var employees = _service.GetFiltered(department, position, name);
        
        // 5. Якщо фільтри не встановлені, але дія викликається вперше, показуємо пустий список, 
        // інакше показуємо результат фільтрації.
        if (ViewBag.SearchAttempted == false && !Request.Query.ContainsKey("filterType"))
        {
            return View(new List<EmployeeDto>());
        }
        
        return View(employees);
    }
}