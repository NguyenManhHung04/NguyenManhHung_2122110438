using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace NguyenManhHung_2122110438.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
<<<<<<< HEAD
        public int CategoryId { get; set; }  // Tham chiếu đến Category
        public Category Category { get; set; }  // Quan hệ với Category
=======
        public string Category { get; set; }

>>>>>>> 9fae4ce55b2735e28fb3aaf2de6efcdeed3b1bfa
    }
}
