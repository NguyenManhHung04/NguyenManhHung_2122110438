namespace NguyenManhHung_2122110438.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        // ⚠️ Không nên lưu plain password! 
        // Nên đổi thành HashPassword khi làm dự án thật.
        public string Password { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Gán mặc định Role cho user mới là Customer
        public string Role { get; set; } = "Customer";
    }
}
