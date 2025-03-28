using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Model;

namespace NguyenManhHung_2122110438.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ✅ Thêm constructor mặc định
        public DbSet<Product> Products { get; set; }
    }
}
