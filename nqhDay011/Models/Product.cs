namespace ShoeStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ShoeName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;   // Thêm thương hiệu
        public int YearRelease { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty; // Đường dẫn ảnh
    }
}
