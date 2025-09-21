using Microsoft.AspNetCore.Mvc;
using nqhDay04_ThucHanh.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace nqhDay04_ThucHanh.Controllers
{
    public class BookController : Controller
    {
        // Hiển thị danh sách sách
        public IActionResult Index(int? authorId, int? genreId)
        {
            Book bookModel = new Book();
            var books = bookModel.GetBookList();

            if (authorId.HasValue)
            {
                books = books.Where(b => b.AuthorId == authorId.Value).ToList();
            }

            if (genreId.HasValue)
            {
                books = books.Where(b => b.GenreId == genreId.Value).ToList();
            }

            return View(books);
        }

        // GET: Hiển thị form tạo sách mới
        public IActionResult Create()
        {
            Book bookModel = new Book(); // Tạo một đối tượng Book để truy cập các danh sách
            ViewBag.authors = bookModel.Authors; // Truyền danh sách tác giả qua ViewBag
            ViewBag.genres = bookModel.Genres;   // Truyền danh sách thể loại qua ViewBag

            Book model = new Book(); // Tạo một đối tượng Book rỗng để dùng cho form
            return View(model);
        }

        // POST: Xử lý tạo sách mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    model.Image = "/images/products/" + fileName;
                }

                // TODO: Lưu vào DB
                return RedirectToAction("Index");
            }

            // Nếu ModelState không hợp lệ, cần truyền lại dữ liệu cho DropDownList
            Book bookModel = new Book();
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;

            return View(model);
        }

        // GET: Hiển thị form chỉnh sửa sách
        public IActionResult Edit(int id)
        {
            Book bookModel = new Book();
            var book = bookModel.GetBookList().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            // Truyền dữ liệu cho DropDownList tương tự như Action Create
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;

            return View(book);
        }

        // POST: Xử lý chỉnh sửa sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book model, IFormFile ImageFile)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    model.Image = "/images/products/" + fileName;
                }

                // TODO: Update DB
                return RedirectToAction("Index");
            }

            // Nếu ModelState không hợp lệ, cần truyền lại dữ liệu cho DropDownList
            Book bookModel = new Book();
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;

            return View(model);
        }

        // PartialView cho danh sách sách phổ biến
        public PartialViewResult PopularBook()
        {
            var books = new Book().GetBookList();
            return PartialView(books);
        }
    }
}