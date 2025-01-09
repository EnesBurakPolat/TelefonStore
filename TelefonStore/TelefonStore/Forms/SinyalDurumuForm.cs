using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonStore.Forms
{
    public partial class SinyalDurumuForm : Form
    {
        public SinyalDurumuForm()
        {
            InitializeComponent();
        }

        private void btnKontrolEt_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcının girdiği Ürün ID'yi al
                string urunID = txtUrunID.Text.Trim();

                if (string.IsNullOrEmpty(urunID))
                {
                    MessageBox.Show("Lütfen bir Ürün ID giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // App.config'ten bağlantı dizesini okuma
                string connectionString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;

                // SQL sorgusunu güncelleme
                string query = "SELECT UrunID, SonSinyalTarihi FROM SinyalDurumu WHERE UrunID = @UrunID"; // belirtilen ürün ID'sine (UrunID) ait son sinyal tarihini (SonSinyalTarihi) getirir

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunID", urunID);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string urunId = reader["UrunID"].ToString();
                        DateTime sonSinyalTarihi = Convert.ToDateTime(reader["SonSinyalTarihi"]);
                        DateTime bugun = DateTime.Now;

                        // Kalan süreyi hesaplama
                        int kalanGun = (sonSinyalTarihi.AddYears(1) - bugun).Days;
                        string durum = kalanGun > 0 ? "Açık" : "Kapalı";

                        // Sonucu göster
                        dgvSinyalDurumu.DataSource = null; // Eski veriyi temizleme
                        dgvSinyalDurumu.Rows.Clear(); // Tabloda sıfırlama
                        dgvSinyalDurumu.Columns.Clear();

                        // Sütunları ekleme
                        dgvSinyalDurumu.Columns.Add("KalanSure", "Kalan Süre (Gün)");
                        dgvSinyalDurumu.Columns.Add("Durum", "Durum");
                        dgvSinyalDurumu.Columns.Add("SonSinyalTarihi", "Son Sinyal Tarihi");
                        dgvSinyalDurumu.Columns.Add("UrunID", "Ürün ID");

                        // Satır ekleme
                        dgvSinyalDurumu.Rows.Add(kalanGun+1, durum, sonSinyalTarihi.ToShortDateString(), urunId);
                    }
                    else
                    {
                        MessageBox.Show("Girilen Ürün ID için veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
