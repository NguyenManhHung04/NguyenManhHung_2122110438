using System.Text.Json.Serialization;

namespace NguyenManhHung_2122110438_asp.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Quan hệ với sản phẩm - chỉ dùng khi cần include
        [JsonIgnore] // Để tránh lỗi khi serialize hoặc POST
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
