using MediatR;

using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Requests.Commands;
using TodoApp.Application.Features.Todos.Requests.Queries;

namespace TodoApp.Api;

public static class WebApplicationUseMinimalApiEndpointsExtensions
{
    public static void UseMinimalApiEndpoints(this WebApplication app)
    {
        app.MapGet("/api/todos", async (IMediator mediator) =>
        {
            var query = new GetTodosQuery();
            var todosDto = await mediator.Send(query);

            return Results.Ok(todosDto);
        })
            .WithName("GetTodos")
            .Produces<IEnumerable<TodoDto>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapGet("api/todos/{id:int}", async (IMediator Mediator, int id) =>
            {
                var query = new GetTodoByIdQuery(id);
                var todoDto = await Mediator.Send(query);

                return Results.Ok(todoDto);
            })
            .WithName("GetTodo")
            .Produces<TodoDto>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPost("/api/todos", async (IMediator mediator, TodoForCreationDto todoForCreationDto) =>
        {
            var command = new CreateTodoCommand(todoForCreationDto);
            var todoDto = await mediator.Send(command);

            return Results.Created($"/api/todos/{todoDto.Id}", todoDto);
        })
            .WithName("CreateTodo")
            .Produces<TodoDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPut("api/todos/{id:int}", async (IMediator Mediator, int id, TodoForUpdateDto todoForUpdateDto) =>
        {
            var command = new UpdateTodoCommand(id, todoForUpdateDto);
            var todoDto = await Mediator.Send(command);

            if (todoDto is null)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        })
            .WithName("UpdateTodo")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapDelete("api/todos/{id:int}", async (IMediator Mediator, int id) =>
            {
                var command = new DeleteTodoCommand(id);
                var wasDeleted = await Mediator.Send(command);

                if (!wasDeleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteTodo")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
