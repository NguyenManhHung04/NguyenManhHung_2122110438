namespace NguyenManhHung_2122110438_asp.Model
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Quan hệ: Một Brand có nhiều Product
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
