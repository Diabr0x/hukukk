using System;

namespace hukukk.Models
{
    public class GorevModel
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; } // Görevin atanacağı kullanıcının Id'si
        public string? GorevAdi { get; set; }
        public string? GorevAciklama { get; set; }
        public string? Muvekkil { get; set; }
        public string? DavaninDurumu { get; set; }
        public DateTime? DurusmaTarihi { get; set; }
        public DateTime? Tarih { get; set; } // Görevin oluşturulma tarihi

        // Diğer gerektiğinde eklenebilecek özellikler
    }
}