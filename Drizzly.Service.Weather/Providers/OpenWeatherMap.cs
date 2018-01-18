using System;
using System.Collections.Generic;
using Drizzly.Service.Weather.Models;
using Drizzly.Service.Weather.Types;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Drizzly.Service.Weather.Providers
{
    public class OpenWeatherMap : BaseProvider
    {
        public OpenWeatherMap(IConfiguration configuration)
        {
            Name = "OpenWeatherMap";
            ApiKey = configuration.GetSection("ApiKeys")["OpenWeatherMap"];
            Endpoints = new List<string>
            {
                "api.openweathermap.org"
            };
            CallsPerMinute = 60;
            CallsPerDay = 0;
        }

        public dynamic GetCurrentWeather(double latitude, double longitude, string units)
        {
            var client = new RestClient("http://" + Endpoints[0] + "/data/2.5/weather");

            var request =
                new RestRequest("?lat=" + latitude + "&lon=" + longitude + "&units=" + units + "&appid=" + ApiKey,
                    Method.GET);

            request.OnBeforeDeserialization = response => { response.ContentType = "application/json"; };

            var queryResult = client.Execute(request);

            return JsonConvert.DeserializeObject(queryResult.Content);
        }

        public object GetForecast(double latitude, double longitude, string units)
        {
            var client = new RestClient("http://" + Endpoints[0] + "/data/2.5/forecast");

            var request =
                new RestRequest("?lat=" + latitude + "&lon=" + longitude + "&units=" + units + "&appid=" + ApiKey,
                    Method.GET);

            request.OnBeforeDeserialization = response => { response.ContentType = "application/json"; };

            var queryResult = client.Execute(request);

            return JsonConvert.DeserializeObject(queryResult.Content);
        }

        public OutputFormat PopulateOutput(dynamic json, BaseProvider provider, OutputFormat model,
            CustomTypes.DataTypes dataType)
        {
            provider.LastData = json.dt;

            model.Infos.DataType = CustomTypes.DataTypes.Current.ToString();
            model.Infos.Location = new CustomTypes.Locations((double) json.coord.lat, (double) json.coord.lon,
                (string) json.name, (string) json.sys.country);
            model.Infos.Sun = new CustomTypes.Sun((double) json.sys.sunrise, (double) json.sys.sunset);

            model.Providers.Add(provider);

            model.Temperatures.Add(new CustomTypes.Temperature((double) json.main.temp_min, (double) json.main.temp_max,
                (double) json.main.temp, CustomTypes.TemperatureUnits.Celsius));
            model.Winds.Add(new CustomTypes.Winds(
                new CustomTypes.WindSpeed((double) json.wind.speed, null, CustomTypes.WindSpeedUnits.KilometersPerHour),
                (int) json.wind.deg));
            model.Humidity.Add((float) json.main.humidity);
            model.Pressure.Add((float) json.main.pressure);
            model.Visibility.Add((float) json.visibility);
            model.CloudCover.Add((float) json.clouds.all);

            return model;
        }
    }
}