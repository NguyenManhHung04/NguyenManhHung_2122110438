using System.ComponentModel.DataAnnotations;

namespace NguyenManhHung_2122110438.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục.")]
        [Display(Name = "Tên danh mục")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [Display(Name = "Ảnh đại diện (URL)")]
        [Url(ErrorMessage = "Vui lòng nhập một URL hợp lệ.")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Danh sách sản phẩm thuộc danh mục này
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
