
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
namespace QuanLyNhaTro.Services
{
    public class DiaChiApiService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        private const string BaseUrl =
            "https://provinces.open-api.vn/api/v2/";

        public async Task<List<DiaChiDto>> LayDanhSachTinhAsync(
            CancellationToken cancellationToken = default)
        {
            var result = await _httpClient.GetFromJsonAsync<List<DiaChiDto>>(
                BaseUrl, cancellationToken);

            return result ?? new List<DiaChiDto>();
        }

        public async Task<List<DiaChiDto>> LayPhuongXaAsync(
            int maTinh,
            CancellationToken cancellationToken = default)
        {
            string url = $"{BaseUrl}p/{maTinh}?depth=2";

            var result = await _httpClient.GetFromJsonAsync<TinhChiTietDto>(
                url, cancellationToken);

            return result?.Wards ?? new List<DiaChiDto>();
        }
    }

    public class DiaChiDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }

    public class TinhChiTietDto : DiaChiDto
    {
        [JsonPropertyName("wards")]
        public List<DiaChiDto> Wards { get; set; } = new();
    }
}
