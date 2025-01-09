namespace TelefonStore.Forms
{
    partial class VeritabaniBaglantiForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnVeritabaniBaglan;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;

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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnVeritabaniBaglan = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // txtServer
            this.txtServer.Location = new System.Drawing.Point(150, 30);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(200, 20);
            this.txtServer.TabIndex = 0;

            // lblServer
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(50, 33);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(65, 13);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Sunucu Adı:";

            // txtDatabase
            this.txtDatabase.Location = new System.Drawing.Point(150, 70);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(200, 20);
            this.txtDatabase.TabIndex = 2;

            // lblDatabase
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(50, 73);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(74, 13);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Text = "Veritabanı Adı:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(150, 110);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 4;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(50, 113);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Kullanıcı Adı:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(150, 150);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 153);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(39, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Parola:";

            // btnVeritabaniBaglan
            this.btnVeritabaniBaglan.Location = new System.Drawing.Point(150, 190);
            this.btnVeritabaniBaglan.Name = "btnVeritabaniBaglan";
            this.btnVeritabaniBaglan.Size = new System.Drawing.Size(100, 30);
            this.btnVeritabaniBaglan.TabIndex = 8;
            this.btnVeritabaniBaglan.Text = "Bağlan";
            this.btnVeritabaniBaglan.UseVisualStyleBackColor = true;
            this.btnVeritabaniBaglan.Click += new System.EventHandler(this.btnVeritabaniBaglan_Click);

            // VeritabaniBaglantiForm
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnVeritabaniBaglan);
            this.Name = "VeritabaniBaglantiForm";
            this.Text = "Veritabanı Bağlantı Formu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
