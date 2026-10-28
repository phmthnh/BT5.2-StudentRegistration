namespace BT5_2_StudentRegistration
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.lblExtras = new System.Windows.Forms.Label();
            this.chkEnglish = new System.Windows.Forms.CheckBox();
            this.chkSoftSkills = new System.Windows.Forms.CheckBox();
            this.chkIT = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FORM ĐĂNG KÝ HỌC VIÊN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFullName
            //
            this.lblFullName.Location = new System.Drawing.Point(30, 63);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(120, 23);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Họ và tên:";
            //
            // txtFullName
            //
            this.txtFullName.Location = new System.Drawing.Point(170, 60);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(260, 23);
            this.txtFullName.TabIndex = 2;
            //
            // lblBirthDate
            //
            this.lblBirthDate.Location = new System.Drawing.Point(30, 103);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(120, 23);
            this.lblBirthDate.TabIndex = 3;
            this.lblBirthDate.Text = "Ngày sinh:";
            //
            // dtpBirthDate
            //
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(170, 100);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 23);
            this.dtpBirthDate.TabIndex = 4;
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(30, 143);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(120, 23);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Điện thoại:";
            //
            // mtxtPhone
            //
            this.mtxtPhone.Location = new System.Drawing.Point(170, 140);
            this.mtxtPhone.Mask = "(000) 000-0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(200, 23);
            this.mtxtPhone.TabIndex = 6;
            //
            // lblCourse
            //
            this.lblCourse.Location = new System.Drawing.Point(30, 183);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(120, 23);
            this.lblCourse.TabIndex = 7;
            this.lblCourse.Text = "Khóa học:";
            //
            // cboCourse
            //
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Location = new System.Drawing.Point(170, 180);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(260, 23);
            this.cboCourse.TabIndex = 8;
            //
            // lblExtras
            //
            this.lblExtras.Location = new System.Drawing.Point(30, 223);
            this.lblExtras.Name = "lblExtras";
            this.lblExtras.Size = new System.Drawing.Size(120, 23);
            this.lblExtras.TabIndex = 9;
            this.lblExtras.Text = "Môn bổ sung:";
            //
            // chkEnglish
            //
            this.chkEnglish.AutoSize = true;
            this.chkEnglish.Location = new System.Drawing.Point(170, 223);
            this.chkEnglish.Name = "chkEnglish";
            this.chkEnglish.Size = new System.Drawing.Size(85, 19);
            this.chkEnglish.TabIndex = 10;
            this.chkEnglish.Text = "Tiếng Anh";
            //
            // chkSoftSkills
            //
            this.chkSoftSkills.AutoSize = true;
            this.chkSoftSkills.Location = new System.Drawing.Point(275, 223);
            this.chkSoftSkills.Name = "chkSoftSkills";
            this.chkSoftSkills.Size = new System.Drawing.Size(100, 19);
            this.chkSoftSkills.TabIndex = 11;
            this.chkSoftSkills.Text = "Kỹ năng mềm";
            //
            // chkIT
            //
            this.chkIT.AutoSize = true;
            this.chkIT.Location = new System.Drawing.Point(390, 223);
            this.chkIT.Name = "chkIT";
            this.chkIT.Size = new System.Drawing.Size(65, 19);
            this.chkIT.TabIndex = 12;
            this.chkIT.Text = "Tin học";
            //
            // btnRegister
            //
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(0, 150, 100);
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(110, 270);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 35);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Đăng Ký";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnClear
            //
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(200, 100, 50);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(250, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 35);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // RegistrationForm
            //
            this.ClientSize = new System.Drawing.Size(480, 335);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.lblExtras);
            this.Controls.Add(this.chkEnglish);
            this.Controls.Add(this.chkSoftSkills);
            this.Controls.Add(this.chkIT);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Học Viên";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label lblExtras;
        private System.Windows.Forms.CheckBox chkEnglish;
        private System.Windows.Forms.CheckBox chkSoftSkills;
        private System.Windows.Forms.CheckBox chkIT;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
    }
}
