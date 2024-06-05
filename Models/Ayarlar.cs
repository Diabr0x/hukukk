using System.Data.SqlClient;
using static hukukk.Program;
namespace hukukk.Models
{
    public class Ayarlar
    {
        public static int Sayac = 100; 

        
        

        public static SqlConnection baglanti = null;

        public static void Baglan()
        {
            try
            {
               
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