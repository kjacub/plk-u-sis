using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace plk_u_sis_wfa
{
    public partial class PLKStudentRecords : Form
    {
        private string selectedStudentId = "";
        public PLKStudentRecords()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dgvStudentRecords.CellClick += dgvStudentRecords_CellClick;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            TestDatabaseConnection();
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void PLKStudentRecords_Load(object sender, EventArgs e)
        {

            LoadStudents();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStudentId_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblYearLevel_Click(object sender, EventArgs e)
        {


        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void TestDatabaseConnection()
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Connected to MySQL successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database connection failed:\n" + ex.Message);
            }
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM students";

                    using (var adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStudentRecords.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students:\n" + ex.Message);
            }
        }


        private void dgvStudentRecords_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvStudentRecords.Rows[e.RowIndex];

            if (row.Cells["student_id"].Value == null)
                return;

            selectedStudentId =
                row.Cells["student_id"].Value?.ToString() ?? "";

            txtStudentId.Text = selectedStudentId;
            txtFullName.Text = row.Cells["full_name"].Value?.ToString() ?? "";
            cmbGender.Text = row.Cells["gender"].Value?.ToString() ?? "";
            cmbYearLevel.Text = row.Cells["year_level"].Value?.ToString() ?? "";
            cmbProgram.Text = row.Cells["program"].Value?.ToString() ?? "";
            txtContact.Text = row.Cells["contact_number"].Value?.ToString() ?? "";
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                cmbGender.SelectedIndex == -1 ||
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
                        cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                        cmd.Parameters.AddWithValue("@year", cmbYearLevel.Text);
                        cmd.Parameters.AddWithValue("@program", cmbProgram.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                }


                MessageBox.Show("Student added successfully!");
                LoadStudents();
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

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                MessageBox.Show("Please select a student from the table first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                cmbGender.SelectedIndex == -1 ||
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
                        cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
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
        private void ClearFields()
        {
            selectedStudentId = "";

            txtStudentId.Clear();
            txtFullName.Clear();
            cmbGender.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            txtContact.Clear();

            dgvStudentRecords.ClearSelection();
        }


        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedStudentId))
            {
                MessageBox.Show("Please select a student from the table first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student?",
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

                    string query =
                        "DELETE FROM students WHERE student_id = @id";

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

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}










