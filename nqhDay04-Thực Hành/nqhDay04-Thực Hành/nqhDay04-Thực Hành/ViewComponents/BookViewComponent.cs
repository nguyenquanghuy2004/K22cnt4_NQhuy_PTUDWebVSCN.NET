using Microsoft.AspNetCore.Mvc;
using nqhDay04_ThucHanh.Models;

namespace nqhDay04_Thực_Hành.ViewComponents
{
    public class BookViewComponent:ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }

        }
}
