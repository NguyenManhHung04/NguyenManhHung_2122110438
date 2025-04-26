using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Model;
using NguyenManhHung_2122110438_asp.Model;

namespace NguyenManhHung_2122110438_asp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }   // <-- Thêm vào đây
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

<<<<<<< HEAD
            modelBuilder.Entity<Product>()
      .HasOne(p => p.Category)
      .WithMany(c => c.Products)
      .HasForeignKey(p => p.CategoryId)
      .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);



            // Cấu hình quan hệ giữa OrderDetail và Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order) // Mỗi OrderDetail thuộc về một Order
                .WithMany(o => o.OrderDetails) // Một Order có thể chứa nhiều OrderDetail
                .HasForeignKey(od => od.OrderId) // Sử dụng khóa ngoại OrderId trong OrderDetail
                .OnDelete(DeleteBehavior.Cascade); // Nếu Order bị xóa, các OrderDetail liên quan cũng bị xóa

            // Cấu hình quan hệ giữa OrderDetail và Product
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product) // Mỗi OrderDetail chứa một sản phẩm
                .WithMany() // Sản phẩm có thể xuất hiện trong nhiều OrderDetail
                .HasForeignKey(od => od.ProductId) // Sử dụng khóa ngoại ProductId trong OrderDetail
                .OnDelete(DeleteBehavior.Cascade); // Nếu Product bị xóa, OrderDetail sẽ bị xóa theo

            // Có thể thêm seed dữ liệu nếu cần (Ví dụ: thêm một số Brand hoặc Category mặc định)
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Default Brand",
                    Description = "This is a default brand",
                    ImageUrl = "https://example.com/defaultbrand.png",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "All kinds of electronics",
                    ImageUrl = "https://example.com/electronics.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
=======
            // Cấu hình quan hệ giữa Product và Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
    .HasOne(od => od.Product)
    .WithMany()
    .HasForeignKey(od => od.ProductId);
>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e
        }
    }
}
