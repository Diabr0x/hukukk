using System.Data.SqlClient;

namespace hukukk.Models
{
    public class Ayarlar
    {
        public static int Sayac = 100; // Genel bir değişken

        // Veri tabanı bağlantı cümlesi
        public static string bcumle = @"Server=(localdb)\MSSQLLocalDB;Database=Uyeler;Integrated Security=True";

        public static SqlConnection baglanti = null;

        public static void Baglan()
        {
            try
            {
                // SqlConnection objesini oluşturup bağlantıyı açma işlemleri
                baglanti = new SqlConnection(bcumle);
                baglanti.Open();
                Console.WriteLine("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }
        }
    }
}