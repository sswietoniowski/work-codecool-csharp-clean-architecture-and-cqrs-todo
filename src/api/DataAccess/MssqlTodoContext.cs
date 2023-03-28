using Microsoft.EntityFrameworkCore;

namespace api.DataAccess;

public class MssqlTodoContext : BaseTodoContext
{
    public MssqlTodoContext(DbContextOptions options) : base(options)
    {
    }
}