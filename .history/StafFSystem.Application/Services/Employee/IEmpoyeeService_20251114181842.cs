namespace StaffSystem.Application.Services.Employee;
using StaffSystem.Domain.Entities;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetFiltered(string? departent, string? position, string? name);
    EmployeeDto? GetById(Guid id);
    void Update(Employee employee);
    void ExportToTxt(IEnumerable<EmployeeDto> employees, Stream outputStream);
}