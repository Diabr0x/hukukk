using System.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace hukukk.Models
{
    public class UyeDbİsle
    {
        private SqlConnection baglanti;
        private void Baglan()
        {
            baglanti = new SqlConnection(Program.bcumle);
            baglanti.Open();
        }
        public bool kayitekle(UyelerModel liste1)
        {
            Baglan();
            string sql = "INSERT INTO Uyelerr (Kullanici, Sifre, Email, Unvan, Adi_Soyadi, TelefonNo) VALUES (@Kullanici, @Sifre, @Email, @Unvan, @Adi_Soyadi , @TelefonNo)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Kullanici", liste1.Kullanici);
            komut.Parameters.AddWithValue("@Sifre", liste1.Sifre);
            komut.Parameters.AddWithValue("@TelefonNo", liste1.TelefonNo);
            komut.Parameters.AddWithValue("@Unvan", liste1.Unvan);
            komut.Parameters.AddWithValue("@Adi_Soyadi", liste1.Adi_Soyadi);
            komut.Parameters.AddWithValue("@Email", liste1.Email);

            int etkilenen = 0;
            etkilenen = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenen >= 1)

                return true;
            else
                return false;

        }
        public List<UyelerModel> Uyelerigetir()
        { Baglan();
            List<UyelerModel> liste1 = new List<UyelerModel>();
            string sql = "Select * from Uyelerr Order By Kullanici";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adap1 = new SqlDataAdapter(komut);
            DataTable tablo1 = new DataTable();
            adap1.Fill(tablo1);
            baglanti.Close();
            foreach (DataRow kayit in tablo1.Rows)
            {
                liste1.Add(new UyelerModel
                {
                    Id = Convert.ToInt32(kayit["Id"]),
                    Sifre = Convert.ToString(kayit["Sifre"]),
                    TelefonNo = Convert.ToString(kayit["TelefonNo"]),
                    Adi_Soyadi = Convert.ToString(kayit["Adi_Soyadi"]),
                    Unvan = Convert.ToString(kayit["Unvan"]),
                    Kullanici = Convert.ToString(kayit["Kullanici"]),
                    Email = Convert.ToString(kayit["Email"])


                });
            } return liste1;
        }
        public bool? Uyebilgiduzen(UyelerModel liste1)
        {
            try
            {
                Baglan();
                string sql = "UPDATE Uyelerr SET Kullanici=@Kullanici, Sifre=@Sifre, Email=@Email, Unvan=@Unvan, TelefonNo=@TelefonNo, Adi_Soyadi=@Adi_Soyadi WHERE Id=@Id";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@Kullanici", liste1.Kullanici);
                komut.Parameters.AddWithValue("@Adi_Soyadi", liste1.Adi_Soyadi);
                komut.Parameters.AddWithValue("@Unvan", liste1.Unvan);
                komut.Parameters.AddWithValue("@TelefonNo", liste1.TelefonNo);
                komut.Parameters.AddWithValue("@Sifre", liste1.Sifre);
                komut.Parameters.AddWithValue("@Email", liste1.Email);
                komut.Parameters.AddWithValue("@Id", liste1.Id);
                int etkilenen = 0;
                etkilenen = komut.ExecuteNonQuery();
                baglanti.Close();
                if (etkilenen >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Mesajı: " + ex.Message);
                return null;
            }
        }
        public bool Uyesil(int Id)
        {
            Baglan();
            string sql = "DELETE FROM Uyelerr WHERE Id=@Id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Id", Id);
            int etkilenen = 0;
            etkilenen = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenen >= 1)
            { return true; }
            else
                return false;

        }
        public UyelerModel GetUser(string Kullanici, string Sifre)
        {
            Baglan();
            string sql = "SELECT * FROM Uyelerr WHERE Kullanici = @Kullanici AND Sifre = @Sifre";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Kullanici", Kullanici);
            komut.Parameters.AddWithValue("@Sifre", Sifre);

            SqlDataReader reader = komut.ExecuteReader();
            UyelerModel user = null;

            if (reader.Read())
            {
                user = new UyelerModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Kullanici = reader["Kullanici"].ToString(),
                    Sifre = reader["Sifre"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }

            baglanti.Close();

            return user;
        }
        public UyelerModel Detaylar(int Id)
        {
            Baglan();
            string sql = "SELECT * FROM Uyelerr WHERE Id = @Id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = komut.ExecuteReader();
            UyelerModel user = null;

            if (reader.Read())
            {
                user = new UyelerModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Kullanici = reader["Kullanici"].ToString(),
                    TelefonNo = reader["TelefonNo"].ToString(),
                    Unvan = reader["Unvan"].ToString(),
                    Adi_Soyadi = reader["Adi_Soyadi"].ToString(),
                    Sifre = reader["Sifre"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }

            baglanti.Close();

            return user;
        }
        public List<UyelerModel> Kullanicilar()
        {
            Baglan();
            string sql = "SELECT * FROM Uyelerr";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            List<UyelerModel> uyeler = new List<UyelerModel>();
            try
            {
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    UyelerModel uyelerModel = new UyelerModel();
                    uyelerModel.Id = Convert.ToInt32(reader["Id"]);
                    uyelerModel.Kullanici = reader["Kullanici"].ToString();
                    uyelerModel.Unvan = reader["Unvan"].ToString();
                    uyelerModel.Adi_Soyadi = reader["Adi_Soyadi"].ToString();
                    uyelerModel.TelefonNo = reader["TelefonNo"].ToString();
                    uyelerModel.Sifre = reader["Sifre"].ToString();
                    uyelerModel.Email = reader["Email"].ToString();
                    uyeler.Add(uyelerModel);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
            }
            finally
            {
                baglanti.Close();
            }
            return uyeler;
        }
        public void Gorevekle(int? kullaniciId, string gorevAdi, string gorevAciklama, DateTime? DurusmaTarihi, string muvekkil, string davaninDurumu)
        {
            // Kullanıcı ID'si alınamadıysa ekleme işlemi yapılmaz
            if (!kullaniciId.HasValue || kullaniciId.Value == 0)
            {
                // Hata yönetimi burada yapılabilir
                return;
            }

            Baglan();
            string sql = "INSERT INTO Gorevler (KullaniciId, GorevAdi, GorevAciklama, Tarih, DurusmaTarihi, Muvekkil, DavaninDurumu) VALUES (@KullaniciId, @GorevAdi, @GorevAciklama, @Tarih, @DurusmaTarihi, @Muvekkil, @DavaninDurumu)";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            try
            {
                // Yeni bir GorevModel oluştur
                GorevModel yeniGorev = new GorevModel
                {
                    KullaniciId = kullaniciId.Value, // Kullanıcı ID'si nullable olduğundan dolayı Value özelliği kullanılır
                    GorevAdi = gorevAdi,
                    GorevAciklama = gorevAciklama,
                    Tarih = DateTime.Now, // Şuanki zamanı ekle
                    DurusmaTarihi = DurusmaTarihi,
                    Muvekkil = muvekkil,
                    DavaninDurumu = davaninDurumu
                };

                // Parametrelerin eklenmesi
                komut.Parameters.AddWithValue("@KullaniciId", yeniGorev.KullaniciId);
                komut.Parameters.AddWithValue("@GorevAdi", yeniGorev.GorevAdi);
                komut.Parameters.AddWithValue("@GorevAciklama", yeniGorev.GorevAciklama);
                komut.Parameters.AddWithValue("@Tarih", yeniGorev.Tarih);
                komut.Parameters.AddWithValue("@DurusmaTarihi", yeniGorev.DurusmaTarihi);
                komut.Parameters.AddWithValue("@Muvekkil", yeniGorev.Muvekkil);
                komut.Parameters.AddWithValue("@DavaninDurumu", yeniGorev.DavaninDurumu);

                // Komutun çalıştırılması
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<GorevModel> GorevleriGetir(int? Id = null)
        {
            Baglan();
            List<GorevModel> gorevler = new List<GorevModel>();
            string sql = "SELECT * FROM Gorevler";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            try
            {
                
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GorevModel gorev = new GorevModel();
                    gorev.Id = Convert.ToInt32(reader["Id"]);
                    gorev.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                    gorev.GorevAdi = reader["GorevAdi"].ToString();
                    gorev.Muvekkil = reader["Muvekkil"].ToString();
                    gorev.GorevAdi = reader["GorevAdi"].ToString();
                    gorev.GorevAciklama = reader["GorevAciklama"].ToString();
                    gorev.Tarih = Convert.ToDateTime(reader["Tarih"]);
                    gorev.DavaninDurumu = reader["DavaninDurumu"].ToString();
                    gorev.DurusmaTarihi = Convert.ToDateTime(reader["DurusmaTarihi"]);
                    gorevler.Add(gorev);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
            }
            finally
            {
                baglanti.Close();
            }
            return gorevler;
        }
        public bool GorevSil(int Id)
        {
            Baglan();
            string sql = "DELETE FROM Gorevler WHERE Id=@Id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Id", Id);
            int etkilenen = 0;
            etkilenen = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenen >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GorevDuzenle(GorevModel gorev)
        {
            Baglan();
            string sql = "UPDATE Gorevler SET KullaniciId=@KullaniciId, GorevAdi=@GorevAdi, GorevAciklama=@GorevAciklama, Tarih=@Tarih, DurusmaTarihi=@DurusmaTarihi, Muvekkil=@Muvekkil, DavaninDurumu=@DavaninDurumu WHERE Id=@Id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@KullaniciId", gorev.KullaniciId);
            komut.Parameters.AddWithValue("@GorevAdi", gorev.GorevAdi);
            komut.Parameters.AddWithValue("@GorevAciklama", gorev.GorevAciklama);
            komut.Parameters.AddWithValue("@Tarih", gorev.Tarih);
            komut.Parameters.AddWithValue("@DurusmaTarihi", gorev.DurusmaTarihi);
            komut.Parameters.AddWithValue("@Muvekkil", gorev.Muvekkil);
            komut.Parameters.AddWithValue("@DavaninDurumu", gorev.DavaninDurumu);
            komut.Parameters.AddWithValue("@Id", gorev.Id); // Güncellenecek kaydı belirtmek için Id'yi kullanın
            int etkilenen = 0;
            etkilenen = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenen >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<GorevModel> GorevleriGetir2(int KullaniciId)
        {
            Baglan();
            List<GorevModel> gorevler = new List<GorevModel>();
            string sql = "SELECT * FROM Gorevler WHERE KullaniciId = @KullaniciId";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@KullaniciId", KullaniciId);

            try
            {
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    GorevModel gorev = new GorevModel();
                    gorev.Id = Convert.ToInt32(reader["Id"]);
                    gorev.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                    gorev.GorevAdi = reader["GorevAdi"].ToString();
                    gorev.Muvekkil = reader["Muvekkil"].ToString();
                    gorev.GorevAciklama = reader["GorevAciklama"].ToString();
                    gorev.Tarih = Convert.ToDateTime(reader["Tarih"]);
                    gorev.DavaninDurumu = reader["DavaninDurumu"].ToString();
                    gorev.DurusmaTarihi = Convert.ToDateTime(reader["DurusmaTarihi"]);
                    gorevler.Add(gorev);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
            }
            finally
            {
                baglanti.Close();
            }
            return gorevler;
        }




    }
    


}


