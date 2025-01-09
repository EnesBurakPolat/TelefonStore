namespace TelefonStore.Forms
{
    partial class UrunForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblMarka = new System.Windows.Forms.Label();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.lblimei = new System.Windows.Forms.Label();
            this.txtimei = new System.Windows.Forms.TextBox();
            this.lblKamera = new System.Windows.Forms.Label();
            this.txtKamera = new System.Windows.Forms.TextBox();
            this.lblBatarya = new System.Windows.Forms.Label();
            this.txtBatarya = new System.Windows.Forms.TextBox();
            this.lblSonSinyalTarihi = new System.Windows.Forms.Label();
            this.dtpSonSinyalTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new System.Windows.Forms.Button();

            // 
            // lblMarka
            // 
            this.lblMarka.AutoSize = true;
            this.lblMarka.Location = new System.Drawing.Point(12, 15);
            this.lblMarka.Name = "lblMarka";
            this.lblMarka.Size = new System.Drawing.Size(40, 15);
            this.lblMarka.TabIndex = 0;
            this.lblMarka.Text = "Marka:";

            // 
            // txtMarka
            // 
            this.txtMarka.Location = new System.Drawing.Point(120, 12);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(215, 23);
            this.txtMarka.TabIndex = 1;

            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(12, 45);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 15);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model:";

            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(120, 42);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(215, 23);
            this.txtModel.TabIndex = 3;

            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Location = new System.Drawing.Point(12, 75);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(34, 15);
            this.lblFiyat.TabIndex = 4;
            this.lblFiyat.Text = "Fiyat:";

            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(120, 72);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(215, 23);
            this.txtFiyat.TabIndex = 5;

            // 
            // lblimei
            // 
            this.lblimei.AutoSize = true;
            this.lblimei.Location = new System.Drawing.Point(12, 105);
            this.lblimei.Name = "lblimei";
            this.lblimei.Size = new System.Drawing.Size(34, 15);
            this.lblimei.TabIndex = 6;
            this.lblimei.Text = "IMEI:";

            // 
            // txtimei
            // 
            this.txtimei.Location = new System.Drawing.Point(120, 102);
            this.txtimei.Name = "txtimei";
            this.txtimei.Size = new System.Drawing.Size(215, 23);
            this.txtimei.TabIndex = 7;

            // 
            // lblKamera
            // 
            this.lblKamera.AutoSize = true;
            this.lblKamera.Location = new System.Drawing.Point(12, 135);
            this.lblKamera.Name = "lblKamera";
            this.lblKamera.Size = new System.Drawing.Size(48, 15);
            this.lblKamera.TabIndex = 8;
            this.lblKamera.Text = "Kamera:";

            // 
            // txtKamera
            // 
            this.txtKamera.Location = new System.Drawing.Point(120, 132);
            this.txtKamera.Name = "txtKamera";
            this.txtKamera.Size = new System.Drawing.Size(215, 23);
            this.txtKamera.TabIndex = 9;

            // 
            // lblBatarya
            // 
            this.lblBatarya.AutoSize = true;
            this.lblBatarya.Location = new System.Drawing.Point(12, 165);
            this.lblBatarya.Name = "lblBatarya";
            this.lblBatarya.Size = new System.Drawing.Size(50, 15);
            this.lblBatarya.TabIndex = 10;
            this.lblBatarya.Text = "Batarya:";

            // 
            // txtBatarya
            // 
            this.txtBatarya.Location = new System.Drawing.Point(120, 162);
            this.txtBatarya.Name = "txtBatarya";
            this.txtBatarya.Size = new System.Drawing.Size(215, 23);
            this.txtBatarya.TabIndex = 11;

            // 
            // lblSonSinyalTarihi
            // 
            this.lblSonSinyalTarihi.AutoSize = true;
            this.lblSonSinyalTarihi.Location = new System.Drawing.Point(12, 195);
            this.lblSonSinyalTarihi.Name = "lblSonSinyalTarihi";
            this.lblSonSinyalTarihi.Size = new System.Drawing.Size(98, 15);
            this.lblSonSinyalTarihi.TabIndex = 12;
            this.lblSonSinyalTarihi.Text = "Son Sinyal Tarihi:";

            // 
            // dtpSonSinyalTarihi
            // 
            this.dtpSonSinyalTarihi.Location = new System.Drawing.Point(120, 192);
            this.dtpSonSinyalTarihi.Name = "dtpSonSinyalTarihi";
            this.dtpSonSinyalTarihi.Size = new System.Drawing.Size(215, 23);
            this.dtpSonSinyalTarihi.TabIndex = 13;

            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(120, 230);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // Form özellikleri
            this.ClientSize = new System.Drawing.Size(356, 280);
            this.Controls.Add(this.lblMarka);
            this.Controls.Add(this.txtMarka);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblFiyat);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.lblimei);
            this.Controls.Add(this.txtimei);
            this.Controls.Add(this.lblKamera);
            this.Controls.Add(this.txtKamera);
            this.Controls.Add(this.lblBatarya);
            this.Controls.Add(this.txtBatarya);
            this.Controls.Add(this.lblSonSinyalTarihi);
            this.Controls.Add(this.dtpSonSinyalTarihi);
            this.Controls.Add(this.btnKaydet);
            this.Name = "UrunForm";
            this.Text = "Ürün Formu";

        }

        private System.Windows.Forms.Label lblMarka;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Label lblimei;
        private System.Windows.Forms.TextBox txtimei;
        private System.Windows.Forms.Label lblKamera;
        private System.Windows.Forms.TextBox txtKamera;
        private System.Windows.Forms.Label lblBatarya;
        private System.Windows.Forms.TextBox txtBatarya;
        private System.Windows.Forms.Label lblSonSinyalTarihi;
        private System.Windows.Forms.DateTimePicker dtpSonSinyalTarihi;
        private System.Windows.Forms.Button btnKaydet;
    }
}
