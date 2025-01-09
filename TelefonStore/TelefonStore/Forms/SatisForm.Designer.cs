namespace TelefonStore.Forms
{
    partial class SatisForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSatislar;
        private System.Windows.Forms.Button btnYenile;

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
            this.lblIMEI = new System.Windows.Forms.Label();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.btnSatisYap = new System.Windows.Forms.Button();
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.btnYenile = new System.Windows.Forms.Button();

            // 
            // lblUrunID
            // 
            this.lblUrunID.AutoSize = true;
            this.lblUrunID.Location = new System.Drawing.Point(20, 20);
            this.lblUrunID.Name = "lblUrunID";
            this.lblUrunID.Size = new System.Drawing.Size(50, 13);
            this.lblUrunID.Text = "Ürün ID:";
            // 
            // txtUrunID
            // 
            this.txtUrunID.Location = new System.Drawing.Point(100, 20);
            this.txtUrunID.Name = "txtUrunID";
            this.txtUrunID.Size = new System.Drawing.Size(200, 20);
            // 
            // lblIMEI
            // 
            this.lblIMEI.AutoSize = true;
            this.lblIMEI.Location = new System.Drawing.Point(20, 60);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(34, 13);
            this.lblIMEI.Text = "IMEI:";
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(100, 60);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.Size = new System.Drawing.Size(200, 20);
            // 
            // btnSatisYap
            // 
            this.btnSatisYap.Location = new System.Drawing.Point(100, 100);
            this.btnSatisYap.Name = "btnSatisYap";
            this.btnSatisYap.Size = new System.Drawing.Size(75, 23);
            this.btnSatisYap.Text = "Satış Yap";
            this.btnSatisYap.Click += new System.EventHandler(this.btnSatisYap_Click);
            // 
            // dgvSatislar
            // 
            this.dgvSatislar.Location = new System.Drawing.Point(20, 140);
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.Size = new System.Drawing.Size(400, 200);
            this.dgvSatislar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(320, 100);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 23);
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // SatisForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.lblUrunID);
            this.Controls.Add(this.txtUrunID);
            this.Controls.Add(this.lblIMEI);
            this.Controls.Add(this.txtIMEI);
            this.Controls.Add(this.btnSatisYap);
            this.Controls.Add(this.dgvSatislar);
            this.Controls.Add(this.btnYenile);
            this.Text = "Satış Yönetimi";
        }

        private System.Windows.Forms.Label lblUrunID;
        private System.Windows.Forms.TextBox txtUrunID;
        private System.Windows.Forms.Label lblIMEI;
        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.Button btnSatisYap;
    }
}
