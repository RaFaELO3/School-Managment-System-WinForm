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
    public partial class StudentMain : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A160AEA;Initial Catalog=SMS;Integrated Security=True");
        
        Point lastPoint;

        public bool chosenTec = false;
        public bool chosenGrp = false;
        public bool chosenSub = false;

        public int groupID;
        public int specialtyID;

        public StudentMain()
        {
            InitializeComponent();

            connection.Open();
            SqlCommand cmd = new SqlCommand($"select * from Student where Email = '{LoginPage.logEmail}' and Password = '{LoginPage.logPass}'", connection);    
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TxtID.Text = Convert.ToString(reader.GetInt32(0));
                TxtStatus.Text = string.Concat(reader.GetString(1)," ",reader.GetString(2));           //Daxil olan Akkaunt melumatlari
                TxtEmail.Text = reader.GetString(4);
                groupID = reader.GetInt32(3);
                specialtyID = reader.GetInt32(6);
            }
            reader.Close();
            SqlCommand cmdGrp = new SqlCommand($"select GroupName from Tbl_Group where GroupID = {groupID}", connection);
            SqlCommand cmdSpe = new SqlCommand($"select SpecialtyName from Specialty where SpecialtyID = {specialtyID}", connection);
            TxtGrpSlry.Text = cmdGrp.ExecuteScalar().ToString();
            TxtSubSpe.Text = cmdSpe.ExecuteScalar().ToString();
            connection.Close();
        }
        #region Window Mowement
        private void LblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void LblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #endregion

        #region Navigation Buttons
        private void StuPbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void StuMinimize_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;

        }

        #endregion

        #region Open Close SubMenu
        private void CloseSubMenu()
        {
            if (panelSubInfo.Visible == true)
            {
                panelSubInfo.Visible = false;
            }      
        }

        private void OpenSubMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                CloseSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }

        }
        #endregion

        #region Button SubMenu
        public void ColorChange(Button button)
        {
            if (button.BackColor == Color.FromArgb(32, 106, 85))
            {
                button.BackColor = Color.FromArgb(29, 98, 79);
            }
            else
            {
                button.BackColor = Color.FromArgb(32, 106, 85);
            }
        }
        private void BtnInfo_MouseEnter(object sender, EventArgs e)
        {
            OpenSubMenu(panelSubInfo);
            ColorChange(BtnInfo);

        }

        private void BtnInfo_MouseLeave(object sender, EventArgs e)
        {
            ColorChange(BtnInfo);
        }

        #endregion

        private void BtnInfoGrp_Click(object sender, EventArgs e)
        {
            chosenGrp = true;
            chosenGrp = false;
            chosenSub = false;

            dataGridView1.Visible = true;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($"select Name,Surname,Email from Student where GroupID = {groupID}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void BtnInfoSub_Click(object sender, EventArgs e)
        {
            chosenGrp = false;
            chosenGrp = true;
            chosenSub = false;

            dataGridView1.Visible = true;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($@"select SubjectName from GroupSubject
                                                           join Tbl_Group on (GroupSubject.GroupID = Tbl_Group.GroupID)
                                                           join Subject on (GroupSubject.SubjectID = Subject.SubjectID)
                                                           where Tbl_Group.GroupID = {groupID}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void BtnInfoTec_Click(object sender, EventArgs e)
        {
            chosenGrp = false;
            chosenGrp = true;
            chosenSub = false;

            dataGridView1.Visible = true;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($@"select Teacher.Name,Teacher.Surname,Subject.SubjectName,Teacher.Email from TeacherGroup
                                                           join Tbl_Group on (TeacherGroup.GroupID = Tbl_Group.GroupID)
                                                           join Teacher on (TeacherGroup.TeacherID = Teacher.TeacherID)
                                                           join Subject on (Teacher.SubjectID = Subject.SubjectID)
                                                           where Tbl_Group.GroupID = {groupID}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void StudentMain_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out ?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginPage LP = new LoginPage();
                this.Hide();
                LP.ShowDialog();
                this.Close();
            }
        }
    }
}
