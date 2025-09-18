using Microsoft.AspNetCore.Mvc;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
    public class ProductController : Controller
    {
        // Tạo danh sách giày mẫu
        private List<Product> GetShoes()
        {
            return new List<Product>
            {
                new Product{ ProductId=1, ShoeName="Nike Air Jordan", Brand="Nike", YearRelease=2024, Price=3500000M },
                new Product{ ProductId=2, ShoeName="Adidas Ultraboost", Brand="Adidas", YearRelease=2023, Price=2800000M },
                new Product{ ProductId=3, ShoeName="Converse Classic", Brand="Converse", YearRelease=2022, Price=1500000M },
                new Product{ ProductId=4, ShoeName="Puma RS-X", Brand="Puma", YearRelease=2024, Price=2200000M },
                new Product{ ProductId=5, ShoeName="Vans Old Skool", Brand="Vans", YearRelease=2021, Price=1300000M }
            };
        }

        // Action hiển thị danh sách giày
        public IActionResult GetAllProducts()
        {
            var shoes = GetShoes();
            return View(shoes);
        }
    }
}
