using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Data;
using NguyenManhHung_2122110438.Model;

namespace NguyenManhHung_2122110438.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Console.WriteLine("==== Dashboard Controller Index action is running ====");

            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            var categories = await _context.Categories.ToListAsync();
            var banners = await _context.Banners.ToListAsync();
            var users = await _context.Users.ToListAsync();

            var viewModel = new DashboardViewModel
            {
                Products = products,
                Categories = categories,
                Banners = banners,
                Users = users
            };

            return View(viewModel);
        }
    }
}
