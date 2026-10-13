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
            btnSearch = new Button();
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
            SuspendLayout();
            // 
            // dgvStudentRecords
            // 
            dgvStudentRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudentRecords.BackgroundColor = Color.FromArgb(255, 202, 228);
            dgvStudentRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentRecords.Location = new Point(728, 295);
            dgvStudentRecords.Name = "dgvStudentRecords";
            dgvStudentRecords.RowHeadersWidth = 51;
            dgvStudentRecords.Size = new Size(869, 676);
            dgvStudentRecords.TabIndex = 0;
            // 
            // txtStudentId
            // 
            txtStudentId.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStudentId.Location = new Point(39, 103);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(187, 25);
            txtStudentId.TabIndex = 1;
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(285, 103);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(309, 27);
            txtFullName.TabIndex = 2;
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.Location = new Point(38, 181);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(187, 25);
            txtContact.TabIndex = 3;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.BackColor = Color.FromArgb(255, 202, 228);
            rbMale.Font = new Font("Constantia", 10.2F);
            rbMale.Location = new Point(286, 181);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(67, 25);
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
            rbFemale.Font = new Font("Constantia", 10.2F);
            rbFemale.Location = new Point(368, 181);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(83, 25);
            rbFemale.TabIndex = 5;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = false;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year", "4th Year" });
            cmbYearLevel.Location = new Point(38, 264);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(187, 28);
            cmbYearLevel.TabIndex = 6;
            // 
            // cmbProgram
            // 
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Items.AddRange(new object[] { "BS Computer Science", "BS Information Technology", "BS Biology", "BS Chemistry" });
            cmbProgram.Location = new Point(285, 264);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(309, 28);
            cmbProgram.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Lucida Fax", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(943, 241);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(429, 28);
            txtSearch.TabIndex = 8;
            // 
            // cmbFilterProgram
            // 
            cmbFilterProgram.BackColor = Color.FromArgb(255, 202, 228);
            cmbFilterProgram.FormattingEnabled = true;
            cmbFilterProgram.Items.AddRange(new object[] { "All", "BS Computer Science", "BS Information Technology", "Bs Biology", "Bs Chemistry" });
            cmbFilterProgram.Location = new Point(8, 38);
            cmbFilterProgram.Name = "cmbFilterProgram";
            cmbFilterProgram.Size = new Size(211, 28);
            cmbFilterProgram.TabIndex = 9;
            // 
            // rbFilter1stYear
            // 
            rbFilter1stYear.AutoSize = true;
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
            rbFilter3rdYear.Location = new Point(13, 160);
            rbFilter3rdYear.Name = "rbFilter3rdYear";
            rbFilter3rdYear.Size = new Size(84, 24);
            rbFilter3rdYear.TabIndex = 11;
            rbFilter3rdYear.TabStop = true;
            rbFilter3rdYear.Text = "3rd Year";
            rbFilter3rdYear.UseVisualStyleBackColor = true;
            // 
            // rbFilter2ndYear
            // 
            rbFilter2ndYear.AutoSize = true;
            rbFilter2ndYear.Location = new Point(13, 130);
            rbFilter2ndYear.Name = "rbFilter2ndYear";
            rbFilter2ndYear.Size = new Size(87, 24);
            rbFilter2ndYear.TabIndex = 12;
            rbFilter2ndYear.TabStop = true;
            rbFilter2ndYear.Text = "2nd Year";
            rbFilter2ndYear.UseVisualStyleBackColor = true;
            // 
            // rbFilter4thYear
            // 
            rbFilter4thYear.AutoSize = true;
            rbFilter4thYear.Location = new Point(13, 190);
            rbFilter4thYear.Name = "rbFilter4thYear";
            rbFilter4thYear.Size = new Size(83, 24);
            rbFilter4thYear.TabIndex = 13;
            rbFilter4thYear.TabStop = true;
            rbFilter4thYear.Text = "4th Year";
            rbFilter4thYear.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 202, 228);
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(49, 330);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 202, 228);
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(174, 330);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 202, 228);
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(427, 330);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 202, 228);
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(300, 330);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(255, 202, 228);
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Constantia", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(663, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(255, 202, 228);
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            btnSort.Font = new Font("Constantia", 9F, FontStyle.Bold);
            btnSort.Location = new Point(763, 22);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(94, 29);
            btnSort.TabIndex = 20;
            btnSort.Text = "Sort A-Z";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click_1;
            // 
            // pnlStudentRecord
            // 
            pnlStudentRecord.BackColor = Color.White;
            pnlStudentRecord.Controls.Add(lblStudentRecords);
            pnlStudentRecord.Controls.Add(lblGender);
            pnlStudentRecord.Controls.Add(lblFullname);
            pnlStudentRecord.Controls.Add(lblContact);
            pnlStudentRecord.Controls.Add(lblYearLevel);
            pnlStudentRecord.Controls.Add(lblProgram);
            pnlStudentRecord.Controls.Add(lblStudentId);
            pnlStudentRecord.Controls.Add(btnAdd);
            pnlStudentRecord.Controls.Add(btnUpdate);
            pnlStudentRecord.Controls.Add(btnClear);
            pnlStudentRecord.Controls.Add(btnDelete);
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
            pnlStudentRecord.Location = new Point(57, 220);
            pnlStudentRecord.Name = "pnlStudentRecord";
            pnlStudentRecord.Size = new Size(638, 392);
            pnlStudentRecord.TabIndex = 21;
            pnlStudentRecord.Paint += panel1_Paint;
            // 
            // lblStudentRecords
            // 
            lblStudentRecords.AutoSize = true;
            lblStudentRecords.Font = new Font("Constantia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentRecords.Location = new Point(14, 17);
            lblStudentRecords.Name = "lblStudentRecords";
            lblStudentRecords.Size = new Size(190, 28);
            lblStudentRecords.TabIndex = 32;
            lblStudentRecords.Text = "Student Records";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.Location = new Point(277, 151);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(69, 21);
            lblGender.TabIndex = 30;
            lblGender.Text = "Gender:";
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFullname.Location = new Point(277, 75);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(91, 21);
            lblFullname.TabIndex = 29;
            lblFullname.Text = "Full Name:";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContact.Location = new Point(31, 151);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(138, 21);
            lblContact.TabIndex = 28;
            lblContact.Text = "Contact Number:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYearLevel.Location = new Point(32, 235);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(87, 21);
            lblYearLevel.TabIndex = 27;
            lblYearLevel.Text = "Year Level:";
            lblYearLevel.Click += label2_Click_1;
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgram.Location = new Point(277, 235);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(79, 21);
            lblProgram.TabIndex = 26;
            lblProgram.Text = "Program:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentId.Location = new Point(32, 75);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(96, 21);
            lblStudentId.TabIndex = 25;
            lblStudentId.Text = "Student ID:";
            // 
            // pnlStudentId
            // 
            pnlStudentId.BackColor = Color.FromArgb(255, 202, 228);
            pnlStudentId.Controls.Add(pbAdminIcon);
            pnlStudentId.Controls.Add(pnlStudentIdUnderline);
            pnlStudentId.Location = new Point(32, 97);
            pnlStudentId.Name = "pnlStudentId";
            pnlStudentId.Size = new Size(201, 39);
            pnlStudentId.TabIndex = 18;
            // 
            // pbAdminIcon
            // 
            pbAdminIcon.BackColor = Color.Transparent;
            pbAdminIcon.Location = new Point(230, 3);
            pbAdminIcon.Margin = new Padding(4, 3, 4, 3);
            pbAdminIcon.Name = "pbAdminIcon";
            pbAdminIcon.Size = new Size(25, 35);
            pbAdminIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbAdminIcon.TabIndex = 8;
            pbAdminIcon.TabStop = false;
            // 
            // pnlStudentIdUnderline
            // 
            pnlStudentIdUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlStudentIdUnderline.Location = new Point(7, 31);
            pnlStudentIdUnderline.Name = "pnlStudentIdUnderline";
            pnlStudentIdUnderline.Size = new Size(187, 2);
            pnlStudentIdUnderline.TabIndex = 19;
            // 
            // pnlContact
            // 
            pnlContact.BackColor = Color.FromArgb(255, 202, 228);
            pnlContact.Controls.Add(pnlContactUnderline);
            pnlContact.Location = new Point(31, 175);
            pnlContact.Name = "pnlContact";
            pnlContact.Size = new Size(201, 39);
            pnlContact.TabIndex = 19;
            // 
            // pnlContactUnderline
            // 
            pnlContactUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlContactUnderline.Location = new Point(7, 31);
            pnlContactUnderline.Name = "pnlContactUnderline";
            pnlContactUnderline.Size = new Size(187, 2);
            pnlContactUnderline.TabIndex = 19;
            // 
            // pnlFullName
            // 
            pnlFullName.BackColor = Color.FromArgb(255, 202, 228);
            pnlFullName.Controls.Add(pnlFullNameUnderline);
            pnlFullName.Location = new Point(277, 97);
            pnlFullName.Name = "pnlFullName";
            pnlFullName.Size = new Size(327, 39);
            pnlFullName.TabIndex = 23;
            pnlFullName.Paint += panel6_Paint;
            // 
            // pnlFullNameUnderline
            // 
            pnlFullNameUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlFullNameUnderline.Location = new Point(8, 33);
            pnlFullNameUnderline.Name = "pnlFullNameUnderline";
            pnlFullNameUnderline.Size = new Size(309, 2);
            pnlFullNameUnderline.TabIndex = 19;
            // 
            // pnlYeerLevel
            // 
            pnlYeerLevel.BackColor = Color.FromArgb(255, 202, 228);
            pnlYeerLevel.Controls.Add(pnlYearLevelUnderline);
            pnlYeerLevel.Location = new Point(31, 259);
            pnlYeerLevel.Name = "pnlYeerLevel";
            pnlYeerLevel.Size = new Size(201, 40);
            pnlYeerLevel.TabIndex = 19;
            // 
            // pnlYearLevelUnderline
            // 
            pnlYearLevelUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlYearLevelUnderline.Location = new Point(7, 33);
            pnlYearLevelUnderline.Name = "pnlYearLevelUnderline";
            pnlYearLevelUnderline.Size = new Size(187, 2);
            pnlYearLevelUnderline.TabIndex = 19;
            // 
            // pnlProgram
            // 
            pnlProgram.BackColor = Color.FromArgb(255, 202, 228);
            pnlProgram.Controls.Add(pnlProgramUnderline);
            pnlProgram.Location = new Point(277, 259);
            pnlProgram.Name = "pnlProgram";
            pnlProgram.Size = new Size(327, 40);
            pnlProgram.TabIndex = 24;
            // 
            // pnlProgramUnderline
            // 
            pnlProgramUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlProgramUnderline.Location = new Point(8, 33);
            pnlProgramUnderline.Name = "pnlProgramUnderline";
            pnlProgramUnderline.Size = new Size(309, 2);
            pnlProgramUnderline.TabIndex = 19;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
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
            btnClearFilter.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblFilterBy.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFilterBy.Location = new Point(8, 14);
            lblFilterBy.Name = "lblFilterBy";
            lblFilterBy.Size = new Size(74, 21);
            lblFilterBy.TabIndex = 34;
            lblFilterBy.Text = "Filter by:";
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.White;
            lblSearch.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(732, 245);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(201, 21);
            lblSearch.TabIndex = 33;
            lblSearch.Text = "Search Student ID/Name:";
            // 
            // pnltxtSearch
            // 
            pnltxtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnltxtSearch.BackColor = Color.FromArgb(255, 202, 228);
            pnltxtSearch.Controls.Add(pnlSearchUnderline);
            pnltxtSearch.Location = new Point(935, 234);
            pnltxtSearch.Name = "pnltxtSearch";
            pnltxtSearch.Size = new Size(447, 43);
            pnltxtSearch.TabIndex = 24;
            pnltxtSearch.Paint += panel13_Paint;
            // 
            // pnlSearchUnderline
            // 
            pnlSearchUnderline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlSearchUnderline.BackColor = Color.FromArgb(137, 35, 91);
            pnlSearchUnderline.Location = new Point(8, 35);
            pnlSearchUnderline.Name = "pnlSearchUnderline";
            pnlSearchUnderline.Size = new Size(429, 2);
            pnlSearchUnderline.TabIndex = 19;
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnSort);
            pnlSearch.Location = new Point(728, 220);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(869, 69);
            pnlSearch.TabIndex = 34;
            // 
            // PLKSISDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblSearch);
            Controls.Add(pnlFilter);
            Controls.Add(pnlStudentRecord);
            Controls.Add(txtSearch);
            Controls.Add(dgvStudentRecords);
            Controls.Add(pnltxtSearch);
            Controls.Add(pnlSearch);
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
        private Button btnSearch;
        private Button btnFilter;
        private Button btnSort;
        private Panel pnlStudentRecord;
        private Panel pnlFilter;
        private Panel pnlContact;
        private PictureBox pictureBox1;
        private Panel pnlContactUnderline;
        private Panel pnlStudentId;
        private PictureBox pbAdminIcon;
        private Panel pnlStudentIdUnderline;
        private Panel pnlFullName;
        private Panel pnlFullNameUnderline;
        private Panel pnlYeerLevel;
        private Panel panel9;
        private Label lblFullname;
        private Label lblContact;
        private Label lblYearLevel;
        private Label lblProgram;
        private Label lblStudentId;
        private Panel pnlProgram;
        private Panel panel10;
        private Panel panel12;
        private Label lblGender;
        private Label lblStudentRecords;
        private Label lblFilterBy;
        private Label lblSearch;
        private Panel panel13;
        private Panel pnlSearchUnderline;
        private Panel pnlSearch;
        private RadioButton rbFilterAll;
        private Panel pnlYearLevelUnderline;
        private Panel pnlProgramUnderline;
        private Panel pnltxtSearch;
        private Button btnClearFilter;
    }
}