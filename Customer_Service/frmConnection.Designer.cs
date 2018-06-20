namespace Customer_Service
{
    partial class frmConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnection));
            this.pictureBoxConnect = new System.Windows.Forms.PictureBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxConnect
            // 
            this.pictureBoxConnect.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxConnect.Image")));
            this.pictureBoxConnect.Location = new System.Drawing.Point(530, 154);
            this.pictureBoxConnect.Name = "pictureBoxConnect";
            this.pictureBoxConnect.Size = new System.Drawing.Size(105, 199);
            this.pictureBoxConnect.TabIndex = 0;
            this.pictureBoxConnect.TabStop = false;
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(89, 154);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(100, 23);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Server";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(89, 201);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(100, 23);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(89, 248);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 23);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "User";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPass
            // 
            this.lblPass.Location = new System.Drawing.Point(89, 294);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(100, 23);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Password";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(285, 117);
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(227, 154);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(227, 22);
            this.txtServer.TabIndex = 6;
            this.txtServer.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(227, 201);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(227, 22);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "3306";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(227, 248);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(227, 22);
            this.txtUser.TabIndex = 8;
            this.txtUser.Text = "root";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(227, 294);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(227, 22);
            this.txtPass.TabIndex = 9;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(184, 367);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(113, 45);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.MouseHover += new System.EventHandler(this.btnConnect_MouseHover);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(371, 367);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(113, 45);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            this.btnDisconnect.MouseHover += new System.EventHandler(this.btnDisconnect_MouseHover);
            // 
            // frmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(685, 469);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.pictureBoxConnect);
            this.Name = "frmConnection";
            this.Text = "frmConnection";
            this.Load += new System.EventHandler(this.frmConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxConnect;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
    }
}