using System.ComponentModel.DataAnnotations;

namespace TaskApp.Dtos;

public class TaskDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsComplete { get; set; } = false;
}
