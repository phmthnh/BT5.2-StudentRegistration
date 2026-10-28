using BT5_2_StudentRegistration.Data;
using Microsoft.Data.Sqlite;

namespace BT5_2_StudentRegistration
{
    public partial class RegistrationForm : Form
    {
        private readonly RegistrationRepository registrations = new();
        private bool databaseReady;

        public RegistrationForm()
        {
            InitializeComponent();
            txtFullName.MaxLength = 200;
            btnRegister.Enabled = false;
            cboCourse.Enabled = false;
            Shown += RegistrationForm_Shown;
        }

        private async void RegistrationForm_Shown(object? sender, EventArgs e)
        {
            try
            {
                await registrations.InitializeAsync();
                var courses = await registrations.GetCoursesAsync();
                if (IsDisposed) return;
                cboCourse.DisplayMember = nameof(Course.Name);
                cboCourse.ValueMember = nameof(Course.Id);
                cboCourse.DataSource = courses;
                databaseReady = courses.Count > 0;
                cboCourse.Enabled = btnRegister.Enabled = databaseReady;
            }
            catch (Exception ex) when (ex is SqliteException or IOException or UnauthorizedAccessException or ArgumentException)
            {
                if (!IsDisposed)
                    MessageBox.Show(this, "Không thể mở cơ sở dữ liệu đăng ký. Kiểm tra quyền ghi thư mục dữ liệu rồi mở lại ứng dụng.",
                        "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRegistration()
        {
            errorProvider.Clear();
            bool valid = true;
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider.SetError(txtFullName, "Vui lòng nhập họ và tên!");
                valid = false;
            }
            if (!mtxtPhone.MaskCompleted)
            {
                errorProvider.SetError(mtxtPhone, "Vui lòng nhập đủ 10 chữ số điện thoại!");
                valid = false;
            }
            if (cboCourse.SelectedItem is not Course)
            {
                errorProvider.SetError(cboCourse, "Vui lòng chọn khóa học!");
                valid = false;
            }
            return valid;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (!databaseReady || !btnRegister.Enabled || !ValidateRegistration()) return;
            var course = (Course)cboCourse.SelectedItem!;
            var data = new RegistrationData(txtFullName.Text.Trim(), dtpBirthDate.Value.Date,
                new string(mtxtPhone.Text.Where(char.IsAsciiDigit).ToArray()), course.Id,
                chkEnglish.Checked, chkSoftSkills.Checked, chkIT.Checked);
            var extras = new List<string>();
            if (data.English) extras.Add("Tiếng Anh");
            if (data.SoftSkills) extras.Add("Kỹ năng mềm");
            if (data.OfficeIT) extras.Add("Tin học văn phòng");
            string extraStr = extras.Count > 0 ? string.Join(", ", extras) : "Không";

            SetEditorEnabled(false);
            try
            {
                var id = await registrations.SaveAsync(data);
                if (IsDisposed) return;
                string info = "===== THÔNG TIN ĐĂNG KÝ =====\n" +
                              $"Mã đăng ký:  {id}\n" +
                              $"Họ tên:      {data.FullName}\n" +
                              $"Ngày sinh:   {data.BirthDate:dd/MM/yyyy}\n" +
                              $"Điện thoại:  {data.Phone}\n" +
                              $"Khóa học:    {course.Name}\n" +
                              $"Môn bổ sung: {extraStr}\n" +
                              "Đã lưu vào cơ sở dữ liệu.";
                MessageBox.Show(this, info, "Đăng Ký Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is SqliteException or IOException or UnauthorizedAccessException or ArgumentException)
            {
                if (!IsDisposed)
                    MessageBox.Show(this, "Không thể lưu đăng ký vào cơ sở dữ liệu. Dữ liệu trên form được giữ lại để bạn thử lại.",
                        "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) SetEditorEnabled(true);
            }
        }

        private void SetEditorEnabled(bool enabled)
        {
            txtFullName.Enabled = dtpBirthDate.Enabled = mtxtPhone.Enabled = enabled;
            cboCourse.Enabled = chkEnglish.Enabled = chkSoftSkills.Enabled = chkIT.Enabled = enabled;
            btnRegister.Enabled = enabled && databaseReady;
            btnClear.Enabled = enabled;
        }

        // Chỉ xóa nội dung nhập, không xóa các đăng ký đã lưu trong CSDL.
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            dtpBirthDate.Value      = DateTime.Today;
            mtxtPhone.Clear();
            cboCourse.SelectedIndex = cboCourse.Items.Count > 0 ? 0 : -1;
            chkEnglish.Checked      = false;
            chkSoftSkills.Checked   = false;
            chkIT.Checked           = false;
            errorProvider.Clear();
            txtFullName.Focus();
        }
    }
}
