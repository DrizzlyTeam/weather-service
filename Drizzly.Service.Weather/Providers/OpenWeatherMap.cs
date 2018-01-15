using Drizzly.Service.Weather.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Drizzly.Service.Weather.Providers
{
    public class OpenWeatherMap
    {

        public OpenWeatherMap()
        {
            
        }

        public object GetJson(string city)
        {

            var client = new RestClient("http://samples.openweathermap.org/data/2.5/forecast");
            
            var request = new RestRequest("?q="+ city +",DE&appid=b6907d289e10d714a6e88b30761fae22", Method.GET);

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