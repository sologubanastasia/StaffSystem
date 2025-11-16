using StaffSystem.Infrastructure.Dto;

namespace StaffSystem.Application.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetFiltered(string? department, string? position, string? name);
    EmployeeDto? GetById(Guid id);
    void Update(EmployeeDto dto);
    void ExportToTxt(IEnumerable<EmployeeDto> employees, Stream outputStream);
}
