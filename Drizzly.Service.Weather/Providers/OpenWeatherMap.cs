﻿using System;
using System.Collections.Generic;
using Drizzly.Service.Weather.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Drizzly.Service.Weather.Providers
{
    public class OpenWeatherMap: BaseProvider
    {
        public OpenWeatherMap(IConfiguration configuration)
        {
            Name = "OpenWeatherMap";
            ApiKey = configuration.GetSection("ApiKey")["OpenWeatherMap"];
            Endpoints = new List<string>
            {
                "127.0.0.1",
                "10.120.50.10"
            };
            CallsPerMinute = 10;
            CallsPerDay = 500;
            
        }

        public object GetCurrentWeather(double latitude, double longitude, string units)
        {

            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
            
            var request = new RestRequest("?lat="+ latitude +"&lon="+ longitude +"&units="+ units +"&appid=" + ApiKey, Method.GET);
            
            request.OnBeforeDeserialization = response => { response.ContentType = "application/json"; };

            var queryResult = client.Execute(request);

            return JsonConvert.DeserializeObject(queryResult.Content);

        }

        public object GetForecast(double latitude, double longitude, string units)
        {
            
            var client = new RestClient("http://api.openweathermap.org/data/2.5/forecast");
            
            var request = new RestRequest("?lat="+ latitude +"&lon="+ longitude +"&units="+ units +"&appid=" + ApiKey, Method.GET);
            
            request.OnBeforeDeserialization = response => { response.ContentType = "application/json"; };

            var queryResult = client.Execute(request);

            return JsonConvert.DeserializeObject(queryResult.Content);
            
        }

        public OutputFormat PopulateOutput(string json, OutputFormat model)
        {

            return model;

        }
        
    }
}