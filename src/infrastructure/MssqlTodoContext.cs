using Microsoft.EntityFrameworkCore;

namespace TodoApp.Infrastructure;

public class MssqlTodoContext : BaseTodoContext
{
    public MssqlTodoContext(DbContextOptions options) : base(options)
    {
    }
}