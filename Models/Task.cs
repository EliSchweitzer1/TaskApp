using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models;

public class TaskItem
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }
    public bool IsComplete { get; set; } = false;
}