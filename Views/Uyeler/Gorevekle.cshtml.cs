using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hukukk.Models;

namespace hukukk.Pages
{
    public class GorevekleModel : PageModel
    {
        private readonly UyeDbİsle _uyeDbİsle;

        public GorevekleModel(UyeDbİsle uyeDbİsle)
        {
            _uyeDbİsle = uyeDbİsle;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GorevModel Gorev { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Gorev.Tarih = DateTime.Now;
            _uyeDbİsle.Gorevekle(Gorev.KullaniciId, Gorev.GorevAdi, Gorev.GorevAciklama);

            TempData["SuccessMessage"] = "Yeni görev başarıyla eklendi.";

            return RedirectToPage("/Uyeler/düzenle");
        }
    }
}