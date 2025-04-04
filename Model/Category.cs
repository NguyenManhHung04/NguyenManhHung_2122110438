namespace NguyenManhHung_2122110438.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Quan hệ với sản phẩm
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
