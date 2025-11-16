namespace StaffSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
public class Department
{
    [Key]
    public Guid DepartmentId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? DepartmentName { get; set; } 
}