using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todos.Requests.Commands;

public record UpdateTodoCommand(int Id, TodoForUpdateDto TodoForUpdate) : IRequest<TodoDto?>
{
}