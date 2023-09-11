using CDR_pdf.Models;
using IBM.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CDR_pdf.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CallLog> CallLogs { get; set; }
        public DbSet<SmsLog> SmsLogs { get; set; }
        public DbSet<DailyDataCdr> DailyDataCdrs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallLog>().HasNoKey();
            modelBuilder.Entity<DailyDataCdr>().HasNoKey();
            modelBuilder.Entity<SmsLog>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
