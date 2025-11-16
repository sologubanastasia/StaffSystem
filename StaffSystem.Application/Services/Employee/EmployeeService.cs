using StaffSystem.Infrastructure.Repositories;
using StaffSystem.Infrastructure.Dto;
using StaffSystem.Domain.Entities;
using System.IO;

namespace StaffSystem.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository; 

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<EmployeeDto> GetFiltered(string? department, string? position, string? name)
    {
        return _repository.GetAll(department, position, name).Select(e => new EmployeeDto
        {
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            MiddleName = e.MiddleName,
            Address = e.Address,
            Phone = e.Phone,
            BirthDate = e.BirthDate,
            HireDate = e.HireDate,
            Salary = e.Salary,
            
            DepartmentId = e.Department.DepartmentId,
            DepartmentName = e.Department.DepartmentName,
            PositionId = e.Position.PositionId,
            PositionName = e.Position.PositionName,
            CompanyId = e.Company.CompanyId,
            CompanyName = e.Company.CompanyName
        });
    }

    public EmployeeDto? GetById(Guid id)
    {
        var employee = _repository.GetById(id);
        
        if(employee is null) return null;

        return new EmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            MiddleName = employee.MiddleName,
            Address = employee.Address,
            Phone = employee.Phone,
            BirthDate = employee.BirthDate,
            HireDate = employee.HireDate,
            Salary = employee.Salary,
            
            DepartmentId = employee.Department.DepartmentId,
            DepartmentName = employee.Department.DepartmentName,
            PositionId = employee.Position.PositionId,
            PositionName = employee.Position.PositionName,
            CompanyId = employee.Company.CompanyId,
            CompanyName = employee.Company.CompanyName
        };
    }

    public void Update(EmployeeDto dto) 
    {
        var employee = new Employee
        {
            EmployeeId = dto.EmployeeId,
            FirstName = dto.FirstName,
            LastName = dto.LastName, 
            MiddleName = dto.MiddleName,
            Address = dto.Address,
            Phone = dto.Phone, 
            BirthDate = dto.BirthDate,
            HireDate = dto.HireDate,
            Salary = dto.Salary, 

            Department = new Department { DepartmentId = dto.DepartmentId },
            Position = new Position { PositionId = dto.PositionId },
            Company = new Company { CompanyId = dto.CompanyId }
        };
        
        _repository.Update(employee);
    }

    public void ExportToTxt(IEnumerable<EmployeeDto> employees, Stream outputStream)
    {
        using var writer = new StreamWriter(outputStream, leaveOpen: true); 
        
        writer.WriteLine("LastName;FirstName;MiddleName;Department;Position;Salary;Phone;Address;BirthDate;HireDate");

        foreach ( var e in employees )
        {
            writer.WriteLine(
                $"{e.LastName};{e.FirstName};{e.MiddleName};{e.DepartmentName};{e.PositionName};{e.Salary:F2};{e.Phone};{e.Address};{e.BirthDate:yyyy-MM-dd};{e.HireDate:yyyy-MM-dd}"
            );
        }
        writer.Flush();
    }
}