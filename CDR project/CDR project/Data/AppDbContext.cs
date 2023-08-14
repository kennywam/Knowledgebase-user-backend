using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public DbSet<CDRData> CDRData { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
