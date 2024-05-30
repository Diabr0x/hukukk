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
            
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            ModelState.Clear();
            return View(uyeDbİsle1.Uyelerigetir());
        }
        public IActionResult Index()
        {
            
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            int userId = Convert.ToInt32(ViewData["UserID"]);// Kullanıcı kimliğini almak için gerçek bir mekanizma kullanmalısınız.

            // Bu kullanıcıya ait görevleri veritabanından alalım.
            UyeDbİsle uyeDbIsle = new UyeDbİsle(); // UyeDbİsle sınıfını kullanarak veritabanı işlemlerini yapmak için bir örnek oluşturun
            var gorevler = uyeDbIsle.GorevleriGetir2(userId); // Kullanıcıya ait görevleri getiren bir metodu çağırın

            // ViewData kullanarak kullanıcı adını ve kimliğini görünüme aktaralım

            ViewData["UserID"] = userId;

            // ViewBag kullanarak görevleri görünüme aktaralım
            ViewBag.Gorevler = gorevler;
            return View();
        }
        
        public IActionResult Index2()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        [AllowAnonymous]
        public IActionResult acilisekrani()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }

        
        public IActionResult Privacy()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult Index1()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
       


        public IActionResult detaylar()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        
        public IActionResult ekle()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        
        public ActionResult Gorevlerim()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            // Örneğin, kullanıcı adı ve kimliğini varsayılan değerlerle alalım.
             // Kullanıcı adını almak için gerçek bir mekanizma kullanmalısınız.
            int userId = Convert.ToInt32(ViewData["UserID"]);// Kullanıcı kimliğini almak için gerçek bir mekanizma kullanmalısınız.

            // Bu kullanıcıya ait görevleri veritabanından alalım.
            UyeDbİsle uyeDbIsle = new UyeDbİsle(); // UyeDbİsle sınıfını kullanarak veritabanı işlemlerini yapmak için bir örnek oluşturun
            var gorevler = uyeDbIsle.GorevleriGetir2(userId); // Kullanıcıya ait görevleri getiren bir metodu çağırın

            // ViewData kullanarak kullanıcı adını ve kimliğini görünüme aktaralım
           
            ViewData["UserID"] = userId;

            // ViewBag kullanarak görevleri görünüme aktaralım
            ViewBag.Gorevler = gorevler;

            // Gorevlerim.cshtml görünümünü döndürelim
            return View();
        }


    }
}
