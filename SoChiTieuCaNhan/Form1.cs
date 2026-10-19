
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoChiTieuCaNhan.Models;
using Serilog;

namespace SoChiTieuCaNhan
{
    public partial class Form1 : Form
    {
        private readonly DbContextOptions<QLChiTieuContext> _options;

        public Form1(DbContextOptions<QLChiTieuContext> options)
        {
            InitializeComponent();

            _options = options;

            // Gọi khi form được mở
            Load += Form1_Load;
            btnThem.Click += (s, e) => ThemChiTieu();
            btnLamMoi.Click += (s, e) => LamMoiForm();
            dgvChiTieu.CellClick += dgvChiTieu_CellClick;
            btnSua.Click += (s, e) => SuaChiTieu();
            btnXoa.Click += (s, e) => XoaChiTieu();

            btnTimKiem.Click += (s, e) => TimKiemChiTieu();

            btnTaiLai.Click += (s, e) =>
            {
                txtTimKiem.Clear();
                cboLocLoai.SelectedIndex = 0;
                dtpTuNgay.Value = DateTime.Today.AddDays(-30);
                dtpDenNgay.Value = DateTime.Today;

                LoadChiTieu();
            };
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Khởi tạo danh sách loại chi
            string[] cacLoaiChi =
            {
                "Ăn uống",
                "Di chuyển",
                "Học tập",
                "Mua sắm",
                "Giải trí",
                "Hóa đơn",
                "Khác"
            };

            cboLoaiChi.Items.Clear();
            cboLoaiChi.Items.AddRange(cacLoaiChi);
            cboLoaiChi.SelectedIndex = 0;

            cboLocLoai.Items.Clear();
            cboLocLoai.Items.Add("Tất cả");
            cboLocLoai.Items.AddRange(cacLoaiChi);
            cboLocLoai.SelectedIndex = 0;

            // Thiết lập ngày
            dtpNgayChi.MaxDate = DateTime.Today;
            dtpTuNgay.MaxDate = DateTime.Today;
            dtpDenNgay.MaxDate = DateTime.Today;

            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            // Tải dữ liệu từ database
            LoadChiTieu();
        }

