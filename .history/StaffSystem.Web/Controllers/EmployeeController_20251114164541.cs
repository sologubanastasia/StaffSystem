namespace StaffInfoSystem.StaffSystem.Web.Controllers;

public class EmployeeController
{
    private EmployeeService _service;

    public EmployeeController( EmployeeService service)
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
            return NotFound;
        }
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
    [ActionName("Export")]
    public IActionResult ExportToTxt(string? department, string? position, string? name)
    {
        var employees = _service.GetFiltered(department, position, name);

        using var stream = new MemoryStream();

        _service.ExportToTxt(employees, stream);

        stream.Seek(0, SeekOrigin.Begin);

        return  File(stream, MediaTypeNames.Text.Plain, $"salary_report_{DataTime.Now:yyyyMMdd_HHmmss}.txt")
    }
}