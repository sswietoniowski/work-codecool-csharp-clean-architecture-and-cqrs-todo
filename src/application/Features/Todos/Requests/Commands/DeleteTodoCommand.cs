using MediatR;

namespace TodoApp.Application.Features.Todos.Requests.Commands;

public record DeleteTodoCommand(int Id) : IRequest<bool>
{
}