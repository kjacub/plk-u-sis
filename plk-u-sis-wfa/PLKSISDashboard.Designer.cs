namespace plk_u_sis_wfa
{
    partial class PLKSISDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLKSISDashboard));
            dgvStudentRecords = new DataGridView();
            txtStudentId = new TextBox();
            txtFullName = new TextBox();
            txtContact = new TextBox();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            cmbYearLevel = new ComboBox();
            cmbProgram = new ComboBox();
            txtSearch = new TextBox();
            cmbFilterProgram = new ComboBox();
            rbFilter1stYear = new RadioButton();
            rbFilter3rdYear = new RadioButton();
            rbFilter2ndYear = new RadioButton();
            rbFilter4thYear = new RadioButton();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnSearchClear = new Button();
            btnFilter = new Button();
            btnSort = new Button();
            pnlStudentRecord = new Panel();
            lblStudentRecords = new Label();
            lblGender = new Label();
            lblFullname = new Label();
            lblContact = new Label();
            lblYearLevel = new Label();
            lblProgram = new Label();
            lblStudentId = new Label();
            pnlStudentId = new Panel();
            pbAdminIcon = new PictureBox();
            pnlStudentIdUnderline = new Panel();
            pnlContact = new Panel();
            pnlContactUnderline = new Panel();
            pnlFullName = new Panel();
            pnlFullNameUnderline = new Panel();
            pnlYeerLevel = new Panel();
            pnlYearLevelUnderline = new Panel();
            pnlProgram = new Panel();
            pnlProgramUnderline = new Panel();
            pnlFilter = new Panel();
            btnClearFilter = new Button();
            rbFilterAll = new RadioButton();
            lblFilterBy = new Label();
            lblSearch = new Label();
            pnltxtSearch = new Panel();
            pnlSearchUnderline = new Panel();
            pnlSearch = new Panel();
            pbAdd = new PictureBox();
            pbClear = new PictureBox();
            pbEdit = new PictureBox();
            pbDelete = new PictureBox();
            pnlHeader = new Panel();
            pbLogo = new PictureBox();
            label1 = new Label();
            lblHeader = new Label();
            lblFooter = new Label();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRecords).BeginInit();
            pnlStudentRecord.SuspendLayout();
            pnlStudentId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAdminIcon).BeginInit();
            pnlContact.SuspendLayout();
            pnlFullName.SuspendLayout();
            pnlYeerLevel.SuspendLayout();
            pnlProgram.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnltxtSearch.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDelete).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // dgvStudentRecords
            // 
            dgvStudentRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudentRecords.BackgroundColor = Color.FromArgb(255, 202, 228);
            dgvStudentRecords.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 202, 228);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 243, 242);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvStudentRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvStudentRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 243, 242);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(137, 35, 91);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvStudentRecords.DefaultCellStyle = dataGridViewCellStyle5;
            dgvStudentRecords.EnableHeadersVisualStyles = false;
            dgvStudentRecords.GridColor = Color.FromArgb(137, 35, 91);
            dgvStudentRecords.Location = new Point(728, 295);
            dgvStudentRecords.Name = "dgvStudentRecords";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 243, 242);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(137, 35, 91);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvStudentRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvStudentRecords.RowHeadersWidth = 51;
            dgvStudentRecords.Size = new Size(869, 676);
            dgvStudentRecords.TabIndex = 0;
            // 
            // txtStudentId
            // 
            txtStudentId.Font = new Font("Segoe UI", 9F);
            txtStudentId.Location = new Point(39, 124);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.PlaceholderText = " Enter Student ID";
            txtStudentId.Size = new Size(187, 27);
            txtStudentId.TabIndex = 1;
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9F);
            txtFullName.Location = new Point(285, 124);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = " Enter Full Name";
            txtFullName.Size = new Size(309, 27);
            txtFullName.TabIndex = 2;
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 9F);
            txtContact.Location = new Point(38, 207);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = " Enter Contact Number";
            txtContact.Size = new Size(187, 27);
            txtContact.TabIndex = 3;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.BackColor = Color.FromArgb(255, 202, 228);
            rbMale.Font = new Font("Segoe UI", 9F);
            rbMale.Location = new Point(286, 207);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(63, 24);
            rbMale.TabIndex = 4;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = false;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.BackColor = Color.FromArgb(255, 202, 228);
            rbFemale.Font = new Font("Segoe UI", 9F);
            rbFemale.Location = new Point(368, 207);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(78, 24);
            rbFemale.TabIndex = 5;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = false;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.Font = new Font("Segoe UI", 9F);
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year", "4th Year" });
            cmbYearLevel.Location = new Point(38, 293);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(187, 28);
            cmbYearLevel.TabIndex = 6;
            // 
            // cmbProgram
            // 
            cmbProgram.Font = new Font("Segoe UI", 9F);
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Items.AddRange(new object[] { "BS in Cosmetic Science", "BS in Floriculture and Botanical Design", "BS in Historical Fashion", "BS in Haute Couture and Luxury Fashion Design" });
            cmbProgram.Location = new Point(285, 293);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(309, 28);
            cmbProgram.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(885, 243);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = " Search by ID or Name";
            txtSearch.Size = new Size(489, 27);
            txtSearch.TabIndex = 8;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbFilterProgram
            // 
            cmbFilterProgram.BackColor = Color.FromArgb(255, 202, 228);
            cmbFilterProgram.DisplayMember = "Program";
            cmbFilterProgram.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cmbFilterProgram.FormattingEnabled = true;
            cmbFilterProgram.Items.AddRange(new object[] { "BS in Cosmetic Science", "BS in Floriculture and Botanical Design", "BS in Historical Fashion", "BS in Haute Couture and Luxury Fashion Design" });
            cmbFilterProgram.Location = new Point(8, 37);
            cmbFilterProgram.Name = "cmbFilterProgram";
            cmbFilterProgram.Size = new Size(211, 28);
            cmbFilterProgram.TabIndex = 9;
            cmbFilterProgram.SelectedIndexChanged += cmbFilterProgram_SelectedIndexChanged;
            // 
            // rbFilter1stYear
            // 
            rbFilter1stYear.AutoSize = true;
            rbFilter1stYear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbFilter1stYear.Location = new Point(13, 100);
            rbFilter1stYear.Name = "rbFilter1stYear";
            rbFilter1stYear.Size = new Size(81, 24);
            rbFilter1stYear.TabIndex = 10;
            rbFilter1stYear.TabStop = true;
            rbFilter1stYear.Text = "1st Year";
            rbFilter1stYear.UseVisualStyleBackColor = true;
            // 
            // rbFilter3rdYear
            // 
            rbFilter3rdYear.AutoSize = true;
            rbFilter3rdYear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbFilter3rdYear.Location = new Point(13, 160);
            rbFilter3rdYear.Name = "rbFilter3rdYear";
            rbFilter3rdYear.Size = new Size(87, 24);
            rbFilter3rdYear.TabIndex = 11;
            rbFilter3rdYear.TabStop = true;
            rbFilter3rdYear.Text = "3rd Year";
            rbFilter3rdYear.UseVisualStyleBackColor = true;
            // 
            // rbFilter2ndYear
            // 
            rbFilter2ndYear.AutoSize = true;
            rbFilter2ndYear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbFilter2ndYear.Location = new Point(13, 131);
            rbFilter2ndYear.Name = "rbFilter2ndYear";
            rbFilter2ndYear.Size = new Size(90, 24);
            rbFilter2ndYear.TabIndex = 12;
            rbFilter2ndYear.TabStop = true;
            rbFilter2ndYear.Text = "2nd Year";
            rbFilter2ndYear.UseVisualStyleBackColor = true;
            // 
            // rbFilter4thYear
            // 
            rbFilter4thYear.AutoSize = true;
            rbFilter4thYear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbFilter4thYear.Location = new Point(13, 189);
            rbFilter4thYear.Name = "rbFilter4thYear";
            rbFilter4thYear.Size = new Size(87, 24);
            rbFilter4thYear.TabIndex = 13;
            rbFilter4thYear.TabStop = true;
            rbFilter4thYear.Text = "4th Year";
            rbFilter4thYear.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(241, 2, 145);
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnAdd.ForeColor = Color.FromArgb(37, 2, 9);
            btnAdd.Location = new Point(57, 619);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(312, 51);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(137, 35, 91);
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.FromArgb(255, 243, 242);
            btnUpdate.Location = new Point(383, 619);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(312, 51);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update Student";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 202, 228);
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(37, 2, 9);
            btnClear.Location = new Point(383, 683);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(312, 51);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(37, 2, 9);
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(255, 243, 242);
            btnDelete.Location = new Point(57, 683);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(312, 51);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete Student";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_2;
            // 
            // btnSearchClear
            // 
            btnSearchClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchClear.BackColor = Color.FromArgb(255, 202, 228);
            btnSearchClear.FlatStyle = FlatStyle.Popup;
            btnSearchClear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSearchClear.Location = new Point(661, 21);
            btnSearchClear.Name = "btnSearchClear";
            btnSearchClear.Size = new Size(94, 29);
            btnSearchClear.TabIndex = 18;
            btnSearchClear.Text = "Clear";
            btnSearchClear.UseVisualStyleBackColor = false;
            btnSearchClear.Click += btnSearchClear_Click_1;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(255, 202, 228);
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilter.Location = new Point(14, 220);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 27);
            btnFilter.TabIndex = 19;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnSort
            // 
            btnSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSort.BackColor = Color.FromArgb(255, 202, 228);
            btnSort.FlatStyle = FlatStyle.Popup;
            btnSort.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSort.Location = new Point(761, 21);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(94, 29);
            btnSort.TabIndex = 20;
            btnSort.Text = "Sort A-Z";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click_1;
            // 
            // pnlStudentRecord
            // 
            pnlStudentRecord.BackColor = Color.FromArgb(255, 243, 242);
            pnlStudentRecord.BorderStyle = BorderStyle.Fixed3D;
            pnlStudentRecord.Controls.Add(lblStudentRecords);
            pnlStudentRecord.Controls.Add(lblGender);
            pnlStudentRecord.Controls.Add(lblFullname);
            pnlStudentRecord.Controls.Add(lblContact);
            pnlStudentRecord.Controls.Add(lblYearLevel);
            pnlStudentRecord.Controls.Add(lblProgram);
            pnlStudentRecord.Controls.Add(lblStudentId);
            pnlStudentRecord.Controls.Add(txtStudentId);
            pnlStudentRecord.Controls.Add(cmbProgram);
            pnlStudentRecord.Controls.Add(rbMale);
            pnlStudentRecord.Controls.Add(rbFemale);
            pnlStudentRecord.Controls.Add(cmbYearLevel);
            pnlStudentRecord.Controls.Add(txtContact);
            pnlStudentRecord.Controls.Add(txtFullName);
            pnlStudentRecord.Controls.Add(pnlStudentId);
            pnlStudentRecord.Controls.Add(pnlContact);
            pnlStudentRecord.Controls.Add(pnlFullName);
            pnlStudentRecord.Controls.Add(pnlYeerLevel);
            pnlStudentRecord.Controls.Add(pnlProgram);
            pnlStudentRecord.Location = new Point(57, 221);
            pnlStudentRecord.Name = "pnlStudentRecord";
            pnlStudentRecord.Size = new Size(638, 381);
            pnlStudentRecord.TabIndex = 21;
            pnlStudentRecord.Paint += panel1_Paint;
            // 
            // lblStudentRecords
            // 
            lblStudentRecords.AutoSize = true;
            lblStudentRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentRecords.ForeColor = Color.FromArgb(37, 2, 9);
            lblStudentRecords.Location = new Point(21, 49);
            lblStudentRecords.Name = "lblStudentRecords";
            lblStudentRecords.Size = new Size(205, 28);
            lblStudentRecords.TabIndex = 32;
            lblStudentRecords.Text = "Student Information";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(37, 2, 9);
            lblGender.Location = new Point(279, 179);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(74, 23);
            lblGender.TabIndex = 30;
            lblGender.Text = "Gender:";
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblFullname.ForeColor = Color.FromArgb(37, 2, 9);
            lblFullname.Location = new Point(279, 93);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(96, 23);
            lblFullname.TabIndex = 29;
            lblFullname.Text = "Full Name:";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblContact.ForeColor = Color.FromArgb(37, 2, 9);
            lblContact.Location = new Point(33, 179);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(149, 23);
            lblContact.TabIndex = 28;
            lblContact.Text = "Contact Number:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblYearLevel.ForeColor = Color.FromArgb(37, 2, 9);
            lblYearLevel.Location = new Point(33, 263);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(94, 23);
            lblYearLevel.TabIndex = 27;
            lblYearLevel.Text = "Year Level:";
            lblYearLevel.Click += label2_Click_1;
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblProgram.ForeColor = Color.FromArgb(37, 2, 9);
            lblProgram.Location = new Point(279, 263);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(85, 23);
            lblProgram.TabIndex = 26;
            lblProgram.Text = "Program:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblStudentId.ForeColor = Color.FromArgb(37, 2, 9);
            lblStudentId.Location = new Point(34, 93);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(102, 23);
            lblStudentId.TabIndex = 25;
            lblStudentId.Text = "Student ID:";
            // 
            // pnlStudentId
            // 
            pnlStudentId.BackColor = Color.FromArgb(255, 202, 228);
            pnlStudentId.Controls.Add(pbAdminIcon);
            pnlStudentId.Controls.Add(pnlStudentIdUnderline);
            pnlStudentId.Location = new Point(32, 119);
            pnlStudentId.Name = "pnlStudentId";
            pnlStudentId.Size = new Size(201, 39);
            pnlStudentId.TabIndex = 18;
            // 
            // pbAdminIcon
            // 
            pbAdminIcon.BackColor = Color.Transparent;
            pbAdminIcon.Location = new Point(230, 3);
            pbAdminIcon.Margin = new Padding(5, 3, 5, 3);
            pbAdminIcon.Name = "pbAdminIcon";
            pbAdminIcon.Size = new Size(25, 35);
            pbAdminIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbAdminIcon.TabIndex = 8;
            pbAdminIcon.TabStop = false;
            // 
            // pnlStudentIdUnderline
            // 
            pnlStudentIdUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlStudentIdUnderline.Location = new Point(7, 32);
            pnlStudentIdUnderline.Name = "pnlStudentIdUnderline";
            pnlStudentIdUnderline.Size = new Size(187, 3);
            pnlStudentIdUnderline.TabIndex = 19;
            // 
            // pnlContact
            // 
            pnlContact.BackColor = Color.FromArgb(255, 202, 228);
            pnlContact.Controls.Add(pnlContactUnderline);
            pnlContact.Location = new Point(31, 203);
            pnlContact.Name = "pnlContact";
            pnlContact.Size = new Size(201, 39);
            pnlContact.TabIndex = 19;
            // 
            // pnlContactUnderline
            // 
            pnlContactUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlContactUnderline.Location = new Point(7, 31);
            pnlContactUnderline.Name = "pnlContactUnderline";
            pnlContactUnderline.Size = new Size(187, 3);
            pnlContactUnderline.TabIndex = 19;
            // 
            // pnlFullName
            // 
            pnlFullName.BackColor = Color.FromArgb(255, 202, 228);
            pnlFullName.Controls.Add(pnlFullNameUnderline);
            pnlFullName.Location = new Point(277, 119);
            pnlFullName.Name = "pnlFullName";
            pnlFullName.Size = new Size(327, 39);
            pnlFullName.TabIndex = 23;
            pnlFullName.Paint += panel6_Paint;
            // 
            // pnlFullNameUnderline
            // 
            pnlFullNameUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlFullNameUnderline.Location = new Point(8, 32);
            pnlFullNameUnderline.Name = "pnlFullNameUnderline";
            pnlFullNameUnderline.Size = new Size(309, 3);
            pnlFullNameUnderline.TabIndex = 19;
            // 
            // pnlYeerLevel
            // 
            pnlYeerLevel.BackColor = Color.FromArgb(255, 202, 228);
            pnlYeerLevel.Controls.Add(pnlYearLevelUnderline);
            pnlYeerLevel.Location = new Point(31, 289);
            pnlYeerLevel.Name = "pnlYeerLevel";
            pnlYeerLevel.Size = new Size(201, 40);
            pnlYeerLevel.TabIndex = 19;
            // 
            // pnlYearLevelUnderline
            // 
            pnlYearLevelUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlYearLevelUnderline.Location = new Point(7, 32);
            pnlYearLevelUnderline.Name = "pnlYearLevelUnderline";
            pnlYearLevelUnderline.Size = new Size(187, 3);
            pnlYearLevelUnderline.TabIndex = 19;
            // 
            // pnlProgram
            // 
            pnlProgram.BackColor = Color.FromArgb(255, 202, 228);
            pnlProgram.Controls.Add(pnlProgramUnderline);
            pnlProgram.Location = new Point(277, 289);
            pnlProgram.Name = "pnlProgram";
            pnlProgram.Size = new Size(327, 40);
            pnlProgram.TabIndex = 24;
            // 
            // pnlProgramUnderline
            // 
            pnlProgramUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlProgramUnderline.Location = new Point(8, 32);
            pnlProgramUnderline.Name = "pnlProgramUnderline";
            pnlProgramUnderline.Size = new Size(309, 3);
            pnlProgramUnderline.TabIndex = 19;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(255, 243, 242);
            pnlFilter.BorderStyle = BorderStyle.Fixed3D;
            pnlFilter.Controls.Add(btnClearFilter);
            pnlFilter.Controls.Add(rbFilterAll);
            pnlFilter.Controls.Add(lblFilterBy);
            pnlFilter.Controls.Add(btnFilter);
            pnlFilter.Controls.Add(rbFilter1stYear);
            pnlFilter.Controls.Add(rbFilter2ndYear);
            pnlFilter.Controls.Add(rbFilter3rdYear);
            pnlFilter.Controls.Add(cmbFilterProgram);
            pnlFilter.Controls.Add(rbFilter4thYear);
            pnlFilter.Location = new Point(1637, 220);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(227, 264);
            pnlFilter.TabIndex = 22;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.FromArgb(255, 202, 228);
            btnClearFilter.FlatStyle = FlatStyle.Popup;
            btnClearFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearFilter.Location = new Point(119, 220);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(94, 27);
            btnClearFilter.TabIndex = 36;
            btnClearFilter.Text = "Clear";
            btnClearFilter.UseVisualStyleBackColor = false;
            // 
            // rbFilterAll
            // 
            rbFilterAll.AutoSize = true;
            rbFilterAll.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbFilterAll.Location = new Point(13, 73);
            rbFilterAll.Name = "rbFilterAll";
            rbFilterAll.Size = new Size(48, 24);
            rbFilterAll.TabIndex = 35;
            rbFilterAll.TabStop = true;
            rbFilterAll.Text = "All";
            rbFilterAll.UseVisualStyleBackColor = true;
            // 
            // lblFilterBy
            // 
            lblFilterBy.AutoSize = true;
            lblFilterBy.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFilterBy.Location = new Point(8, 13);
            lblFilterBy.Name = "lblFilterBy";
            lblFilterBy.Size = new Size(69, 20);
            lblFilterBy.TabIndex = 34;
            lblFilterBy.Text = "Filter by:";
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.White;
            lblSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(5, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(137, 23);
            lblSearch.TabIndex = 33;
            lblSearch.Text = "Search Student:";
            lblSearch.Click += lblSearch_Click;
            // 
            // pnltxtSearch
            // 
            pnltxtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnltxtSearch.BackColor = Color.FromArgb(255, 202, 228);
            pnltxtSearch.Controls.Add(pnlSearchUnderline);
            pnltxtSearch.Location = new Point(875, 235);
            pnltxtSearch.Name = "pnltxtSearch";
            pnltxtSearch.Size = new Size(506, 43);
            pnltxtSearch.TabIndex = 24;
            pnltxtSearch.Paint += panel13_Paint;
            // 
            // pnlSearchUnderline
            // 
            pnlSearchUnderline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlSearchUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlSearchUnderline.Location = new Point(11, 34);
            pnlSearchUnderline.Name = "pnlSearchUnderline";
            pnlSearchUnderline.Size = new Size(488, 3);
            pnlSearchUnderline.TabIndex = 19;
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.FromArgb(255, 243, 242);
            pnlSearch.BorderStyle = BorderStyle.Fixed3D;
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(btnSearchClear);
            pnlSearch.Controls.Add(btnSort);
            pnlSearch.Location = new Point(728, 220);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(869, 69);
            pnlSearch.TabIndex = 34;
            // 
            // pbAdd
            // 
            pbAdd.BackColor = Color.FromArgb(241, 2, 145);
            pbAdd.Image = (Image)resources.GetObject("pbAdd.Image");
            pbAdd.Location = new Point(129, 633);
            pbAdd.Name = "pbAdd";
            pbAdd.Size = new Size(30, 20);
            pbAdd.SizeMode = PictureBoxSizeMode.Zoom;
            pbAdd.TabIndex = 35;
            pbAdd.TabStop = false;
            // 
            // pbClear
            // 
            pbClear.BackColor = Color.FromArgb(255, 202, 228);
            pbClear.Image = (Image)resources.GetObject("pbClear.Image");
            pbClear.Location = new Point(459, 699);
            pbClear.Name = "pbClear";
            pbClear.Size = new Size(30, 20);
            pbClear.SizeMode = PictureBoxSizeMode.Zoom;
            pbClear.TabIndex = 36;
            pbClear.TabStop = false;
            // 
            // pbEdit
            // 
            pbEdit.BackColor = Color.FromArgb(137, 35, 91);
            pbEdit.Image = (Image)resources.GetObject("pbEdit.Image");
            pbEdit.Location = new Point(443, 633);
            pbEdit.Name = "pbEdit";
            pbEdit.Size = new Size(30, 20);
            pbEdit.SizeMode = PictureBoxSizeMode.Zoom;
            pbEdit.TabIndex = 37;
            pbEdit.TabStop = false;
            // 
            // pbDelete
            // 
            pbDelete.BackColor = Color.FromArgb(37, 2, 9);
            pbDelete.Image = (Image)resources.GetObject("pbDelete.Image");
            pbDelete.Location = new Point(122, 697);
            pbDelete.Name = "pbDelete";
            pbDelete.Size = new Size(30, 20);
            pbDelete.SizeMode = PictureBoxSizeMode.Zoom;
            pbDelete.TabIndex = 38;
            pbDelete.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(255, 202, 228);
            pnlHeader.BorderStyle = BorderStyle.Fixed3D;
            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Location = new Point(57, 41);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1807, 156);
            pnlHeader.TabIndex = 39;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Constantia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(137, 35, 91);
            label1.Location = new Point(703, 107);
            label1.Name = "label1";
            label1.Size = new Size(382, 37);
            label1.TabIndex = 35;
            label1.Text = "Student Information System";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.FromArgb(255, 202, 228);
            lblHeader.Font = new Font("Constantia", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(137, 35, 91);
            lblHeader.Location = new Point(462, 2);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(876, 122);
            lblHeader.TabIndex = 34;
            lblHeader.Text = "PLK UNIVERSITY";
            lblHeader.Click += lblHeader_Click;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.BackColor = Color.Transparent;
            lblFooter.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFooter.ForeColor = Color.FromArgb(37, 2, 9);
            lblFooter.Location = new Point(837, 1001);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(349, 23);
            lblFooter.TabIndex = 40;
            lblFooter.Text = "PLK University · Student Information System";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(255, 202, 228);
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnExit.Location = new Point(1637, 495);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(228, 49);
            btnExit.TabIndex = 41;
            btnExit.Text = "Exit Dashbaord";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // PLKSISDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnExit);
            Controls.Add(lblFooter);
            Controls.Add(pnlHeader);
            Controls.Add(pbDelete);
            Controls.Add(pbEdit);
            Controls.Add(pbClear);
            Controls.Add(pbAdd);
            Controls.Add(pnlFilter);
            Controls.Add(pnlStudentRecord);
            Controls.Add(txtSearch);
            Controls.Add(dgvStudentRecords);
            Controls.Add(pnltxtSearch);
            Controls.Add(pnlSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Name = "PLKSISDashboard";
            Text = "PLK University Student Information System";
            Load += PLKSISDashboard_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvStudentRecords).EndInit();
            pnlStudentRecord.ResumeLayout(false);
            pnlStudentRecord.PerformLayout();
            pnlStudentId.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbAdminIcon).EndInit();
            pnlContact.ResumeLayout(false);
            pnlFullName.ResumeLayout(false);
            pnlYeerLevel.ResumeLayout(false);
            pnlProgram.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnltxtSearch.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClear).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDelete).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStudentRecords;
        private TextBox txtStudentId;
        private TextBox txtFullName;
        private TextBox txtContact;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private ComboBox cmbYearLevel;
        private ComboBox cmbProgram;
        private TextBox txtSearch;
        private ComboBox cmbFilterProgram;
        private RadioButton rbFilter1stYear;
        private RadioButton rbFilter3rdYear;
        private RadioButton rbFilter2ndYear;
        private RadioButton rbFilter4thYear;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSearchClear;
        private Button btnFilter;
        private Button btnSort;
        private Panel pnlStudentRecord;
        private Panel pnlFilter;
        private Panel pnlContact;
        private Panel pnlContactUnderline;
        private Panel pnlStudentId;
        private PictureBox pbAdminIcon;
        private Panel pnlStudentIdUnderline;
        private Panel pnlFullName;
        private Panel pnlFullNameUnderline;
        private Panel pnlYeerLevel;
    
        private Label lblFullname;
        private Label lblContact;
        private Label lblYearLevel;
        private Label lblProgram;
        private Label lblStudentId;
        private Panel pnlProgram;
   
        private Label lblGender;
        private Label lblStudentRecords;
        private Label lblFilterBy;
        private Label lblSearch;
        private Panel pnlSearchUnderline;
        private Panel pnlSearch;
        private RadioButton rbFilterAll;
        private Panel pnlYearLevelUnderline;
        private Panel pnlProgramUnderline;
        private Panel pnltxtSearch;
        private Button btnClearFilter;
        private PictureBox pbAdd;
        private PictureBox pbClear;
        private PictureBox pbEdit;
        private PictureBox pbDelete;
        private Panel pnlHeader;
        private Label lblHeader;
        private Label label1;
        private Label lblFooter;
        private PictureBox pbLogo;
        private Button btnExit;
    }
}