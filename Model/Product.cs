namespace NguyenManhHung_2122110438.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // FK - Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
    }
}
