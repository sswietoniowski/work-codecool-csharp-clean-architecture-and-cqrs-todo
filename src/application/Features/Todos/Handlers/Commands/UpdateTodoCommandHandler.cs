using AutoMapper;

using MediatR;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Requests.Commands;
using TodoApp.Core;

namespace TodoApp.Application.Features.Todos.Handlers.Commands;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto?> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todoToBeUpdated = _mapper.Map<Todo>(request.TodoForUpdate);

        var todo = await _todoRepository.UpdateTodoAsync(request.Id, todoToBeUpdated);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<Todo, TodoDto>(todo);
    }
}