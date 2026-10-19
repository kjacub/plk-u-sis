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

            this.Shown += (s, e) =>
            {
                lblAdminLogin.Focus();
            };
        }

        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPass.Checked)
            {
                txtPasswordField.UseSystemPasswordChar = false;
                txtPasswordField.PasswordChar = '\0';
            }
            else
            {
                txtPasswordField.UseSystemPasswordChar = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
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
            timer1_Tick(sender, e);
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


            string[] allowedAdmins = { "8520", "8520", "8520" };


            string correctPassword = "plk";


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


                PLKSISDashboard mainForm = new PLKSISDashboard();
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

        private void txtPasswordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblCharter_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void lblAdminLogin_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void pnlLoginDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void ckbShowPass_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCharter2_Click(object sender, EventArgs e)
        {
            PLKProgAndProf charterForm = new PLKProgAndProf();
            charterForm.Show();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnCharter1_Click(object sender, EventArgs e)
        {
            PLKCharterBook charterForm = new PLKCharterBook();
            charterForm.Show();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnCharter3_Click(object sender, EventArgs e)
        {
            PLKHistory charterForm = new PLKHistory();
            charterForm.Show();
        }
    }
}
