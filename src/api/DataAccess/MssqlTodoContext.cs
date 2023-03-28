using Microsoft.EntityFrameworkCore;

namespace Todo.Api.DataAccess;

public class MssqlTodoContext : BaseTodoContext
{
    public MssqlTodoContext(DbContextOptions options) : base(options)
    {
    }
}