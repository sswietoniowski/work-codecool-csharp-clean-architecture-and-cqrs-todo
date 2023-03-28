using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.DataAccess;

public class SqliteTodoContext : BaseTodoContext
{
    public SqliteTodoContext(DbContextOptions options) : base(options)
    {
    }
}