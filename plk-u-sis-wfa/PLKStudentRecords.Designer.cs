namespace plk_u_sis_wfa
{
    partial class PLKStudentRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLKStudentRecords));
            txtStudentId = new TextBox();
            txtFullName = new TextBox();
            lblStudentId = new Label();
            lblFullName = new Label();
            cmbGender = new ComboBox();
            cmbProgram = new ComboBox();
            cmbYearLevel = new ComboBox();
            lblYearLevel = new Label();
            lblProgram = new Label();
            lblContact = new Label();
            lblGender = new Label();
            txtContact = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnAdd = new Button();
            label3 = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvStudentRecords = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRecords).BeginInit();
            SuspendLayout();
            // 
            // txtStudentId
            // 
            resources.ApplyResources(txtStudentId, "txtStudentId");
            txtStudentId.Name = "txtStudentId";
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            // 
            // txtFullName
            // 
            resources.ApplyResources(txtFullName, "txtFullName");
            txtFullName.Name = "txtFullName";
            txtFullName.TextChanged += txtFullName_TextChanged;
            // 
            // lblStudentId
            // 
            resources.ApplyResources(lblStudentId, "lblStudentId");
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Click += lblStudentId_Click;
            // 
            // lblFullName
            // 
            resources.ApplyResources(lblFullName, "lblFullName");
            lblFullName.Name = "lblFullName";
            // 
            // cmbGender
            // 
            resources.ApplyResources(cmbGender, "cmbGender");
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { resources.GetString("cmbGender.Items"), resources.GetString("cmbGender.Items1"), resources.GetString("cmbGender.Items2") });
            cmbGender.Name = "cmbGender";
            cmbGender.SelectedIndexChanged += cmbGender_SelectedIndexChanged;
            // 
            // cmbProgram
            // 
            resources.ApplyResources(cmbProgram, "cmbProgram");
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Items.AddRange(new object[] { resources.GetString("cmbProgram.Items") });
            cmbProgram.Name = "cmbProgram";
            cmbProgram.SelectedIndexChanged += cmbProgram_SelectedIndexChanged;
            // 
            // cmbYearLevel
            // 
            resources.ApplyResources(cmbYearLevel, "cmbYearLevel");
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Items.AddRange(new object[] { resources.GetString("cmbYearLevel.Items"), resources.GetString("cmbYearLevel.Items1"), resources.GetString("cmbYearLevel.Items2"), resources.GetString("cmbYearLevel.Items3") });
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblYearLevel
            // 
            resources.ApplyResources(lblYearLevel, "lblYearLevel");
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Click += lblYearLevel_Click;
            // 
            // lblProgram
            // 
            resources.ApplyResources(lblProgram, "lblProgram");
            lblProgram.Name = "lblProgram";
            // 
            // lblContact
            // 
            resources.ApplyResources(lblContact, "lblContact");
            lblContact.Name = "lblContact";
            lblContact.Click += lblContact_Click;
            // 
            // lblGender
            // 
            resources.ApplyResources(lblGender, "lblGender");
            lblGender.Name = "lblGender";
            // 
            // txtContact
            // 
            resources.ApplyResources(txtContact, "txtContact");
            txtContact.Name = "txtContact";
            txtContact.TextChanged += txtContact_TextChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            label2.Click += label2_Click;
            // 
            // btnAdd
            // 
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // btnUpdate
            // 
            resources.ApplyResources(btnUpdate, "btnUpdate");
            btnUpdate.Name = "btnUpdate";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.Name = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            resources.ApplyResources(btnClear, "btnClear");
            btnClear.Name = "btnClear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            // 
            // lblSearch
            // 
            resources.ApplyResources(lblSearch, "lblSearch");
            lblSearch.Name = "lblSearch";
            // 
            // dgvStudentRecords
            // 
            resources.ApplyResources(dgvStudentRecords, "dgvStudentRecords");
            dgvStudentRecords.AllowUserToAddRows = false;
            dgvStudentRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudentRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentRecords.MultiSelect = false;
            dgvStudentRecords.Name = "dgvStudentRecords";
            dgvStudentRecords.ReadOnly = true;
            dgvStudentRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // PLKStudentRecords
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvStudentRecords);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(label3);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblGender);
            Controls.Add(lblContact);
            Controls.Add(lblProgram);
            Controls.Add(lblYearLevel);
            Controls.Add(cmbYearLevel);
            Controls.Add(cmbProgram);
            Controls.Add(cmbGender);
            Controls.Add(lblFullName);
            Controls.Add(lblStudentId);
            Controls.Add(txtFullName);
            Controls.Add(txtStudentId);
            Controls.Add(txtContact);
            Name = "PLKStudentRecords";
            Load += PLKStudentRecords_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStudentId;
        private TextBox txtFullName;
        private Label lblStudentId;
        private Label lblFullName;
        private ComboBox cmbGender;
        private ComboBox cmbProgram;
        private ComboBox cmbYearLevel;
        private Label lblYearLevel;
        private Label lblProgram;
        private Label lblContact;
        private Label lblGender;
        private TextBox txtContact;
        private Label label1;
        private Label label2;
        private Button btnAdd;
        private Label label3;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvStudentRecords;
    }
}