namespace StaffSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
public class Employee
{
    [Key]
    public Guid EmployeeId { get; set;}

    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string? LastName  { get; set; }
    [Required]
    [MaxLength(100)]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Address { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }

    [Required]
    [Column(TypeName = "numeric(10, 2)")]
    public decimal Salary { get; set; }

    public Guid DepartmentId { get; set; } 
    public Department? Department { get; set; } 
    public Guid PositionId { get; set; } 
    public Position? Position { get; set; } 
    public Guid CompanyId { get; set; } 
    public Company? Company { get; set; } 
}