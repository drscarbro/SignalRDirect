using Microsoft.EntityFrameworkCore;

namespace SignalRDirect
{
    public class CallCenterContext : DbContext
    {
        public CallCenterContext(DbContextOptions<CallCenterContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }

        public DbSet<User> Users { get; set; }
    }
}