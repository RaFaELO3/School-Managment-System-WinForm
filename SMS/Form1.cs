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
    public partial class LoginPage : Form
    {
        public static string logEmail;
        public static string logPass;

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A160AEA;Initial Catalog=SMS;Integrated Security=True");

        Point lastPoint;

        public bool asStudent = false;
        public bool asTeacher = false;
        public bool asDeveloper = false;

        public int mailCount = 0;
        public int passCount = 0;


        public LoginPage()
        {
            InitializeComponent();
        }
        #region Window Movement
        private void LoginPage_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void LoginPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #endregion

        private void PbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PbStudent.Image = SMS.Properties.Resources.Student1;
            PbTeacher.Image = SMS.Properties.Resources.Teacher;

            asDeveloper = true;
            asTeacher = false;
            asStudent = false;
        }
        private void PbStudent_Click(object sender, EventArgs e)
        {
            PbStudent.Image = SMS.Properties.Resources.Student2;
            PbTeacher.Image = SMS.Properties.Resources.Teacher;

            asStudent = true;
            asTeacher = false;
            asDeveloper = false;
        }

        private void PbTeacher_Click(object sender, EventArgs e)
        {
            PbTeacher.Image = SMS.Properties.Resources.Teacher2;
            PbStudent.Image = PbStudent.Image = SMS.Properties.Resources.Student1;

            asTeacher = true;
            asStudent = false;
            asDeveloper = false;
        }

        private void TxtMail_Click(object sender, EventArgs e)
        {
            if (mailCount == 0)
            {
                TxtMail.Clear();
                mailCount++;
            }

            pictureBox2.Image = SMS.Properties.Resources.ChosenMail;
            panel1.BackColor = Color.FromArgb(44, 160, 44);

            pictureBox5.Image = SMS.Properties.Resources.DefaultQifil;
            panel2.BackColor = Color.White;
        }

        private void TxtPass_Click(object sender, EventArgs e)
        {
            if (passCount == 0)
            {
                TxtPass.Clear();
                passCount++;
            }
            
            TxtPass.UseSystemPasswordChar = true;

            pictureBox5.Image = SMS.Properties.Resources.ChosenQifil;
            panel2.BackColor = Color.FromArgb(44, 160, 44);

            pictureBox2.Image = SMS.Properties.Resources.DefaultMail;
            panel1.BackColor = Color.White;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = TxtMail.Text;
            string password = TxtPass.Text;

            List<string> DevMails = new List<string>();
            List<string> StuMails = new List<string>();
            List<string> TecMails = new List<string>();

            if (asStudent == false && asTeacher == false && asDeveloper == false)
            {
                MessageBox.Show("Choose how you want to login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (asStudent == false && asTeacher == false && asDeveloper == true)
            {
                SqlCommand passDev = new SqlCommand($"select Password from Developer where Email = '{email}'", connection);
                SqlCommand DevCommand = new SqlCommand($"select Email from Developer", connection);

                connection.Open();
                SqlDataReader devReader = DevCommand.ExecuteReader();
                while (devReader.Read())
                {
                    DevMails.Add(devReader.GetString(0));
                }
                devReader.Close();

                if (String.IsNullOrEmpty(email) && String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Email and Password can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Email can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!DevMails.Contains(email))
                {
                    MessageBox.Show("Wrong Email. Try again", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password == passDev.ExecuteScalar().ToString())
                {
                    logEmail = email;
                    logPass = password;

                    DeveloperMain DM = new DeveloperMain();
                    this.Hide();
                    DM.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password. Try again", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else if (asStudent == true && asTeacher == false && asDeveloper == false)
            {
                SqlCommand passStu = new SqlCommand($"select Password from Student where Email = '{email}'", connection);
                SqlCommand StuCommand = new SqlCommand($"select Email from Student", connection);

                connection.Open();
                SqlDataReader stuReader = StuCommand.ExecuteReader();
                while (stuReader.Read())
                {
                    StuMails.Add(stuReader.GetString(0));
                }
                stuReader.Close();

                if (String.IsNullOrEmpty(email) && String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Email and Password can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Email can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!StuMails.Contains(email))
                {
                    MessageBox.Show("Wrong Email. Try again", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password == passStu.ExecuteScalar().ToString())
                {
                    logEmail = email;
                    logPass = password;

                    StudentMain SM = new StudentMain();
                    this.Hide();
                    SM.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password. Try again", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else if (asStudent == false && asTeacher == true && asDeveloper == false)
            {
                SqlCommand passTec = new SqlCommand($"select Password from Teacher where Email = '{email}'", connection);
                SqlCommand TecCommand = new SqlCommand($"select Email from Teacher", connection);

                connection.Open();
                SqlDataReader tecReader = TecCommand.ExecuteReader();
                while (tecReader.Read())
                {
                    TecMails.Add(tecReader.GetString(0));
                }
                tecReader.Close();

                if (String.IsNullOrEmpty(email) && String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Email and Password can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Email can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!TecMails.Contains(email))
                {
                    MessageBox.Show("Wrong Email. Try again", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password can't be empty", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password == passTec.ExecuteScalar().ToString())
                {
                    logEmail = email;
                    logPass = password;

                    TeacherMain TM = new TeacherMain();
                    this.Hide();
                    TM.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password. Try again", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void LblForgot_MouseEnter(object sender, EventArgs e)
        {
            LblForgot.ForeColor = Color.FromArgb(0, 170, 0);
        }

        private void LblForgot_MouseLeave(object sender, EventArgs e)
        {
            LblForgot.ForeColor = Color.White;
        }

        private void LblForgot_Click(object sender, EventArgs e)
        {
            ForgotPassword FP = new ForgotPassword();
            this.Hide();
            FP.ShowDialog();
            this.Close();
            
        }
    }
}
