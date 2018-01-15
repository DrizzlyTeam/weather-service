using System.Collections.Generic;
using Drizzly.Service.Weather.Types;

namespace Drizzly.Service.Weather.Models
{
    
    public class OutputFormat
    {
        
        public List<CustomTypes.Providers> Providers { get; set; }
        public List<CustomTypes.Temperature> Temperatures { get; set; }

        public OutputFormat()
        {
            Providers = new List<CustomTypes.Providers>();
            Providers.Add(new CustomTypes.Providers("test", "test", new List<string>
            {
                "127.0.0.1",
                "10.91.88"
            }, 10, 500));
            Temperatures = new List<CustomTypes.Temperature>();
        }
        
    }
    
    
}