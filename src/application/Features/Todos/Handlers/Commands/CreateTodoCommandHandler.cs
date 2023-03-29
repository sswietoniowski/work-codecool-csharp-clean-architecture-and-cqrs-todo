using AutoMapper;

using MediatR;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Requests.Commands;
using TodoApp.Core;

namespace TodoApp.Application.Features.Todos.Handlers.Commands;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = _mapper.Map<TodoForCreationDto, Core.Todo>(request.TodoForCreation);

        await _todoRepository.CreateTodoAsync(todo);

        return _mapper.Map<Todo, TodoDto>(todo);

    }
}