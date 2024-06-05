using hukukk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                    return RedirectToAction("düzenle");
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
                return RedirectToAction("Index"); // Sorun: "Index" eylemine yönlendirme, bu denetleyicide mevcut olmayabilir
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

                // Kullanıcıyı sil ve silme işlemi başarılıysa
                if (uyeDbİsle1.Uyesil(Id))
                {
                    ViewData["sonucmesaj"] = "Kayıt silindi";
                }
                else
                {
                    ViewData["sonucmesaj"] = "Kayıt silinirken bir hata oluştu.";
                }

                return RedirectToAction("düzenle");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                ViewData["sonucmesaj"] = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction("düzenle");
            }
        }
        public ActionResult detaylar(int Id)
        {
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            UyelerModel kullaniciDetaylari = uyeDbİsle1.Detaylar(Id);

            if (kullaniciDetaylari != null)
            {
                return View(kullaniciDetaylari);
            }
            else
            {
                // Kullanıcı bulunamadı mesajı görüntüleyin
                ViewData["hataMesaji"] = "Kullanıcı bulunamadı.";
                return View();
            }
        }
        public IActionResult Gorevler()
        {
            ViewData["UserID"] = HttpContext.Session.GetString("UserId");
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            var gorevler = uyeDbİsle1.GorevleriGetir();
            return View(gorevler);
        }

        
        [HttpGet]
        public IActionResult Gorevekle()
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            ViewBag.Users = uyeDbİsle1.Uyelerigetir(); // Uyelerigetir metodu uyeleri getirir.
            return View();

        }

        [HttpPost]
        public IActionResult Gorevekle(int? kullaniciId, string gorevAdi, string gorevAciklama, DateTime? DurusmaTarihi, string Muvekkil, string DavaninDurumu)
        {
            ViewData["IsLoggedIn"] = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            try
            {
                Console.WriteLine("Gorevekle metodu başlatıldı.");
                Console.WriteLine($"KullanıcıId: {kullaniciId}, GorevAdi: {gorevAdi}, GorevAciklama: {gorevAciklama}");

                // Kullanıcı adı ve görev adının boş olmadığını kontrol et
                if (string.IsNullOrWhiteSpace(gorevAdi) || kullaniciId == null)
                {
                    Console.WriteLine("Görev adı veya kullanıcı ID boş olamaz.");
                    TempData["ErrorMessage"] = "Görev adı veya kullanıcı ID boş olamaz.";
                    return RedirectToAction("Gorevekle");
                }

                UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
                GorevModel yeniGorev = new GorevModel
                {
                    KullaniciId = kullaniciId.Value, // Null koalesans operatörü ile kontrol edin
                    GorevAdi = gorevAdi,
                    GorevAciklama = gorevAciklama,
                    DurusmaTarihi = DurusmaTarihi.Value, // Nullable türden değeri alın
                    Muvekkil = Muvekkil,
                    DavaninDurumu = DavaninDurumu,
                    Tarih = DateTime.Now // Şuanki zamanı ekle
                };

                // Veritabanına yeni görevi ekle
                uyeDbİsle1.Gorevekle(yeniGorev.KullaniciId, yeniGorev.GorevAdi, yeniGorev.GorevAciklama, yeniGorev.DurusmaTarihi, yeniGorev.Muvekkil, yeniGorev.DavaninDurumu);

                // Başarı mesajını göster
                TempData["SuccessMessage"] = $"{gorevAdi} görevi başarıyla eklenmiştir.";

                // Sayfayı yönlendir
                return RedirectToAction("düzenle", "Uyeler");
            }
            catch (Exception ex)
            {
                // Hata durumunda hatayı konsola yazdır
                Console.WriteLine("Görev eklenirken bir hata oluştu: " + ex.ToString());

                // Hata mesajını göster
                TempData["ErrorMessage"] = "Görev eklenirken bir hata oluştu.";

                // Sayfayı yeniden yükle
                return RedirectToAction("Gorevekle");
            }
        }
        public IActionResult GorevSil(int id)
        {
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            bool silindi = uyeDbİsle1.GorevSil(id);
            if (silindi)
            {
                return RedirectToAction("Gorevler");
            }
            else
            {
                // Silme işlemi başarısız oldu, burada hata mesajı gösterebilirsiniz.
                return RedirectToAction("Gorevler");
            }
        }
      
        [HttpGet]
        public ActionResult GorevDuzenle(int Id) 
        {
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
            return View(uyeDbİsle1.GorevleriGetir().Find(Gorevmodeli=>Gorevmodeli.Id == Id));
        }
        [HttpPost]
        public ActionResult GorevDuzenle(int Id,GorevModel gorev) 
        {
            try { 
            UyeDbİsle uyeDbİsle1 = new UyeDbİsle();
                uyeDbİsle1.GorevDuzenle(gorev);
                return RedirectToAction("Gorevler");
            }
            catch 
            { return View(); }
        }
       

    }











}
    
