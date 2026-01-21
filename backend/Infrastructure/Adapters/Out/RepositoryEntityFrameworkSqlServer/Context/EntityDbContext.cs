using Microsoft.EntityFrameworkCore;

namespace RepositoryEntityFrameworkSqlServer.Context;

public class EntityDbContext : DbContext
{
    public EntityDbContext()
    {
    }

    public EntityDbContext(DbContextOptions<EntityDbContext> options)
    : base(options)
    { }

    // Example
    public DbSet<SupplierEntity> Supplier { get; set; }
}
