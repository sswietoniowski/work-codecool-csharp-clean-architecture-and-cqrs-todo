using Microsoft.EntityFrameworkCore;

namespace Todo.Api.DataAccess;

public class SqliteTodoContext : BaseTodoContext
{
    public SqliteTodoContext(DbContextOptions options) : base(options)
    {
    }
}