using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace plk_u_sis_wfa
{
    public partial class PLKSISDashboard : Form
    {
        private string selectedStudentId = "";
        private bool isSortedAlphabetically = false;

        public PLKSISDashboard()
        {
            InitializeComponent();

            this.Load += PLKSISDashboard_Load;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSort.Click += btnSort_Click;
            btnSearchClear.Click += btnSearchClear_Click;
            btnFilter.Click += btnFilter_Click;
            btnClearFilter.Click += btnClearFilter_Click;
            dgvStudentRecords.CellClick += dgvStudentRecords_CellClick;
            btnClear.Click += btnClear_Click;

            TestDatabaseConnection();
            SetupComboBoxPlaceholders();
            LoadStudents();
        }

        private void PLKSISDashboard_Load(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadStudents();
        }

        // Gets active (non-deleted) data from MySQL to DataGridView
        private void LoadStudents(string programFilter = "", string yearFilter = "", string searchQuery = "")
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM students WHERE is_deleted = 0";

                    bool applyProgram = !string.IsNullOrWhiteSpace(programFilter) &&
                                       !programFilter.Trim().Equals("Select Program", StringComparison.OrdinalIgnoreCase) &&
                                       !programFilter.Trim().Equals("ALL", StringComparison.OrdinalIgnoreCase) &&
                                       !programFilter.Trim().Equals("All Programs", StringComparison.OrdinalIgnoreCase) &&
                                       !programFilter.Trim().Equals("None", StringComparison.OrdinalIgnoreCase);

                    bool applyYear = !string.IsNullOrWhiteSpace(yearFilter) &&
                                    !yearFilter.Trim().Equals("ALL", StringComparison.OrdinalIgnoreCase) &&
                                    !yearFilter.Trim().Equals("All Years", StringComparison.OrdinalIgnoreCase) &&
                                    !yearFilter.Trim().Equals("All", StringComparison.OrdinalIgnoreCase) &&
                                    !yearFilter.Trim().Equals("None", StringComparison.OrdinalIgnoreCase);

                    bool applySearch = !string.IsNullOrWhiteSpace(searchQuery);

                    if (applyProgram)
                        query += " AND program = @program";

                    if (applyYear)
                        query += " AND year_level = @year";

                    if (applySearch)
                        query += " AND (CONCAT_WS(' ', first_name, middle_name, last_name) LIKE @search OR last_name LIKE @search OR first_name LIKE @search OR student_id LIKE @search)";

                    if (isSortedAlphabetically)
                        query += " ORDER BY last_name ASC, first_name ASC";

                    using (var adapter = new MySqlDataAdapter(query, conn))
                    {
                        if (applyProgram)
                            adapter.SelectCommand.Parameters.AddWithValue("@program", programFilter.Trim());

                        if (applyYear)
                            adapter.SelectCommand.Parameters.AddWithValue("@year", yearFilter.Trim());

                        if (applySearch)
                            adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchQuery.Trim() + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // 1. Bind DataSource
                        dgvStudentRecords.DataSource = dt;

                        // 2. Format Headers & Hide System Columns pagkatapos mag-bind
                        dgvStudentRecords.RowHeadersVisible = false;
                        dgvStudentRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvStudentRecords.ColumnHeadersDefaultCellStyle.Font = new Font(dgvStudentRecords.Font, FontStyle.Bold);
                        dgvStudentRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        FormatColumn("student_id", "Student ID", 75);
                        FormatColumn("first_name", "First Name", 95);
                        FormatColumn("middle_name", "Middle Name", 95);
                        FormatColumn("last_name", "Last Name", 95);
                        FormatColumn("gender", "Gender", 60);
                        FormatColumn("year_level", "Year Level", 75);
                        FormatColumn("program", "Program", 130);
                        FormatColumn("contact_number", "Contact Number", 100);
                        FormatColumn("enrollment_year", "Enrollment Year", 75);
                        FormatColumn("academic_status", "Academic Status", 90);

                        if (dgvStudentRecords.Columns["is_deleted"] != null)
                            dgvStudentRecords.Columns["is_deleted"].Visible = false;

                        if (dgvStudentRecords.Columns["created_at"] != null)
                            dgvStudentRecords.Columns["created_at"].Visible = false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error while loading students:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error loading students:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatColumn(string colName, string headerText, float fillWeight)
        {
            if (dgvStudentRecords.Columns[colName] != null)
            {
                dgvStudentRecords.Columns[colName].HeaderText = headerText;
                dgvStudentRecords.Columns[colName].FillWeight = fillWeight;
            }
        }

        private void SetupComboBoxPlaceholders()
        {
            cmbFilterProgram.Items.Clear();
            cmbFilterProgram.Items.Add("Select Program");
            cmbFilterProgram.Items.Add("BS in Cosmetic Science");
            cmbFilterProgram.Items.Add("BS in Floriculture and Botanical Design");
            cmbFilterProgram.Items.Add("BS in Historical Fashion");
            cmbFilterProgram.Items.Add("BS in Haute Couture and Luxury Fashion Design");
            cmbFilterProgram.SelectedIndex = 0;

            if (cmbEnrollmentYear != null)
            {
                cmbEnrollmentYear.Items.Clear();
                cmbEnrollmentYear.Items.AddRange(new string[] { "2023", "2024", "2025", "2026", "2027" });
                cmbEnrollmentYear.SelectedIndex = -1; 
            }

            if (cmbAcademicStatus != null)
            {
                cmbAcademicStatus.Items.Clear();
                cmbAcademicStatus.Items.AddRange(new string[] { "Active", "Graduated", "Dropped", "Transferred In", "Transferred Out" });
                cmbAcademicStatus.SelectedIndex = -1; 
            }
        }

        private void TestDatabaseConnection()
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed. Please check if MySQL is running:\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetSelectedFilterYear()
        {
            if (rbFilter1stYear != null && rbFilter1stYear.Checked) return "1st Year";
            if (rbFilter2ndYear != null && rbFilter2ndYear.Checked) return "2nd Year";
            if (rbFilter3rdYear != null && rbFilter3rdYear.Checked) return "3rd Year";
            if (rbFilter4thYear != null && rbFilter4thYear.Checked) return "4th Year";
            return "ALL";
        }

        private void btnFilter_Click(object? sender, EventArgs e)
        {
            string selectedProgram = cmbFilterProgram.SelectedItem?.ToString() ?? cmbFilterProgram.Text;
            string selectedYear = GetSelectedFilterYear();
            LoadStudents(selectedProgram, selectedYear, txtSearch.Text);
        }

        private void btnSearchClear_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            string selectedProgram = cmbFilterProgram.SelectedIndex > 0 ? cmbFilterProgram.SelectedItem?.ToString() ?? "" : "";
            string selectedYear = GetSelectedFilterYear();
            LoadStudents(selectedProgram, selectedYear, "");
        }

        private void btnSort_Click(object? sender, EventArgs e)
        {
            isSortedAlphabetically = !isSortedAlphabetically;
            btnSort.Text = isSortedAlphabetically ? "Sorted (A-Z)" : "Sort A-Z";

            string selectedProgram = cmbFilterProgram.SelectedIndex > 0 ? cmbFilterProgram.SelectedItem?.ToString() ?? "" : "";
            string selectedYear = GetSelectedFilterYear();
            LoadStudents(selectedProgram, selectedYear, txtSearch.Text.Trim());
        }

        private string GetSelectedGender()
        {
            if (rbMale.Checked) return "Male";
            if (rbFemale.Checked) return "Female";
            return "";
        }

        // Populate form fields when a row is clicked
        private void dgvStudentRecords_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStudentRecords.Rows[e.RowIndex];
            if (row.Cells["student_id"].Value == null) return;

            selectedStudentId = row.Cells["student_id"].Value?.ToString() ?? "";

            txtStudentId.Text = selectedStudentId;
            txtFN.Text = row.Cells["first_name"].Value?.ToString() ?? "";
            txtMN.Text = row.Cells["middle_name"].Value?.ToString() ?? "";
            txtLN.Text = row.Cells["last_name"].Value?.ToString() ?? "";

            string gender = row.Cells["gender"].Value?.ToString() ?? "";
            rbMale.Checked = (gender == "Male");
            rbFemale.Checked = (gender == "Female");

            cmbYearLevel.SelectedItem = row.Cells["year_level"].Value?.ToString();
            cmbProgram.SelectedItem = row.Cells["program"].Value?.ToString();
            txtContact.Text = row.Cells["contact_number"].Value?.ToString() ?? "";

            string enrYear = row.Cells["enrollment_year"].Value?.ToString() ?? "2026";
            if (!cmbEnrollmentYear.Items.Contains(enrYear) && !string.IsNullOrWhiteSpace(enrYear))
            {
                cmbEnrollmentYear.Items.Add(enrYear);
            }
            cmbEnrollmentYear.SelectedItem = enrYear;

            cmbAcademicStatus.SelectedItem = row.Cells["academic_status"].Value?.ToString() ?? "Active";
        }

        // Add student
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string gender = GetSelectedGender();

            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFN.Text) ||
                string.IsNullOrWhiteSpace(txtLN.Text) ||
                string.IsNullOrWhiteSpace(gender) ||
                cmbYearLevel.SelectedIndex == -1 ||
                cmbProgram.SelectedIndex == -1 ||
                cmbEnrollmentYear.SelectedIndex == -1 ||
                cmbAcademicStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all required fields (Middle Name is optional).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int enrollmentYear = int.Parse(cmbEnrollmentYear.SelectedItem!.ToString()!);

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO students 
                        (student_id, first_name, middle_name, last_name, gender, year_level, program, contact_number, enrollment_year, academic_status, is_deleted)
                        VALUES 
                        (@id, @fn, @mn, @ln, @gender, @year, @program, @contact, @enrYear, @status, 0)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtStudentId.Text.Trim());
                        cmd.Parameters.AddWithValue("@fn", txtFN.Text.Trim());
                        cmd.Parameters.AddWithValue("@mn", string.IsNullOrWhiteSpace(txtMN.Text) ? DBNull.Value : txtMN.Text.Trim());
                        cmd.Parameters.AddWithValue("@ln", txtLN.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@year", cmbYearLevel.SelectedItem?.ToString() ?? cmbYearLevel.Text);
                        cmd.Parameters.AddWithValue("@program", cmbProgram.SelectedItem?.ToString() ?? cmbProgram.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@enrYear", enrollmentYear);
                        cmd.Parameters.AddWithValue("@status", cmbAcademicStatus.SelectedItem?.ToString() ?? "Active");

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
                ClearFields();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show($"Student ID '{txtStudentId.Text.Trim()}' already exists.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add student:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update student
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                MessageBox.Show("Please select a student from the table first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gender = GetSelectedGender();

            if (string.IsNullOrWhiteSpace(txtFN.Text) ||
                string.IsNullOrWhiteSpace(txtLN.Text) ||
                string.IsNullOrWhiteSpace(gender) ||
                cmbYearLevel.SelectedIndex == -1 ||
                cmbProgram.SelectedIndex == -1 ||
                cmbEnrollmentYear.SelectedIndex == -1 ||
                cmbAcademicStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int enrollmentYear = int.Parse(cmbEnrollmentYear.SelectedItem!.ToString()!);

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"UPDATE students 
                        SET first_name = @fn, 
                            middle_name = @mn, 
                            last_name = @ln, 
                            gender = @gender, 
                            year_level = @year, 
                            program = @program, 
                            contact_number = @contact,
                            enrollment_year = @enrYear,
                            academic_status = @status
                        WHERE student_id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fn", txtFN.Text.Trim());
                        cmd.Parameters.AddWithValue("@mn", string.IsNullOrWhiteSpace(txtMN.Text) ? DBNull.Value : txtMN.Text.Trim());
                        cmd.Parameters.AddWithValue("@ln", txtLN.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@year", cmbYearLevel.SelectedItem?.ToString() ?? cmbYearLevel.Text);
                        cmd.Parameters.AddWithValue("@program", cmbProgram.SelectedItem?.ToString() ?? cmbProgram.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@enrYear", enrollmentYear);
                        cmd.Parameters.AddWithValue("@status", cmbAcademicStatus.SelectedItem?.ToString() ?? "Active");
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No changes made or student not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Soft-Delete student
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                MessageBox.Show("Please select a student from the table first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedStudentId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE students SET is_deleted = 1 WHERE student_id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Student record was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            selectedStudentId = "";

            txtStudentId.Clear();
            txtFN.Clear();
            txtMN.Clear();
            txtLN.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cmbYearLevel.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            txtContact.Clear();

            cmbEnrollmentYear.SelectedIndex = -1;
            cmbEnrollmentYear.SelectedIndex = -1;
            cmbEnrollmentYear.Text = string.Empty;

            cmbAcademicStatus.SelectedIndex = -1;
            cmbAcademicStatus.SelectedIndex = -1;
            cmbAcademicStatus.Text = string.Empty;

            dgvStudentRecords.ClearSelection();
        }



        private void btnClearFilter_Click(object? sender, EventArgs e)
        {
            if (cmbFilterProgram.Items.Count > 0) cmbFilterProgram.SelectedIndex = 0;
            if (rbFilter1stYear != null) rbFilter1stYear.Checked = false;
            if (rbFilter2ndYear != null) rbFilter2ndYear.Checked = false;
            if (rbFilter3rdYear != null) rbFilter3rdYear.Checked = false;
            if (rbFilter4thYear != null) rbFilter4thYear.Checked = false;
            LoadStudents();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string selectedProgram = cmbFilterProgram.SelectedIndex > 0 ? cmbFilterProgram.SelectedItem?.ToString() ?? "" : "";
            string selectedYear = GetSelectedFilterYear();
            LoadStudents(selectedProgram, selectedYear, txtSearch.Text.Trim());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PLKLoginScreenForm loginForm = new PLKLoginScreenForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}