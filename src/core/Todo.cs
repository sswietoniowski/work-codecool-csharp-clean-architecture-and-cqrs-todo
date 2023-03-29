using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace TodoApp.Core;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this).ToString();
    }
}