using System.Collections.Generic;

namespace Drizzly.Service.Weather.Types
{
    public class CustomTypes
    {

        public class Providers
        {

            public string Name;
            public string ApiKey;
            public List<string> Endpoints;
            public int CallsPerMinute;
            public int CallsPerDay;
            
            public Providers(string name, string apiKey, List<string> endpoints, int callsPerMinute, int callsPerDay)
            {
                Name = name;
                ApiKey = apiKey;
                Endpoints = endpoints;
                CallsPerMinute = callsPerMinute;
                CallsPerDay = callsPerDay;
            }
            
        }
        
        public class Temperature
        {

            public double Min;
            public double Max;
            public double ?Observed;
            public TemperatureUnits Units;
            
            public Temperature(double min, double max, double ?observed, TemperatureUnits units)
            {
                Min = min;
                Max = max;
                Observed = observed;
                Units = units;
            }
            
        }
        
        public class WindSpeed
        {
            
            public double ?Observed;
            public double ?ObservedGust;
            public WindSpeedUnits Units;
            
            public WindSpeed(double ?observed, WindSpeedUnits units)
            {
                Observed = observed;
                Units = units;
            }
            
        }

        public class WindDirection
        {

            public float Direction;

            public WindDirection(float direction)
            {
                Direction = direction;
            }

        }

        public enum TemperatureUnits
        {
            Celsius,
            Fahrenheit,
            Kelvin
        }
        
        public enum WindSpeedUnits
        {
            KilometersPerHour,
            MilesPerHour,
            MetersPerSeconds
        }
        
    }
}