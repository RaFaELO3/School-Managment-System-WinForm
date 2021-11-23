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
    public partial class DeveloperMain : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-A160AEA;Initial Catalog=SMS;Integrated Security=True");

        Point lastPoint;

        public bool chosenDev = false;
        public bool chosenDep = false;
        public bool chosenTec = false;
        public bool chosenGrp = false;
        public bool chosenStu = false;
        public bool chosenSub = false;
        public bool chosenSpe = false;

        public bool queryList = false;
        public bool queryAdd = false;
        public bool queryUpdate = false;
        public bool queryDelete = false;
        public bool queryFind = false;



        public DeveloperMain()
        {
            InitializeComponent();
            SubMenuDisable();

            connection.Open();
            SqlCommand cmd = new SqlCommand($"select * from Developer where Email = '{LoginPage.logEmail}' and Password = '{LoginPage.logPass}'", connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AccID.Text = Convert.ToString(reader.GetInt32(0));
                AccName.Text = reader.GetString(1);
                AccSurname.Text = reader.GetString(2);
                AccEmail.Text = reader.GetString(3);
            }
            reader.Close();
            connection.Close();

        }

        public void HideInfo()
        {
            LblID.Visible = false;
            TxtID.Visible = false;

            LblStatus.Visible = false;
            TxtStatus.Visible = false;

            LblMail.Visible = false;
            TxtEmail.Visible = false;

            LblPass.Visible = false;
            TxtPass.Visible = false;

            LblGrpSlry.Visible = false;
            TxtGrpSlry.Visible = false;

            LblSubSpe.Visible = false;
            TxtSubSpe.Visible = false;

            LblDep.Visible = false;
            TxtDep.Visible = false;

            panel5.Visible = false;   //ID
            panel6.Visible = false;   //Status
            panel7.Visible = false;   //Password
            panel8.Visible = false;   //Email
            panel10.Visible = false;  //Subject or Specialty
            panel11.Visible = false;  //Department
            panel12.Visible = false;  //Group or Salary

            BtnCrud.Visible = false;
        }

        public void ClearTxtBox()
        {
            TxtID.Clear();
            TxtStatus.Clear();
            TxtEmail.Clear();
            TxtDep.Clear();
            TxtGrpSlry.Clear();
            TxtSubSpe.Clear();
            TxtPass.Clear();
        }
        public void EnableTxtBox()
        {
            TxtStatus.ReadOnly = false;
            TxtEmail.ReadOnly = false;
            TxtDep.ReadOnly = false;
            TxtGrpSlry.ReadOnly = false;
            TxtSubSpe.ReadOnly = false;
            TxtPass.ReadOnly = false;
        } 

        private void SubMenuDisable()
        {
            panelSubAdd.Visible = false;
            panelSubList.Visible = false;
            panelSubUpdate.Visible = false;
            panelSubDelete.Visible = false;
            panelSubFind.Visible = false;
        }

        #region Open Close SubMenu
        private void CloseSubMenu()
        {
            if (panelSubAdd.Visible == true)
            {
                panelSubAdd.Visible = false;
            }
            if (panelSubList.Visible == true)
            {
                panelSubList.Visible = false;
            }
            if (panelSubUpdate.Visible == true)
            {
                panelSubUpdate.Visible = false;
            }
            if (panelSubDelete.Visible == true)
            {
                panelSubDelete.Visible = false;
            }
            if (panelSubFind.Visible == true)
            {
                panelSubFind.Visible = false;
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

        private void DevPbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Window Movement

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

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


        private void BtnList_MouseEnter(object sender, EventArgs e)
        {
            OpenSubMenu(panelSubList);
            ColorChange(BtnList);

        }

        private void BtnList_MouseLeave(object sender, EventArgs e)
        {
            ColorChange(BtnList);
        }

        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            OpenSubMenu(panelSubAdd);
            ColorChange(BtnAdd);

        }
        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            ColorChange(BtnAdd);
        }

        private void BtnUpdate_MouseEnter(object sender, EventArgs e)
        {
            OpenSubMenu(panelSubUpdate);
            ColorChange(BtnUpdate);

        }
        private void BtnUpdate_MouseLeave(object sender, EventArgs e)
        {
            ColorChange(BtnUpdate);
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            OpenSubMenu(panelSubDelete);
            ColorChange(BtnDelete);

        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {

            ColorChange(BtnDelete);
        }

        private void BtnFind_MouseEnter(object sender, EventArgs e)
        {
            OpenSubMenu(panelSubFind);
            ColorChange(BtnFind);
            if (panelSubFind.Visible == true)
            {
                MessageBox.Show("Please select how you want to search in below", "Ultimate Search System", MessageBoxButtons.OK);
            }
        }

        private void BtnFind_MouseLeave(object sender, EventArgs e)
        {
            ColorChange(BtnFind);
        }
        #endregion

        #region Getinfo

        public void GetDeveloper()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Developer", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        public void GetDepartment()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Department", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        public void GetTeacher()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Teacher", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        public void GetGroup()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Tbl_Group", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        public void GetStudent()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Student", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        public void GetSubject()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Subject", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        public void GetSpecialty()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Specialty", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        #endregion

        #region List Commands

        public void TrueList()
        {
            queryList = true;
            queryAdd = false;
            queryUpdate = false;
            queryDelete = false;
            queryFind = false;

            if (queryFind == false)
            {
                LblID.Text = "ID";
                TxtID.ReadOnly = true;
            }
            TxtStatus.ReadOnly = true;
            TxtEmail.ReadOnly = true;
            TxtPass.ReadOnly = true;
            TxtGrpSlry.ReadOnly = true;
            TxtSubSpe.ReadOnly = true;
            TxtDep.ReadOnly = true;

            BtnCrud.Visible = false;
        }
        private void BtnListDev_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDeveloper();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Developer";

            chosenDev = true;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueList();

        }
        private void BtnListDep_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDepartment();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Department";

            chosenDev = false;
            chosenDep = true;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueList();
        }
        private void BtnListTec_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetTeacher();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Teacher";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueList();
        }

        private void BtnListGrp_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetGroup();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Group";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = true;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueList();
        }

        private void BtnListStu_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetStudent();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Student";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = true;
            chosenSub = false;
            chosenSpe = false;

            TrueList();
        }

        private void BtnListSub_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSubject();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Subject";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = true;
            chosenSpe = false;

            TrueList();
        }
        private void BtnListSte_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSpecialty();
            LblTitle.Visible = true;
            LblTitle.Text = "List - Specialty";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = true;

            TrueList();

        }

        #endregion

        #region Add Commands
        public void TrueAdd()
        {
            queryList = false;
            queryAdd = true;
            queryUpdate = false;
            queryDelete = false;
            queryFind = false;

            if (queryFind == false)
            {
                LblID.Text = "ID";
                TxtID.ReadOnly = true;
            }
            TxtStatus.ReadOnly = false;
            TxtEmail.ReadOnly = false;
            TxtPass.ReadOnly = false;
            TxtGrpSlry.ReadOnly = false;
            TxtSubSpe.ReadOnly = false;
            TxtDep.ReadOnly = false;

            TxtID.Clear();
            ShowButton();

            if (chosenDev == false && chosenTec == false && chosenStu == false)
            {
                TxtStatus.Text = "Name";
            }
            else
            {
                TxtStatus.Text = "Name Surname";
            }
            TxtEmail.Text = "Email";
            TxtPass.Text = "Password";
            if (chosenTec == true)
            {
                TxtGrpSlry.Text = "Salary";
                TxtSubSpe.Text = "Subject ID";
            }
            else if (chosenStu == true)
            {
                TxtGrpSlry.Text = "Group ID";
                TxtSubSpe.Text = "Specialty ID";
            }
            TxtDep.Text = "Department ID";

        }
        private void BtnAddDev_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDeveloper();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Developer";

            chosenDev = true;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            DevInfo();
            TrueAdd();
        }

        private void BtnAddDep_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDepartment();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Department";

            chosenDev = false;
            chosenDep = true;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            DepInfo();
            TrueAdd();
        }

        private void BtnAddTec_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetTeacher();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Teacher";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TecInfo();
            TrueAdd();


        }

        private void BtnAddGrp_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetGroup();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Group";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = true;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            GrpInfo();
            TrueAdd();
        }

        private void BtnAddStu_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetStudent();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Student";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = true;
            chosenSub = false;
            chosenSpe = false;

            StuInfo();
            TrueAdd();
        }

        private void BtnAddSub_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSubject();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Subject";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = true;
            chosenSpe = false;

            SubInfo();
            TrueAdd();
        }

        private void BtnAddSpe_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSpecialty();

            LblTitle.Visible = true;
            LblTitle.Text = "Add - Specialty";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = true;

            SpeInfo();
            TrueAdd();
        }
        #endregion

        #region Update Commands

        public void TrueUpdate()
        {
            queryList = false;
            queryAdd = false;
            queryUpdate = true;
            queryDelete = false;
            queryFind = false;

            if (queryFind == false)
            {
                LblID.Text = "ID";
                TxtID.ReadOnly = true;
            }
            TxtStatus.ReadOnly = false;
            TxtEmail.ReadOnly = false;
            TxtPass.ReadOnly = false;
            TxtGrpSlry.ReadOnly = false;
            TxtSubSpe.ReadOnly = false;
            TxtDep.ReadOnly = false;

            TxtID.Clear();
            ShowButton();
        }

        private void BtnUptDev_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDeveloper();

            LblTitle.Visible = true;
            LblTitle.Text = "Update - Developer";

            chosenDev = true;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            DevInfo();
            TrueUpdate();
        }

        private void BtnUptDep_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDepartment();

            LblTitle.Visible = true;
            LblTitle.Text = "Update - Department";

            chosenDev = false;
            chosenDep = true;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            DepInfo();
            TrueUpdate();
        }

        private void BtnUptTec_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetTeacher();

            LblTitle.Visible = true;
            LblTitle.Text = "Update - Teacher";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TecInfo();
            TrueUpdate();
        }

        private void BtnUptGrp_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetGroup();
            LblTitle.Visible = true;
            LblTitle.Text = "Update - Group";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = true;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            GrpInfo();
            TrueUpdate();
        }

        private void BtnUptStu_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetStudent();
            LblTitle.Visible = true;
            LblTitle.Text = "Update - Student";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = true;
            chosenSub = false;
            chosenSpe = false;
            StuInfo();
            TrueUpdate();
        }

        private void BtnUptSub_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSubject();
            LblTitle.Visible = true;
            LblTitle.Text = "Update - Subject";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            SubInfo();
            TrueUpdate();
        }

        private void BtnUptSpe_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSpecialty();
            LblTitle.Visible = true;
            LblTitle.Text = "Update - Specialty";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            SpeInfo();
            TrueUpdate();
        }
        #endregion

        #region Delete Commands
        public void TrueDelete()
        {
            queryList = false;
            queryAdd = false;
            queryUpdate = false;
            queryDelete = true;
            queryFind = false;

            TxtStatus.ReadOnly = true;
            TxtEmail.ReadOnly = true;
            TxtPass.ReadOnly = true;
            TxtGrpSlry.ReadOnly = true;
            TxtSubSpe.ReadOnly = true;
            TxtDep.ReadOnly = true;

            TxtID.Clear();
            ShowButton();
        }

        private void BtnDelDev_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDeveloper();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Developer";

            chosenDev = true;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueDelete();
        }

        private void BtnDelDep_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetDepartment();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Department";

            chosenDev = false;
            chosenDep = true;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueDelete();
        }

        private void BtnDelTec_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetTeacher();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Teacher";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueDelete();
        }

        private void BtnDelGrp_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetGroup();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Group";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = true;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueDelete();
        }

        private void BtnDelStu_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetStudent();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Student";

            chosenDev = true;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = true;
            chosenSub = false;
            chosenSpe = false;

            TrueDelete();
        }

        private void BtnDelSub_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSubject();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Subject";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = true;
            chosenSpe = false;

            TrueDelete();
        }

        private void BtnDelSpe_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            GetSpecialty();
            LblTitle.Visible = true;
            LblTitle.Text = "Delete - Specialty";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = true;

            TrueDelete();
        }
        #endregion

        #region Find Commands
        public void TrueFind()
        {
            queryList = false;
            queryAdd = false;
            queryUpdate = false;
            queryDelete = false;
            queryFind = true;
     
            TxtEmail.ReadOnly = true;
            TxtPass.ReadOnly = true;
            TxtGrpSlry.ReadOnly = true;
            TxtSubSpe.ReadOnly = true;
            TxtDep.ReadOnly = true;

            TxtID.Clear();
            ShowButton();
        }
        public void CheckBoxText()
        {
            if (ChkBoxName.Checked)
            {                               
                LblStatus.Visible = true;
                LblStatus.Text = "Search by Name";
                TxtStatus.Visible = true;
                TxtStatus.ReadOnly = false;
                panel6.Visible = true; //Status

                LblID.Visible = false;
                TxtID.Visible = false;
                panel5.Visible = false; //ID
                TxtID.Clear();


            }
            else if (ChkBoxID.Checked)
            {
                LblID.Visible = true;
                LblID.Text = "Search by ID";
                TxtID.Visible = true;
                TxtID.ReadOnly = false;
                panel5.Visible = true; //ID

                LblStatus.Visible = false;
                TxtStatus.Visible = false;
                panel6.Visible = false;   //Status
                TxtStatus.Clear();
            }
        }

        private void ChkBoxID_CheckedChanged(object sender, EventArgs e)
        {
            ChkBoxName.Checked = !ChkBoxID.Checked;
        }

        private void ChkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            ChkBoxID.Checked = !ChkBoxName.Checked;
        }

        private void BtnFindDev_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetDeveloper();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Developer";

            chosenDev = true;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;
            
            TrueFind();
            CheckBoxText();
        }

        private void BtnFindDep_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetDepartment();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Department";

            chosenDev = false;
            chosenDep = true;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;
          
            TrueFind();
            CheckBoxText();
        }

        private void BtnFindTec_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetTeacher();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Teacher";

            chosenDev = false;
            chosenDep = false;
            chosenTec = true;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueFind();
            CheckBoxText();
        }

        private void BtnFindGrp_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetGroup();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Group";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = true;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = false;

            TrueFind();
            CheckBoxText();
        }

        private void BtnFindStu_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetStudent();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Student";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = true;
            chosenSub = false;
            chosenSpe = false;

            TrueFind();
            CheckBoxText();
        }

        private void BtnFindSub_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetSubject();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Subject";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = true;
            chosenSpe = false;

            TrueFind();
            CheckBoxText();
        }

        private void BtnFindSpe_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            HideInfo();
            GetSpecialty();
            LblTitle.Visible = true;
            LblTitle.Text = "Find - Specialty";

            chosenDev = false;
            chosenDep = false;
            chosenTec = false;
            chosenGrp = false;
            chosenStu = false;
            chosenSub = false;
            chosenSpe = true;

            TrueFind();
            CheckBoxText();
        }
        #endregion

        #region Maximize Minimize
        private void DevMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void DevMinimize_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;

        }


        #endregion

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

        public void ShowButton()
        {
            if (queryList == false)
            {
                BtnCrud.Visible = true;
                if (queryAdd == true)
                {
                    BtnCrud.Text = "Add";
                }
                else if (queryUpdate == true)
                {
                    BtnCrud.Text = "Save Changes";
                }
                else if (queryDelete == true)
                {
                    BtnCrud.Text = "Delete";
                }
                else if (queryFind == true)
                {
                    BtnCrud.Text = "Find";
                }
            }
        }

        #region Table Informations
        public void DevInfo()
        {
            HideInfo();
            ShowButton();

            LblID.Visible = true;
            TxtID.Visible = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Developer";
            TxtStatus.Visible = true;

            LblMail.Visible = true;
            TxtEmail.Visible = true;

            LblPass.Visible = true;
            TxtPass.Visible = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status
            panel7.Visible = true;   //Password
            panel8.Visible = true;   //Email
        }
        public void DepInfo()
        {
            HideInfo();

            ShowButton();

            LblID.Visible = true;
            TxtID.Visible = true;
            TxtID.ReadOnly = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Department";
            TxtStatus.Visible = true;
            TxtStatus.ReadOnly = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status
        }
        public void TecInfo()
        {
            HideInfo();
            ShowButton();
            LblID.Visible = true;
            TxtID.Visible = true;
            TxtID.ReadOnly = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Teacher";
            TxtStatus.Visible = true;
            TxtStatus.ReadOnly = true;

            LblMail.Visible = true;
            TxtEmail.Visible = true;
            TxtEmail.ReadOnly = true;

            LblPass.Visible = true;
            TxtPass.Visible = true;
            TxtPass.ReadOnly = true;

            LblGrpSlry.Visible = true;
            LblGrpSlry.Text = "Salary";
            TxtGrpSlry.Visible = true;
            TxtGrpSlry.ReadOnly = true;

            LblSubSpe.Visible = true;
            LblSubSpe.Text = "Subject";
            TxtSubSpe.Visible = true;
            TxtSubSpe.ReadOnly = true;

            LblDep.Visible = true;
            TxtDep.Visible = true;
            TxtDep.ReadOnly = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status
            panel7.Visible = true;   //Password
            panel8.Visible = true;   //Email
            panel10.Visible = true;  //Subject or Specialty
            panel11.Visible = true;  //Department
            panel12.Visible = true;  //Group or Salary
        }
        public void GrpInfo()
        {
            HideInfo();
            ShowButton();
            LblID.Visible = true;
            TxtID.Visible = true;
            TxtID.ReadOnly = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Group";
            TxtStatus.Visible = true;
            TxtStatus.ReadOnly = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status

        }
        public void StuInfo()
        {
            HideInfo();
            ShowButton();
            LblID.Visible = true;
            TxtID.Visible = true;
            TxtID.ReadOnly = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Student";
            TxtStatus.Visible = true;
            TxtStatus.ReadOnly = true;

            LblMail.Visible = true;
            TxtEmail.Visible = true;
            TxtEmail.ReadOnly = true;

            LblPass.Visible = true;
            TxtPass.Visible = true;
            TxtPass.ReadOnly = true;

            LblGrpSlry.Visible = true;
            LblGrpSlry.Text = "Group";
            TxtGrpSlry.Visible = true;
            TxtGrpSlry.ReadOnly = true;

            LblSubSpe.Visible = true;
            LblSubSpe.Text = "Specialty";
            TxtSubSpe.Visible = true;
            TxtSubSpe.ReadOnly = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status
            panel7.Visible = true;   //Password
            panel8.Visible = true;   //Email
            panel10.Visible = true;  //Subject or Specialty
            panel12.Visible = true;  //Group or Salary
        }
        public void SubInfo()
        {
            HideInfo();
            ShowButton();
            LblID.Visible = true;
            TxtID.Visible = true;
            TxtID.ReadOnly = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Subject";
            TxtStatus.Visible = true;
            TxtStatus.ReadOnly = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status
        }
        public void SpeInfo()
        {

            HideInfo();
            ShowButton();
            LblID.Visible = true;
            TxtID.Visible = true;
            TxtID.ReadOnly = true;

            LblStatus.Visible = true;
            LblStatus.Text = "Specialty";
            TxtStatus.Visible = true;
            TxtStatus.ReadOnly = true;

            panel5.Visible = true;   //ID
            panel6.Visible = true;   //Status
        }
        #endregion
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCell = dataGridView1.SelectedCells[0].RowIndex;

            if (chosenDev == true && queryAdd == false && queryFind == false)
            {
                DevInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = string.Concat(dataGridView1.Rows[selectedCell].Cells[1].Value.ToString(), " ", dataGridView1.Rows[selectedCell].Cells[2].Value.ToString());
                TxtEmail.Text = dataGridView1.Rows[selectedCell].Cells[3].Value.ToString();
                TxtPass.Text = dataGridView1.Rows[selectedCell].Cells[4].Value.ToString();
                if (queryUpdate == true)
                {
                    EnableTxtBox();
                }

            }
            else if (chosenDep == true && queryAdd == false && queryFind == false)
            {
                DepInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = dataGridView1.Rows[selectedCell].Cells[1].Value.ToString();
                ShowButton();
            }
            else if (chosenTec == true && queryAdd == false && queryFind == false)
            {
                TecInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = string.Concat(dataGridView1.Rows[selectedCell].Cells[1].Value.ToString(), " ", dataGridView1.Rows[selectedCell].Cells[2].Value.ToString());
                TxtEmail.Text = dataGridView1.Rows[selectedCell].Cells[3].Value.ToString();
                TxtPass.Text = dataGridView1.Rows[selectedCell].Cells[4].Value.ToString();
                TxtGrpSlry.Text = dataGridView1.Rows[selectedCell].Cells[5].Value.ToString();
                TxtSubSpe.Text = (dataGridView1.Rows[selectedCell].Cells[6].Value).ToString();
                TxtDep.Text = (dataGridView1.Rows[selectedCell].Cells[7].Value).ToString();
                ShowButton();
                if (queryUpdate == true)
                {
                    EnableTxtBox();
                }
            }
            else if (chosenGrp == true && queryAdd == false && queryFind == false)
            {
                GrpInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = dataGridView1.Rows[selectedCell].Cells[1].Value.ToString();
                ShowButton();
                if (queryUpdate == true)
                {
                    EnableTxtBox();
                }
            }
            else if (chosenStu == true && queryAdd == false && queryFind == false)
            {
                StuInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = string.Concat(dataGridView1.Rows[selectedCell].Cells[1].Value.ToString(), " ", dataGridView1.Rows[selectedCell].Cells[2].Value.ToString());
                TxtEmail.Text = dataGridView1.Rows[selectedCell].Cells[3].Value.ToString();
                TxtPass.Text = dataGridView1.Rows[selectedCell].Cells[4].Value.ToString();
                TxtGrpSlry.Text = dataGridView1.Rows[selectedCell].Cells[5].Value.ToString();
                TxtSubSpe.Text = dataGridView1.Rows[selectedCell].Cells[6].Value.ToString();
                ShowButton();
                if (queryUpdate == true)
                {
                    EnableTxtBox();
                }
            }
            else if (chosenSub == true && queryAdd == false && queryFind == false)
            {
                SubInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = dataGridView1.Rows[selectedCell].Cells[1].Value.ToString();
                ShowButton();
                if (queryUpdate == true)
                {
                    EnableTxtBox();
                }
            }
            else if (chosenSpe == true && queryAdd == false && queryFind == false)
            {
                SpeInfo();

                TxtID.Text = dataGridView1.Rows[selectedCell].Cells[0].Value.ToString();
                TxtStatus.Text = dataGridView1.Rows[selectedCell].Cells[1].Value.ToString();
                ShowButton();
                if (queryUpdate == true)
                {
                    EnableTxtBox();
                }
            }
        }

        private void BtnCrud_Click(object sender, EventArgs e)
        {
            #region Add Query
            if (queryAdd == true)
            {
                if (chosenDev == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text) ||  string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text.Substring(0, TxtStatus.Text.IndexOf(" "));
                            string surname = TxtStatus.Text.Substring(TxtStatus.Text.IndexOf(" ") + 1, (TxtStatus.Text.Length - 1) - TxtStatus.Text.IndexOf(" "));

                            try
                            {

                                SqlCommand cmd = new SqlCommand("AddDeveloper", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Surname", surname);
                                cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
                                cmd.Parameters.AddWithValue("Password", TxtPass.Text);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This email adress is already in use. Please use a different email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
                else if (chosenDep == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text;
                            try
                            {

                                SqlCommand cmd = new SqlCommand("AddDepartment", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Name", name);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDepartment();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
                else if (chosenTec == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text) ||  string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text) || string.IsNullOrEmpty(TxtGrpSlry.Text) || string.IsNullOrEmpty(TxtDep.Text) || string.IsNullOrEmpty(TxtSubSpe.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text.Substring(0, TxtStatus.Text.IndexOf(" "));
                            string surname = TxtStatus.Text.Substring(TxtStatus.Text.IndexOf(" ") + 1, (TxtStatus.Text.Length - 1) - TxtStatus.Text.IndexOf(" "));
                            string email = TxtEmail.Text;
                            string password = TxtPass.Text;
                            decimal salary = Convert.ToDecimal(TxtGrpSlry.Text);
                            int subjectID = Convert.ToInt32(TxtSubSpe.Text);
                            int departmentID = Convert.ToInt32(TxtDep.Text);

                            try
                            {

                                SqlCommand cmd = new SqlCommand($"insert into Teacher values ('{name}','{surname}','{email}','{password}',{salary},{subjectID},{departmentID})", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetTeacher();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 547)
                                {
                                    MessageBox.Show("There is no department or subject with this ID. Please check departments and subjects carefully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This email adress is already in use. Please use a different email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
                else if (chosenGrp == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text;

                            try
                            {

                                SqlCommand cmd = new SqlCommand("AddGroup", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Name", name);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetGroup();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
                else if (chosenStu == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text) ||  string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text) || string.IsNullOrEmpty(TxtGrpSlry.Text) || string.IsNullOrEmpty(TxtDep.Text) || string.IsNullOrEmpty(TxtSubSpe.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text.Substring(0, TxtStatus.Text.IndexOf(" "));
                            string surname = TxtStatus.Text.Substring(TxtStatus.Text.IndexOf(" ") + 1, (TxtStatus.Text.Length - 1) - TxtStatus.Text.IndexOf(" "));
                            int groupID = Convert.ToInt32(TxtGrpSlry.Text);
                            string email = TxtEmail.Text;
                            string password = TxtPass.Text;
                            int specialtyID = Convert.ToInt32(TxtSubSpe.Text);

                            try
                            {

                                SqlCommand cmd = new SqlCommand($"insert into Student values ('{name}','{surname}',{groupID},'{email}','{password}',{specialtyID})", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetStudent();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 547)
                                {
                                    MessageBox.Show("There is no group or specialty with this ID. Please check groups and specialties carefully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This email adress is already in use. Please use a different email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
                else if (chosenSub == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text;
                            try
                            {

                                SqlCommand cmd = new SqlCommand("AddSubject", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Name", name);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetSubject();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
                else if (chosenSpe == true)
                {
                    DialogResult result = MessageBox.Show("Add information ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string name = TxtStatus.Text;
                            try
                            {

                                SqlCommand cmd = new SqlCommand("AddSpecialty", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Name", name);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetSpecialty();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }

                            }
                        }
                    }
                }
            }
            #endregion
            #region Update Query
            else if (queryUpdate == true)
            {
                if (chosenDev == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text) || string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            string name = TxtStatus.Text.Substring(0, TxtStatus.Text.IndexOf(" "));
                            string surname = TxtStatus.Text.Substring(TxtStatus.Text.IndexOf(" ") + 1, (TxtStatus.Text.Length - 1) - TxtStatus.Text.IndexOf(" "));
                            string email = TxtEmail.Text;
                            string password = TxtPass.Text;

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Developer set Name = '{name}',Surname = '{surname}',Email='{email}',Password='{password}' where DeveloperID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (SqlException exp)
                            {
                                if (exp.Number == 2627)
                                {
                                    MessageBox.Show("This email adress is already in use. Please use a different email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }

                    }
                }
                else if (chosenDep == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            string name = TxtStatus.Text;

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Department set DepartmentName = '{name}' where DepartmentID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }
                    }
                }
                else if (chosenTec == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtID.Text) || string.IsNullOrEmpty(TxtStatus.Text) || string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text) || string.IsNullOrEmpty(TxtGrpSlry.Text) || string.IsNullOrEmpty(TxtDep.Text) || string.IsNullOrEmpty(TxtSubSpe.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            int subjectID = Convert.ToInt32(TxtSubSpe.Text);
                            int departmentID = Convert.ToInt32(TxtDep.Text);
                            string name = TxtStatus.Text.Substring(0, TxtStatus.Text.IndexOf(" "));
                            string surname = TxtStatus.Text.Substring(TxtStatus.Text.IndexOf(" ") + 1, (TxtStatus.Text.Length - 1) - TxtStatus.Text.IndexOf(" "));
                            string email = TxtEmail.Text;
                            string password = TxtPass.Text;
                            decimal salary = Convert.ToDecimal(TxtGrpSlry.Text);

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Teacher set Name = '{name}',Surname = '{surname}',Email='{email}',Password='{password}',Salary = {salary},SubjectID = {subjectID},DepartmentID = {departmentID} where TeacherID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetTeacher();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This email adress is already in use. Please use a different email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                                if (exception.Number == 547)
                                {
                                    MessageBox.Show("There is no department or subject with this ID. Please check departments and subjects carefully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }
                    }
                }
                else if (chosenGrp == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {                     
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            string name = TxtStatus.Text;

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Tbl_Group set GroupName = '{name}' where GroupID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetGroup();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }
                    }
                }
                else if (chosenStu == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtID.Text) || string.IsNullOrEmpty(TxtStatus.Text) ||  string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text) || string.IsNullOrEmpty(TxtGrpSlry.Text) || string.IsNullOrEmpty(TxtDep.Text) || string.IsNullOrEmpty(TxtSubSpe.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            int specialtyID = Convert.ToInt32(TxtSubSpe.Text);
                            int groupID = Convert.ToInt32(TxtGrpSlry.Text);
                            string name = TxtStatus.Text.Substring(0, TxtStatus.Text.IndexOf(" "));
                            string surname = TxtStatus.Text.Substring(TxtStatus.Text.IndexOf(" ") + 1, (TxtStatus.Text.Length - 1) - TxtStatus.Text.IndexOf(" "));
                            string email = TxtEmail.Text;
                            string password = TxtPass.Text;

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Student set Name = '{name}',Surname = '{surname}',GroupID = {groupID},Email='{email}',Password='{password}',SpecialtyID = {specialtyID} where StudentID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetStudent();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This email adress is already in use. Please use a different email adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                                if (exception.Number == 547)
                                {
                                    MessageBox.Show("There is no specialty with this ID. Please check specialties carefully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }
                    }
                }
                else if (chosenSub == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {                                           
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            string name = TxtStatus.Text;

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Subject set SubjectName = '{name}' where SubjectID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetSubject();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }
                    }
                }
                else if (chosenSpe == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtStatus.Text))
                        {
                            MessageBox.Show("Fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            string name = TxtStatus.Text;

                            try
                            {
                                SqlCommand cmd = new SqlCommand($"Update Specialty set SpecialtyName = '{name}' where SpecialtyID = {id}", connection);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetSpecialty();
                            }
                            catch (SqlException exception)
                            {
                                if (exception.Number == 2627)
                                {
                                    MessageBox.Show("This name is already in use. Please use a different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Delete Query
            else if (queryDelete == true)
            {
                if (chosenDev == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteDevByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id",id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                               //log
                            }
                        }

                    }
                }
                else if (chosenDep == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteDepByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                                //log
                            }
                        }

                    }
                }
                else if (chosenTec == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {                        
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteTecByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                                //log
                            }
                        }

                    }
                }
                else if (chosenGrp == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {                        
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteGrpByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                                //log
                            }
                        }

                    }
                }
                else if (chosenStu == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteStuByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                                //log
                            }
                        }

                    }
                }
                else if (chosenSub == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteSubByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                                //log
                            }
                        }

                    }
                }
                else if (chosenSpe == true)
                {
                    DialogResult result = MessageBox.Show("Do you want delete information ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {                        
                        if (string.IsNullOrEmpty(TxtID.Text))
                        {
                            MessageBox.Show("Select information that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int id = Convert.ToInt32(TxtID.Text);
                            try
                            {
                                SqlCommand cmd = new SqlCommand($"DeleteSpeByID", connection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", id);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                ClearTxtBox();
                                GetDeveloper();
                            }
                            catch (Exception)
                            {
                                //log
                            }
                        }

                    }
                }
            }
            #endregion
            #region Find Query
            else if (queryFind == true)
            {
                if (ChkBoxID.Checked)
                {
                    if (string.IsNullOrEmpty(TxtID.Text))
                    {
                        MessageBox.Show("Please fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int id = Convert.ToInt32(TxtID.Text);
                        if (chosenDev == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchDevByID",connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);                          
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenDep == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchDepByID", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenTec == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchTecByID", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenGrp == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchGrpByID", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenStu == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchStuByID", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenSub == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchSubByID", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenSpe == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchSpeByID", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                    }
                }
                else if (ChkBoxName.Checked)
                {
                    if (string.IsNullOrEmpty(TxtStatus.Text))
                    {
                        MessageBox.Show("Please fill the boxes correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string Name = TxtStatus.Text;
                        if (chosenDev == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchDevByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenDep == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchDepByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenTec == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchTecByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenGrp == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchGrpByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenStu == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchStuByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenSub == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchSubByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                        else if (chosenSpe == true)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("SearchSpeByName", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            connection.Close();
                            ClearTxtBox();
                        }
                    }
                }
            }
            #endregion
        }

        private void TxtStatus_Click(object sender, EventArgs e)
        {
            if (TxtStatus.Text == "Name Surname" || TxtStatus.Text == "Name")
            {
                TxtStatus.Clear();
            }
        }

        private void TxtEmail_Click(object sender, EventArgs e)
        {
            if (TxtEmail.Text == "Email")
            {
                TxtEmail.Clear();
            }
        }

        private void TxtPass_Click(object sender, EventArgs e)
        {
            if (TxtPass.Text == "Password")
            {
                TxtPass.Clear();
            }
        }

        private void TxtGrpSlry_Click(object sender, EventArgs e)
        {
            if (TxtGrpSlry.Text == "Salary" || TxtGrpSlry.Text == "Group ID")
            {
                TxtGrpSlry.Clear();
            }
        }

        private void TxtSubSpe_Click(object sender, EventArgs e)
        {
            if (TxtSubSpe.Text == "Subject ID" || TxtSubSpe.Text == "Specialty ID")
            {
                TxtSubSpe.Clear();
            }
        }

        private void TxtDep_Click(object sender, EventArgs e)
        {
            if (TxtDep.Text == "Department ID")
            {
                TxtDep.Clear();
            }
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            if (TxtID.Text == "ID")
            {
                TxtID.Clear();
            }
        }
    }
}
