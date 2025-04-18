// ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438_asp.Data;
using NguyenManhHung_2122110438_asp.Model;

namespace NguyenManhHung_2122110438_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách sản phẩm, có thêm Brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products
                                         .Where(p => p.IsActive)
                                         .Include(p => p.Category)
                                         .Include(p => p.Brand) // Thêm brand vào đây
                                         .ToListAsync();
            return Ok(products);
        }

        // Lấy 1 sản phẩm theo ID, có thêm Brand
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                                        .Include(p => p.Category)
                                        .Include(p => p.Brand) // Thêm brand vào đây
                                        .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (product == null)
                return NotFound(new { message = $"Không tìm thấy sản phẩm với ID = {id}" });

            return Ok(product);
        }

        // Tạo mới sản phẩm, kiểm tra Category & Brand
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId))
                return BadRequest(new { message = "Danh mục không tồn tại." });

            if (!await _context.Brands.AnyAsync(b => b.Id == product.BrandId))
                return BadRequest(new { message = "Thương hiệu không tồn tại." });

            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            product.IsActive = true;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Cập nhật sản phẩm
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest(new { message = "ID không khớp!" });

            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId))
                return BadRequest(new { message = "Danh mục không tồn tại." });

            if (!await _context.Brands.AnyAsync(b => b.Id == product.BrandId))
                return BadRequest(new { message = "Thương hiệu không tồn tại." });

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound(new { message = "Sản phẩm không tồn tại." });

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.BrandId = product.BrandId; // cập nhật BrandId
            existingProduct.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Xoá mềm sản phẩm
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { message = "Sản phẩm không tồn tại." });

            product.IsActive = false;
            product.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã chuyển sản phẩm vào thùng rác." });
        }
    }
}
