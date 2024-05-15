using hukukk.Models;
using Microsoft.AspNetCore.Mvc;

namespace hukukk.Controllers
{
    public class UyelerController : Controller
    {
        public IActionResult düzenle()
        {
            ViewData["baslik"] = "veri tabanindaki üyeler";
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            ModelState.Clear();
            return View(uyeDbİsle1.Uyelerigetir());
        }
        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ekle(UyelerModel liste1)
        {
           if(ModelState.IsValid)
            {
                UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
                if(uyeDbİsle1.kayitekle(liste1))
                {
                    ViewData["sonucmesaj"] = "Kayıt eklendi";
                    ModelState.Clear();
                }
            }
           return View(liste1);

        }
        [HttpGet]
        public ActionResult düzenlee(int Id)
        {
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            return View(uyeDbİsle1.Uyelerigetir().Find(Uyemodeli => Uyemodeli.Id == Id));
        }
        [HttpPost]
        public ActionResult düzenlee(int Id, UyelerModel liste1) 
        {
            try 
            {
                UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
                uyeDbİsle1.Uyebilgiduzen(liste1);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
        public ActionResult silme(int Id) 
        {
            try 
            {
                UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
                if(uyeDbİsle1.Uyesil(Id))
                {
                    ViewData["sonucmesaj"] = "Kayıt silindi";
                }
                return RedirectToAction("Index");
            }catch
            { return View(); }
        }
        
    }
}
