using System.Collections.Generic;
using Drizzly.Service.Weather.Providers;
using Drizzly.Service.Weather.Types;

namespace Drizzly.Service.Weather.Models
{
    
    public class OutputFormat
    {
        
        public List<BaseProvider> Providers { get; set; }
        public List<CustomTypes.Temperature> Temperatures { get; set; }

        public OutputFormat()
        {
            Providers = new List<BaseProvider>();
            Temperatures = new List<CustomTypes.Temperature>();
        }
        
    }
    
    
}