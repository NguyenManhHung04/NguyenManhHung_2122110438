using System.ComponentModel.DataAnnotations;

namespace NguyenManhHung_2122110438.Model
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả tối đa 500 ký tự.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
