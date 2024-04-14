using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WeatherReport.Models.ApiModels;

namespace WeatherReport.Services
{
    internal class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constance.API_BASE_URL);
        }

        public async Task<WeatherApiResponse> GetWeatherInformation(string q)
        {
            if (q == null || q == "" || q == " ")
            {
                return await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"forecast?q=Novosibirsk&units=metric&appid={Constance.API_KEY}");
            }
            else
            {
                return await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"forecast?q={q}&units=metric&appid={Constance.API_KEY}");
            }
        }
    }
}
