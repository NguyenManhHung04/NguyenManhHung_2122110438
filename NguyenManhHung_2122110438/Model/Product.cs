using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace NguyenManhHung_2122110438.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

    }
}
