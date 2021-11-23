using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class ForgotPassword : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A160AEA;Initial Catalog=SMS;Integrated Security=True");

        Point lastPoint;
        public int emailCount = 0;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ForgotPassword_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void ForgotPassword_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TxtMail_Click(object sender, EventArgs e)
        {
            if (emailCount == 0 )
            {
                TxtMail.Clear();
                emailCount++;
            }

            panel1.BackColor = Color.FromArgb(67, 172, 152);
        }

        private void GetPass_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;

            string email = TxtMail.Text;
            string password;

            List<string> DevMails = new List<string>();
            List<string> StuMails = new List<string>();
            List<string> TecMails = new List<string>();

            SqlCommand passDev = new SqlCommand($"select Password from Developer where Email = '{email}'", connection);
            SqlCommand passStu = new SqlCommand($"select Password from Student where Email = '{email}'", connection);
            SqlCommand passTec = new SqlCommand($"select Password from Teacher where Email = '{email}'", connection);


            SqlCommand devCommand = new SqlCommand($"select Email from Developer", connection);
            SqlCommand stuCommand = new SqlCommand($"select Email from Student", connection);
            SqlCommand tecCommand = new SqlCommand($"select Email from Teacher", connection);

            connection.Open();
            SqlDataReader devReader = devCommand.ExecuteReader();

            while (devReader.Read())
            {
                DevMails.Add(devReader.GetString(0));
            }
            devReader.Close();

            SqlDataReader stuReader = stuCommand.ExecuteReader();
            while (stuReader.Read())
            {
                StuMails.Add(stuReader.GetString(0));
            }
            stuReader.Close();

            SqlDataReader tecReader = tecCommand.ExecuteReader();
            while (tecReader.Read())
            {
                TecMails.Add(tecReader.GetString(0));
            }
            tecReader.Close();

            if (String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DevMails.Contains(email))
            {
                password = passDev.ExecuteScalar().ToString();
                MessageBox.Show($"Your Password is {password}", "Forgot Password", MessageBoxButtons.OK);
            }
            else if (StuMails.Contains(email))
            {
                password = passStu.ExecuteScalar().ToString();
                MessageBox.Show($"Your Password is {password}", "Forgot Password", MessageBoxButtons.OK);
            }
            else if (TecMails.Contains(email))
            {
                password = passTec.ExecuteScalar().ToString();
                MessageBox.Show($"Your Password is {password}", "Forgot Password", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Email doesn't exist", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LoginPage LP = new LoginPage();
            this.Hide();
            LP.ShowDialog();
            this.Close();
        }
    }
}
