using Microsoft.EntityFrameworkCore;

using TodoApp.Core;
using TodoApp.Infrastructure.Configurations.Entities;

namespace TodoApp.Infrastructure;

public abstract class BaseTodoContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public BaseTodoContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TodoConfiguration());
    }
}