using AutoMapper;

using MediatR;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Requests.Queries;
using TodoApp.Core;

namespace TodoApp.Application.Features.Todos.Handlers.Queries;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoDto>>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetTodosAsync();

        return _mapper.Map<IEnumerable<Todo>, IEnumerable<TodoDto>>(todos);
    }
}