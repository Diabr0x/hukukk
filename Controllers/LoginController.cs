using Microsoft.AspNetCore.Mvc;
using hukukk.Models;

namespace hukukk.Controllers
{
    public class LoginController : Controller
    {
        private readonly UyeDbİsle _uyeDbIsle;

        public LoginController(UyeDbİsle uyeDbIsle)
        {
            _uyeDbIsle = uyeDbIsle;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UyelerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _uyeDbIsle.GetUser(model.Kullanici, model.Sifre);
                    if (user != null)
                    {
                        HttpContext.Session.SetString("IsLoggedIn", "true");
                        HttpContext.Session.SetString("UserName", model.Kullanici);
                       
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        
                        ViewBag.Message = "Kullanıcı adı veya şifre yanlış";
                    }
                }
                // Model doğrulama başarısız olduğunda tekrar login sayfasını göster
                return View();
            }
            catch (Exception)
            {
                // Handle the exception here, you can log it or handle it according to your application's requirements
                ModelState.AddModelError(string.Empty, "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                ViewBag.Message = "Kullanıcı adı veya şifre yanlış";
                return View();
            }
        }
    }
}