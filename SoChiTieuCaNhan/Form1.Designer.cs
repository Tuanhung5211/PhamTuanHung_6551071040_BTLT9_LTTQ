
namespace SoChiTieuCaNhan
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblNgayChi;
        private System.Windows.Forms.DateTimePicker dtpNgayChi;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblLoaiChi;
        private System.Windows.Forms.ComboBox cboLoaiChi;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.NumericUpDown nudSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.DataGridView dgvChiTieu;
        private System.Windows.Forms.Label lblTongTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTieuDe = new System.Windows.Forms.Label();
            grpThongTin = new System.Windows.Forms.GroupBox();
            lblNgayChi = new System.Windows.Forms.Label();
            dtpNgayChi = new System.Windows.Forms.DateTimePicker();
            lblNoiDung = new System.Windows.Forms.Label();
            txtNoiDung = new System.Windows.Forms.TextBox();
            lblLoaiChi = new System.Windows.Forms.Label();
            cboLoaiChi = new System.Windows.Forms.ComboBox();
            lblSoTien = new System.Windows.Forms.Label();
            nudSoTien = new System.Windows.Forms.NumericUpDown();
            lblGhiChu = new System.Windows.Forms.Label();
            txtGhiChu = new System.Windows.Forms.TextBox();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            grpTimKiem = new System.Windows.Forms.GroupBox();
            lblTimKiem = new System.Windows.Forms.Label();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblLocLoai = new System.Windows.Forms.Label();
            cboLocLoai = new System.Windows.Forms.ComboBox();
            lblTuNgay = new System.Windows.Forms.Label();
            dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            lblDenNgay = new System.Windows.Forms.Label();
            dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            btnTimKiem = new System.Windows.Forms.Button();
            btnTaiLai = new System.Windows.Forms.Button();
            dgvChiTieu = new System.Windows.Forms.DataGridView();
            lblTongTien = new System.Windows.Forms.Label();

            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).BeginInit();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).BeginInit();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1180, 760);
            MinimumSize = new System.Drawing.Size(1000, 700);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sổ chi tiêu cá nhân";
            Font = new System.Drawing.Font("Segoe UI", 10F);
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // Title
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(37, 64, 97);
            lblTieuDe.Location = new System.Drawing.Point(20, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "QUẢN LÝ CHI TIÊU CÁ NHÂN";

            // Information group
            grpThongTin.Text = "Thông tin khoản chi";
            grpThongTin.Location = new System.Drawing.Point(20, 65);
            grpThongTin.Size = new System.Drawing.Size(1140, 235);
            grpThongTin.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            lblNgayChi.Text = "Ngày chi:";
            lblNgayChi.Location = new System.Drawing.Point(20, 35);
            lblNgayChi.AutoSize = true;

            dtpNgayChi.Name = "dtpNgayChi";
            dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpNgayChi.Location = new System.Drawing.Point(130, 30);
            dtpNgayChi.Size = new System.Drawing.Size(300, 27);
            dtpNgayChi.MaxDate = System.DateTime.Today;

            lblNoiDung.Text = "Nội dung:";
            lblNoiDung.Location = new System.Drawing.Point(20, 80);
            lblNoiDung.AutoSize = true;

            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Location = new System.Drawing.Point(130, 75);
            txtNoiDung.Size = new System.Drawing.Size(300, 27);
            txtNoiDung.MaxLength = 100;
            txtNoiDung.PlaceholderText = "Nhập nội dung khoản chi";

            lblLoaiChi.Text = "Loại chi:";
            lblLoaiChi.Location = new System.Drawing.Point(20, 125);
            lblLoaiChi.AutoSize = true;

            cboLoaiChi.Name = "cboLoaiChi";
            cboLoaiChi.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLoaiChi.Location = new System.Drawing.Point(130, 120);
            cboLoaiChi.Size = new System.Drawing.Size(300, 28);

            lblSoTien.Text = "Số tiền (VNĐ):";
            lblSoTien.Location = new System.Drawing.Point(480, 35);
            lblSoTien.AutoSize = true;

            nudSoTien.Name = "nudSoTien";
            nudSoTien.Location = new System.Drawing.Point(610, 30);
            nudSoTien.Size = new System.Drawing.Size(300, 27);
            nudSoTien.Minimum = 0;
            nudSoTien.Maximum = 1000000000;
            nudSoTien.Increment = 1000;
            nudSoTien.ThousandsSeparator = true;

            lblGhiChu.Text = "Ghi chú:";
            lblGhiChu.Location = new System.Drawing.Point(480, 80);
            lblGhiChu.AutoSize = true;

            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Location = new System.Drawing.Point(610, 75);
            txtGhiChu.Size = new System.Drawing.Size(480, 70);
            txtGhiChu.Multiline = true;
            txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtGhiChu.MaxLength = 200;
            txtGhiChu.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.Location = new System.Drawing.Point(130, 175);
            btnThem.Size = new System.Drawing.Size(120, 38);
            btnThem.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.Location = new System.Drawing.Point(270, 175);
            btnSua.Size = new System.Drawing.Size(120, 38);
            btnSua.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.Location = new System.Drawing.Point(410, 175);
            btnXoa.Size = new System.Drawing.Size(120, 38);
            btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new System.Drawing.Point(550, 175);
            btnLamMoi.Size = new System.Drawing.Size(120, 38);

            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblNgayChi, dtpNgayChi,
                lblNoiDung, txtNoiDung,
                lblLoaiChi, cboLoaiChi,
                lblSoTien, nudSoTien,
                lblGhiChu, txtGhiChu,
                btnThem, btnSua, btnXoa, btnLamMoi
            });

            // Search group
            grpTimKiem.Text = "Tìm kiếm và lọc chi tiêu";
            grpTimKiem.Location = new System.Drawing.Point(20, 310);
            grpTimKiem.Size = new System.Drawing.Size(1140, 125);
            grpTimKiem.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            lblTimKiem.Text = "Nội dung:";
            lblTimKiem.Location = new System.Drawing.Point(15, 35);
            lblTimKiem.AutoSize = true;

            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Location = new System.Drawing.Point(100, 30);
            txtTimKiem.Size = new System.Drawing.Size(230, 27);
            txtTimKiem.PlaceholderText = "Nhập từ khóa";

            lblLocLoai.Text = "Loại chi:";
            lblLocLoai.Location = new System.Drawing.Point(350, 35);
            lblLocLoai.AutoSize = true;

            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocLoai.Location = new System.Drawing.Point(420, 30);
            cboLocLoai.Size = new System.Drawing.Size(170, 28);

            lblTuNgay.Text = "Từ ngày:";
            lblTuNgay.Location = new System.Drawing.Point(15, 80);
            lblTuNgay.AutoSize = true;

            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTuNgay.Location = new System.Drawing.Point(100, 75);
            dtpTuNgay.Size = new System.Drawing.Size(230, 27);

            lblDenNgay.Text = "Đến ngày:";
            lblDenNgay.Location = new System.Drawing.Point(350, 80);
            lblDenNgay.AutoSize = true;

            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDenNgay.Location = new System.Drawing.Point(445, 75);
            dtpDenNgay.Size = new System.Drawing.Size(145, 27);
            dtpDenNgay.MaxDate = System.DateTime.Today;

            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location = new System.Drawing.Point(620, 30);
            btnTimKiem.Size = new System.Drawing.Size(130, 35);
            btnTimKiem.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnTimKiem.ForeColor = System.Drawing.Color.White;
            btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.Location = new System.Drawing.Point(620, 75);
            btnTaiLai.Size = new System.Drawing.Size(130, 35);

            grpTimKiem.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTimKiem, txtTimKiem,
                lblLocLoai, cboLocLoai,
                lblTuNgay, dtpTuNgay,
                lblDenNgay, dtpDenNgay,
                btnTimKiem, btnTaiLai
            });

            // Data grid
            dgvChiTieu.Name = "dgvChiTieu";
            dgvChiTieu.Location = new System.Drawing.Point(20, 445);
            dgvChiTieu.Size = new System.Drawing.Size(1140, 245);
            dgvChiTieu.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            dgvChiTieu.ReadOnly = true;
            dgvChiTieu.AllowUserToAddRows = false;
            dgvChiTieu.AllowUserToDeleteRows = false;
            dgvChiTieu.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvChiTieu.MultiSelect = false;
            dgvChiTieu.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTieu.RowHeadersVisible = false;
            dgvChiTieu.BackgroundColor = System.Drawing.Color.White;
            dgvChiTieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Total
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Text = "Tổng chi: 0 VNĐ";
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new System.Drawing.Font(
                "Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.FromArgb(37, 64, 97);
            lblTongTien.Location = new System.Drawing.Point(20, 700);
            lblTongTien.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            Controls.Add(lblTieuDe);
            Controls.Add(grpThongTin);
            Controls.Add(grpTimKiem);
            Controls.Add(dgvChiTieu);
            Controls.Add(lblTongTien);

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).EndInit();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
