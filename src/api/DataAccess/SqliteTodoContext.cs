using Microsoft.EntityFrameworkCore;

namespace api.DataAccess;

public class SqliteTodoContext : BaseTodoContext
{
    public SqliteTodoContext(DbContextOptions options) : base(options)
    {
    }
}