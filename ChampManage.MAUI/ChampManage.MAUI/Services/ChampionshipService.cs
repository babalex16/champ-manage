using ChampManage.MAUI.Models;
using System.Net.Http.Json;

namespace ChampManage.MAUI.Services
{
    public class ChampionshipService
    {
        public async Task<List<Championship>> GetChampionships()
        {
            var httpClient = new HttpClientService().GetPlatformSpecificHttpClient();
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7200"
                : "https://localhost:7200";
            var response = await httpClient.GetAsync($"{baseUrl}/api/championships");

            if (response.IsSuccessStatusCode)
            {
                var championshipList = await response.Content.ReadFromJsonAsync<List<Championship>>();
                return championshipList;
            }
            else
            {
                throw new Exception($"Failed to get championships. Status code: {response.StatusCode}");
            }
        }
    }
}
