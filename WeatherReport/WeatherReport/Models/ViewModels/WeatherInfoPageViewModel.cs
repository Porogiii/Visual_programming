using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WeatherReport.Models.ApiModels;
using WeatherReport.Services;
using Avalonia.Platform;

namespace WeatherReport.Models.ViewModels
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {
        private readonly WeatherApiService _weatherApiService;

        public WeatherInfoPageViewModel()
        {
            _weatherApiService = new WeatherApiService();
            FetchWeatherInformation();
        }

        [ObservableProperty]
        private string q;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string temperature1;

        [ObservableProperty]
        private string temperature2;

        [ObservableProperty]
        private string temperature3;

        [ObservableProperty]
        private string temperature4;

        [ObservableProperty]
        private string temperature5;

        [ObservableProperty]
        private string date;

        [ObservableProperty]
        private string date1;

        [ObservableProperty]
        private string date2;

        [ObservableProperty]
        private string date3;

        [ObservableProperty]
        private string date4;

        [ObservableProperty]
        private string date5;

        [ObservableProperty]
        private string time;

        [ObservableProperty]
        private string colorBackground;

        [ObservableProperty]
        private string colorBorder;

        [ObservableProperty]
        private string colorText;

        public Clock _Clock { get; set; } = new Clock();

        public Clock Clock
        { 
            get => _Clock;
            set { FetchWeatherInformation(); OnPropertyChanged(nameof(Clock.OnEveryHour)); }
        }

        public Bitmap WeatherIcon
        {
            get => _WeatherIcon;
            set { _WeatherIcon = value; OnPropertyChanged(nameof(WeatherIcon)); }
        }
        public Bitmap _WeatherIcon { get; set; }

        public Bitmap WeatherIcon1
        {
            get => _WeatherIcon1;
            set { _WeatherIcon1 = value; OnPropertyChanged(nameof(WeatherIcon1)); }
        }
        public Bitmap _WeatherIcon1 { get; set; }

        public Bitmap WeatherIcon2
        {
            get => _WeatherIcon2;
            set { _WeatherIcon2 = value; OnPropertyChanged(nameof(WeatherIcon2)); }
        }
        public Bitmap _WeatherIcon2 { get; set; }

        public Bitmap WeatherIcon3
        {
            get => _WeatherIcon3;
            set { _WeatherIcon3 = value; OnPropertyChanged(nameof(WeatherIcon3)); }
        }
        public Bitmap _WeatherIcon3 { get; set; }

        public Bitmap WeatherIcon4
        {
            get => _WeatherIcon4;
            set { _WeatherIcon4 = value; OnPropertyChanged(nameof(WeatherIcon4)); }
        }
        public Bitmap _WeatherIcon4 { get; set; }

        public Bitmap WeatherIcon5
        {
            get => _WeatherIcon5;
            set { _WeatherIcon5 = value; OnPropertyChanged(nameof(WeatherIcon5)); }
        }
        public Bitmap _WeatherIcon5 { get; set; }

        [RelayCommand]
        private async Task FetchWeatherInformation()
        {
            var weatherApiResponse = await _weatherApiService.GetWeatherInformation(q);
            if (weatherApiResponse != null)
            {
                Temperature = $"{(int)weatherApiResponse.List[0].Main.Temp}°C";
                Temperature1 = $"{(int)weatherApiResponse.List[8].Main.Temp}°C";
                Temperature2 = $"{(int)weatherApiResponse.List[16].Main.Temp}°C";
                Temperature3 = $"{(int)weatherApiResponse.List[24].Main.Temp}°C";
                Temperature4 = $"{(int)weatherApiResponse.List[32].Main.Temp}°C";
                Temperature5 = $"{(int)weatherApiResponse.List[39].Main.Temp}°C";

                Date = System.DateTime.Now.DayOfWeek.ToString() + ", " + System.DateTime.Now.Day.ToString();
                Date1 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString() + ", " + System.DateTime.Now.AddDays(1).Day.ToString();
                Date2 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString() + ", " + System.DateTime.Now.AddDays(2).Day.ToString();
                Date3 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString() + ", " + System.DateTime.Now.AddDays(3).Day.ToString();
                Date4 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString() + ", " + System.DateTime.Now.AddDays(4).Day.ToString();
                Date5 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString() + ", " + System.DateTime.Now.AddDays(5).Day.ToString();

                int tempTime = System.Convert.ToInt32(weatherApiResponse.List[0].Dt_txt.Substring(weatherApiResponse.List[0].Dt_txt.LastIndexOf(" ") + 1).Remove(2));
                if (tempTime <= 19)
                {
                    tempTime += 4;
                }
                else
                {
                    tempTime -= 20;
                }
                if (tempTime >= 7 && tempTime <= 17)
                {
                    ColorBackground = "#6bb9f0";
                    ColorBorder = "#89c4f4";
                    ColorText = "#175b8b";
                    switch (weatherApiResponse.List[0].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                        default:
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[8].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                        default:
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[16].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                        default:
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[24].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                        default:
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[32].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                        default:
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[39].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                        default:
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/sunny.png")));
                            break;
                    }
                }
                else
                {
                    ColorBackground = "#2c3e50";
                    ColorBorder = "#34495e";
                    ColorText = "#70a8d0";
                    switch (weatherApiResponse.List[0].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                        default:
                            WeatherIcon = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[8].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                        default:
                            WeatherIcon1 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[16].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                        default:
                            WeatherIcon2 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[24].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                        default:
                            WeatherIcon3 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[32].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                        default:
                            WeatherIcon4 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                    }
                    switch (weatherApiResponse.List[39].Weather[0].Main)
                    {
                        case "Snow":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-snowy.png")));
                            break;
                        case "Clouds":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-cloudy-2.png")));
                            break;
                        case "Rain":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-rainy.png")));
                            break;
                        case "Clear":
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                        default:
                            WeatherIcon5 = new Bitmap(AssetLoader.Open(new Uri("avares://WeatherReport/Assets/night-clear.png")));
                            break;
                    }
                }
            }
        }
    }
}
