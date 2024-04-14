using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherReport.Models.ApiModels
{
    internal class WeatherApiResponse
    {
        [JsonPropertyName("cod")]
        public string Cod { get; set; }
        [JsonPropertyName("message")]
        public int Message { get; set; }
        [JsonPropertyName("cnt")]
        public int Cnt { get; set; }
        [JsonPropertyName("list")]
        public WeatherApiResponseList[] List { get; set; }
        [JsonPropertyName("city")]
        public WeatherApiResponseCity City { get; set; }
    }
}

public class WeatherApiResponseCity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("coord")]
    public WeatherApiResponseCoord Coord { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }
    [JsonPropertyName("population")]
    public int Population { get; set; }
    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }
    [JsonPropertyName("sunrise")]
    public int Sunrise { get; set; }
    [JsonPropertyName("sunset")]
    public int Sunset { get; set; }
}

public class WeatherApiResponseCoord
{
    [JsonPropertyName("lat")]
    public float Lat { get; set; }
    [JsonPropertyName("lon")]
    public float Lon { get; set; }
}

public class WeatherApiResponseList
{
    [JsonPropertyName("dt")]
    public int Dt { get; set; }
    [JsonPropertyName("main")]
    public WeatherApiResponseMain Main { get; set; }
    [JsonPropertyName("weather")]
    public WeatherApiResponseWeather[] Weather { get; set; }
    [JsonPropertyName("clouds")]
    public WeatherApiResponseClouds Clouds { get; set; }
    [JsonPropertyName("wind")]
    public WeatherApiResponseWind Wind { get; set; }
    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }
    [JsonPropertyName("pop")]
    public float Pop { get; set; }
    [JsonPropertyName("snow")]
    public WeatherApiResponseSnow Snow { get; set; }
    [JsonPropertyName("sys")]
    public WeatherApiResponseSys Sys { get; set; }
    [JsonPropertyName("dt_txt")]
    public string Dt_txt { get; set; }
    [JsonPropertyName("rain")]
    public WeatherApiResponseRain Rain { get; set; }
}

public class WeatherApiResponseMain
{
    [JsonPropertyName("temp")]
    public float Temp { get; set; }
    [JsonPropertyName("feels_like")]
    public float Feels_like { get; set; }
    [JsonPropertyName("temp_min")]
    public float Temp_min { get; set; }
    [JsonPropertyName("temp_max")]
    public float Temp_max { get; set; }
    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }
    [JsonPropertyName("sea_level")]
    public int Sea_level { get; set; }
    [JsonPropertyName("Grnd_level")]
    public int grnd_level { get; set; }
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
    [JsonPropertyName("temp_kf")]
    public float Temp_kf { get; set; }
}

public class WeatherApiResponseClouds
{
    [JsonPropertyName("all")]
    public int All { get; set; }
}

public class WeatherApiResponseWind
{
    [JsonPropertyName("speed")]
    public float Speed { get; set; }
    [JsonPropertyName("deg")]
    public int Deg { get; set; }
    [JsonPropertyName("gust")]
    public float Gust { get; set; }
}

public class WeatherApiResponseSnow
{
    [JsonPropertyName("_3h")]
    public float _3H { get; set; }
}

public class WeatherApiResponseSys
{
    [JsonPropertyName("pod")]
    public string Pod { get; set; }
}

public class WeatherApiResponseRain
{
    [JsonPropertyName("_3h")]
    public float _3H { get; set; }
}

public class WeatherApiResponseWeather
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("main")]
    public string Main { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}
