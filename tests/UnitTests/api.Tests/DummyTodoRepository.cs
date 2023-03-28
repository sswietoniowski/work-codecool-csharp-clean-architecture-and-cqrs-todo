using Todo.Api.DataAccess;

namespace Todo.Api.Tests;

internal class DummyTodoRepository : ITodoRepository
{
    private List<DataAccess.Todo> _todos = new List<DataAccess.Todo>()
    {
        new DataAccess.Todo { Id = 1, Title = "Todo 1", Description = "Todo 1 Description", IsCompleted = false },
        new DataAccess.Todo { Id = 2, Title = "Todo 2", Description = "Todo 2 Description", IsCompleted = true },
        new DataAccess.Todo { Id = 3, Title = "Todo 3", Description = "Todo 3 Description", IsCompleted = false },
    };

    public DummyTodoRepository()
    {

    }

    public Task<DataAccess.Todo> CreateTodoAsync(DataAccess.Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Todo?> GetTodoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DataAccess.Todo>> GetTodosAsync()
    {
        return Task.FromResult(_todos.AsEnumerable());
    }

    public Task<DataAccess.Todo?> UpdateTodoAsync(int id, DataAccess.Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTodoAsync(int id)
    {
        throw new NotImplementedException();
    }
}