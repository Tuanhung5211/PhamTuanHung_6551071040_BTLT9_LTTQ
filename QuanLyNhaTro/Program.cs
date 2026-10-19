
using Microsoft.EntityFrameworkCore;
using QuanLyNhaTro.Models;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaTro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string thuMucLog = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Logs");

            Directory.CreateDirectory(thuMucLog);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    path: Path.Combine(
                        thuMucLog,
                        "nhatro-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information(
                "========== KHỞI ĐỘNG ỨNG DỤNG ==========");

            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, e) =>
            {
                Log.Error(
                    e.Exception,
                    "Lỗi không xử lý trên giao diện");

                MessageBox.Show(
                    "Đã xảy ra lỗi. Thông tin đã được ghi lại trong file log.",
                    "Lỗi ứng dụng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException +=
                (sender, e) =>
                {
                    if (e.ExceptionObject is Exception ex)
                    {
                        Log.Fatal(
                            ex,
                            "Lỗi không xử lý trong AppDomain");
                    }
                    else
                    {
                        Log.Fatal(
                            "Đã xảy ra lỗi không xử lý trong AppDomain");
                    }

                    Log.CloseAndFlush();
                };

            try
            {
                ApplicationConfiguration.Initialize();

                var options =
                    new DbContextOptionsBuilder<QLNhaTroContext>()
                        .UseSqlServer(
                            "Server=LAPTOP-BHA07K98;Database=QL_NhaTro;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False")
                        .Options;

                Log.Information(
                    "Đang kiểm tra kết nối cơ sở dữ liệu");

                using (var db = new QLNhaTroContext(options))
                {
                    bool ketNoiThanhCong = db.Database.CanConnect();

                    if (!ketNoiThanhCong)
                    {
                        throw new InvalidOperationException(
                            "Không thể kết nối cơ sở dữ liệu QL_NhaTro.");
                    }
                }

                Log.Information(
                    "Kết nối cơ sở dữ liệu thành công");

                Log.Information(
                    "Đang mở FormKhachThue");

                Application.Run(new FormKhachThue(options));

                Log.Information(
                    "Ứng dụng đã đóng");
            }
            catch (Exception ex)
            {
                Log.Fatal(
                    ex,
                    "Không thể khởi chạy hoặc vận hành ứng dụng");

                MessageBox.Show(
                    "Không thể khởi chạy ứng dụng. " +
                    "Hãy kiểm tra SQL Server và file log trong thư mục Logs.",
                    "Lỗi ứng dụng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
