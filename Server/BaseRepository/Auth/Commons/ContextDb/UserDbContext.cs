using Microsoft.EntityFrameworkCore;
using Auth.Models;

namespace Auth.Commons {
    public class UserDbContext : DbContext {
        public UserDbContext (DbContextOptions option) : base (option) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasIndex(c => new { c.Id}).IsUnique();
        }

    }
}