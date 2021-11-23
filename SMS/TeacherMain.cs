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
    public partial class TeacherMain : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A160AEA;Initial Catalog=SMS;Integrated Security=True");

        Point lastPoint;

        public int subjectID;
        public int departmentID;
        public int teacherID;

        public TeacherMain()
        {
            InitializeComponent();
            connection.Open();
            SqlCommand cmd = new SqlCommand($"select * from Teacher where Email = '{LoginPage.logEmail}' and Password = '{LoginPage.logPass}'", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TxtID.Text = Convert.ToString(reader.GetInt32(0));
                teacherID = reader.GetInt32(0);
                TxtStatus.Text = string.Concat(reader.GetString(1), " ", reader.GetString(2));           //Daxil olan Akkaunt melumatlari
                TxtEmail.Text = reader.GetString(3);
                TxtGrpSlry.Text = Convert.ToString(reader.GetSqlDecimal(5));
                subjectID = reader.GetInt32(6);
                departmentID = reader.GetInt32(7);
            }
            reader.Close();
            SqlCommand cmdSub = new SqlCommand($"select  SubjectName from Subject where SubjectID = {subjectID}", connection);
            SqlCommand cmdDep = new SqlCommand($"select DepartmentName from Department where DepartmentID = {departmentID}", connection);
            TxtDep.Text = cmdDep.ExecuteScalar().ToString();
            TxtSubSpe.Text = cmdSub.ExecuteScalar().ToString();
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
            dataGridView1.Visible = true;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($@"select Tbl_Group.GroupID,GroupName from TeacherGroup
                                                          join Tbl_Group on (TeacherGroup.GroupID = Tbl_Group.GroupID)
                                                          join Teacher on (TeacherGroup.TeacherID = Teacher.TeacherID)
                                                          where Teacher.TeacherID = {teacherID}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCell = dataGridView1.SelectedCells[0].RowIndex;

            int groupID = (int)dataGridView1.Rows[selectedCell].Cells[0].Value;

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($@"select Name,Surname,Email,Specialty.SpecialtyName from Student 
                                                         join Specialty on (Student.SpecialtyID = Specialty.SpecialtyID)
                                                         where GroupID = {groupID}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
    }
}
