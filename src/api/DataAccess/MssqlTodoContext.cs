using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.DataAccess;

public class MssqlTodoContext : BaseTodoContext
{
    public MssqlTodoContext(DbContextOptions options) : base(options)
    {
    }
}