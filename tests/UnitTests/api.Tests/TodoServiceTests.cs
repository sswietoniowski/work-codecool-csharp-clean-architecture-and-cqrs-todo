using AutoFixture;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using TodoApp.Api.Configurations;
using TodoApp.Api.DataAccess;
using TodoApp.Api.Dtos;
using TodoApp.Api.Services;

using Xunit.Abstractions;

namespace TodoApp.Api.Tests;

public class TodoServiceTests
{
    private readonly ITestOutputHelper _outputHelper;

    public TodoServiceTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public async Task GetTodoItems_ReturnsAllTodoItems_Dummy()
    {
        // Arrange
        var todoRepository = new DummyTodoRepository(); // <- Dummy

        // manual mapping
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Todo, TodoDto>());
        var mapper = new Mapper(config);

        var todoService = new TodoService(todoRepository, mapper);

        // Act
        var todos = await todoService.GetTodosAsync();

        // Assert
        Assert.Equal(3, todos.Count());
        Assert.Equal("Todo 1", todos.First().Title);
    }

    [Fact]
    public async Task GetTodoItems_ReturnsAllTodoItems_Stub()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<SqliteTodoContext>(options =>
        {
            options.UseSqlite("Data Source=:memory:");
        });

        serviceCollection.AddScoped<BaseTodoContext>(provider => provider.GetRequiredService<SqliteTodoContext>());
        serviceCollection.AddAutoMapper(typeof(TodoProfile));
        serviceCollection.AddScoped<ITodoRepository, TodoRepository>();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var context = serviceProvider.GetRequiredService<SqliteTodoContext>();
        context.Database.OpenConnection();
        context.Database.EnsureCreated();

        var mapper = serviceProvider.GetRequiredService<IMapper>(); // <- Stub
        var todoRepository = serviceProvider.GetRequiredService<ITodoRepository>(); // <- Stub

        var todoService = new TodoService(todoRepository, mapper);

        // Act
        var todos = await todoService.GetTodosAsync();

        // Assert
        Assert.Equal(3, todos.Count());
        Assert.Equal("Todo 1", todos.First().Title);
    }

    [Fact]
    public async Task GetTodoItems_ReturnsAllTodoItems_Mock()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Todo, TodoDto>());
        var mapper = new Mapper(config);

        var todoRepositoryMock = new Mock<ITodoRepository>(); // <- Mock
        todoRepositoryMock
            .Setup(m => m.GetTodosAsync())
            .ReturnsAsync
            (
                new List<Todo>
                {
                    new Todo { Id = 1, Title = "Todo 1", Description = "Todo 1 Description", IsCompleted = false },
                    new Todo { Id = 2, Title = "Todo 2", Description = "Todo 2 Description", IsCompleted = true },
                    new Todo { Id = 3, Title = "Todo 3", Description = "Todo 3 Description", IsCompleted = false }
                }
            );

        var todoService = new TodoService(todoRepositoryMock.Object, mapper);

        // Act
        var todos = await todoService.GetTodosAsync();

        // Assert
        Assert.Equal(3, todos.Count());
        Assert.Equal("Todo 1", todos.First().Title);
    }

    [Fact]
    public async Task GetTodoItems_ReturnsAllTodoItems_AutoFixture()
    {
        // Arrange
        var fixture = new Fixture(); // <- AutoFixture
        var autoTodos = fixture.CreateMany<Todo>(30);

        // proper way of outputting any info from tests
        _outputHelper.WriteLine($"AutoFixture generated {autoTodos.Count()} todos");
        foreach (var todo in autoTodos)
        {
            _outputHelper.WriteLine($"Todo: {todo}");
        }

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Todo, TodoDto>());
        var mapper = new Mapper(config);

        var todoRepositoryMock = new Mock<ITodoRepository>(); // <- Mock
        todoRepositoryMock
            .Setup(m => m.GetTodosAsync())
            .ReturnsAsync
            (
                autoTodos
            );

        var todoService = new TodoService(todoRepositoryMock.Object, mapper);

        // Act
        var todos = await todoService.GetTodosAsync();

        // Assert
        Assert.Equal(autoTodos.Count(), todos.Count());
        Assert.Equal(autoTodos.First().Title, todos.First().Title);
    }
}