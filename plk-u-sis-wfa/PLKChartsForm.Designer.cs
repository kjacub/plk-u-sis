namespace plk_u_sis_wfa
{
    partial class PLKChartsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLKChartsForm));
            formsPlotSurvival = new ScottPlot.WinForms.FormsPlot();
            formsPlotEnrollment = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel1 = new TableLayoutPanel();
            formsPlotTransfer = new ScottPlot.WinForms.FormsPlot();
            btnBack = new Button();
            btnRefresh = new Button();
            btnExportEnrollment = new Button();
            btnExportTransfer = new Button();
            btnExportSurvival = new Button();
            pnlHeader = new Panel();
            label1 = new Label();
            label2 = new Label();
            pbLogo = new PictureBox();
            lblHeader = new Label();
            lblFooter = new Label();
            tableLayoutPanel1.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // formsPlotSurvival
            // 
            formsPlotSurvival.BackColor = Color.FromArgb(255, 243, 242);
            formsPlotSurvival.Location = new Point(602, 3);
            formsPlotSurvival.Name = "formsPlotSurvival";
            formsPlotSurvival.Size = new Size(621, 649);
            formsPlotSurvival.TabIndex = 0;
            // 
            // formsPlotEnrollment
            // 
            formsPlotEnrollment.BackColor = Color.FromArgb(255, 243, 242);
            formsPlotEnrollment.Location = new Point(3, 3);
            formsPlotEnrollment.Name = "formsPlotEnrollment";
            formsPlotEnrollment.Size = new Size(593, 649);
            formsPlotEnrollment.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(137, 35, 91);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 627F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(formsPlotEnrollment, 0, 0);
            tableLayoutPanel1.Controls.Add(formsPlotTransfer, 2, 0);
            tableLayoutPanel1.Controls.Add(formsPlotSurvival, 1, 0);
            tableLayoutPanel1.Location = new Point(35, 222);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1826, 655);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // formsPlotTransfer
            // 
            formsPlotTransfer.BackColor = Color.FromArgb(255, 243, 242);
            formsPlotTransfer.Location = new Point(1229, 3);
            formsPlotTransfer.Name = "formsPlotTransfer";
            formsPlotTransfer.Size = new Size(594, 649);
            formsPlotTransfer.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 202, 228);
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnBack.Location = new Point(1358, 918);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(228, 49);
            btnBack.TabIndex = 43;
            btnBack.Text = "Back to Dashboard";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(255, 202, 228);
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRefresh.Location = new Point(1098, 918);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(228, 49);
            btnRefresh.TabIndex = 44;
            btnRefresh.Text = "Refresh Charts";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnExportEnrollment
            // 
            btnExportEnrollment.BackColor = Color.FromArgb(255, 202, 228);
            btnExportEnrollment.FlatStyle = FlatStyle.Popup;
            btnExportEnrollment.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnExportEnrollment.Location = new Point(296, 918);
            btnExportEnrollment.Name = "btnExportEnrollment";
            btnExportEnrollment.Size = new Size(254, 49);
            btnExportEnrollment.TabIndex = 45;
            btnExportEnrollment.Text = "Export Enrollment Rate Chart";
            btnExportEnrollment.UseVisualStyleBackColor = false;
            // 
            // btnExportTransfer
            // 
            btnExportTransfer.BackColor = Color.FromArgb(255, 202, 228);
            btnExportTransfer.FlatStyle = FlatStyle.Popup;
            btnExportTransfer.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnExportTransfer.Location = new Point(839, 918);
            btnExportTransfer.Name = "btnExportTransfer";
            btnExportTransfer.Size = new Size(228, 49);
            btnExportTransfer.TabIndex = 46;
            btnExportTransfer.Text = "Export Transfer Rate Chart";
            btnExportTransfer.UseVisualStyleBackColor = false;
            // 
            // btnExportSurvival
            // 
            btnExportSurvival.BackColor = Color.FromArgb(255, 202, 228);
            btnExportSurvival.FlatStyle = FlatStyle.Popup;
            btnExportSurvival.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnExportSurvival.Location = new Point(581, 918);
            btnExportSurvival.Name = "btnExportSurvival";
            btnExportSurvival.Size = new Size(228, 49);
            btnExportSurvival.TabIndex = 47;
            btnExportSurvival.Text = "Export Survival Rate Chart";
            btnExportSurvival.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(255, 202, 228);
            pnlHeader.BorderStyle = BorderStyle.Fixed3D;
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Location = new Point(46, 40);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1807, 156);
            pnlHeader.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Constantia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(137, 35, 91);
            label1.Location = new Point(703, 107);
            label1.Name = "label1";
            label1.Size = new Size(375, 37);
            label1.TabIndex = 35;
            label1.Text = "Student Charts and Reports";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 202, 228);
            label2.Font = new Font("Constantia", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(137, 35, 91);
            label2.Location = new Point(463, 3);
            label2.Name = "label2";
            label2.Size = new Size(876, 122);
            label2.TabIndex = 37;
            label2.Text = "PLK UNIVERSITY";
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.FromArgb(255, 202, 228);
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(1617, -8);
            pbLogo.Margin = new Padding(4, 3, 4, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(189, 161);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 36;
            pbLogo.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.FromArgb(255, 202, 228);
            lblHeader.Font = new Font("Constantia", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(137, 35, 91);
            lblHeader.Location = new Point(2065, 2);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(876, 122);
            lblHeader.TabIndex = 34;
            lblHeader.Text = "PLK UNIVERSITY";
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.BackColor = Color.Transparent;
            lblFooter.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFooter.ForeColor = Color.FromArgb(37, 2, 9);
            lblFooter.Location = new Point(789, 1001);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(345, 23);
            lblFooter.TabIndex = 49;
            lblFooter.Text = "PLK University · Student Charts and Reports";
            // 
            // PLKChartsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblFooter);
            Controls.Add(pnlHeader);
            Controls.Add(btnExportSurvival);
            Controls.Add(btnExportTransfer);
            Controls.Add(btnExportEnrollment);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(tableLayoutPanel1);
            Name = "PLKChartsForm";
            Text = "Student Charts and Reports";
            Load += PLKChartsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlotSurvival;
        private ScottPlot.WinForms.FormsPlot formsPlotEnrollment;
        private Button btnRefresh;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnBack;
        private Button btnExportEnrollment;
        private Button btnExportTransfer;
        private Button btnExportSurvival;
        private Panel pnlHeader;
        private PictureBox pbLogo;
        private Label label1;
        private Label lblHeader;
        private Label label2;
        private Label lblFooter;
        private ScottPlot.WinForms.FormsPlot formsPlotTransfer;
    }
}