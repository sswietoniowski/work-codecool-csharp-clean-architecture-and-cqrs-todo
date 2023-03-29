using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todo.Requests.Commands;

public record UpdateTodoCommand(int Id, TodoForUpdateDto TodoForUpdate) : IRequest<TodoDto?>
{
}