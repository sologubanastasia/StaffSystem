namespace StaffSystem.Domain.Entities;

public class Position
{
    [Key]
    public Guid PositionId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? PositionName { get; set; }
}