<<<<<<< HEAD
﻿using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public DbSet<CDRData> CDRData { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
=======
﻿namespace CDR_project.Data
{
    public class AppDbContext
>>>>>>> ebadd27 (Initial commit)
    {
    }
}
