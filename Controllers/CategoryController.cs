using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Data;
using NguyenManhHung_2122110438.Model;

namespace NguyenManhHung_2122110438.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Danh sách danh mục
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // GET: Hiển thị form tạo mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tạo mới danh mục
        [HttpPost]
        [IgnoreAntiforgeryToken] // 👉 Bỏ qua xác thực AntiForgery (nếu cần)
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Hiển thị form chỉnh sửa
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Lưu chỉnh sửa danh mục
        [HttpPost]
        [IgnoreAntiforgeryToken] // 👉 Bỏ xác thực nếu cần
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(category);

            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
                return NotFound();

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.ImageUrl = category.ImageUrl;
            existingCategory.IsActive = category.IsActive;
            existingCategory.UpdatedAt = DateTime.Now;

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Xóa danh mục
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
