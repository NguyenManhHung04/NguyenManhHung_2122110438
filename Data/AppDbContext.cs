using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Model;

namespace NguyenManhHung_2122110438.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

      
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
