using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TelefonStore.Forms
{
    public partial class VeritabaniBaglantiForm : Form
    {
        // Event tanımı
        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

        public VeritabaniBaglantiForm()
        {
            InitializeComponent();
        }

        private void btnVeritabaniBaglan_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";

            // Bağlantıyı kontrol et
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Veritabanına başarıyla bağlanıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Bağlantı başarılı, buton rengini yeşil yap
                    btnVeritabaniBaglan.BackColor = System.Drawing.Color.Green;

                    // Bağlantı başarılı, App.config'e kaydet
                    SaveConnectionString(connectionString);

                    // Bağlantı başarılı olduğunda olayı tetikle
                    ConnectionStatusChanged?.Invoke(this, new ConnectionStatusEventArgs { IsConnected = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bağlantı sırasında bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Bağlantı başarısız, buton rengini kırmızı yap
                    btnVeritabaniBaglan.BackColor = System.Drawing.Color.Red;

                    // Bağlantı başarısız olduğunda olayı tetikle
                    ConnectionStatusChanged?.Invoke(this, new ConnectionStatusEventArgs { IsConnected = false });
                }
            }
        }

        // Bağlantı Dizgesini App.config'e Kaydet
        private void SaveConnectionString(string connectionString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["VeritabaniBaglantisi"].ConnectionString = connectionString;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }

    // Yeni olay argümanı sınıfı
    public class ConnectionStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
    }
}
