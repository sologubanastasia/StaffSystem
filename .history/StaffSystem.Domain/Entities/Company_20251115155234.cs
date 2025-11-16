namespace StaffSystem.Domain.Entities;

public class Company
{
    [Key]
    public Guid CompanyId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? CompanyName { get; set; }
}