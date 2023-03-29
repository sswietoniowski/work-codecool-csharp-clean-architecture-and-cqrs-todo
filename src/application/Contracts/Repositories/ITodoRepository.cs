using TodoApp.Core;

namespace TodoApp.Application.Contracts.Repositories;

public interface ITodoRepository
{
    Task<Todo> CreateTodoAsync(Todo todo);
    Task<Todo?> GetTodoAsync(int id);
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<Todo?> UpdateTodoAsync(int id, Todo todo);
    Task<bool> DeleteTodoAsync(int id);
}