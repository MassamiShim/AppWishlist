using Microsoft.EntityFrameworkCore;
using APIwishlist.Models;

namespace APIwishlist.Models
{
    public class WishlistContext : DbContext
    {
        public WishlistContext(DbContextOptions<WishlistContext> options)
            : base(options)
        {
        }

        public DbSet<UserList> UserList { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Listproduct> ListProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listproduct>()
                .HasKey(lp => new { lp.IdList, lp.IdProduct });
        }
    }
}
