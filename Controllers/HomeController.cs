using hukukk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hukukk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Büromuz()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult register()
        {
            return View();
        }
        public IActionResult düzenle()
        {
            return View();
        }
        public IActionResult ekle()
        {
            return View();
        }
        public IActionResult düzenlee() 
        {
            return View();
        }
    }
}
