using FluentAssertions;

using TodoApp.Core;

namespace TodoApp.Api.Tests;

public class TodoTests
{
    [Fact]
    public void Constructor_WhenCreated_ShouldNotBeCompleted()
    {
        // Arrange

        // Act
        var todo = new Todo();

        // Assert
        Assert.False(todo.IsCompleted);
    }

    [Fact]
    public void Constructor_WhenCreated_ShouldNotBeCompleted_FluentAssertions()
    {
        // Arrange

        // Act
        var todo = new Todo();

        // Assert with FluentAssertions
        todo.IsCompleted.Should().BeFalse();
    }

    public static IEnumerable<object?[]> TestData =>
        new List<object?[]>
        {
            new object?[] { "Title #1", null },
            new object?[] { "Title #2", "Description ... #2" },
        };

    [Theory]
    //[InlineData("Title #1", null)]
    //[InlineData("Title #2", "Description ... #2")]
    [MemberData(nameof(TestData))]
    public void Constructor_WhenCreatedWithInitializationBlock_ShouldBeInitialized(string title, string? description)
    {
        // Arrange

        // Act
        var todo = new Todo
        {
            Title = title,
            Description = description
        };

        // Assert
        Assert.Equal(title, todo.Title);
        Assert.Equal(description, todo.Description);
    }
}