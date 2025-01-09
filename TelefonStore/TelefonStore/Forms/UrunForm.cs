using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonStore.Forms
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            string marka = txtMarka.Text.Trim();
            string model = txtModel.Text.Trim();
            string fiyat = txtFiyat.Text.Trim();
            string imei = txtimei.Text.Trim();
            string kamera = txtKamera.Text.Trim();
            string batarya = txtBatarya.Text.Trim();
            DateTime sonSinyalTarihi = dtpSonSinyalTarihi.Value;

            // Giriş kontrolü (boş alanlar için uyarı)
            if (string.IsNullOrEmpty(marka))
            {
                MessageBox.Show("Marka alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarka.Focus();
                return;
            }

            if (string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Model alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModel.Focus();
                return;
            }

            if (string.IsNullOrEmpty(fiyat) || !decimal.TryParse(fiyat, out _))
            {
                MessageBox.Show("Fiyat alanı boş bırakılamaz ve geçerli bir sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFiyat.Focus();
                return;
            }

            long parsedimei;
            if (string.IsNullOrEmpty(imei) || !long.TryParse(imei, out parsedimei) || parsedimei < 0)
            {
                MessageBox.Show("İMEİ alanı boş bırakılamaz, geçerli bir tam sayı olmalıdır ve negatif değer kabul edilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtimei.Focus();
                return;
            }


            if (string.IsNullOrEmpty(kamera))
            {
                MessageBox.Show("Kamera alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKamera.Focus();
                return;
            }

            if (string.IsNullOrEmpty(batarya))
            {
                MessageBox.Show("Batarya alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBatarya.Focus();
                return;
            }

            // Hattın kapanma tarihi (Son sinyal tarihine 1 yıl eklenir)
            DateTime kapanmaTarihi = sonSinyalTarihi.AddDays(365);

            // Kalan süre hesaplama (gün cinsinden)
            TimeSpan kalanSure = kapanmaTarihi - DateTime.Now;
            int kalanGun = (int)kalanSure.TotalDays; // Gün sayısını tam sayı olarak al

            // Aktiflik durumu belirleme (otomatik olarak hesaplanacak)
            bool aktiflik = kalanGun > 0; // Eğer kalan süre pozitifse aktif, değilse pasif
            int aktiflikDegeri = aktiflik ? 1 : 0; // Aktiflik durumu 1 (aktif) veya 0 (pasif) olacak

            // Durum belirleme ("Açık" ya da "Kapalı")
            string durum = aktiflik ? "Açık" : "Kapalı";

            // App.config'ten bağlantı dizesini okuma
            string connectionString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Veritabanı bağlantı bilgileri bulunamadı. Lütfen bağlantıyı yapılandırın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL INSERT komutu için ürün verilerini ekleme
            string urunQuery = "INSERT INTO Urunler (Marka, Model, Fiyat, imei, Kamera, Batarya, Aktiflik) OUTPUT INSERTED.Id VALUES (@Marka, @Model, @Fiyat, @imei, @Kamera, @Batarya, @Aktiflik)";
            int urunId = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(urunQuery, connection))
                    {
                        // Parametreleri ekleme
                        command.Parameters.AddWithValue("@Marka", marka);
                        command.Parameters.AddWithValue("@Model", model);
                        command.Parameters.AddWithValue("@Fiyat", decimal.TryParse(fiyat, out var parsedFiyat) ? parsedFiyat : 0);
                        command.Parameters.AddWithValue("@imei", parsedimei);
                        command.Parameters.AddWithValue("@Kamera", kamera);
                        command.Parameters.AddWithValue("@Batarya", batarya);
                        command.Parameters.AddWithValue("@Aktiflik", aktiflikDegeri); // Aktiflik değerini ekliyoruz

                        // Ürün kaydını ekleyip, eklenen ürünün ID'sini almak
                        urunId = (int)command.ExecuteScalar();
                    }

                    // SinyalDurumu tablosuna veri ekleme
                    string sinyalDurumuQuery = "INSERT INTO SinyalDurumu (UrunId, SonSinyalTarihi, Durum, KalanSure) VALUES (@UrunId, @SonSinyalTarihi, @Durum, @KalanSure)";

                    using (SqlCommand command = new SqlCommand(sinyalDurumuQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UrunId", urunId);
                        command.Parameters.AddWithValue("@SonSinyalTarihi", sonSinyalTarihi);
                        command.Parameters.AddWithValue("@Durum", durum);
                        command.Parameters.AddWithValue("@KalanSure", kalanGun); // Gün sayısını ekliyoruz

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ürün ve sinyal durumu başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}