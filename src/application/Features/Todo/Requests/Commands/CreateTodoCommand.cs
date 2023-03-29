using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todo.Requests.Commands;

public record CreateTodoCommand(TodoForCreationDto TodoForCreation) : IRequest<TodoDto>
{
}