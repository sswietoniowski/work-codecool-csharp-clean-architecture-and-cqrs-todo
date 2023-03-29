using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todos.Requests.Queries;

public record GetTodoByIdQuery(int Id) : IRequest<TodoDto?>
{
}