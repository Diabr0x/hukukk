using Microsoft.AspNetCore.Mvc;

public class DestekController : Controller
{
    // POST: /Destek
    [HttpPost]
    public IActionResult Index(string AdSoyad, string Eposta, string SikayetTur, string Aciklama)
    {
        // Form verilerini işleyin ve başarı mesajını oluşturun
        string successMessage = "Gönderim başarılı, geri bildiriminiz için teşekkürler!";
        // Başarı mesajını ViewBag'e veya ViewData'ya ekleyin
        ViewBag.SuccessMessage = successMessage;
        // Index.cshtml görünümünü geri dönün
        return View("Index");
    }
}