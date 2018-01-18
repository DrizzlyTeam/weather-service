using System;
using System.Collections.Generic;

namespace Drizzly.Service.Weather.Providers
{
    public class BaseProvider
    {
        public string Name;
        protected string ApiKey;
        public List<string> Endpoints;
        public int CallsPerMinute;
        public int CallsPerDay;
        public double LastData;
    }
}