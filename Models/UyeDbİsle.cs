using System.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

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
            string sql = "INSERT INTO Uyelerr (Kullanici, Sifre, Email) VALUES (@Kullanici, @Sifre, @Email)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Kullanici", liste1.Kullanici);
            komut.Parameters.AddWithValue("@Sifre", liste1.Sifre);
            komut.Parameters.AddWithValue("@Email", liste1.Email);
            int etkilenen = 0;
            etkilenen=komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenen >= 1)

                return true;
            else 
                return false;

        }
        public List<UyelerModel> Uyelerigetir()
        { Baglan();
         List<UyelerModel> liste1=new List<UyelerModel>();
            string sql = "Select * from Uyelerr Order By Kullanici";
            SqlCommand komut = new SqlCommand( sql, baglanti);
            SqlDataAdapter adap1= new SqlDataAdapter(komut);
            DataTable tablo1=new DataTable();
            adap1.Fill(tablo1);
            baglanti.Close();
            foreach(DataRow kayit in tablo1.Rows)
            {
                liste1.Add(new UyelerModel
                {
                    Id = Convert.ToInt32(kayit["Id"]),
                    Sifre = Convert.ToString(kayit["Sifre"]),
                    Kullanici = Convert.ToString(kayit["Kullanici"]),
                    Email = Convert.ToString(kayit["Email"])


                });
            } return liste1;
        }
        public bool Uyebilgiduzen(UyelerModel liste1)
        {
            Baglan();
            string sql = "UPDATE Uyelerr SET Kullanici=@Kullanici, Sifre=@Sifre, Email=@Email WHERE Id=@Id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Kullanici", liste1.Kullanici);
            komut.Parameters.AddWithValue("@Sifre", liste1.Sifre);
            komut.Parameters.AddWithValue("@Email", liste1.Email);
            komut.Parameters.AddWithValue("@Id", liste1.Id); // Güncellenecek kaydı belirtmek için Id'yi kullanın
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
        public bool Uyesil(int Id)
        { 
            Baglan();
            string sql = "DELETE FROM Uyelerr WHERE Id=@Id";
            SqlCommand komut=new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Id", Id);
            int etkilenen = 0;  
            etkilenen=komut.ExecuteNonQuery();
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
    }
}

