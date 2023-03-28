using api.DataAccess;

namespace api.Tests;

internal class DummyTodoRepository : ITodoRepository
{
    private List<Todo> _todos = new List<Todo>()
    {
        new Todo { Id = 1, Title = "Todo 1", Description = "Todo 1 Description", IsCompleted = false },
        new Todo { Id = 2, Title = "Todo 2", Description = "Todo 2 Description", IsCompleted = true },
        new Todo { Id = 3, Title = "Todo 3", Description = "Todo 3 Description", IsCompleted = false },
    };

    public DummyTodoRepository()
    {

    }

    public Task<Todo> CreateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<Todo?> GetTodoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return Task.FromResult(_todos.AsEnumerable());
    }

    public Task<Todo?> UpdateTodoAsync(int id, Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTodoAsync(int id)
    {
        throw new NotImplementedException();
    }
}