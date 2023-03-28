using AutoMapper;

using TodoApp.Api.DataAccess;
using TodoApp.Api.Dtos;

namespace TodoApp.Api.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public TodoService(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto> CreateTodoAsync(TodoForCreationDto todoForCreation)
    {
        var todo = _mapper.Map<TodoForCreationDto, Todo>(todoForCreation);

        await _todoRepository.CreateTodoAsync(todo);

        return _mapper.Map<Todo, TodoDto>(todo);
    }

    public async Task<TodoDto?> GetTodoAsync(int id)
    {
        var todo = await _todoRepository.GetTodoAsync(id);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<Todo, TodoDto>(todo);
    }

    public async Task<IEnumerable<TodoDto>> GetTodosAsync()
    {
        var todos = await _todoRepository.GetTodosAsync();

        return _mapper.Map<IEnumerable<Todo>, IEnumerable<TodoDto>>(todos);
    }

    public async Task<TodoDto?> UpdateTodoAsync(int id, TodoForUpdateDto todoForUpdate)
    {

        var todoToBeUpdated = _mapper.Map<Todo>(todoForUpdate);
        
        var todo = await _todoRepository.UpdateTodoAsync(id, todoToBeUpdated);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<Todo, TodoDto>(todo);
    }

    public async Task<bool> DeleteTodoAsync(int id) =>
        await _todoRepository.DeleteTodoAsync(id);
}