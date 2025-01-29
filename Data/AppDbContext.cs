using AccessControl_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<UserField> UserField { get; set; }
        public DbSet<UserFieldValue> UserFieldValue { get; set; }
        public DbSet<Operator> Operator { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFieldValue>()
                .HasKey(ub => ub.UserFieldId);

            modelBuilder.Entity<UserFieldValue>()
                .HasOne(ub => ub.User)
                .WithMany()
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFieldValue>()
                .HasOne(ub => ub.UserField)
                .WithMany()
                .HasForeignKey(ub => ub.UserFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Operator>()
                .HasOne(ub => ub.User)
                .WithMany()
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
