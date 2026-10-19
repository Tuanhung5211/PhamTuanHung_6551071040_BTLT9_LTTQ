
using Microsoft.EntityFrameworkCore;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro
{
    public partial class FormKhachThue : Form
    {
        private readonly DbContextOptions<QLNhaTroContext> _options;
        private readonly DiaChiApiService _diaChiService = new();

        private int? _maKhachDangChon;
        private List<DiaChiDto> _danhSachTinh = new();
        private bool _dangNapDuLieu;

        public FormKhachThue(DbContextOptions<QLNhaTroContext> options)
        {
            InitializeComponent();
            _options = options;

            cboPhong.DisplayMember = nameof(PhongTro.TenPhong);
            cboPhong.ValueMember = nameof(PhongTro.MaPhong);

            cboLocPhong.DisplayMember = nameof(PhongTro.TenPhong);
            cboLocPhong.ValueMember = nameof(PhongTro.MaPhong);

            cboTinh.DisplayMember = nameof(DiaChiDto.Name);
            cboTinh.ValueMember = nameof(DiaChiDto.Code);

            cboLocTinh.DisplayMember = nameof(DiaChiDto.Name);
            cboLocTinh.ValueMember = nameof(DiaChiDto.Code);

            cboPhuongXa.DisplayMember = nameof(DiaChiDto.Name);
            cboPhuongXa.ValueMember = nameof(DiaChiDto.Code);

            // Cho phép nhập thủ công nếu API địa chỉ gặp sự cố.
            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;

            dgvKhachThue.AutoGenerateColumns = true;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnBoLoc.Click += btnBoLoc_Click;

            cboTinh.SelectedIndexChanged += cboTinh_SelectedIndexChanged;
            dgvKhachThue.SelectionChanged += dgvKhachThue_SelectionChanged;

            btnGayLoiThu.Click += (sender, e) =>
            {
                throw new InvalidOperationException(
                    "Đây là lỗi được tạo ra để kiểm thử Serilog.");
            };

            Load += FormKhachThue_Load;
        }

        private QLNhaTroContext TaoContext()
        {
            return new QLNhaTroContext(_options);
        }

        private async void FormKhachThue_Load(object? sender, EventArgs e)
        {
            try
            {
                _dangNapDuLieu = true;

                await NapDanhSachTinhAsync();
                await NapDanhSachPhongAsync();
                await NapBoLocAsync();
                await TaiDanhSachKhachThueAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khởi tạo FormKhachThue");
                MessageBox.Show(
                    "Không thể tải dữ liệu ban đầu. Vui lòng kiểm tra kết nối SQL Server.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        // ==================== ĐỊA CHỈ API ====================

        private async Task NapDanhSachTinhAsync()
        {
            cboTinh.Enabled = false;
            cboTinh.Items.Clear();
            cboTinh.Text = "Đang tải...";

            try
            {
                _danhSachTinh = await _diaChiService.LayDanhSachTinhAsync();

                cboTinh.DataSource = null;
                cboTinh.DataSource = _danhSachTinh;

                cboLocTinh.DataSource = null;
                var dsLoc = new List<DiaChiDto>
                {
                    new DiaChiDto { Code = -1, Name = "Tất cả tỉnh/thành phố" }
                };
                dsLoc.AddRange(_danhSachTinh);
                cboLocTinh.DataSource = dsLoc;
                cboLocTinh.SelectedValue = -1;
            }
            catch (HttpRequestException ex)
            {
                Log.Warning(ex, "Không thể tải danh sách tỉnh/thành phố");
                MessageBox.Show(
                    "Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng.",
                    "Lỗi kết nối API",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException ex)
            {
                Log.Warning(ex, "Hết thời gian chờ tải tỉnh/thành phố");
                MessageBox.Show(
                    "API địa chỉ phản hồi quá lâu. Bạn có thể thử lại sau.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                cboTinh.Enabled = true;
            }
        }

        private async void cboTinh_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_dangNapDuLieu)
                return;

            if (cboTinh.SelectedValue is int maTinh && maTinh > 0)
            {
                await NapDanhSachPhuongXaAsync(maTinh);
            }
        }

        private async Task NapDanhSachPhuongXaAsync(int maTinh)
        {
            cboPhuongXa.Enabled = false;
            cboPhuongXa.DataSource = null;
            cboPhuongXa.Text = "Đang tải...";

            try
            {
                var ds = await _diaChiService.LayPhuongXaAsync(maTinh);

                cboPhuongXa.DataSource = ds;
                cboPhuongXa.DisplayMember = nameof(DiaChiDto.Name);
                cboPhuongXa.ValueMember = nameof(DiaChiDto.Code);

                if (ds.Count == 0)
                    cboPhuongXa.Text = "";
            }
            catch (HttpRequestException ex)
            {
                Log.Warning(ex, "Không tải được phường/xã của tỉnh {MaTinh}", maTinh);
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Text = "";
                MessageBox.Show(
                    "Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng. Bạn có thể nhập tên phường/xã thủ công.",
                    "Lỗi kết nối API",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException ex)
            {
                Log.Warning(ex, "Hết thời gian chờ tải phường/xã");
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Text = "";
            }
            finally
            {
                cboPhuongXa.Enabled = true;
            }
        }

        // ==================== PHÒNG TRỌ ====================

        private async Task NapDanhSachPhongAsync()
        {
            using var db = TaoContext();

            var dsPhong = await db.PhongTros
                .AsNoTracking()
                .OrderBy(p => p.TenPhong)
                .ToListAsync();

            cboPhong.DataSource = null;
            cboPhong.DataSource = dsPhong
                .Where(p => p.TinhTrang == "Trống")
                .ToList();

            cboLocPhong.DataSource = null;

            var dsLoc = new List<PhongTro>
            {
                new PhongTro { MaPhong = -1, TenPhong = "Tất cả phòng" }
            };
            dsLoc.AddRange(dsPhong);

            cboLocPhong.DataSource = dsLoc;
            cboLocPhong.SelectedValue = -1;
        }

        private async Task CapNhatTinhTrangPhongAsync(
            QLNhaTroContext db, int maPhong)
        {
            var phong = await db.PhongTros
                .FirstOrDefaultAsync(p => p.MaPhong == maPhong);

            if (phong == null)
                return;

            bool coKhach = await db.KhachThues
                .AnyAsync(k => k.MaPhong == maPhong);

            phong.TinhTrang = coKhach ? "Đang thuê" : "Trống";
        }

        // ==================== HIỂN THỊ DANH SÁCH ====================

        private async Task TaiDanhSachKhachThueAsync()
        {
            using var db = TaoContext();

            var ds = await db.KhachThues
                .AsNoTracking()
                .Include(k => k.MaPhongNavigation)
                .OrderBy(k => k.MaKhach)
                .Select(k => new
                {
                    k.MaKhach,
                    k.HoTen,
                    k.GioiTinh,
                    k.NgaySinh,
                    k.SoDienThoai,
                    Phong = k.MaPhongNavigation.TenPhong,
                    GiaThue = k.MaPhongNavigation.GiaThue,
                    TinhThanh = k.TenTinh,
                    PhuongXa = k.TenPhuongXa,
                    k.DaDangKyTamTru,
                    k.MaPhong,
                    k.MaTinh
                })
                .ToListAsync();

            var tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                ds = ds.Where(k =>
                    k.HoTen.ToLower().Contains(tuKhoa) ||
                    k.SoDienThoai.ToLower().Contains(tuKhoa))
                    .ToList();
            }

            if (cboLocPhong.SelectedValue is int maPhong && maPhong > 0)
                ds = ds.Where(k => k.MaPhong == maPhong).ToList();

            if (cboLocTinh.SelectedValue is int maTinh && maTinh > 0)
                ds = ds.Where(k => k.MaTinh == maTinh).ToList();

            dgvKhachThue.DataSource = ds.Select(k => new
            {
                k.MaKhach,
                k.HoTen,
                k.GioiTinh,
                NgaySinh = k.NgaySinh.ToString("dd/MM/yyyy"),
                k.SoDienThoai,
                k.Phong,
                GiaThue = k.GiaThue.ToString("N0"),
                TinhThanh = k.TinhThanh ?? "",
                PhuongXa = k.PhuongXa,
                k.DaDangKyTamTru,
                k.MaPhong,
                k.MaTinh
            }).ToList();

            if (dgvKhachThue.Columns["MaKhach"] != null)
                dgvKhachThue.Columns["MaKhach"]!.HeaderText = "Mã khách";

            if (dgvKhachThue.Columns["HoTen"] != null)
                dgvKhachThue.Columns["HoTen"]!.HeaderText = "Họ tên";

            if (dgvKhachThue.Columns["GioiTinh"] != null)
                dgvKhachThue.Columns["GioiTinh"]!.HeaderText = "Giới tính";

            if (dgvKhachThue.Columns["NgaySinh"] != null)
                dgvKhachThue.Columns["NgaySinh"]!.HeaderText = "Ngày sinh";

            if (dgvKhachThue.Columns["SoDienThoai"] != null)
                dgvKhachThue.Columns["SoDienThoai"]!.HeaderText = "Số điện thoại";

            if (dgvKhachThue.Columns["Phong"] != null)
                dgvKhachThue.Columns["Phong"]!.HeaderText = "Phòng";

            if (dgvKhachThue.Columns["GiaThue"] != null)
                dgvKhachThue.Columns["GiaThue"]!.HeaderText = "Giá thuê";

            if (dgvKhachThue.Columns["TinhThanh"] != null)
                dgvKhachThue.Columns["TinhThanh"]!.HeaderText = "Tỉnh/Thành phố";

            if (dgvKhachThue.Columns["PhuongXa"] != null)
                dgvKhachThue.Columns["PhuongXa"]!.HeaderText = "Phường/Xã";

            if (dgvKhachThue.Columns["DaDangKyTamTru"] != null)
                dgvKhachThue.Columns["DaDangKyTamTru"]!.HeaderText = "Đã đăng ký tạm trú";

            if (dgvKhachThue.Columns["MaPhong"] != null)
                dgvKhachThue.Columns["MaPhong"]!.Visible = false;

            if (dgvKhachThue.Columns["MaTinh"] != null)
                dgvKhachThue.Columns["MaTinh"]!.Visible = false;
        }

        // ==================== KIỂM TRA DỮ LIỆU ====================

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trọ còn trống.");
                return false;
            }

            if (dtpNgaySinh.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.");
                return false;
            }

            return true;
        }

        private int? LayMaTinh()
        {
            return cboTinh.SelectedValue is int ma && ma > 0 ? ma : null;
        }

        private string? LayTenTinh()
        {
            if (cboTinh.SelectedItem is DiaChiDto tinh)
                return tinh.Name;

            return null;
        }

        private int? LayMaPhuongXa()
        {
            return cboPhuongXa.SelectedItem is DiaChiDto xa
                ? xa.Code
                : null;
        }

        private string LayTenPhuongXa()
        {
            if (cboPhuongXa.SelectedItem is DiaChiDto xa)
                return xa.Name;

            return cboPhuongXa.Text.Trim();
        }

        // ==================== THÊM KHÁCH ====================

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                using var db = TaoContext();

                int maPhong = Convert.ToInt32(cboPhong.SelectedValue);

                var khach = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaTinh = LayMaTinh(),
                    TenTinh = LayTenTinh(),
                    MaPhuongXa = LayMaPhuongXa(),
                    TenPhuongXa = LayTenPhuongXa(),
                    DaDangKyTamTru = chkTamTru.Checked,
                    MaPhong = maPhong
                };

                db.KhachThues.Add(khach);
                await db.SaveChangesAsync();

                await CapNhatTinhTrangPhongAsync(db, maPhong);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm khách thuê thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LamMoiDuLieuAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi thêm khách thuê");
                MessageBox.Show("Không thể thêm khách thuê. Vui lòng kiểm tra dữ liệu và database.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== CHỌN DÒNG ====================

        private async void dgvKhachThue_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvKhachThue.CurrentRow == null ||
                dgvKhachThue.CurrentRow.IsNewRow)
                return;

            try
            {
                var row = dgvKhachThue.CurrentRow;

                if (row.Cells["MaKhach"].Value == null)
                    return;

                _maKhachDangChon = Convert.ToInt32(row.Cells["MaKhach"].Value);

                txtHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value) ?? "";
                txtSoDienThoai.Text = Convert.ToString(row.Cells["SoDienThoai"].Value) ?? "";

                rdoNam.Checked =
                    Convert.ToString(row.Cells["GioiTinh"].Value) == "Nam";
                rdoNu.Checked = !rdoNam.Checked;

                if (DateTime.TryParse(
                    Convert.ToString(row.Cells["NgaySinh"].Value), out var ngay))
                {
                    dtpNgaySinh.Value = ngay;
                }

                chkTamTru.Checked =
                    Convert.ToBoolean(row.Cells["DaDangKyTamTru"].Value);

                int maPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
                int? maTinh = row.Cells["MaTinh"].Value == null
                    || row.Cells["MaTinh"].Value == DBNull.Value
                    ? null
                    : Convert.ToInt32(row.Cells["MaTinh"].Value);

                // Khi sửa, cho phép chọn lại phòng hiện tại hoặc phòng trống.
                using var db = TaoContext();

                var dsPhong = await db.PhongTros
                    .AsNoTracking()
                    .Where(p => p.TinhTrang == "Trống" || p.MaPhong == maPhong)
                    .OrderBy(p => p.TenPhong)
                    .ToListAsync();

                cboPhong.DataSource = dsPhong;
                cboPhong.DisplayMember = nameof(PhongTro.TenPhong);
                cboPhong.ValueMember = nameof(PhongTro.MaPhong);
                cboPhong.SelectedValue = maPhong;

                if (maTinh.HasValue)
                {
                    _dangNapDuLieu = true;

                    try
                    {
                        cboTinh.SelectedValue = maTinh.Value;

                        await NapPhuongXaKhiChonAsync(maTinh.Value);

                        // Lấy tên phường/xã trực tiếp từ cơ sở dữ liệu
                        using var dbDiaChi = TaoContext();

                        string? tenPhuongXa = await dbDiaChi.KhachThues
                            .AsNoTracking()
                            .Where(k => k.MaKhach == _maKhachDangChon)
                            .Select(k => k.TenPhuongXa)
                            .FirstOrDefaultAsync();

                        cboPhuongXa.Text = tenPhuongXa ?? "";
                    }
                    finally
                    {
                        _dangNapDuLieu = false;
                    }
                }
                else
                {
                    _dangNapDuLieu = true;

                    try
                    {
                        cboTinh.SelectedIndex = -1;
                        cboPhuongXa.DataSource = null;
                        cboPhuongXa.Text = "";
                    }
                    finally
                    {
                        _dangNapDuLieu = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Không thể đưa thông tin khách lên form");
            }
        }

        private async Task NapPhuongXaKhiChonAsync(int maTinh)
        {
            try
            {
                var ds = await _diaChiService.LayPhuongXaAsync(maTinh);
                cboPhuongXa.DataSource = ds;
                cboPhuongXa.DisplayMember = nameof(DiaChiDto.Name);
                cboPhuongXa.ValueMember = nameof(DiaChiDto.Code);
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Không tải được phường/xã khi chọn khách");
                cboPhuongXa.DataSource = null;
            }
        }

        // ==================== SỬA KHÁCH ====================

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (_maKhachDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần sửa.");
                return;
            }

            if (!KiemTraDuLieu())
                return;

            try
            {
                using var db = TaoContext();

                var khach = await db.KhachThues
                    .FirstOrDefaultAsync(k => k.MaKhach == _maKhachDangChon);

                if (khach == null)
                {
                    MessageBox.Show("Không tìm thấy khách thuê.");
                    return;
                }

                int phongCu = khach.MaPhong;
                int phongMoi = Convert.ToInt32(cboPhong.SelectedValue);

                khach.HoTen = txtHoTen.Text.Trim();
                khach.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                khach.SoDienThoai = txtSoDienThoai.Text.Trim();
                khach.MaTinh = LayMaTinh();
                khach.TenTinh = LayTenTinh();
                khach.MaPhuongXa = LayMaPhuongXa();
                khach.TenPhuongXa = LayTenPhuongXa();
                khach.DaDangKyTamTru = chkTamTru.Checked;
                khach.MaPhong = phongMoi;

                await db.SaveChangesAsync();

                await CapNhatTinhTrangPhongAsync(db, phongCu);
                await CapNhatTinhTrangPhongAsync(db, phongMoi);
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật khách thuê thành công!");

                await LamMoiDuLieuAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi sửa khách thuê");
                MessageBox.Show("Không thể cập nhật khách thuê.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== XÓA KHÁCH ====================

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_maKhachDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần xóa.");
                return;
            }

            var xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách thuê này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                using var db = TaoContext();

                var khach = await db.KhachThues
                    .FirstOrDefaultAsync(k => k.MaKhach == _maKhachDangChon);

                if (khach == null)
                    return;

                int maPhong = khach.MaPhong;

                db.KhachThues.Remove(khach);
                await db.SaveChangesAsync();

                await CapNhatTinhTrangPhongAsync(db, maPhong);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa khách thuê thành công!");

                await LamMoiDuLieuAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xóa khách thuê");
                MessageBox.Show("Không thể xóa khách thuê.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== TÌM KIẾM / LỌC ====================

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            await TaiDanhSachKhachThueAsync();
        }

        private async void btnBoLoc_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();

            if (cboLocPhong.Items.Count > 0)
                cboLocPhong.SelectedIndex = 0;

            if (cboLocTinh.Items.Count > 0)
                cboLocTinh.SelectedIndex = 0;

            await TaiDanhSachKhachThueAsync();
        }

        // ==================== LÀM MỚI ====================

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            await LamMoiDuLieuAsync();
        }

        private async Task LamMoiDuLieuAsync()
        {
            _maKhachDangChon = null;

            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            chkTamTru.Checked = false;

            cboTinh.SelectedIndex = -1;
            cboPhuongXa.DataSource = null;
            cboPhuongXa.Text = "";

            await NapDanhSachPhongAsync();
            await NapBoLocAsync();
            await TaiDanhSachKhachThueAsync();

            dgvKhachThue.ClearSelection();
        }

        private async Task NapBoLocAsync()
        {
            using var db = TaoContext();

            var dsPhong = await db.PhongTros
                .AsNoTracking()
                .OrderBy(p => p.TenPhong)
                .ToListAsync();

            var locPhong = new List<PhongTro>
            {
                new PhongTro { MaPhong = -1, TenPhong = "Tất cả phòng" }
            };
            locPhong.AddRange(dsPhong);

            cboLocPhong.DataSource = locPhong;
            cboLocPhong.DisplayMember = nameof(PhongTro.TenPhong);
            cboLocPhong.ValueMember = nameof(PhongTro.MaPhong);
            cboLocPhong.SelectedValue = -1;

            var locTinh = new List<DiaChiDto>
            {
                new DiaChiDto { Code = -1, Name = "Tất cả tỉnh/thành phố" }
            };
            locTinh.AddRange(_danhSachTinh);

            cboLocTinh.DataSource = locTinh;
            cboLocTinh.DisplayMember = nameof(DiaChiDto.Name);
            cboLocTinh.ValueMember = nameof(DiaChiDto.Code);
            cboLocTinh.SelectedValue = -1;
        }
    }
}
