namespace StaffSystem.Domain.Entities;

public class Department
{
    [Key]
    public Guid DepartmentId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? DepartmentName { get; set; } 
}