
namespace SMS
{
    partial class LoginPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            this.PbDeveloper = new System.Windows.Forms.PictureBox();
            this.PbStudent = new System.Windows.Forms.PictureBox();
            this.PbTeacher = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.PbClose = new System.Windows.Forms.PictureBox();
            this.LblForgot = new System.Windows.Forms.Label();
            this.BtnLogin = new ePOSOne.btnProduct.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.PbDeveloper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // PbDeveloper
            // 
            this.PbDeveloper.BackColor = System.Drawing.Color.Transparent;
            this.PbDeveloper.Image = ((System.Drawing.Image)(resources.GetObject("PbDeveloper.Image")));
            this.PbDeveloper.Location = new System.Drawing.Point(762, -7);
            this.PbDeveloper.Name = "PbDeveloper";
            this.PbDeveloper.Size = new System.Drawing.Size(431, 325);
            this.PbDeveloper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbDeveloper.TabIndex = 0;
            this.PbDeveloper.TabStop = false;
            this.PbDeveloper.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PbStudent
            // 
            this.PbStudent.BackColor = System.Drawing.Color.Transparent;
            this.PbStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PbStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbStudent.Image = ((System.Drawing.Image)(resources.GetObject("PbStudent.Image")));
            this.PbStudent.Location = new System.Drawing.Point(645, 276);
            this.PbStudent.Name = "PbStudent";
            this.PbStudent.Size = new System.Drawing.Size(311, 124);
            this.PbStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbStudent.TabIndex = 4;
            this.PbStudent.TabStop = false;
            this.PbStudent.Click += new System.EventHandler(this.PbStudent_Click);
            // 
            // PbTeacher
            // 
            this.PbTeacher.BackColor = System.Drawing.Color.Transparent;
            this.PbTeacher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PbTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbTeacher.Image = ((System.Drawing.Image)(resources.GetObject("PbTeacher.Image")));
            this.PbTeacher.Location = new System.Drawing.Point(947, 338);
            this.PbTeacher.Name = "PbTeacher";
            this.PbTeacher.Size = new System.Drawing.Size(311, 124);
            this.PbTeacher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbTeacher.TabIndex = 5;
            this.PbTeacher.TabStop = false;
            this.PbTeacher.Click += new System.EventHandler(this.PbTeacher_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(808, 486);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(808, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 1);
            this.panel1.TabIndex = 7;
            // 
            // TxtMail
            // 
            this.TxtMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.TxtMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMail.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMail.ForeColor = System.Drawing.Color.White;
            this.TxtMail.Location = new System.Drawing.Point(869, 503);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(213, 28);
            this.TxtMail.TabIndex = 8;
            this.TxtMail.Text = "E-Mail";
            this.TxtMail.Click += new System.EventHandler(this.TxtMail_Click);
            // 
            // TxtPass
            // 
            this.TxtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPass.Font = new System.Drawing.Font("Arial", 18F);
            this.TxtPass.ForeColor = System.Drawing.Color.White;
            this.TxtPass.Location = new System.Drawing.Point(866, 566);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(213, 28);
            this.TxtPass.TabIndex = 11;
            this.TxtPass.Text = "Password";
            this.TxtPass.Click += new System.EventHandler(this.TxtPass_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(807, 596);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 1);
            this.panel2.TabIndex = 10;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(813, 555);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(45, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // PbClose
            // 
            this.PbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(98)))), ((int)(((byte)(79)))));
            this.PbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbClose.Image = ((System.Drawing.Image)(resources.GetObject("PbClose.Image")));
            this.PbClose.Location = new System.Drawing.Point(1250, 0);
            this.PbClose.Name = "PbClose";
            this.PbClose.Size = new System.Drawing.Size(29, 27);
            this.PbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbClose.TabIndex = 13;
            this.PbClose.TabStop = false;
            this.PbClose.Click += new System.EventHandler(this.PbClose_Click);
            // 
            // LblForgot
            // 
            this.LblForgot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(97)))), ((int)(((byte)(78)))));
            this.LblForgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblForgot.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblForgot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblForgot.Location = new System.Drawing.Point(950, 598);
            this.LblForgot.Name = "LblForgot";
            this.LblForgot.Size = new System.Drawing.Size(132, 23);
            this.LblForgot.TabIndex = 20;
            this.LblForgot.Text = "Forgot Password ?";
            this.LblForgot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblForgot.Click += new System.EventHandler(this.LblForgot_Click);
            this.LblForgot.MouseEnter += new System.EventHandler(this.LblForgot_MouseEnter);
            this.LblForgot.MouseLeave += new System.EventHandler(this.LblForgot_MouseLeave);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(79)))));
            this.BtnLogin.BorderColor = System.Drawing.Color.Black;
            this.BtnLogin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.Location = new System.Drawing.Point(853, 627);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.OnHoverBorderColor = System.Drawing.Color.White;
            this.BtnLogin.OnHoverButtonColor = System.Drawing.Color.Green;
            this.BtnLogin.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnLogin.Size = new System.Drawing.Size(192, 66);
            this.BtnLogin.TabIndex = 19;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.TextColor = System.Drawing.Color.Black;
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1278, 794);
            this.Controls.Add(this.LblForgot);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.PbClose);
            this.Controls.Add(this.TxtPass);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.TxtMail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PbTeacher);
            this.Controls.Add(this.PbStudent);
            this.Controls.Add(this.PbDeveloper);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginPage";
            this.Text = "School Managment System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginPage_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginPage_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.PbDeveloper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbDeveloper;
        private System.Windows.Forms.PictureBox PbStudent;
        private System.Windows.Forms.PictureBox PbTeacher;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox PbClose;
        private ePOSOne.btnProduct.Button_WOC BtnLogin;
        private System.Windows.Forms.Label LblForgot;
    }
}

