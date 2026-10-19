
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using SoChiTieuCaNhan.Models;

namespace SoChiTieuCaNhan
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string logDirectory = Path.Combine(
                AppContext.BaseDirectory, "Logs");

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true)
                .CreateLogger();

            try
            {
                Log.Information("Ứng dụng bắt đầu khởi động");

                var builder = new ConfigurationBuilder()
     .SetBasePath(AppContext.BaseDirectory)
     .AddJsonFile(
         "appsettings.json",
         optional: false,
         reloadOnChange: true);

                string environment =
                    Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                    ?? "Production";

                if (string.Equals(
                    environment,
                    "Development",
                    StringComparison.OrdinalIgnoreCase))
                {
                    builder.AddJsonFile(
                        "appsettings.Development.json",
                        optional: true,
                        reloadOnChange: true);
                }

                IConfiguration configuration = builder.Build();

                var settings = configuration
                    .GetSection("AppSettings")
                    .Get<AppSettings>();

                if (settings == null ||
                    string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    throw new InvalidOperationException(
                        "Chưa cấu hình chuỗi kết nối database.");
                }

                var options =
                    new DbContextOptionsBuilder<QLChiTieuContext>()
                        .UseSqlServer(settings.ConnectionString)
                        .Options;

                Application.Run(new Form1(options));

                Log.Information("Ứng dụng đã đóng");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng gặp lỗi khi khởi động");

                MessageBox.Show(
                    "Không thể khởi động ứng dụng.\n\n" + ex.Message,
                    "Lỗi",
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
