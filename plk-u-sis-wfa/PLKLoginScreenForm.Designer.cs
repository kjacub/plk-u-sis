namespace plk_u_sis_wfa
{
    partial class PLKLoginScreenForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLKLoginScreenForm));
            pnlAdminUnder = new Panel();
            pnlHeader = new Panel();
            lblUni = new Label();
            lblPLKU = new Label();
            pbLogo = new PictureBox();
            btnSignIn = new Button();
            txtAdminId = new TextBox();
            picAdminIcon = new PictureBox();
            pnlLoginField = new Panel();
            panel1 = new Panel();
            btnLogInn = new Button();
            pnlUnder = new Panel();
            pnlPasswordUnder = new Panel();
            pnlPassword = new Panel();
            txtPasswordField = new TextBox();
            pbPasswordIcon = new PictureBox();
            txtAdminIdField = new TextBox();
            pnlAdminId = new Panel();
            pbAdminIcon = new PictureBox();
            lblAdminId = new Label();
            lblPassword = new Label();
            pnlLogin = new Panel();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAdminIcon).BeginInit();
            pnlLoginField.SuspendLayout();
            pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPasswordIcon).BeginInit();
            pnlAdminId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAdminIcon).BeginInit();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAdminUnder
            // 
            pnlAdminUnder.BackColor = Color.FromArgb(137, 35, 91);
            pnlAdminUnder.Location = new Point(0, 0);
            pnlAdminUnder.Name = "pnlAdminUnder";
            pnlAdminUnder.Size = new Size(261, 2);
            pnlAdminUnder.TabIndex = 12;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.BackgroundImageLayout = ImageLayout.Center;
            pnlHeader.Controls.Add(lblUni);
            pnlHeader.Controls.Add(lblPLKU);
            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Location = new Point(48, 26);
            pnlHeader.Margin = new Padding(4, 3, 4, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(774, 133);
            pnlHeader.TabIndex = 7;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblUni
            // 
            lblUni.AutoSize = true;
            lblUni.BackColor = Color.Transparent;
            lblUni.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUni.ForeColor = Color.FromArgb(137, 35, 91);
            lblUni.Location = new Point(316, 70);
            lblUni.Name = "lblUni";
            lblUni.Size = new Size(174, 36);
            lblUni.TabIndex = 8;
            lblUni.Text = "PRINCESS LEIGH KATE\r\nUNIVERSITY\r\n";
            lblUni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPLKU
            // 
            lblPLKU.AutoSize = true;
            lblPLKU.BackColor = Color.Transparent;
            lblPLKU.Font = new Font("Constantia", 37.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPLKU.ForeColor = Color.FromArgb(137, 35, 91);
            lblPLKU.Location = new Point(305, 8);
            lblPLKU.Name = "lblPLKU";
            lblPLKU.Size = new Size(202, 77);
            lblPLKU.TabIndex = 7;
            lblPLKU.Text = "PLKU";
            lblPLKU.Click += lblPLKU_Click;
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.Transparent;
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(184, -11);
            pbLogo.Margin = new Padding(4, 3, 4, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(144, 133);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(0, 0);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(75, 23);
            btnSignIn.TabIndex = 8;
            // 
            // txtAdminId
            // 
            txtAdminId.BackColor = Color.FromArgb(255, 202, 228);
            txtAdminId.Location = new Point(38, 128);
            txtAdminId.Margin = new Padding(4, 3, 4, 3);
            txtAdminId.Name = "txtAdminId";
            txtAdminId.Size = new Size(250, 28);
            txtAdminId.TabIndex = 5;
            // 
            // picAdminIcon
            // 
            picAdminIcon.Location = new Point(0, 0);
            picAdminIcon.Name = "picAdminIcon";
            picAdminIcon.Size = new Size(100, 50);
            picAdminIcon.TabIndex = 7;
            picAdminIcon.TabStop = false;
            // 
            // pnlLoginField
            // 
            pnlLoginField.BackColor = Color.Transparent;
            pnlLoginField.BackgroundImageLayout = ImageLayout.Zoom;
            pnlLoginField.Controls.Add(panel1);
            pnlLoginField.Controls.Add(btnLogInn);
            pnlLoginField.Controls.Add(pnlUnder);
            pnlLoginField.Controls.Add(pnlPasswordUnder);
            pnlLoginField.Controls.Add(pnlPassword);
            pnlLoginField.Controls.Add(txtAdminIdField);
            pnlLoginField.Controls.Add(pnlAdminId);
            pnlLoginField.Controls.Add(lblAdminId);
            pnlLoginField.Controls.Add(lblPassword);
            pnlLoginField.ForeColor = Color.White;
            pnlLoginField.Location = new Point(-2, -2);
            pnlLoginField.Margin = new Padding(4, 3, 4, 3);
            pnlLoginField.Name = "pnlLoginField";
            pnlLoginField.Size = new Size(774, 395);
            pnlLoginField.TabIndex = 6;
            pnlLoginField.Paint += pnlLoginField_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(137, 35, 91);
            panel1.Location = new Point(65, 162);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 2);
            panel1.TabIndex = 17;
            // 
            // btnLogInn
            // 
            btnLogInn.BackColor = Color.FromArgb(137, 35, 91);
            btnLogInn.FlatStyle = FlatStyle.Flat;
            btnLogInn.Font = new Font("Constantia", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogInn.Location = new Point(65, 262);
            btnLogInn.Name = "btnLogInn";
            btnLogInn.Size = new Size(263, 40);
            btnLogInn.TabIndex = 13;
            btnLogInn.Text = "LOGIN";
            btnLogInn.UseVisualStyleBackColor = false;
            btnLogInn.Click += btnLogIn_Click;
            // 
            // pnlUnder
            // 
            pnlUnder.BackColor = Color.FromArgb(137, 35, 91);
            pnlUnder.Location = new Point(65, 254);
            pnlUnder.Name = "pnlUnder";
            pnlUnder.Size = new Size(261, 2);
            pnlUnder.TabIndex = 12;
            pnlUnder.Paint += pnlUnder_Paint_1;
            // 
            // pnlPasswordUnder
            // 
            pnlPasswordUnder.BackColor = Color.FromArgb(137, 35, 91);
            pnlPasswordUnder.Location = new Point(65, 240);
            pnlPasswordUnder.Name = "pnlPasswordUnder";
            pnlPasswordUnder.Size = new Size(261, 2);
            pnlPasswordUnder.TabIndex = 10;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.FromArgb(255, 202, 228);
            pnlPassword.Controls.Add(txtPasswordField);
            pnlPassword.Controls.Add(pbPasswordIcon);
            pnlPassword.Location = new Point(65, 202);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(261, 39);
            pnlPassword.TabIndex = 9;
            pnlPassword.Paint += panel2_Paint;
            // 
            // txtPasswordField
            // 
            txtPasswordField.BackColor = Color.White;
            txtPasswordField.BorderStyle = BorderStyle.None;
            txtPasswordField.Cursor = Cursors.IBeam;
            txtPasswordField.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPasswordField.Location = new Point(8, 9);
            txtPasswordField.Margin = new Padding(4, 3, 4, 3);
            txtPasswordField.Name = "txtPasswordField";
            txtPasswordField.PasswordChar = '*';
            txtPasswordField.Size = new Size(217, 21);
            txtPasswordField.TabIndex = 17;
            // 
            // pbPasswordIcon
            // 
            pbPasswordIcon.BackColor = Color.Transparent;
            pbPasswordIcon.Image = (Image)resources.GetObject("pbPasswordIcon.Image");
            pbPasswordIcon.Location = new Point(230, 2);
            pbPasswordIcon.Margin = new Padding(4, 3, 4, 3);
            pbPasswordIcon.Name = "pbPasswordIcon";
            pbPasswordIcon.Size = new Size(25, 35);
            pbPasswordIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbPasswordIcon.TabIndex = 1;
            pbPasswordIcon.TabStop = false;
            pbPasswordIcon.Click += pictureBox1_Click;
            // 
            // txtAdminIdField
            // 
            txtAdminIdField.BackColor = Color.White;
            txtAdminIdField.BorderStyle = BorderStyle.None;
            txtAdminIdField.Cursor = Cursors.IBeam;
            txtAdminIdField.Font = new Font("Constantia", 10F);
            txtAdminIdField.Location = new Point(73, 134);
            txtAdminIdField.Margin = new Padding(4, 3, 4, 3);
            txtAdminIdField.Name = "txtAdminIdField";
            txtAdminIdField.Size = new Size(217, 21);
            txtAdminIdField.TabIndex = 5;
            txtAdminIdField.TextChanged += textBox2_TextChanged;
            // 
            // pnlAdminId
            // 
            pnlAdminId.BackColor = Color.FromArgb(255, 202, 228);
            pnlAdminId.Controls.Add(pbAdminIcon);
            pnlAdminId.Location = new Point(65, 125);
            pnlAdminId.Name = "pnlAdminId";
            pnlAdminId.Size = new Size(261, 39);
            pnlAdminId.TabIndex = 6;
            pnlAdminId.Paint += pnlAdminId_Paint;
            // 
            // pbAdminIcon
            // 
            pbAdminIcon.BackColor = Color.Transparent;
            pbAdminIcon.Image = (Image)resources.GetObject("pbAdminIcon.Image");
            pbAdminIcon.Location = new Point(230, 3);
            pbAdminIcon.Margin = new Padding(4, 3, 4, 3);
            pbAdminIcon.Name = "pbAdminIcon";
            pbAdminIcon.Size = new Size(25, 35);
            pbAdminIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbAdminIcon.TabIndex = 8;
            pbAdminIcon.TabStop = false;
            pbAdminIcon.Click += pictureBox2_Click;
            // 
            // lblAdminId
            // 
            lblAdminId.AutoSize = true;
            lblAdminId.Font = new Font("Constantia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminId.ForeColor = Color.Black;
            lblAdminId.Location = new Point(64, 100);
            lblAdminId.Name = "lblAdminId";
            lblAdminId.Size = new Size(88, 22);
            lblAdminId.TabIndex = 15;
            lblAdminId.Text = "Admin ID";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Constantia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(64, 177);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(83, 22);
            lblPassword.TabIndex = 16;
            lblPassword.Text = "Password";
            lblPassword.Click += lblPassword_Click_1;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.BorderStyle = BorderStyle.Fixed3D;
            pnlLogin.Controls.Add(pnlLoginField);
            pnlLogin.Controls.Add(picAdminIcon);
            pnlLogin.Controls.Add(txtAdminId);
            pnlLogin.Controls.Add(btnSignIn);
            pnlLogin.Location = new Point(48, 182);
            pnlLogin.Margin = new Padding(4, 3, 4, 3);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(774, 395);
            pnlLogin.TabIndex = 0;
            // 
            // PLKLoginScreenForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(877, 615);
            Controls.Add(pnlHeader);
            Controls.Add(pnlLogin);
            Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            Name = "PLKLoginScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PLK University Admin Login";
            Load += PLKLoginScreenForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAdminIcon).EndInit();
            pnlLoginField.ResumeLayout(false);
            pnlLoginField.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPasswordIcon).EndInit();
            pnlAdminId.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbAdminIcon).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlHeader;
        private PictureBox pbLogo;
        private Label lblPLKU;
        private Label lblUni;
        private Panel pnlAdminUnder;
        private Button btnSignIn;
        private TextBox txtAdminId;
        private PictureBox picAdminIcon;
        private Panel pnlLoginField;
        private Button btnLogInn;
        private Panel pnlUnder;
        private Panel pnlPasswordUnder;
        private Panel pnlPassword;
        private PictureBox pbPasswordIcon;

        private TextBox txtAdminIdField;
        private Panel pnlAdminId;
        private PictureBox pbAdminIcon;
        private Label lblAdminId;
        private Label lblPassword;
        private Panel pnlLogin;
        private TextBox txtPasswordField;
        private Panel panel1;
    }
}