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
    public IActionResult SalaryReport(string? department)
    {
        ViewBag.CurrentDepartment = department;
        ViewBag.SearchAttempted = !string.IsNullOrWhiteSpace(department); 

        var employees = _service.GetFiltered(department, position: null, name: null);
        
        if (!ViewBag.SearchAttempted)
        {
            return View(new List<StaffSystem.Infrastructure.DTO>());
        }
        
        return View(employees);
    }
}
