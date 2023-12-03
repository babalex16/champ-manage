using ChampManage.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChampManage.MAUI.Services
{
    public class NewsService
    {
        public async Task<List<News>> GetNews()
        {
            var httpClient = new HttpClientService().GetPlatformSpecificHttpClient();
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7200"
                : "https://localhost:7200";
            var response = await httpClient.GetAsync($"{baseUrl}/api/news");

            if (response.IsSuccessStatusCode)
            {
                var newsList = await response.Content.ReadFromJsonAsync<List<News>>();
                return newsList;
            }
            else
            {
                throw new Exception($"Failed to get news. Status code: {response.StatusCode}");
            }
        }
    }
}
