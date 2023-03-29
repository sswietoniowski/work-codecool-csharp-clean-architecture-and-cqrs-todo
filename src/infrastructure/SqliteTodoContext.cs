using Microsoft.EntityFrameworkCore;

namespace TodoApp.Infrastructure;

public class SqliteTodoContext : BaseTodoContext
{
    public SqliteTodoContext(DbContextOptions options) : base(options)
    {
    }
}