namespace StaffSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
public class Company
{
    [Key]
    public Guid CompanyId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? CompanyName { get; set; }
}