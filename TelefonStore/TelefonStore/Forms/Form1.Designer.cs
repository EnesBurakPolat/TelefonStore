using System.Drawing;
using System.Windows.Forms;

namespace TelefonStore
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.Button btnUrunYonetimi;
        private System.Windows.Forms.Button btnSatisYonetimi;
        private System.Windows.Forms.Button btnSinyalDurumu;




        private System.Windows.Forms.Button btnYenile;

        private System.Windows.Forms.Button btnVeritabaniBaglan;

        //DARK MODE
        private System.Windows.Forms.Button btnDarkMode;           // Koyu mod renkleri
        Color darkBackgroundColor = Color.Black; // Koyu arka plan
        //Color darkBackgroundColor = Color.FromArgb(30, 30, 30); // Koyu arka plan
        Color darkTextColor = Color.White; // Beyaz metin
        Color darkButtonColor = Color.FromArgb(50, 50, 50); // Koyu buton arka planı
        Color darkButtonTextColor = Color.White; // Buton metin rengi



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.btnUrunYonetimi = new System.Windows.Forms.Button();
            this.btnSatisYonetimi = new System.Windows.Forms.Button();
            this.btnSinyalDurumu = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnVeritabaniBaglan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();

            //BU OLMADAN BASMIYOR FORMA GİTMİYOR
            this.btnSinyalDurumu.Click += new System.EventHandler(this.btnSinyalDurumu_Click);
            this.btnUrunYonetimi.Click += new System.EventHandler(this.btnUrunYonetimi_Click);
            this.btnSatisYonetimi.Click += new System.EventHandler(this.btnSatisYonetimi_Click);


            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(970, 381);
            this.Controls.Add(this.dgvUrunler);
            this.Controls.Add(this.btnUrunYonetimi);
            this.Controls.Add(this.btnSatisYonetimi);
            this.Controls.Add(this.btnSinyalDurumu);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnVeritabaniBaglan);
            this.Name = "Form1";
            this.Text = "Cep Telefonu Satış Mağazası Yönetim Sistemi";
            this.StartPosition = FormStartPosition.CenterScreen; // Başlangıç pozisyonu
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);


            // 
            // dgvUrunler
            // 
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(12, 12);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.Size = new System.Drawing.Size(945, 300);
            this.dgvUrunler.TabIndex = 0;

            this.dgvUrunler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right));

            // 
            // btnUrunYonetimi
            // 
            this.btnUrunYonetimi.Location = new System.Drawing.Point(12, 320);
            this.btnUrunYonetimi.Name = "btnUrunYonetimi";
            this.btnUrunYonetimi.Size = new System.Drawing.Size(200, 40);
            this.btnUrunYonetimi.TabIndex = 1;
            this.btnUrunYonetimi.Text = "Ürün Ekle";
            this.btnUrunYonetimi.UseVisualStyleBackColor = true;

            this.btnUrunYonetimi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            // 
            // btnSatisYonetimi
            // 
            this.btnSatisYonetimi.Location = new System.Drawing.Point(220, 320);
            this.btnSatisYonetimi.Name = "btnSatisYonetimi";
            this.btnSatisYonetimi.Size = new System.Drawing.Size(200, 40);
            this.btnSatisYonetimi.TabIndex = 2;
            this.btnSatisYonetimi.Text = "Satış";
            this.btnSatisYonetimi.UseVisualStyleBackColor = true;

            this.btnSatisYonetimi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            // 
            // btnSinyalDurumu
            // 
            this.btnSinyalDurumu.Location = new System.Drawing.Point(430, 320);
            this.btnSinyalDurumu.Name = "btnSinyalDurumu";
            this.btnSinyalDurumu.Size = new System.Drawing.Size(200, 40);
            this.btnSinyalDurumu.TabIndex = 3;
            this.btnSinyalDurumu.Text = "Sinyal Durumu";
            this.btnSinyalDurumu.UseVisualStyleBackColor = true;

            this.btnSinyalDurumu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(773, 320);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 40);
            this.btnYenile.TabIndex = 4;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);

            this.btnYenile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            // 
            // btnVeritabaniBaglan
            // 
            this.btnVeritabaniBaglan.Location = new System.Drawing.Point(653, 320);
            this.btnVeritabaniBaglan.Name = "btnVeritabaniBaglan";
            this.btnVeritabaniBaglan.Size = new System.Drawing.Size(100, 40);
            this.btnVeritabaniBaglan.TabIndex = 0;
            this.btnVeritabaniBaglan.Text = "DB Bağlan";
            this.btnVeritabaniBaglan.Click += new System.EventHandler(this.btnVeritabaniBaglan_Click);
            // Butonun rengini kırmızı yapma
            this.btnVeritabaniBaglan.BackColor = System.Drawing.Color.Red;

            this.btnVeritabaniBaglan.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;


            //DARK MODE
            this.btnDarkMode = new System.Windows.Forms.Button();
            // 
            // btnDarkMode
            // 
            this.btnDarkMode.Location = new System.Drawing.Point(896, 320); // Butonun konumunu
            this.btnDarkMode.Name = "btnDarkMode";
            this.btnDarkMode.Size = new System.Drawing.Size(60, 40);
            this.btnDarkMode.TabIndex = 5;
            this.btnDarkMode.Text = "Dark Mode";
            this.btnDarkMode.UseVisualStyleBackColor = true;
            this.btnDarkMode.Click += new System.EventHandler(this.btnDarkMode_Click);
            this.Controls.Add(this.btnDarkMode);

            this.btnDarkMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;


        }

    }
}
