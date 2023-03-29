using MediatR;

namespace TodoApp.Application.Features.Todo.Requests.Commands;

public record DeleteTodoCommand(int Id) : IRequest<bool>
{
}