using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            TestDatabaseConnection();
            SetupComboBoxPlaceholders();
            LoadStudents();
        }

        // open dashboard form
        private void PLKSISDashboard_Load(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadStudents();
        }

        // gets data from the mysql to dgv
        private void LoadStudents(string programFilter = "", string yearFilter = "", string searchQuery = "")
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM students WHERE 1=1";

                    bool applyProgram = !string.IsNullOrWhiteSpace(programFilter) &&
                                       !programFilter.Trim().Equals(" Select Program", StringComparison.OrdinalIgnoreCase) &&
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
                    {
                        query += " AND program = @program";
                    }

                    if (applyYear)
                    {
                        query += " AND year_level = @year";
                    }

                    if (applySearch)
                    {
                        query += " AND (full_name LIKE @search OR student_id LIKE @search)";
                    }

                    if (isSortedAlphabetically)
                    {
                        query += " ORDER BY full_name ASC";
                    }

                    using (var adapter = new MySqlDataAdapter(query, conn))
                    {
                        if (applyProgram)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@program", programFilter.Trim());
                        }

                        if (applyYear)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@year", yearFilter.Trim());
                        }

                        if (applySearch)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchQuery.Trim() + "%");
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStudentRecords.DataSource = dt;

                        dgvStudentRecords.RowHeadersVisible = false;
                        dgvStudentRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvStudentRecords.ColumnHeadersDefaultCellStyle.Font = new Font(dgvStudentRecords.Font, FontStyle.Bold);

                        dgvStudentRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvStudentRecords.Columns["student_id"] != null)
                        {
                            dgvStudentRecords.Columns["student_id"].HeaderText = "Student ID";
                            dgvStudentRecords.Columns["student_id"].FillWeight = 80;
                        }

                        if (dgvStudentRecords.Columns["full_name"] != null)
                        {
                            dgvStudentRecords.Columns["full_name"].HeaderText = "Full Name";
                            dgvStudentRecords.Columns["full_name"].FillWeight = 150;
                        }

                        if (dgvStudentRecords.Columns["gender"] != null)
                        {
                            dgvStudentRecords.Columns["gender"].HeaderText = "Gender";
                            dgvStudentRecords.Columns["gender"].FillWeight = 60;
                        }

                        if (dgvStudentRecords.Columns["year_level"] != null)
                        {
                            dgvStudentRecords.Columns["year_level"].HeaderText = "Year Level";
                            dgvStudentRecords.Columns["year_level"].FillWeight = 80;
                        }

                        if (dgvStudentRecords.Columns["program"] != null)
                        {
                            dgvStudentRecords.Columns["program"].HeaderText = "Program";
                            dgvStudentRecords.Columns["program"].FillWeight = 100;
                        }

                        if (dgvStudentRecords.Columns["contact_number"] != null)
                        {
                            dgvStudentRecords.Columns["contact_number"].HeaderText = "Contact Number";
                            dgvStudentRecords.Columns["contact_number"].FillWeight = 100;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students:\n" + ex.Message);
            }
        }


        // selection for program filter field
        private void SetupComboBoxPlaceholders()
        {
            cmbFilterProgram.Items.Clear();
            cmbFilterProgram.Items.Add("Select Program");
            cmbFilterProgram.Items.Add("BS in Cosmetic Science");
            cmbFilterProgram.Items.Add("BS in Floriculture and Botanical Design");
            cmbFilterProgram.Items.Add("BS in Historical Fashion");
            cmbFilterProgram.Items.Add("BS in Haute Couture and Luxury Fashion Design");

            cmbFilterProgram.SelectedIndex = 0;
        }

        // c# and mysql connection checker
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
                MessageBox.Show("Database connection failed:\n" + ex.Message);
            }
        }
        // year level selection for filter field
        private string GetSelectedFilterYear()
        {
            if (rbFilter1stYear != null && rbFilter1stYear.Checked) return "1st Year";
            if (rbFilter2ndYear != null && rbFilter2ndYear.Checked) return "2nd Year";
            if (rbFilter3rdYear != null && rbFilter3rdYear.Checked) return "3rd Year";
            if (rbFilter4thYear != null && rbFilter4thYear.Checked) return "4th Year";

            return "ALL";
        }



        // filter button for program and year level filter field
        private void btnFilter_Click(object? sender, EventArgs e)
        {
            string selectedProgram = cmbFilterProgram.SelectedItem?.ToString() ?? cmbFilterProgram.Text;
            string selectedYear = GetSelectedFilterYear();
            string searchText = txtSearch.Text;

            LoadStudents(selectedProgram, selectedYear, searchText);
        }

        // search clear button to clear search box
        private void btnSearchClear_Click(object? sender, EventArgs e)
        {

            txtSearch.Clear();


            string selectedProgram = cmbFilterProgram.SelectedIndex > 0 ? cmbFilterProgram.SelectedItem?.ToString() ?? "" : "";
            string selectedYear = GetSelectedFilterYear();


            LoadStudents(selectedProgram, selectedYear, "");


        }

        //sorting records a-z
        private void btnSort_Click(object? sender, EventArgs e)
        {
            isSortedAlphabetically = !isSortedAlphabetically;

            if (isSortedAlphabetically)
            {
                btnSort.Text = "Sorted (A-Z)";
            }
            else
            {
                btnSort.Text = "Sort A-Z";
            }

            string selectedProgram = cmbFilterProgram.SelectedIndex > 0 ? cmbFilterProgram.SelectedItem?.ToString() ?? "" : "";
            string selectedYear = GetSelectedFilterYear();

            LoadStudents(selectedProgram, selectedYear, txtSearch.Text.Trim());
        }

        // gender selection
        private string GetSelectedGender()
        {
            if (rbMale.Checked) return "Male";
            if (rbFemale.Checked) return "Female";
            return "";
        }

        // data grid view for student records
        private void dgvStudentRecords_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvStudentRecords.Rows[e.RowIndex];

            if (row.Cells["student_id"].Value == null)
                return;

            selectedStudentId = row.Cells["student_id"].Value?.ToString() ?? "";

            txtStudentId.Text = selectedStudentId;
            txtFullName.Text = row.Cells["full_name"].Value?.ToString() ?? "";

            string gender = row.Cells["gender"].Value?.ToString() ?? "";
            rbMale.Checked = (gender == "Male");
            rbFemale.Checked = (gender == "Female");

            cmbYearLevel.Text = row.Cells["year_level"].Value?.ToString() ?? "";
            cmbProgram.Text = row.Cells["program"].Value?.ToString() ?? "";
            txtContact.Text = row.Cells["contact_number"].Value?.ToString() ?? "";
        }

        // add student function
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string gender = GetSelectedGender();

            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(gender) ||
                cmbYearLevel.SelectedIndex == -1 ||
                cmbProgram.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all student fields.");
                return;
            }

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO students 
                        (student_id, full_name, gender, year_level, program, contact_number)
                        VALUES 
                        (@id, @name, @gender, @year, @program, @contact)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtStudentId.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@year", cmbYearLevel.Text);
                        cmd.Parameters.AddWithValue("@program", cmbProgram.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Student added successfully!");
                LoadStudents();
                ClearFields();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Unable to add student:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
            }
        }

        // update stduent function
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                MessageBox.Show("Please select a student from the table first.");
                return;
            }

            string gender = GetSelectedGender();

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(gender) ||
                cmbYearLevel.SelectedIndex == -1 ||
                cmbProgram.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all student fields.");
                return;
            }

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"UPDATE students 
                        SET full_name = @name, 
                            gender = @gender, 
                            year_level = @year, 
                            program = @program, 
                            contact_number = @contact 
                        WHERE student_id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@year", cmbYearLevel.Text);
                        cmd.Parameters.AddWithValue("@program", cmbProgram.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Student updated successfully!");
                        else
                            MessageBox.Show("No changes made or student not found.");
                    }
                }

                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student:\n" + ex.Message);
            }
        }

        // delete stduent function
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                MessageBox.Show("Please select a student from the table first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedStudentId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM students WHERE student_id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Student deleted successfully!");
                        else
                            MessageBox.Show("Student record was not found.");
                    }
                }

                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student:\n" + ex.Message);
            }
        }

        // clear function for student data field/form
        private void ClearFields()
        {
            selectedStudentId = "";

            txtStudentId.Clear();
            txtFullName.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cmbYearLevel.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            txtContact.Clear();

            dgvStudentRecords.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // clear filter button for year level and program filter
        private void btnClearFilter_Click(object? sender, EventArgs e)
        {
            if (cmbFilterProgram.Items.Count > 0)
                cmbFilterProgram.SelectedIndex = 0;
            else
                cmbFilterProgram.SelectedIndex = -1;

            if (rbFilter1stYear != null) rbFilter1stYear.Checked = false;
            if (rbFilter2ndYear != null) rbFilter2ndYear.Checked = false;
            if (rbFilter3rdYear != null) rbFilter3rdYear.Checked = false;
            if (rbFilter4thYear != null) rbFilter4thYear.Checked = false;

            LoadStudents();
        }

        //automatic names showing up while typing sa search bar
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string selectedProgram = cmbFilterProgram.SelectedIndex > 0 ? cmbFilterProgram.SelectedItem?.ToString() ?? "" : "";
            string selectedYear = GetSelectedFilterYear();

            LoadStudents(selectedProgram, selectedYear, txtSearch.Text.Trim());
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e) { }
        private void rbMale_CheckedChanged(object sender, EventArgs e) { }
        private void btnSort_Click_1(object sender, EventArgs e) { }
        private void PLKSISDashboard_Load_1(object sender, EventArgs e) { }
        private void rbFemale_CheckedChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel6_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void panel12_Paint(object sender, PaintEventArgs e) { }
        private void panel13_Paint(object sender, PaintEventArgs e) { }
        private void cmbFilterProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlYeerLevel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFullName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_2(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchClear_Click_1(object sender, EventArgs e)
        {

        }

        // exit button
        private void btnExit_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {

                PLKLoginScreenForm loginForm = new PLKLoginScreenForm();
                loginForm.Show();

                this.Close();
            }
        }

    }
}