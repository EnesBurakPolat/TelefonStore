using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TelefonStore.Forms;

namespace TelefonStore
{
    public partial class Form1 : Form
    {
       
        private string connString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // Form yüklenirken bağlantı kontrolü yapılacak
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckDatabaseConnection(); // Veritabanı bağlantısını kontrol et
        }


        private void CheckDatabaseConnection()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    btnVeritabaniBaglan.BackColor = System.Drawing.Color.Green; // Bağlantı başarılı
                }
                catch
                {
                    btnVeritabaniBaglan.BackColor = System.Drawing.Color.Red; // Bağlantı başarısız
                }
            }
        }

        private void btnVeritabaniBaglan_Click(object sender, EventArgs e)
        {
            VeritabaniBaglantiForm veritabaniForm = new VeritabaniBaglantiForm();
            veritabaniForm.ConnectionStatusChanged += VeritabaniForm_ConnectionStatusChanged;
            veritabaniForm.ShowDialog(); // Modallik sağlar, form kapanana kadar diğer formlar erişilemez.
        }

        private void VeritabaniForm_ConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
        {
            if (e.IsConnected)
            {
                btnVeritabaniBaglan.BackColor = System.Drawing.Color.Green; // Bağlantı başarılı
            }
            else
            {
                btnVeritabaniBaglan.BackColor = System.Drawing.Color.Red; // Bağlantı başarısız
            }
        }

        private void btnUrunYonetimi_Click(object sender, EventArgs e)
        {
            try
            {
                UrunForm urunForm = new UrunForm();
                urunForm.Show();  // Formu göster
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Form Açma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSatisYonetimi_Click(object sender, EventArgs e)
        {
            try
            {
                SatisForm satisForm = new SatisForm();
                satisForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Form Açma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSinyalDurumu_Click(object sender, EventArgs e)
        {
            try
            {
                SinyalDurumuForm sinyalForm = new SinyalDurumuForm();
                sinyalForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Form Açma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            try
            {
                // App.config'ten bağlantı dizesini alma
                string connectionString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("Veritabanı bağlantı bilgileri bulunamadı. Lütfen bağlantıyı yapılandırın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL tarafında kalan süreyi hesaplayıp güncelleme işlemi
                UpdateKalanSureInDatabase(connectionString);

                // Veritabanındaki Urunler tablosundaki ürünleri çekme
                DataTable urunler = GetUrunler(connectionString);

                if (urunler == null || urunler.Rows.Count == 0)
                {
                    MessageBox.Show("Ürün verileri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Veri kaynağını güncelleme
                if (dgvUrunler.DataSource is DataTable mevcutVeriKaynagi)
                {
                    mevcutVeriKaynagi.Clear();
                    mevcutVeriKaynagi.Merge(urunler);
                }
                else
                {
                    dgvUrunler.DataSource = urunler;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yenileme sırasında hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SQL tarafında kalan süreyi güncelleyen metod
        private void UpdateKalanSureInDatabase(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = @"
                UPDATE SinyalDurumu
                SET KalanSure = DATEDIFF(DAY, GETDATE(), DATEADD(DAY, 365, SonSinyalTarihi))
                WHERE SonSinyalTarihi IS NOT NULL
            ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kalan süre güncellenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Veritabanından veri çekme
        private DataTable GetUrunler(string connectionString)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(@"
        SELECT
            U.ID AS UrunID,
            U.Marka,
            U.Model,
            U.Fiyat,
            U.imei,
            U.Batarya,
            U.Kamera,
            CASE
                WHEN SD.SonSinyalTarihi IS NULL THEN 'Bilinmiyor'
                WHEN DATEDIFF(DAY, GETDATE(), DATEADD(DAY, 365, SD.SonSinyalTarihi)) > 0 THEN 'Açık'
                ELSE 'Kapalı'
            END AS Durum,
            ISNULL(DATEDIFF(DAY, GETDATE(), DATEADD(DAY, 365, SD.SonSinyalTarihi)), 0) AS KalanSure
        FROM Urunler U
        LEFT JOIN SinyalDurumu SD ON U.ID = SD.UrunID;
    ", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return dt;
        }


        //DARK MODE
        private bool isDarkMode = false;

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                // Normal moda geçiş
                this.BackColor = Color.White;

                foreach (Control control in this.Controls)
                {
                    if (control != btnVeritabaniBaglan)
                    {
                        control.BackColor = Color.White;
                        control.ForeColor = Color.Black;

                        if (control is Button)
                        {
                            control.BackColor = Color.LightGray;
                            control.ForeColor = Color.Black;
                        }
                    }
                }

                // DataGridView için normal mod renkleri
                dgvUrunler.BackgroundColor = Color.White;
                dgvUrunler.DefaultCellStyle.BackColor = Color.White;
                dgvUrunler.DefaultCellStyle.ForeColor = Color.Black;
                dgvUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgvUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                // Koyu moda geçiş
                this.BackColor = darkBackgroundColor;

                foreach (Control control in this.Controls)
                {
                    if (control != btnVeritabaniBaglan)
                    {
                        control.BackColor = darkBackgroundColor;
                        control.ForeColor = darkTextColor;

                        if (control is Button)
                        {
                            control.BackColor = darkButtonColor;
                            control.ForeColor = darkButtonTextColor;
                        }
                    }
                }

                // DataGridView için koyu mod renkleri
                dgvUrunler.BackgroundColor = Color.FromArgb(30, 30, 30);
                dgvUrunler.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                dgvUrunler.DefaultCellStyle.ForeColor = Color.White;
                dgvUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Koyu gri
                dgvUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }

            isDarkMode = !isDarkMode;
        }






    }
}
