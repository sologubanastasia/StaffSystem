namespace StaffSystem.Domain.Entities;

public class Employee
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

    public Department Department { get; set; } = new Department();
    public Position Position { get; set; } = new Position();
    public Company Company { get; set; } = new Company();
}