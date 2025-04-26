using NguyenManhHung_2122110438_asp.Model;
using System.Text.Json.Serialization;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Quan hệ: Một Brand có nhiều Product
    [JsonIgnore] // Rất quan trọng nếu bạn không muốn đưa Products khi POST
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
