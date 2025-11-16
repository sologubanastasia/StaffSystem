namespace StaffSystem.Infrastructure.Dto;

public class EmployeeDto
{
    public Guid EmployeeId { get; set;}
    public string? FirstName { get; set; }
    public string? LastName  { get; set; }
    public string? MiddleName { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }

    public Guid DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public Guid PositionId { get; set; } 
    public string? PositionName { get; set; }
    public Guid CompanyId { get; set; } 
    public string? CompanyName { get; set; }
}