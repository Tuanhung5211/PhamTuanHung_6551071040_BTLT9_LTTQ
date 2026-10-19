
namespace QuanLyNhaTro
{
    partial class FormKhachThue
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblTinh;
        private System.Windows.Forms.ComboBox cboTinh;
        private System.Windows.Forms.Label lblPhuongXa;
        private System.Windows.Forms.ComboBox cboPhuongXa;
        private System.Windows.Forms.CheckBox chkTamTru;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnBoLoc;
        private System.Windows.Forms.Label lblLocPhong;
        private System.Windows.Forms.ComboBox cboLocPhong;
        private System.Windows.Forms.Label lblLocTinh;
        private System.Windows.Forms.ComboBox cboLocTinh;
        private System.Windows.Forms.DataGridView dgvKhachThue;
        private System.Windows.Forms.Button btnGayLoiThu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTieuDe = new System.Windows.Forms.Label();
            grpThongTin = new System.Windows.Forms.GroupBox();
            lblHoTen = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            lblGioiTinh = new System.Windows.Forms.Label();
            rdoNam = new System.Windows.Forms.RadioButton();
            rdoNu = new System.Windows.Forms.RadioButton();
            lblNgaySinh = new System.Windows.Forms.Label();
            dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            lblSoDienThoai = new System.Windows.Forms.Label();
            txtSoDienThoai = new System.Windows.Forms.TextBox();
            lblPhong = new System.Windows.Forms.Label();
            cboPhong = new System.Windows.Forms.ComboBox();
            lblTinh = new System.Windows.Forms.Label();
            cboTinh = new System.Windows.Forms.ComboBox();
            lblPhuongXa = new System.Windows.Forms.Label();
            cboPhuongXa = new System.Windows.Forms.ComboBox();
            chkTamTru = new System.Windows.Forms.CheckBox();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            grpDanhSach = new System.Windows.Forms.GroupBox();
            lblTimKiem = new System.Windows.Forms.Label();
            txtTimKiem = new System.Windows.Forms.TextBox();
            btnTimKiem = new System.Windows.Forms.Button();
            btnBoLoc = new System.Windows.Forms.Button();
            lblLocPhong = new System.Windows.Forms.Label();
            cboLocPhong = new System.Windows.Forms.ComboBox();
            lblLocTinh = new System.Windows.Forms.Label();
            cboLocTinh = new System.Windows.Forms.ComboBox();
            dgvKhachThue = new System.Windows.Forms.DataGridView();
            btnGayLoiThu = new System.Windows.Forms.Button();

            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachThue).BeginInit();
            SuspendLayout();

            // Form
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1180, 760);
            MinimumSize = new System.Drawing.Size(1000, 700);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản lý khách thuê nhà trọ";
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            Font = new System.Drawing.Font("Segoe UI", 10F);

            // Tiêu đề
            lblTieuDe.AutoSize = false;
            lblTieuDe.Location = new System.Drawing.Point(20, 15);
            lblTieuDe.Size = new System.Drawing.Size(1140, 45);
            lblTieuDe.Text = "QUẢN LÝ KHÁCH THUÊ NHÀ TRỌ";
            lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F,
                System.Drawing.FontStyle.Bold);
            lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);

            // Nhóm thông tin
            grpThongTin.Text = "Thông tin khách thuê";
            grpThongTin.Location = new System.Drawing.Point(20, 70);
            grpThongTin.Size = new System.Drawing.Size(1140, 260);
            grpThongTin.Padding = new System.Windows.Forms.Padding(15);

            // Họ tên
            lblHoTen.Text = "Họ và tên:";
            lblHoTen.Location = new System.Drawing.Point(20, 35);
            lblHoTen.Size = new System.Drawing.Size(110, 25);

            txtHoTen.Location = new System.Drawing.Point(135, 32);
            txtHoTen.Size = new System.Drawing.Size(300, 30);
            txtHoTen.MaxLength = 100;
            txtHoTen.PlaceholderText = "Nhập họ tên khách thuê";

            // Giới tính
            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.Location = new System.Drawing.Point(490, 35);
            lblGioiTinh.Size = new System.Drawing.Size(90, 25);

            rdoNam.Text = "Nam";
            rdoNam.Location = new System.Drawing.Point(590, 34);
            rdoNam.Size = new System.Drawing.Size(75, 28);
            rdoNam.Checked = true;

            rdoNu.Text = "Nữ";
            rdoNu.Location = new System.Drawing.Point(680, 34);
            rdoNu.Size = new System.Drawing.Size(75, 28);

            // Ngày sinh
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Location = new System.Drawing.Point(790, 35);
            lblNgaySinh.Size = new System.Drawing.Size(100, 25);

            dtpNgaySinh.Location = new System.Drawing.Point(895, 32);
            dtpNgaySinh.Size = new System.Drawing.Size(215, 30);
            dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = System.DateTime.Today;
            dtpNgaySinh.Value = new System.DateTime(2000, 1, 1);

            // Số điện thoại
            lblSoDienThoai.Text = "Số điện thoại:";
            lblSoDienThoai.Location = new System.Drawing.Point(20, 85);
            lblSoDienThoai.Size = new System.Drawing.Size(110, 25);

            txtSoDienThoai.Location = new System.Drawing.Point(135, 82);
            txtSoDienThoai.Size = new System.Drawing.Size(300, 30);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";

            // Phòng trọ
            lblPhong.Text = "Phòng trọ:";
            lblPhong.Location = new System.Drawing.Point(490, 85);
            lblPhong.Size = new System.Drawing.Size(90, 25);

            cboPhong.Location = new System.Drawing.Point(590, 82);
            cboPhong.Size = new System.Drawing.Size(250, 30);
            cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Tỉnh
            lblTinh.Text = "Tỉnh/Thành phố:";
            lblTinh.Location = new System.Drawing.Point(20, 135);
            lblTinh.Size = new System.Drawing.Size(115, 25);

            cboTinh.Location = new System.Drawing.Point(135, 132);
            cboTinh.Size = new System.Drawing.Size(300, 30);
            cboTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Phường xã
            lblPhuongXa.Text = "Phường/Xã:";
            lblPhuongXa.Location = new System.Drawing.Point(490, 135);
            lblPhuongXa.Size = new System.Drawing.Size(100, 25);

            cboPhuongXa.Location = new System.Drawing.Point(590, 132);
            cboPhuongXa.Size = new System.Drawing.Size(350, 30);
            cboPhuongXa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Tạm trú
            chkTamTru.Text = "Đã đăng ký tạm trú";
            chkTamTru.Location = new System.Drawing.Point(135, 180);
            chkTamTru.Size = new System.Drawing.Size(230, 30);

            // Nút thao tác
            btnThem.Text = "＋ Thêm";
            btnThem.Location = new System.Drawing.Point(490, 180);
            btnThem.Size = new System.Drawing.Size(130, 40);
            btnThem.BackColor = System.Drawing.Color.FromArgb(22, 125, 87);
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Cursor = System.Windows.Forms.Cursors.Hand;

            btnSua.Text = "Sửa";
            btnSua.Location = new System.Drawing.Point(635, 180);
            btnSua.Size = new System.Drawing.Size(110, 40);
            btnSua.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Cursor = System.Windows.Forms.Cursors.Hand;

            btnXoa.Text = "Xóa";
            btnXoa.Location = new System.Drawing.Point(760, 180);
            btnXoa.Size = new System.Drawing.Size(110, 40);
            btnXoa.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new System.Drawing.Point(885, 180);
            btnLamMoi.Size = new System.Drawing.Size(130, 40);
            btnLamMoi.BackColor = System.Drawing.Color.FromArgb(75, 85, 99);
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;

            // Nhóm danh sách
            grpDanhSach.Text = "Danh sách khách thuê";
            grpDanhSach.Location = new System.Drawing.Point(20, 345);
            grpDanhSach.Size = new System.Drawing.Size(1140, 390);
            grpDanhSach.Padding = new System.Windows.Forms.Padding(12);

            lblTimKiem.Text = "Tìm tên/SĐT:";
            lblTimKiem.Location = new System.Drawing.Point(15, 32);
            lblTimKiem.Size = new System.Drawing.Size(110, 25);

            txtTimKiem.Location = new System.Drawing.Point(125, 29);
            txtTimKiem.Size = new System.Drawing.Size(240, 30);
            txtTimKiem.PlaceholderText = "Nhập tên hoặc số điện thoại";

            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location = new System.Drawing.Point(375, 27);
            btnTimKiem.Size = new System.Drawing.Size(100, 34);

            lblLocPhong.Text = "Phòng:";
            lblLocPhong.Location = new System.Drawing.Point(495, 32);
            lblLocPhong.Size = new System.Drawing.Size(60, 25);

            cboLocPhong.Location = new System.Drawing.Point(555, 29);
            cboLocPhong.Size = new System.Drawing.Size(145, 30);
            cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            lblLocTinh.Text = "Tỉnh:";
            lblLocTinh.Location = new System.Drawing.Point(715, 32);
            lblLocTinh.Size = new System.Drawing.Size(50, 25);

            cboLocTinh.Location = new System.Drawing.Point(765, 29);
            cboLocTinh.Size = new System.Drawing.Size(190, 30);
            cboLocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.Location = new System.Drawing.Point(970, 27);
            btnBoLoc.Size = new System.Drawing.Size(100, 34);

            // Bảng dữ liệu
            dgvKhachThue.Location = new System.Drawing.Point(15, 75);
            dgvKhachThue.Size = new System.Drawing.Size(1105, 285);
            dgvKhachThue.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvKhachThue.AllowUserToAddRows = false;
            dgvKhachThue.AllowUserToDeleteRows = false;
            dgvKhachThue.ReadOnly = true;
            dgvKhachThue.MultiSelect = false;
            dgvKhachThue.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvKhachThue.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachThue.RowHeadersVisible = false;
            dgvKhachThue.BackgroundColor = System.Drawing.Color.White;
            dgvKhachThue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvKhachThue.EnableHeadersVisualStyles = false;
            dgvKhachThue.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            dgvKhachThue.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            dgvKhachThue.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            dgvKhachThue.ColumnHeadersHeight = 38;
            dgvKhachThue.RowTemplate.Height = 32;
            dgvKhachThue.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(241, 245, 249);

            // Nút kiểm thử lỗi: ẩn mặc định
            btnGayLoiThu.Text = "Gây lỗi thử";
            btnGayLoiThu.Name = "btnGayLoiThu";
            btnGayLoiThu.Visible = false;

            // Thêm control vào nhóm thông tin
            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblHoTen, txtHoTen,
                lblGioiTinh, rdoNam, rdoNu,
                lblNgaySinh, dtpNgaySinh,
                lblSoDienThoai, txtSoDienThoai,
                lblPhong, cboPhong,
                lblTinh, cboTinh,
                lblPhuongXa, cboPhuongXa,
                chkTamTru,
                btnThem, btnSua, btnXoa, btnLamMoi
            });

            // Thêm control vào nhóm danh sách
            grpDanhSach.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTimKiem, txtTimKiem, btnTimKiem,
                lblLocPhong, cboLocPhong,
                lblLocTinh, cboLocTinh,
                btnBoLoc, dgvKhachThue
            });

            Controls.Add(lblTieuDe);
            Controls.Add(grpThongTin);
            Controls.Add(grpDanhSach);
            Controls.Add(btnGayLoiThu);

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            grpDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachThue).EndInit();
            ResumeLayout(false);
        }
    }
}
