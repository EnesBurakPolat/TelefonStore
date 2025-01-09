using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonStore.Forms
{
    public partial class SatisForm : Form
    {
        public SatisForm()
        {
            InitializeComponent();
            SatislariYukle(); // Form açıldığında satışları yükle
        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            int urunID;
            long imei;
            if (!int.TryParse(txtUrunID.Text, out urunID) || !long.TryParse(txtIMEI.Text, out imei))
            {
                MessageBox.Show("Lütfen geçerli bir Ürün ID ve IMEI numarası girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Veritabanı bağlantı bilgileri bulunamadı. Lütfen bağlantıyı yapılandırın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string urunDogrulamaSorgusu = "SELECT COUNT(*) FROM Urunler WHERE ID = @UrunID AND imei = @IMEI"; //Urunler tablosunda, ID sütunu @UrunID ve imei sütunu @IMEI değerlerine eşit olan kayıtların sayısını döndürür.
                    using (SqlCommand command = new SqlCommand(urunDogrulamaSorgusu, connection))
                    {
                        command.Parameters.AddWithValue("@UrunID", urunID);
                        command.Parameters.AddWithValue("@IMEI", imei);
                        int urunVarMi = Convert.ToInt32(command.ExecuteScalar());

                        if (urunVarMi == 0)
                        {
                            MessageBox.Show("Girilen Ürün ID ve IMEI numarası eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    decimal urunFiyati = GetUrunFiyati(urunID);

                    string satisEklemeSorgusu = "INSERT INTO Satislar (UrunID, SatisTarihi, ToplamTutar) VALUES (@UrunID, @SatisTarihi, @ToplamTutar)";
                    using (SqlCommand command = new SqlCommand(satisEklemeSorgusu, connection))
                    {
                        command.Parameters.AddWithValue("@UrunID", urunID);
                        command.Parameters.AddWithValue("@SatisTarihi", DateTime.Now);
                        command.Parameters.AddWithValue("@ToplamTutar", urunFiyati);
                        command.ExecuteNonQuery();
                    }

                    // Veritabanında her iki tablodan tek bir DELETE ile silme işlemi
                    string deleteBothTables = "DELETE FROM SinyalDurumu WHERE UrunID = @UrunID; DELETE FROM Urunler WHERE ID = @UrunID AND imei = @IMEI;";
                    using (SqlCommand command = new SqlCommand(deleteBothTables, connection))
                    {
                        command.Parameters.AddWithValue("@UrunID", urunID);
                        command.Parameters.AddWithValue("@IMEI", imei);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Satış işlemi başarıyla tamamlandı.");
                    SatislariYukle(); // Satış sonrası tabloyu yenile
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetUrunFiyati(int urunID)
        {
            decimal fiyat = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Fiyat FROM Urunler WHERE ID = @UrunID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UrunID", urunID);
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            fiyat = Convert.ToDecimal(result);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün fiyatı alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return fiyat;
        }

        private void SatislariYukle()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VeritabaniBaglantisi"]?.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT \r\n    S.ID AS Satis_No,\r\n    S.UrunID, \r\n    S.SatisTarihi, \r\n    S.ToplamTutar\r\nFROM Satislar S;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSatislar.DataSource = dt; // DataGridView'e veriyi bağla
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satışlar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            SatislariYukle(); // Yenile butonuna basıldığında satışları yeniden yükle
        }
    }
}
