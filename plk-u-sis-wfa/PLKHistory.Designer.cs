namespace plk_u_sis_wfa
{
    partial class PLKHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLKHistory));
            panel1 = new Panel();
            lblHeader2 = new Label();
            pictureBox1 = new PictureBox();
            lblHeader = new Label();
            btnBack = new Button();
            label1 = new Label();
            lblFooter = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 202, 228);
            panel1.Controls.Add(lblHeader2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblHeader);
            panel1.Controls.Add(btnBack);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 155);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lblHeader2
            // 
            lblHeader2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeader2.AutoSize = true;
            lblHeader2.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader2.ForeColor = Color.FromArgb(137, 35, 91);
            lblHeader2.Location = new Point(676, 95);
            lblHeader2.Name = "lblHeader2";
            lblHeader2.Size = new Size(470, 37);
            lblHeader2.TabIndex = 5;
            lblHeader2.Text = "A Brief History of the University\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.FromArgb(255, 202, 228);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1696, -13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(204, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Constantia", 40.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(137, 35, 91);
            lblHeader.Location = new Point(477, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(896, 82);
            lblHeader.TabIndex = 4;
            lblHeader.Text = "PLK UNIVERSITY HISTORY";
            // 
            // btnBack
            // 
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(137, 35, 91);
            btnBack.Location = new Point(16, 34);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 29);
            btnBack.TabIndex = 3;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(89, 233);
            label1.Name = "label1";
            label1.Size = new Size(1719, 620);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.BackColor = Color.Transparent;
            lblFooter.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFooter.ForeColor = Color.FromArgb(255, 202, 228);
            lblFooter.Location = new Point(730, 986);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(458, 23);
            lblFooter.TabIndex = 23;
            lblFooter.Text = "© 2026 Princess Leigh Kate University. All Rights Reserved.";
            // 
            // PLKHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblFooter);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "PLKHistory";
            Text = "PLKHistory";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblHeader2;
        private PictureBox pictureBox1;
        private Label lblHeader;
        private Button btnBack;
        private Label label1;
        private Label lblFooter;
    }
}