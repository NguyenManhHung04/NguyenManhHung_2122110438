<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿// CategoryController.cs
using Microsoft.AspNetCore.Mvc;
>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e
using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438_asp.Data;
using NguyenManhHung_2122110438_asp.Model;

namespace NguyenManhHung_2122110438_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.Where(c => c.IsActive).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
<<<<<<< HEAD
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.IsActive); // Không cần Include Products nữa
=======
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e

            if (category == null)
                return NotFound(new { message = $"Không tìm thấy danh mục với ID = {id}" });

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
<<<<<<< HEAD
            try
            {
                category.CreatedAt = DateTime.Now;
                category.UpdatedAt = DateTime.Now;
                category.IsActive = true;

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }


=======
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            category.IsActive = true;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest(new { message = "ID không khớp!" });

            category.UpdatedAt = DateTime.Now;
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Categories.Any(e => e.Id == id))
                    return NotFound(new { message = "Danh mục không tồn tại!" });
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound(new { message = $"Không tìm thấy danh mục với ID = {id}" });

            category.IsActive = false;
            category.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
