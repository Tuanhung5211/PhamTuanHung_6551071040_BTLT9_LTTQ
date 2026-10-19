# Sổ chi tiêu cá nhân (WinForms · .NET 10 · EF Core Database First)

## 1. Yêu cầu
- Visual Studio 2022/2026 (workload *.NET desktop development*) hoặc .NET 10 SDK
- SQL Server (Express/LocalDB/Developer) + SSMS

## 2. Tạo CSDL
Mở `Database/QL_ChiTieu.sql` trong SSMS rồi Execute: tạo CSDL `QL_ChiTieu`, bảng `ChiTieu`, 12 dòng mẫu.

## 3. Scaffold (Database First)
Source đã kèm sẵn `Models/ChiTieu.cs` và `Models/QlChiTieuContext.cs`.
Muốn tự sinh lại (chạy trong thư mục chứa `SoChiTieu.csproj`):

```powershell
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c QlChiTieuContext --no-onconfiguring --force
```
`--no-onconfiguring` giúp connection string không bị hard-code vào DbContext (nạp từ appsettings.json qua `Data/DbFactory.cs`).
Lưu ý: EF đặt tên thuộc tính khóa là `MaCt` (ánh xạ cột `MaCT`) và DbSet là `ChiTieus`; code đã dùng đúng các tên này.

## 4. Cấu hình
1. Sửa `appsettings.json` (mật khẩu SQL thật) và/hoặc `appsettings.Development.json` (ghi đè khi chạy Debug).
2. Hai file này nằm trong `.gitignore`; file mẫu để commit là `appsettings.example.json`.
3. Cả hai file đã đặt *Copy to Output Directory = Copy if newer* (trong `.csproj`).
4. `appsettings.Development.json` không được đưa vào thư mục publish.

## 5. Log
Serilog ghi `Logs\log-yyyyMMdd.txt` cạnh file .exe: Information khi Thêm/Sửa/Xóa (kèm MaCT), Error khi lỗi CSDL.

## 6. Publish (Framework-Dependent, win-x64)
```powershell
dotnet publish -c Release -r win-x64 --self-contained false -o publish
```
(hoặc Visual Studio: Publish → profile `FolderProfile`).

Trên máy khác:
1. Cài **.NET Desktop Runtime 10 (x64)**.
2. Chép cả thư mục `publish` sang.
3. Mở `appsettings.json` bằng Notepad, sửa `ConnectionStrings:QL_ChiTieu` cho đúng máy đó (không cần build lại).
4. Chạy `SoChiTieu.exe`.

## 7. Kiểm thử nhanh
- Thêm/Sửa/Xóa xong lưới tự làm mới, kiểm tra lại bằng SSMS.
- Lọc "Ăn uống" + khoảng ngày trong tháng → nhãn "Tổng chi" khớp tổng cộng tay.
- Đổi connection string sang CSDL khác, mở lại app → dữ liệu của CSDL đó hiện ra.
- Kiểm tra `Logs\log-yyyyMMdd.txt`; tắt SQL Server rồi thao tác để thấy thông báo lỗi thân thiện + log Error.
