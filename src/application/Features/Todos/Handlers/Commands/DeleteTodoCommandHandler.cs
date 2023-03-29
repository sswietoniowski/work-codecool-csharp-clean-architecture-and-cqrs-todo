using AutoMapper;

using MediatR;

using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Features.Todos.Requests.Commands;

namespace TodoApp.Application.Features.Todos.Handlers.Commands;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken) =>
        await _todoRepository.DeleteTodoAsync(request.Id);
}