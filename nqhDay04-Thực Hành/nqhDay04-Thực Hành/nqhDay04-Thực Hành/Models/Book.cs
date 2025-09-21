using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace nqhDay04_ThucHanh.Models
{
    public class Book
    {
        internal dynamic Authors;
        internal dynamic Genres;

        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên sách")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Tác giả")]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Thể loại")]
        public int GenreId { get; set; }

        [Display(Name = "Hình ảnh/Poster")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Giá sách")]
        public float Price { get; set; }

        [Display(Name = "Tổng số trang")]
        public int TotalPage { get; set; }

        [Display(Name = "Giới thiệu ngắn")]
        public string Sumary { get; set; }

        // Phương thức trả về danh sách các cuốn sách mẫu
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    Sumary = "Tác phẩm kinh điển của Nam Cao phản ánh hiện thực xã hội nông thôn Việt Nam.",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/b2.jpg",
                    Price = 450000,
                    Sumary = "Truyện ngắn nổi tiếng của Nam Cao về thân phận người nông dân nghèo.",
                    TotalPage = 200
                },
                new Book()
                {
                    Id = 3,
                    Title = "Dế Mèn Phiêu Lưu Ký",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/b3.jpg",
                    Price = 300000,
                    Sumary = "Tác phẩm dành cho thiếu nhi của Tô Hoài kể về chuyến phiêu lưu đầy thú vị.",
                    TotalPage = 180
                },
                new Book()
                {
                    Id = 4,
                    Title = "Tắt Đèn",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "/images/products/b4.jpg",
                    Price = 550000,
                    Sumary = "Tác phẩm nổi bật của Ngô Tất Tố nói về cuộc sống cơ cực của người nông dân.",
                    TotalPage = 320
                }
            };

            return books;
        }

        // Phương thức lấy chi tiết 1 cuốn sách theo Id
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
    }
}
