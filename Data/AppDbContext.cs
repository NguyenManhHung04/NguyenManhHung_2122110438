using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Model;

namespace NguyenManhHung_2122110438.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ✅ Thêm constructor mặc định
        public DbSet<Product> Products { get; set; }
<<<<<<< HEAD
        public DbSet<Category> Categories { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<User> Users { get; set; }
=======
>>>>>>> 9fae4ce55b2735e28fb3aaf2de6efcdeed3b1bfa
    }
}