        private void LoadChiTieu()
        {
            try
            {
                using var db = new QLChiTieuContext(_options);

                var danhSach = db.ChiTieus
                    .OrderByDescending(x => x.NgayChi)
                    .ThenByDescending(x => x.MaCt)
                    .ToList();

                dgvChiTieu.DataSource = danhSach.Select(x => new
                {
                    x.MaCt,
                    x.NgayChi,
                    x.NoiDung,
                    x.LoaiChi,
                    x.SoTien,
                    x.GhiChu
                }).ToList();

                dgvChiTieu.Columns["MaCt"]!.HeaderText = "Mã chi";
                dgvChiTieu.Columns["NgayChi"]!.HeaderText = "Ngày chi";
                dgvChiTieu.Columns["NoiDung"]!.HeaderText = "Nội dung";
                dgvChiTieu.Columns["LoaiChi"]!.HeaderText = "Loại chi";
                dgvChiTieu.Columns["SoTien"]!.HeaderText = "Số tiền (VNĐ)";
                dgvChiTieu.Columns["GhiChu"]!.HeaderText = "Ghi chú";

                dgvChiTieu.Columns["SoTien"]!.DefaultCellStyle.Format = "N0";
                dgvChiTieu.Columns["NgayChi"]!.DefaultCellStyle.Format = "dd/MM/yyyy";

                decimal tongTien = danhSach.Sum(x => x.SoTien);
                lblTongTien.Text = $"Tổng chi: {tongTien:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu chi tiêu.\n\n" + ex.Message,
                    "Lỗi database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ThemChiTieu()
        {
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrWhiteSpace(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung khoản chi!");
                txtNoiDung.Focus();
                return;
            }

            if (cboLoaiChi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại chi!");
                return;
            }

            if (nudSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0!");
                nudSoTien.Focus();
                return;
            }

            if (dtpNgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn ngày hôm nay!");
                return;
            }

            try
            {
                using var db = new QLChiTieuContext(_options);

                var chiTieu = new ChiTieu
                {
                    NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value),
                    NoiDung = noiDung,
                    LoaiChi = cboLoaiChi.Text,
                    SoTien = nudSoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text)
                        ? null
                        : txtGhiChu.Text.Trim()
                };

                db.ChiTieus.Add(chiTieu);
                db.SaveChanges();
                Log.Information(
    "Thêm khoản chi thành công. MaCT={MaCT}, SoTien={SoTien}",
    chiTieu.MaCt,
    chiTieu.SoTien);

                MessageBox.Show("Thêm khoản chi thành công!");

                LoadChiTieu();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm khoản chi.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LamMoiForm()
        {
            dtpNgayChi.Value = DateTime.Today;
            txtNoiDung.Clear();
            cboLoaiChi.SelectedIndex = 0;
            nudSoTien.Value = 0;
            txtGhiChu.Clear();
            txtNoiDung.Focus();
        }


        private void dgvChiTieu_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvChiTieu.Rows[e.RowIndex];

            dtpNgayChi.Value = DateTime.Parse(
                row.Cells["NgayChi"].Value!.ToString()!);

            txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString() ?? "";

            cboLoaiChi.SelectedItem =
                row.Cells["LoaiChi"].Value?.ToString();

            nudSoTien.Value = Convert.ToDecimal(
                row.Cells["SoTien"].Value);

            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
        }

        private void SuaChiTieu()
        {
            if (dgvChiTieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khoản chi cần sửa!");
                return;
            }

            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrWhiteSpace(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung khoản chi!");
                txtNoiDung.Focus();
                return;
            }

            if (cboLoaiChi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại chi!");
                return;
            }

            if (nudSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0!");
                return;
            }

            try
            {
                int maCt = Convert.ToInt32(
                    dgvChiTieu.CurrentRow.Cells["MaCt"].Value);

                using var db = new QLChiTieuContext(_options);

                var chiTieu = db.ChiTieus.Find(maCt);

                if (chiTieu == null)
                {
                    MessageBox.Show("Không tìm thấy khoản chi!");
                    LoadChiTieu();
                    return;
                }

                chiTieu.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value);
                chiTieu.NoiDung = noiDung;
                chiTieu.LoaiChi = cboLoaiChi.Text;
                chiTieu.SoTien = nudSoTien.Value;
                chiTieu.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text)
                    ? null
                    : txtGhiChu.Text.Trim();

                db.SaveChanges();
                Log.Information(
    "Sửa khoản chi thành công. MaCT={MaCT}",
    chiTieu.MaCt);

                MessageBox.Show("Cập nhật khoản chi thành công!");

                LoadChiTieu();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể sửa khoản chi.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void XoaChiTieu()
        {
            if (dgvChiTieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khoản chi cần xóa!");
                return;
            }

            int maCt = Convert.ToInt32(
                dgvChiTieu.CurrentRow.Cells["MaCt"].Value);

            string noiDung = dgvChiTieu.CurrentRow
                .Cells["NoiDung"].Value?.ToString() ?? "";

            DialogResult ketQua = MessageBox.Show(
                $"Bạn có chắc muốn xóa khoản chi '{noiDung}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (ketQua != DialogResult.Yes)
                return;

            try
            {
                using var db = new QLChiTieuContext(_options);

                var chiTieu = db.ChiTieus.Find(maCt);

                if (chiTieu == null)
                {
                    MessageBox.Show("Khoản chi không tồn tại!");
                    LoadChiTieu();
                    return;
                }

                db.ChiTieus.Remove(chiTieu);
                db.SaveChanges();
                Log.Information(
    "Xóa khoản chi thành công. MaCT={MaCT}",
    maCt);

                MessageBox.Show("Xóa khoản chi thành công!");

                LoadChiTieu();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa khoản chi.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TimKiemChiTieu()
        {
            try
            {
                using var db = new QLChiTieuContext(_options);

                var query = db.ChiTieus.AsQueryable();

                string tuKhoa = txtTimKiem.Text.Trim();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(x => x.NoiDung.Contains(tuKhoa));
                }

                string loaiChi = cboLocLoai.Text;

                if (cboLocLoai.SelectedIndex > 0)
                {
                    query = query.Where(x => x.LoaiChi == loaiChi);
                }

                DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value);
                DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value);

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Từ ngày không được lớn hơn đến ngày!");
                    return;
                }

                query = query.Where(x =>
                    x.NgayChi >= tuNgay && x.NgayChi <= denNgay);

                var danhSach = query
                    .OrderByDescending(x => x.NgayChi)
                    .ThenByDescending(x => x.MaCt)
                    .ToList();

                dgvChiTieu.DataSource = danhSach.Select(x => new
                {
                    x.MaCt,
                    x.NgayChi,
                    x.NoiDung,
                    x.LoaiChi,
                    x.SoTien,
                    x.GhiChu
                }).ToList();

                dgvChiTieu.Columns["MaCt"]!.HeaderText = "Mã chi";
                dgvChiTieu.Columns["NgayChi"]!.HeaderText = "Ngày chi";
                dgvChiTieu.Columns["NoiDung"]!.HeaderText = "Nội dung";
                dgvChiTieu.Columns["LoaiChi"]!.HeaderText = "Loại chi";
                dgvChiTieu.Columns["SoTien"]!.HeaderText = "Số tiền (VNĐ)";
                dgvChiTieu.Columns["GhiChu"]!.HeaderText = "Ghi chú";

                dgvChiTieu.Columns["SoTien"]!.DefaultCellStyle.Format = "N0";
                dgvChiTieu.Columns["NgayChi"]!.DefaultCellStyle.Format = "dd/MM/yyyy";

                decimal tongTien = danhSach.Sum(x => x.SoTien);
                lblTongTien.Text = $"Tổng chi: {tongTien:N0} VNĐ";

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khoản chi phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm chi tiêu.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}
