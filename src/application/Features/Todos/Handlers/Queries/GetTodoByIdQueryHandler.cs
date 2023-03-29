using AutoMapper;

using MediatR;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Requests.Queries;
using TodoApp.Core;

namespace TodoApp.Application.Features.Todos.Handlers.Queries;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodoByIdQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodoAsync(request.Id);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<Todo, TodoDto>(todo);
    }
}