namespace StaffSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
public class Position
{
    [Key]
    public Guid PositionId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? PositionName { get; set; }
}