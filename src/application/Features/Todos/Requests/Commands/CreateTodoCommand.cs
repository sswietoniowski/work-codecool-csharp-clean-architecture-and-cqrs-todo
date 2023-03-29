using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todos.Requests.Commands;

public record CreateTodoCommand(TodoForCreationDto TodoForCreation) : IRequest<TodoDto>
{
}