using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Data;
using NguyenManhHung_2122110438.Model;

namespace NguyenManhHung_2122110438.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                                         .Include(p => p.Category)
                                         .OrderByDescending(p => p.CreatedAt)
                                         .ToListAsync();
            return View(products);
        }

        // GET: Form tạo sản phẩm
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductCreateViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        // POST: Tạo sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    CategoryId = viewModel.CategoryId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }

        // GET: Form chỉnh sửa sản phẩm
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductCreateViewModel
            {
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Categories = _context.Categories.ToList()
            };

            ViewBag.ProductId = product.Id;

            return View(viewModel);
        }

        // POST: Cập nhật sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.CategoryId = viewModel.CategoryId;
                product.UpdatedAt = DateTime.Now;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Categories = _context.Categories.ToList();
            ViewBag.ProductId = id;

            return View(viewModel);
        }

        // GET: Hiển thị xác nhận xóa
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product); // <-- View hiển thị xác nhận
        }

        // POST: Xóa sau khi xác nhận
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
