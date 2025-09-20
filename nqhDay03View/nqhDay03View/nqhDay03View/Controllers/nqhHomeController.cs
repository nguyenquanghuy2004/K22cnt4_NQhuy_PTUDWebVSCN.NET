using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nqhDay03View.Models;

namespace nqhDay03View.Controllers
{
    public class nqhHomeController : Controller
    {
        private readonly ILogger<nqhHomeController> _logger;

        public nqhHomeController(ILogger<nqhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult nqhIndex()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult nqhAbout()
        {
            return View();
        }

        public IActionResult nqhViewIf()
        {
            return View();
        }

        public IActionResult nqhViewLoop()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
