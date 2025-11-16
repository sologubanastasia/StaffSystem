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
        ViewBag.CurrentFilterType = filterType;
        ViewBag.CurrentFilterValue = filterValue;
        
        ViewBag.SearchAttempted = !string.IsNullOrEmpty(filterType) || !string.IsNullOrEmpty(filterValue);
        
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

        var employees = _service.GetFiltered(department, position, name);
        
        if (ViewBag.SearchAttempted == false && !Request.Query.ContainsKey("filterType"))
        {
            return View(new List<EmployeeDto>());
        }
        
        return View(employees);
    }
}