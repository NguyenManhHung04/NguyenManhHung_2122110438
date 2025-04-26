using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438_asp.Data;
using NguyenManhHung_2122110438_asp.Model;

namespace NguyenManhHung_2122110438_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
<<<<<<< HEAD
            return await _context.Brands.ToListAsync(); // Không cần Include bây giờ
=======
            return await _context.Brands.Include(b => b.Products).ToListAsync();
>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
<<<<<<< HEAD
            var brand = await _context.Brands.FindAsync(id);
=======
            var brand = await _context.Brands
                .Include(b => b.Products)
                .FirstOrDefaultAsync(b => b.Id == id);
>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e

            if (brand == null)
                return NotFound();

            return brand;
        }

        // POST: api/Brand
        [HttpPost]
        public async Task<ActionResult<Brand>> CreateBrand(Brand brand)
        {
<<<<<<< HEAD
            try
            {
                brand.CreatedAt = DateTime.Now;
                brand.UpdatedAt = DateTime.Now;

                _context.Brands.Add(brand);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBrand), new { id = brand.Id }, brand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }


=======
            brand.CreatedAt = DateTime.Now;
            brand.UpdatedAt = DateTime.Now;

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrand), new { id = brand.Id }, brand);
        }

>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e
        // PUT: api/Brand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, Brand brand)
        {
            if (id != brand.Id)
                return BadRequest();

            brand.UpdatedAt = DateTime.Now;
            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Brands.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Brand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
