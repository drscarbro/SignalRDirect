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

            modelBuilder.Entity<Call>().ToTable("Call");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasMany( u => u.Calls );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Call> Calls { get; set; }
    }
}