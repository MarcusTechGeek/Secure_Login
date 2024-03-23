using Microsoft.EntityFrameworkCore;
using SecureLogin.Models;

namespace SecureLogin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordResetToken)
                .HasMaxLength(36); // Assuming the reset token is a GUID

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordResetTokenExpiration)
                .IsRequired(false); // Make the expiration nullable
        }
    }
}