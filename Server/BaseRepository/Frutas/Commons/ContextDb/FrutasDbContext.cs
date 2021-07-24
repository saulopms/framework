using Microsoft.EntityFrameworkCore;
using Frutas.Models;

namespace Frutas.Commons {
    public class FrutasDbContext : DbContext {
        public FrutasDbContext (DbContextOptions option) : base (option) { }
        public DbSet<Fruta> Frutas { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fruta>()
                .HasIndex(c => new { c.Id}).IsUnique();
            builder.Entity<ItemCarrinho>()
                .HasIndex(c => new { c.Id }).IsUnique();
            builder.Entity<Carrinho>()
                .HasIndex(c => new { c.Id }).IsUnique();
            builder.Entity<Carrinho>().HasMany(x => x.Itens);

        }

    }
}