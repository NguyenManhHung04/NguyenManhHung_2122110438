namespace NguyenManhHung_2122110438_asp.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Quan hệ với danh mục (Category)
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Quan hệ với thương hiệu (Brand) => bạn cần thêm
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
