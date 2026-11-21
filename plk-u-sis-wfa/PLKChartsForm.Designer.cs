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
            formsPlotTransfer = new ScottPlot.WinForms.FormsPlot();
            formsPlotEnrollment = new ScottPlot.WinForms.FormsPlot();
            btnRefresh = new Button();
            btnBack = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnExportSurvival = new Button();
            btnExportTransfer = new Button();
            btnExportEnrollment = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlotSurvival
            // 
            formsPlotSurvival.BackColor = Color.FromArgb(255, 243, 242);
            formsPlotSurvival.Location = new Point(598, 3);
            formsPlotSurvival.Name = "formsPlotSurvival";
            formsPlotSurvival.Size = new Size(629, 649);
            formsPlotSurvival.TabIndex = 0;
            // 
            // formsPlotTransfer
            // 
            formsPlotTransfer.BackColor = Color.FromArgb(255, 243, 242);
            formsPlotTransfer.Location = new Point(3, 3);
            formsPlotTransfer.Name = "formsPlotTransfer";
            formsPlotTransfer.Size = new Size(589, 649);
            formsPlotTransfer.TabIndex = 1;
            // 
            // formsPlotEnrollment
            // 
            formsPlotEnrollment.BackColor = Color.FromArgb(255, 243, 242);
            formsPlotEnrollment.Location = new Point(1233, 3);
            formsPlotEnrollment.Name = "formsPlotEnrollment";
            formsPlotEnrollment.Size = new Size(590, 649);
            formsPlotEnrollment.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1008, 971);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(204, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh Dashboard";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(547, 949);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(217, 29);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back to Dashboard";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 635F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(formsPlotSurvival, 1, 0);
            tableLayoutPanel1.Controls.Add(formsPlotTransfer, 0, 0);
            tableLayoutPanel1.Controls.Add(formsPlotEnrollment, 2, 0);
            tableLayoutPanel1.Location = new Point(35, 222);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1826, 655);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // btnExportSurvival
            // 
            btnExportSurvival.Location = new Point(770, 949);
            btnExportSurvival.Name = "btnExportSurvival";
            btnExportSurvival.Size = new Size(204, 29);
            btnExportSurvival.TabIndex = 6;
            btnExportSurvival.Text = "Export Survival Rate Chart";
            btnExportSurvival.UseVisualStyleBackColor = true;
            // 
            // btnExportTransfer
            // 
            btnExportTransfer.Location = new Point(977, 892);
            btnExportTransfer.Name = "btnExportTransfer";
            btnExportTransfer.Size = new Size(204, 29);
            btnExportTransfer.TabIndex = 7;
            btnExportTransfer.Text = "Export Transfer Rate Chart";
            btnExportTransfer.UseVisualStyleBackColor = true;
            // 
            // btnExportEnrollment
            // 
            btnExportEnrollment.Location = new Point(1144, 927);
            btnExportEnrollment.Name = "btnExportEnrollment";
            btnExportEnrollment.Size = new Size(204, 29);
            btnExportEnrollment.TabIndex = 8;
            btnExportEnrollment.Text = "Export Enrollment Rate Chart";
            btnExportEnrollment.UseVisualStyleBackColor = true;
            // 
            // PLKChartsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnExportEnrollment);
            Controls.Add(btnExportTransfer);
            Controls.Add(btnExportSurvival);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Name = "PLKChartsForm";
            Text = "PLKChartsForm";
            Load += PLKChartsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlotSurvival;
        private ScottPlot.WinForms.FormsPlot formsPlotTransfer;
        private ScottPlot.WinForms.FormsPlot formsPlotEnrollment;
        private Button btnRefresh;
        private Button btnBack;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnExport1;
        private Button btnExportSurvival;
        private Button btnExportTransfer;
        private Button btnExportEnrollment;
    }
}