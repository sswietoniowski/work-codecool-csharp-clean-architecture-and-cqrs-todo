using AutoMapper;

using Todo.Api.DataAccess;
using Todo.Api.Dtos;

namespace Todo.Api.Services;

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
        var todo = _mapper.Map<TodoForCreationDto, DataAccess.Todo>(todoForCreation);

        await _todoRepository.CreateTodoAsync(todo);

        return _mapper.Map<DataAccess.Todo, TodoDto>(todo);
    }

    public async Task<TodoDto?> GetTodoAsync(int id)
    {
        var todo = await _todoRepository.GetTodoAsync(id);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<DataAccess.Todo, TodoDto>(todo);
    }

    public async Task<IEnumerable<TodoDto>> GetTodosAsync()
    {
        var todos = await _todoRepository.GetTodosAsync();

        return _mapper.Map<IEnumerable<DataAccess.Todo>, IEnumerable<TodoDto>>(todos);
    }

    public async Task<TodoDto?> UpdateTodoAsync(int id, TodoForUpdateDto todoForUpdate)
    {

        var todoToBeUpdated = _mapper.Map<DataAccess.Todo>(todoForUpdate);
        
        var todo = await _todoRepository.UpdateTodoAsync(id, todoToBeUpdated);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<DataAccess.Todo, TodoDto>(todo);
    }

    public async Task<bool> DeleteTodoAsync(int id) =>
        await _todoRepository.DeleteTodoAsync(id);
}