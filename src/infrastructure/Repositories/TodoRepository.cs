using AutoMapper;

using Microsoft.EntityFrameworkCore;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Core;

namespace TodoApp.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly BaseTodoContext _todoContext;

    public TodoRepository(BaseTodoContext todoContext, IMapper mapper)
    {
        _todoContext = todoContext;
    }

    public async Task<Todo> CreateTodoAsync(Todo todo)
    {
        await _todoContext.Todos.AddAsync(todo);
        await _todoContext.SaveChangesAsync();
        return todo;
    }

    public async Task<Todo?> GetTodoAsync(int id)
    {
        var todo = await _todoContext.Todos.FindAsync(id);

        if (todo == null)
        {
            return null;
        }

        return todo;
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync() =>
        await _todoContext.Todos.ToListAsync();

    public async Task<Todo?> UpdateTodoAsync(int id, Todo todo)
    {
        var todoToBeUpdated = await _todoContext.Todos.FindAsync(id);

        if (todoToBeUpdated is null)
        {
            return null;
        }

        todoToBeUpdated.Title = todo.Title;
        todoToBeUpdated.Description = todo.Description;
        todoToBeUpdated.IsCompleted = todo.IsCompleted;

        await _todoContext.SaveChangesAsync();

        return todoToBeUpdated;
    }

    public async Task<bool> DeleteTodoAsync(int id)
    {
        var todo = await _todoContext.Todos.FindAsync(id);

        if (todo == null)
        {
            return false;
        }

        _todoContext.Todos.Remove(todo);
        await _todoContext.SaveChangesAsync();

        return true;
    }
}