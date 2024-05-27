using hukukk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hukukk.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public ActionResult Büromuz(int Id)
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            ModelState.Clear();
            return View(uyeDbİsle1.Uyelerigetir());
        }
        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        
        public IActionResult Index2()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        [AllowAnonymous]
        public IActionResult acilisekrani()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }

        
        public IActionResult Privacy()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult Index1()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
       


        public IActionResult detaylar()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult düzenle()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult ekle()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult düzenlee() 
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        
    }
}
