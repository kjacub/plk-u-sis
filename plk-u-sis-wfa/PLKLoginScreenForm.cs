using System;
using System.Drawing;
using System.Windows.Forms;

namespace plk_u_sis_wfa
{
    public partial class PLKLoginScreenForm : Form
    {
        public PLKLoginScreenForm()
        {
            InitializeComponent();
            pbLogo.Parent = pnlHeader;
            pbLogo.BackColor = Color.White;
            pbLogo.BorderStyle = BorderStyle.None;

            pbAdminIcon.SizeMode = PictureBoxSizeMode.Zoom;
        }

             private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblAdminId_Click(object sender, EventArgs e)
        {

        }

        private void picUserIcon_Click(object sender, EventArgs e)
        {

        }

        private void PLKLoginScreenForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblPLKU_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlAdminId_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlLoginField_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbAdminIcon_Click(object sender, EventArgs e)
        {

        }

        private void pnlUnder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlUnder_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblPassword_Click_1(object sender, EventArgs e)
        {

        }

            private void btnLogIn_Click(object sender, EventArgs e)
        {
            string enteredAdmin = txtAdminIdField.Text.Trim();
            string enteredPassword = txtPasswordField.Text.Trim();

         
            string[] allowedAdmins = { "05609", "05610", "05611" };

       
            string correctPassword = "plkuniversity2026";

        
            if (string.IsNullOrEmpty(enteredAdmin) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValidAdmin = Array.Exists(allowedAdmins, admin => admin.Equals(enteredAdmin, StringComparison.OrdinalIgnoreCase));

            if (isValidAdmin && enteredPassword == correctPassword)
            {
                MessageBox.Show("Login Successful!" +
                    "\nWelcome to PLK University Student Information System.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                PLKStudentRecords mainForm = new PLKStudentRecords();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Admin ID or Password. Access restricted to authorized personnel.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordField.Clear();
                txtPasswordField.Focus();
            }
        }

     


            

            }
        }

       