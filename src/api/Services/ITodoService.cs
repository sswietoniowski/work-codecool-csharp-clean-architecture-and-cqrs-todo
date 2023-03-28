using Todo.Api.Dtos;

namespace Todo.Api.Services;

public interface ITodoService
{
    Task<TodoDto> CreateTodoAsync(TodoForCreationDto todoForCreation);
    Task<bool> DeleteTodoAsync(int id);
    Task<TodoDto?> GetTodoAsync(int id);
    Task<IEnumerable<TodoDto>> GetTodosAsync();
    Task<TodoDto?> UpdateTodoAsync(int id, TodoForUpdateDto todoForUpdate);
}