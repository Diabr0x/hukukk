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
                return RedirectToAction("düzenle");
            }catch
            { return View(); }
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
        public IActionResult Gorevekle(int? kullaniciId, string gorevAdi, string gorevAciklama)
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
                    Tarih = DateTime.Now // Şuanki zamanı ekle
                };

                // Veritabanına yeni görevi ekle
                uyeDbİsle1.Gorevekle(yeniGorev.KullaniciId, yeniGorev.GorevAdi, yeniGorev.GorevAciklama);

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






    }
}
