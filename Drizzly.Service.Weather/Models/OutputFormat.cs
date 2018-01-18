using System.Collections.Generic;
using Drizzly.Service.Weather.Providers;
using Drizzly.Service.Weather.Types;

namespace Drizzly.Service.Weather.Models
{
    
    public class OutputFormat
    {
        public CustomTypes.Infos Infos { get; set; }
        public List<BaseProvider> Providers { get; set; }
        public List<CustomTypes.Temperature> Temperatures { get; set; }
        public List<CustomTypes.Winds> Winds { get; set; }
        public List<float> Humidity { get; set; }
        public List<float> Pressure { get; set; }
        public List<float> Visibility { get; set; }
        public List<float> CloudCover { get; set; }

        public OutputFormat()
        {
            Infos = new CustomTypes.Infos();
            Providers = new List<BaseProvider>();
            Temperatures = new List<CustomTypes.Temperature>();
            Winds = new List<CustomTypes.Winds>();
            Humidity = new List<float>();
            Pressure = new List<float>();
            Visibility = new List<float>();
            CloudCover = new List<float>();
        }
        
    }
    
    
}