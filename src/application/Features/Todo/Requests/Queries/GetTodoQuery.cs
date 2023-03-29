using MediatR;

using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todo.Requests.Queries;

public record GetTodoQuery(int Id) : IRequest<TodoDto?>
{
}