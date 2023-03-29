using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todo.Requests.Queries;

public record GetTodosQuery : IRequest<IEnumerable<TodoDto>>
{
}