using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TodoApp.Core;

namespace TodoApp.Infrastructure.Configurations.Entities;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(t => t.Description);

        builder.Property(t => t.IsCompleted)
        .IsRequired();

        builder.HasData(
            new Todo { Id = 1, Title = "Todo 1", Description = "Todo 1 Description", IsCompleted = false },
            new Todo { Id = 2, Title = "Todo 2", Description = "Todo 2 Description", IsCompleted = true },
            new Todo { Id = 3, Title = "Todo 3", Description = "Todo 3 Description", IsCompleted = false }
        );
    }
}