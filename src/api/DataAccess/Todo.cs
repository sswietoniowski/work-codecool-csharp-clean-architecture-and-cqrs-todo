using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Todo.Api.DataAccess;

public class Todo
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(128)]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    [Required]
    public bool IsCompleted { get; set; } = false;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this).ToString();
    }
}