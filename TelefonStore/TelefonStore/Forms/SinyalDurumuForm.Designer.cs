namespace TelefonStore.Forms
{
    partial class SinyalDurumuForm
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
            this.lblUrunID = new System.Windows.Forms.Label();
            this.txtUrunID = new System.Windows.Forms.TextBox();
            this.btnKontrolEt = new System.Windows.Forms.Button();
            this.dgvSinyalDurumu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinyalDurumu)).BeginInit();
            this.SuspendLayout();

            // 
            // lblUrunID
            // 
            this.lblUrunID.AutoSize = true;
            this.lblUrunID.Location = new System.Drawing.Point(20, 20);
            this.lblUrunID.Name = "lblUrunID";
            this.lblUrunID.Size = new System.Drawing.Size(50, 13);
            this.lblUrunID.TabIndex = 0;
            this.lblUrunID.Text = "Ürün ID:";

            // 
            // txtUrunID
            // 
            this.txtUrunID.Location = new System.Drawing.Point(100, 20);
            this.txtUrunID.Name = "txtUrunID";
            this.txtUrunID.Size = new System.Drawing.Size(200, 20);
            this.txtUrunID.TabIndex = 1;

            // 
            // btnKontrolEt
            // 
            this.btnKontrolEt.Location = new System.Drawing.Point(100, 60);
            this.btnKontrolEt.Name = "btnKontrolEt";
            this.btnKontrolEt.Size = new System.Drawing.Size(75, 23);
            this.btnKontrolEt.TabIndex = 2;
            this.btnKontrolEt.Text = "Kontrol Et";
            this.btnKontrolEt.UseVisualStyleBackColor = true;
            this.btnKontrolEt.Click += new System.EventHandler(this.btnKontrolEt_Click);

            // 
            // dgvSinyalDurumu
            // 
            this.dgvSinyalDurumu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinyalDurumu.Location = new System.Drawing.Point(20, 100);
            this.dgvSinyalDurumu.Name = "dgvSinyalDurumu";
            this.dgvSinyalDurumu.Size = new System.Drawing.Size(457, 150);
            this.dgvSinyalDurumu.TabIndex = 3;

            // 
            // SinyalDurumuForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.lblUrunID);
            this.Controls.Add(this.txtUrunID);
            this.Controls.Add(this.btnKontrolEt);
            this.Controls.Add(this.dgvSinyalDurumu);
            this.Name = "SinyalDurumuForm";
            this.Text = "Sinyal Durumu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinyalDurumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUrunID;
        private System.Windows.Forms.TextBox txtUrunID;
        private System.Windows.Forms.Button btnKontrolEt;
        private System.Windows.Forms.DataGridView dgvSinyalDurumu;

    }
}
