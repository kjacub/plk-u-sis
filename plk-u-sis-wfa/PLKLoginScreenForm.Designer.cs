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
            panel1 = new Panel();
            lblAdminId = new Label();
            lblPassword = new Label();
            textBox1 = new TextBox();
            btnSignIn = new Button();
            txtAdminId = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 2, 9);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(txtAdminId);
            panel1.Controls.Add(btnSignIn);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(lblAdminId);
            panel1.Location = new Point(38, 138);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 374);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lblAdminId
            // 
            lblAdminId.AutoSize = true;
            lblAdminId.BackColor = Color.FromArgb(255, 243, 242);
            lblAdminId.Location = new Point(30, 69);
            lblAdminId.Name = "lblAdminId";
            lblAdminId.Size = new Size(72, 20);
            lblAdminId.TabIndex = 1;
            lblAdminId.Text = "Admin ID";
            lblAdminId.Click += lblAdminId_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.FromArgb(255, 243, 242);
            lblPassword.Location = new Point(30, 151);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            lblPassword.Click += lblPassword_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(255, 202, 228);
            textBox1.Location = new Point(30, 174);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.FromArgb(241, 2, 145);
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatAppearance.MouseOverBackColor = Color.FromArgb(137, 35, 91);
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.ForeColor = Color.White;
            btnSignIn.Location = new Point(190, 270);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(94, 29);
            btnSignIn.TabIndex = 4;
            btnSignIn.Text = "SIGN IN";
            btnSignIn.UseVisualStyleBackColor = false;
            // 
            // txtAdminId
            // 
            txtAdminId.BackColor = Color.FromArgb(255, 202, 228);
            txtAdminId.Location = new Point(30, 92);
            txtAdminId.Name = "txtAdminId";
            txtAdminId.Size = new Size(201, 27);
            txtAdminId.TabIndex = 5;
            txtAdminId.TextChanged += this.txtAdminId_TextChanged;
            // 
            // PLKLoginScreenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 202, 228);
            ClientSize = new Size(522, 548);
            Controls.Add(panel1);
            Name = "PLKLoginScreenForm";
            Text = "PLK University Admin Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Label lblPassword;
        private Label lblAdminId;
        private Button btnSignIn;
        private TextBox txtAdminId;
    }
}
