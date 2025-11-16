using StaffSystem.Domain.Entities;

namespace StaffSystem.Infrastructure.Repositories.Employee;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll(string? department, string? position, string? name);
    Employee? GetById(Guid id);
    void Update(Employee employee);
}