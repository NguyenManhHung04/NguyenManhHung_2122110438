namespace NguyenManhHung_2122110438.Model
{
    public class DashboardViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Banner> Banners { get; set; } = new List<Banner>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
